using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }


        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["recipeConnString"].ConnectionString);

            string data = "SELECT * FROM Users WHERE username = '" + tbUserName.Text + "'";

            string command = "SELECT COUNT(1) FROM Users WHERE Username = @username AND Password = @password";

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                string result = string.Empty;
                bool admin = false;
                string username = string.Empty;

                SqlCommand sqlCom1 = new SqlCommand(data, connection);
                using (var reader = sqlCom1.ExecuteReader(CommandBehavior.SingleRow))
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            result = reader["Password"].ToString().Trim();
                            admin = Convert.ToBoolean(reader["IsAdmin"]);
                            username = reader["Username"].ToString();
                        }

                    }
                }

                if (Encryption(tbPassword.Password.Trim()) == result)
                {
                    SqlCommand sqlCom2 = new SqlCommand(command, connection);
                    sqlCom2.CommandType = CommandType.Text;
                    sqlCom2.Parameters.AddWithValue("@username", tbUserName.Text.Trim());
                    sqlCom2.Parameters.AddWithValue("@password", Encryption(tbPassword.Password.Trim()));
                    int id = Convert.ToInt32(sqlCom2.ExecuteScalar());

                    if (id > 0)
                    {
                        MainWindow newWindow = new MainWindow(admin, username);
                        newWindow.Show();
                        connection.Close();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong username or password", "Login failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Can not connect to the database", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_Registration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow newWindow = new RegistrationWindow();
            newWindow.Show();
            Close();
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
        }
        public static string Encryption(string password)
        {
            var textBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(textBytes);
        }

    }
}
