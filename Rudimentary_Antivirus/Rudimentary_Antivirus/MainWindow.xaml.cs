using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Rudimentary_Antivirus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isRegistered;
        private string username;

        static List<Process> runningApps;
        private System.Windows.Threading.DispatcherTimer timer;
        public MainWindow(bool registered, string username)
        {
            InitializeComponent();

            this.isRegistered = registered;
            this.username = username;
            this.lb_userName.Text = "Welcome " + username;

            //Éppen futó alkalmazások kilistázása
            Process[] processes = Process.GetProcesses();
            runningApps = processes
                .Where(p => !string.IsNullOrEmpty(p.MainWindowTitle))
                .ToList();
            ProcessesLB.ItemsSource = runningApps.Select(p => p.MainWindowTitle).ToList();


            // Timer létrehozása, amely minden másodpercben frissíti a runningApps listát
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }
        public MainWindow()
        {
            InitializeComponent();
            this.lb_userName.Text = "Welcome Guest";
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                if (Tasks.IsSelected)
                {
                    btn_Scan.IsEnabled = false;
                    btn_Scan.Visibility = Visibility.Hidden;
                    btn_Flag.IsEnabled = false;
                    btn_Flag.Visibility = Visibility.Hidden;
                    btn_Task_Terminate.IsEnabled = true;
                    btn_Task_Terminate.Visibility = Visibility.Visible;
                }
                else
                {
                    btn_Scan.IsEnabled = true;
                    btn_Scan.Visibility = Visibility.Visible;
                    btn_Flag.IsEnabled = true;
                    btn_Flag.Visibility = Visibility.Visible;
                    btn_Task_Terminate.IsEnabled = false;
                    btn_Task_Terminate.Visibility = Visibility.Hidden;
                }
            }
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow lw = new LoginWindow();
            this.Close();
            lw.Show();
        }

        private void btn_Task_Terminate_Click(object sender, RoutedEventArgs e)
        {
            if (isRegistered)
            {
                Process selectedProcess = runningApps[ProcessesLB.SelectedIndex];
                selectedProcess.Kill();
                runningApps.Remove(selectedProcess);
                ProcessesLB.ItemsSource = runningApps.Select(p => p.MainWindowTitle).ToList();

            }
            else
            {
                MessageBox.Show("Kérlek jelentkezz be ennek a funkciónak a használatához!");
            }
        }

        private async void btn_Scan_Click(object sender, RoutedEventArgs e)
        {

            if (isRegistered)
            {
                var dialog = new CommonOpenFileDialog();
                dialog.IsFolderPicker = true;
                bool hasVirus = false;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {

                    string folderPath = dialog.FileName;
                    ProgressBar progressBar = this.progressBar;
                    await ScanFolder(folderPath, hasVirus, progressBar);
                    
                    if (hasVirus)
                    {
                        MessageBox.Show($"A keresett mappában vírus található", "Gyanús fájl", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        MessageBox.Show($"A keresett mappában nem található vírus", "Minden rendben", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    progressBar.Value = 0;

                }
            }
            else
            {
                //Vendég
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.DefaultExt = ".txt";
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

                bool? result = openFileDialog.ShowDialog();

                if (result == true)
                {
                    string filePath = openFileDialog.FileName;
                    string fileName = System.IO.Path.GetFileName(filePath);
                    string hash = GenerateMD5HashCode(filePath);

                    RestClient client = new RestClient("http://localhost/API");
                    var request = new RestRequest("hashCodes.php", Method.Get);
                    request.AddParameter("fileHashCode", hash);
                    RestResponse response = client.Execute(request);

                    JObject json = JObject.Parse(response.Content);
                    string message = (string)json["message"];

                    if (message == "The hash code is in the table.")
                    {
                        MessageBox.Show($"A {fileName} hash kódja megtalálható az adatbázisban!", "Gyanús fájl", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else if (message == "The hash code is not in the table.")
                    {
                        MessageBox.Show($"A {fileName} hash kódja nem található meg az adatbázisban!", "Téves riasztás", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Valami hiba történt az adatok lekérdezése során!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }



        private async Task ScanFolder(string folderPath, bool hasVirus, ProgressBar progressBar)
        {
            string projectFolder = Directory.GetCurrentDirectory();
            string quarantineFolder = System.IO.Path.Combine(projectFolder, "quarantine");
            // Create the quarantine folder if it doesn't exist
            if (!Directory.Exists(quarantineFolder))
            {
                Directory.CreateDirectory(quarantineFolder);
            }

            string[] files = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories);
            int totalFiles = files.Length;
            int processedFiles = 0;

            foreach (string filePath in files)
            {
                string fileName = System.IO.Path.GetFileName(filePath);
                string hash = GenerateMD5HashCode(filePath);

                RestClient client = new RestClient("http://localhost/API");
                var request = new RestRequest("hashCodes.php", Method.Get);
                request.AddParameter("fileHashCode", hash);
                RestResponse response = client.Execute(request);

                JObject json = JObject.Parse(response.Content);
                string message = (string)json["message"];

                if (message == "The hash code is in the table.")
                {
                    // Move the file to the quarantine folder
                    string quarantineFilePath = System.IO.Path.Combine(quarantineFolder, fileName);
                    if (!File.Exists(quarantineFilePath))
                    {
                        File.Move(filePath, quarantineFilePath);
                        hasVirus = true;
                    }
                    else
                    {
                        File.Delete(filePath);
                    }
                }
                else if (message == "The hash code is not in the table.")
                {
                    // No virus found, continue scanning
                }
                else
                {
                    MessageBox.Show("Valami hiba történt az adatok lekérdezése során!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                processedFiles++;
                int progressPercentage = (int)((processedFiles / (double)totalFiles) * 100);
                await Task.Delay(10); // Kis késleltetés, hogy a UI frissülhessen
                progressBar.Dispatcher.Invoke(() => progressBar.Value = progressPercentage);
            }

            foreach (string subFolderPath in Directory.EnumerateDirectories(folderPath))
            {
                await ScanFolder(subFolderPath, hasVirus, progressBar);
            }
        }


        private async void StartScanButton_Click(object sender, RoutedEventArgs e)
        {
            // ...

            

            // ...
        }



        private void btn_Flag_Click(object sender, RoutedEventArgs e)
        {
            if (isRegistered)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.DefaultExt = ".txt";
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

                bool? result = openFileDialog.ShowDialog();
                if (result == true)
                {
                    string filePath = openFileDialog.FileName;
                    string fileName = System.IO.Path.GetFileName(filePath);
                    string hash = GenerateMD5HashCode(filePath);

                    RestClient client = new RestClient("http://localhost/API");
                    var request = new RestRequest("hashCodes.php", Method.Post);
                    JObject body = new JObject();
                    body.Add("fileHashCode", hash);
                    request.AddParameter("application/json", body.ToString(), ParameterType.RequestBody);
                    request.AddHeader("Content-Type", "application/json");
                    RestResponse response = client.Execute(request);

                    JObject json = JObject.Parse(response.Content);
                    string message = (string)json["message"];

                    if (message == "Actual file flagged, and stored in database!")
                    {
                        MessageBox.Show($"A {fileName} hash kódját elhelyeztük az adatbázisban! Köszönjük hogy jelezte :)", "Gyanús fájl", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else if (message == "Actual file hash code is already in database!")
                    {
                        MessageBox.Show($"A {fileName} hash kódja már benne van az adatbázisban!", "Téves riasztás", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Valami hiba történt az adatok lekérdezése során!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("A flag-eléshez be kell jelentkezned!");
            }
            

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Éppen futó alkalmazások kilistázása
            Process[] processes = Process.GetProcesses();
            runningApps = processes
                .Where(p => !string.IsNullOrEmpty(p.MainWindowTitle))
                .ToList();
            ProcessesLB.ItemsSource = runningApps.Select(p => p.MainWindowTitle).ToList();
        }


        private string GenerateMD5HashCode(string path)
        {
            using (MD5 md5 = MD5.Create())
            {
                using (FileStream stream = File.OpenRead(path))
                {
                    byte[] hashBytes = md5.ComputeHash(stream);
                    return BitConverter.ToString(hashBytes).Replace("-", "").ToUpper();
                }
            }
        }
    }
}
