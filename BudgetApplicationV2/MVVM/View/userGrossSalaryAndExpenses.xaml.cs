using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BudgetApplicationV2.Classes;

namespace BudgetApplicationV2.MVVM.View
{
    /// <summary>
    /// Interaction logic for userGrossSalaryAndExpenses.xaml
    /// </summary>
    public partial class userGrossSalaryAndExpenses : UserControl
    {
        public userGrossSalaryAndExpenses()
        {
            InitializeComponent();
        }

        //Declaring global varaibles so it can be accessed in other forms 
        public static double grossSalary;
        public static double monthlyTax;
        public static string UserName;

        public static List<double> expensesMonthlyList;

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //Creating a try catch statment to stop app from crashing if a textBox is not filled
            try
            {

                //Creating and getting entered values from the textbox that the user has entered
                grossSalary = Convert.ToDouble(txbGrossSalary.Text);
                monthlyTax = Convert.ToDouble(txbMonthlyTax.Text);
                UserName = txbName.Text;

                //Storing the exepsnes into a list type double , i do this by getting the vlaues from the textboxes and inserting 
                //them into the list which means those values are now stored in the list ready to be accessed 
                expensesMonthlyList = new List<double>();

                expensesMonthlyList.Insert(0, Convert.ToDouble(txbCellphone.Text));
                expensesMonthlyList.Insert(1, Convert.ToDouble(txbGroceries.Text));
                expensesMonthlyList.Insert(2, Convert.ToDouble(txbOtherExpenses.Text));
                expensesMonthlyList.Insert(3, Convert.ToDouble(txbTravelCosts.Text));
                expensesMonthlyList.Insert(4, Convert.ToDouble(txbWaterAndLights.Text));

                MessageBox.Show("Hi" +" "+ userGrossSalaryAndExpenses.UserName + " " + "we have recevied your information , you may procced to housing");

                ////Code atrribution.
                ////Webiste: StackOverFlow
                ////Topic: How to make a TextBox accept only alphabetic characters
                ////Link:https://stackoverflow.com/questions/8321871/how-to-make-a-textbox-accept-only-alphabetic-characters

                if (!System.Text.RegularExpressions.Regex.IsMatch(txbName.Text, "^[a-zA-Z ]"))
                {
                    MessageBox.Show("Please re-enter your name");
                    txbName.Text.Remove(txbName.Text.Length - 1);
                }
            }
            //Exception handling which handles wether a user missed entering in a textbox or entering the wrong information 
            catch (NullReferenceException)
            {
                MessageBox.Show("Please fill all the information");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter correct details");
            }

            //Clearing all textboxes after submision 
            txbCellphone.Clear();
            txbGroceries.Clear();
            txbGrossSalary.Clear();
            txbMonthlyTax.Clear();
            txbName.Clear();
            txbOtherExpenses.Clear();
            txbTravelCosts.Clear();
            txbWaterAndLights.Clear();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Button created to shut the application down 
            System.Environment.Exit(1);
        }
    }
}
