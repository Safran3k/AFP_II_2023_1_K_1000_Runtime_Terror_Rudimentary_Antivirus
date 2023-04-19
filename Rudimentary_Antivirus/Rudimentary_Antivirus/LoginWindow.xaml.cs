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

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        dynamic result = JsonConvert.DeserializeObject(responseContent);

                        if (result.error == 0)
                        {
                            // User logged in successfully
                            return true;
                        }
                        else
                        {
                            // Login failed
                            MessageBox.Show(result.message);
                            return false;
                        }
                        
                    }
                }
                catch (Exception)
                {
                    // Error occurred while sending request
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
                MainWindow newWindow = new MainWindow();
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
