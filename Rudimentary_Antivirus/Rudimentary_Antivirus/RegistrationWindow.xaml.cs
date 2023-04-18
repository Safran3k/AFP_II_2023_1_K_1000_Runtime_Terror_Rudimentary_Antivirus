using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RestSharp;
using System.Net.Http;
using Newtonsoft.Json;

namespace Rudimentary_Antivirus
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>

    public class UserRegistrationData
    {
        public string userName { get; set; }
        public string password { get; set; }
    }

    
    public partial class RegistrationWindow : Window
    {
        RestClient usersClient = new RestClient("http://localhost/API/registration.php"); //még át kell írni
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        public async Task<bool> RegisterUser(string userName, string password)
        {
            string apiUrl = "http://localhost/API/registration.php";

            var registrationData = new UserRegistrationData()
            {
                userName = userName,
                password = password
            };

            using (var client = new HttpClient())
            {
                var jsonData = JsonConvert.SerializeObject(registrationData);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject(responseContent);

                    if (result.error == 0)
                    {
                        // User registered successfully
                        return true;
                    }
                    else
                    {
                        // Registration failed
                        //MessageBox.Show(jsonData);
                        MessageBox.Show(result.message.ToString());


                        return false;
                    }
                }
                else
                {
                    // Error occurred while sending request
                    MessageBox.Show("An error occurred while registering the user.");
                    return false;
                }
            }
        }

        private async void btn_Registration_Click(object sender, RoutedEventArgs e)
        {
            string userName = tbUserName.Text;
            string password = tbPassword.Password;

            bool success = await RegisterUser(userName, password);

            if (success)
            {
                MessageBox.Show("User registered successfully!");
            }
            else
            {
                // Registration failed
            }
        }


        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow newWindow = new LoginWindow();
            newWindow.Show();
            Close();
        }

        public static string Enryption(string password)
        {
            var textBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(textBytes);
        }
    }
}
