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

namespace Rudimentary_Antivirus
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void btn_Registration_Click(object sender, RoutedEventArgs e)
        {
            if (tbUserName.Text == "" || tbPassword.Password == "")
            {
                MessageBox.Show("Username and password can't be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (tbPassword.Password != tbPasswordAgain.Password)
            {
                MessageBox.Show("Passwords aren't matching", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["recipeConnString"].ConnectionString);

                try
                {
                    if (connection.State == System.Data.ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    string command1 = "SELECT id FROM users WHERE username = @username";

                    SqlCommand sqlCom1 = new SqlCommand(command1, connection);
                    sqlCom1.CommandType = System.Data.CommandType.Text;
                    sqlCom1.Parameters.AddWithValue("@username", tbUserName.Text);
                    int id = Convert.ToInt32(sqlCom1.ExecuteScalar());

                    if (id > 0)
                    {
                        MessageBox.Show("This username already exists", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                    }
                    else
                    {
                        string command2 = "INSERT INTO users(username, password, isAdmin) VALUES('" + tbUsername.Text + "', '" + Enryption(tbPassword.Password.ToString()) + "', '" + 0 + "')";

                        SqlCommand sqlCom2 = new SqlCommand(command2, connection);
                        sqlCom2.CommandType = System.Data.CommandType.Text;
                        sqlCom2.ExecuteNonQuery();

                        MessageBox.Show("Successful registration", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                        LoginWindow newWindow = new LoginWindow();
                        newWindow.Show();
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    connection.Close();
                }
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
