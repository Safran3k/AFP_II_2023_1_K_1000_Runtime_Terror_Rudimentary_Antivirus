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
        public MainWindow()
        {
            InitializeComponent();

            TabItem selectedTabItem = tabControl.SelectedItem as TabItem;

            // Check if TabItem 1 is selected
            if (selectedTabItem == Tasks)
            {
                btnScan.IsEnabled = true;
                btnTerminate.IsEnabled = false;
            }
            else if (selectedTabItem == Scanner) { }
            {
                btnScan.IsEnabled = false;
                btnTerminate.IsEnabled = true;
            }
        }
        
        

    }
}
