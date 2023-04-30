using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace Rudimentary_Antivirus
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        public async Task<bool> LoginUser(string userName, string password)
        {
            string apiUrl = $"http://localhost/API/login.php?userName={userName}&password={password}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        dynamic result = JsonConvert.DeserializeObject(responseContent);

                        if (result.error == 0)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show(result.message);
                            return false;
                        }

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("An error occurred while logging in.");
                    return false;
                }

            }
            return false;
        }

        private async void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            string userName = tbUserName.Text;
            string password = tbPassword.Password;

            bool success = await LoginUser(userName, password);

            if (success)
            {
                MessageBox.Show("User logged in successfully!");
                MainWindow newWindow = new MainWindow(true, userName);
                Close();
                newWindow.Show();

            }
        }

        private void btn_Registration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow newWindow = new RegistrationWindow();
            newWindow.Show();
            Close();
        }

        private void btn_GuestLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
            Close();

        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Application.Current.Shutdown();
        }
    }
}
