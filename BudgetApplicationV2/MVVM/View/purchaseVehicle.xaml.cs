using System;
using BudgetApplicationV2.Classes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace BudgetApplicationV2.MVVM.View
{
    /// <summary>
    /// Interaction logic for purchaseVehicle.xaml
    /// </summary>
    public partial class purchaseVehicle : UserControl
    {
        public purchaseVehicle()
        {
            InitializeComponent();
          
        }

      

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Creating varaibles and storing the values/text in them 
                string model = txbModel.Text;
                string make = txbMake.Text;
                double purchasePrice = Convert.ToDouble(txbprice.Text);
                double deposit = Convert.ToDouble(txbDeposit.Text);
                double interestRate = Convert.ToDouble(txbRate.Text);
                double insurance = Convert.ToDouble(txbInsure.Text);

                //Creating an object to pass through the values to the vehicle class
                vehicle v = new vehicle(model, make, purchasePrice, deposit, interestRate, insurance,
                  userGrossSalaryAndExpenses.grossSalary, userGrossSalaryAndExpenses.monthlyTax,
                  userGrossSalaryAndExpenses.UserName, userGrossSalaryAndExpenses.expensesMonthlyList);

                //Storing the values in the list so we can access them from the listhandler 
                worker.vehList.Add(v);



                ////Code atrribution.
                ////Webiste: StackOverFlow
                ////Topic: How to make a TextBox accept only alphabetic characters
                ////Link:https://stackoverflow.com/questions/8321871/how-to-make-a-textbox-accept-only-alphabetic-characters

                //This code does not allow for a use to enter integers into the txbMake 
                if (!System.Text.RegularExpressions.Regex.IsMatch(txbMake.Text, "^[a-zA-Z]"))
                {
                    MessageBox.Show("Please re-enter the make");
                  
                }

                MessageBox.Show(userGrossSalaryAndExpenses.UserName + " " + "we have recevied your information , you may procced to GOALS");


            }
            //This error handling is to not allow a user to submit without filling in all the information 
            catch (Exception)
            {
                MessageBox.Show("Please fill all the information");
            }

            txbDeposit.Clear();
            txbInsure.Clear();
            txbMake.Clear();
            txbModel.Clear();
            txbprice.Clear();
            txbRate.Clear();
        }
    }
}
