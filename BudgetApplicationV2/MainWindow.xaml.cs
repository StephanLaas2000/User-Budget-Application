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

namespace BudgetApplicationV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == true)
            {
                tt_Salary.Visibility = Visibility.Collapsed;
                tt_Home.Visibility = Visibility.Collapsed;
                tt_Vehicle.Visibility = Visibility.Collapsed;
                tt_Goal.Visibility = Visibility.Collapsed;
                tt_Report.Visibility = Visibility.Collapsed;
               
            }
            else
            {
                tt_Salary.Visibility = Visibility.Visible;
                tt_Home.Visibility = Visibility.Visible;
                tt_Vehicle.Visibility = Visibility.Visible;
                tt_Goal.Visibility = Visibility.Visible;
                tt_Report.Visibility = Visibility.Visible;
                
            }
        }
    }
}
