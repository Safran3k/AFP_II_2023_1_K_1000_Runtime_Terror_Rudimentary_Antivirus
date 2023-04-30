using System;
using System.Collections.Generic;
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

        public MainWindow(bool registered, string username)
        {
            InitializeComponent();

            this.isRegistered = registered;
            this.username = username;
            this.lb_userName.Text = "Welcome " + username;
        }
        public MainWindow()
        {
            InitializeComponent();

            TabItem selectedTabItem = tabControl.SelectedItem as TabItem;
            this.lb_userName.Text = "Welcome Guest";
            if (selectedTabItem == Tasks)
            {

            }
            else if (selectedTabItem == Scanner) { }
            {

            }
        }



    }
}
