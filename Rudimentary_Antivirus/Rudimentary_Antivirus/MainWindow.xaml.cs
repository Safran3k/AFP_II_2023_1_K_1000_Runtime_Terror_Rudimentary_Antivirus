﻿using System;
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
                    btn_Task_Terminate.IsEnabled = true;
                    btn_Task_Terminate.Visibility = Visibility.Visible;
                }
                else
                {
                    btn_Scan.IsEnabled = true;
                    btn_Scan.Visibility = Visibility.Visible;
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
            Process selectedProcess = runningApps[ProcessesLB.SelectedIndex];
            selectedProcess.Kill();
            runningApps.Remove(selectedProcess);
            ProcessesLB.ItemsSource = runningApps.Select(p => p.MainWindowTitle).ToList();
        }

        private void btn_Scan_Click(object sender, RoutedEventArgs e)
        {

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
