using BudgetApplicationV2.Classes;
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

namespace BudgetApplicationV2.MVVM.View
{
    /// <summary>
    /// Interaction logic for RentOrHomePurchase.xaml
    /// </summary>
    public partial class RentOrHomePurchase : UserControl
    {
        public RentOrHomePurchase()
        {
            InitializeComponent();
          

        }
        

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            //Creating a try catch statment to stop app from crashing if a textBox is not filled
            try
            {
                //Creating variables to store user data from the texboxes , if statement is create in order to isolate the 
                // the property and rent values to avoid error 
                if (cbRentOrProp.SelectedIndex == 1)
                {



                    //Creating varaibles for the homeLoan data
                    double propertyPrice = Convert.ToDouble(txbPurchasePrice.Text);
                    double deposit = Convert.ToDouble(txbDeposit.Text);
                    double interestRate = Convert.ToDouble(txbRate.Text);
                    int repayments = Convert.ToInt32(txbRepayments.Text);

                    //Creating an object for homeloan
                    HomeLoan h = new HomeLoan(propertyPrice, deposit, interestRate, repayments,
                         userGrossSalaryAndExpenses.grossSalary, userGrossSalaryAndExpenses.monthlyTax,
                         userGrossSalaryAndExpenses.UserName, userGrossSalaryAndExpenses.expensesMonthlyList);

                    worker.homeLoanList.Add(h);



                    //Alert message method been called from homeloan class
                    if (h.monthlyRepayment() == 0)
                    {
                        MessageBox.Show(h.alertMsg());
                    }

                }

                if (cbRentOrProp.SelectedIndex == 0)
                {
                    //Creating varaibles for the rent information 
                    double monthlyRent = Convert.ToDouble(txbRent.Text);

                    //Creating an object for rent 
                    rent r = new rent(monthlyRent, userGrossSalaryAndExpenses.grossSalary, userGrossSalaryAndExpenses.monthlyTax, userGrossSalaryAndExpenses.UserName, userGrossSalaryAndExpenses.expensesMonthlyList);

                    worker.rentList.Add(r);

                }


                MessageBox.Show(userGrossSalaryAndExpenses.UserName + " " + "we have recevied your information , you may procced to vehicle");

            }
            catch (NullReferenceException)
            {
                //Showing a message if an exception class is thrown 
                MessageBox.Show("Please fill all the information");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter correct details");
            }

            txbDeposit.Clear();
            txbPurchasePrice.Clear();
            txbRate.Clear();
            txbRent.Clear();
            txbRepayments.Clear();

        }

        private void cbRentOrProp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//Hiding lables/textbox until combobox is true 


            this.labDeposit.Visibility = Visibility.Visible;
            this.labPurchasePrice.Visibility = Visibility.Visible;
            this.labRepayments.Visibility = Visibility.Visible;
            this.labRate.Visibility = Visibility.Visible;
            this.labRent2.Visibility = Visibility.Visible;

            this.txbDeposit.Visibility = Visibility.Visible;
            this.txbPurchasePrice.Visibility = Visibility.Visible;
            this.txbRate.Visibility = Visibility.Visible;
            this.txbRepayments.Visibility = Visibility.Visible;

            this.txbRent.Visibility = Visibility.Visible;



            if (cbRentOrProp.SelectedIndex == 0)
            {

                this.labDeposit.Visibility = Visibility.Collapsed;
                this.labPurchasePrice.Visibility = Visibility.Collapsed;
                this.labRepayments.Visibility = Visibility.Collapsed;
                this.labRate.Visibility = Visibility.Collapsed;


                this.txbDeposit.Visibility = Visibility.Collapsed;
                this.txbPurchasePrice.Visibility = Visibility.Collapsed;
                this.txbRate.Visibility = Visibility.Collapsed;
                this.txbRepayments.Visibility = Visibility.Collapsed;
            }
            else if (cbRentOrProp.SelectedIndex == 1)
            {

                this.labRent2.Visibility = Visibility.Collapsed;
                this.txbRent.Visibility = Visibility.Collapsed;
            }
        }
    }
    }

