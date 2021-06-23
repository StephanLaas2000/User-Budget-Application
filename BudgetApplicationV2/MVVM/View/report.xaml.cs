using System;
using System.Collections.Generic;
using BudgetApplicationV2.Classes;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace BudgetApplicationV2.MVVM.View
{
    /// <summary>
    /// Interaction logic for report.xaml
    /// </summary>
    public partial class report : UserControl
    {
        public report()
        {
            InitializeComponent();
            //InitializeComponent();
            populatListBox();


            //When the form loads these lables and textboxes below will be hidden 
            txbRent.Visibility = Visibility.Hidden;
            labRent.Visibility = Visibility.Hidden;

            labLoan.Visibility = Visibility.Hidden;
            txbLoanPayments.Visibility = Visibility.Hidden;

            txbCarMake.Visibility = Visibility.Hidden;
            labCarMake.Visibility = Visibility.Hidden;

            txbMonthlyCostCar.Visibility = Visibility.Hidden;
            labMonthlyCostOnCar.Visibility = Visibility.Hidden;

            txbFinalAmt.Visibility = Visibility.Hidden;
            labFinalAmt.Visibility = Visibility.Hidden;

            txbModel.Visibility = Visibility.Hidden;
            labModel.Visibility = Visibility.Hidden;

            txbGoal.Visibility = Visibility.Hidden;
            labGoalDescription.Visibility = Visibility.Hidden;

            txbGoalRepay.Visibility = Visibility.Hidden;
            labGoalRepayments.Visibility = Visibility.Hidden;
        }

        private void populatListBox()
        {
            foreach (HomeLoan item in worker.homeLoanList)
            {
                //HomeLoan data is confined and populates the listbox name
                lbUsers.Items.Add(item.Name.ToUpper());

            }

            foreach (rent item in worker.rentList)
            {
                //Rent data is confined and populates the listbox with name
                lbUsers.Items.Add(item.Name.ToUpper());

            }
        }

        private void lbUsers_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //Creating a new list type string to store the expenses and insert the data , this list while be
                //used in the linq code to display/output expenses in the report form 
                List<string> expenses = new List<string>();

                //Creating variable for selected item that the user selects
                string itemSelect = lbUsers.SelectedItem.ToString();

                //Creating variable homeLoanData that will obtain all the values from the homeLoanList from the worker class
                List<HomeLoan> homeLoanData = worker.homeLoanList;

                //Using LINQ to confine the entered data and then to populate the textbox 
                homeLoanData = homeLoanData.Where(x => x.Name.ToUpper() == itemSelect).ToList();

                //Foreach to show labels/textbox when true and to populate textboxes
                foreach (HomeLoan item in homeLoanData)
                {
                    //Making lables and textboxes hidden and visible when it fills the neccassary conditions 
                    txbRent.Visibility = Visibility.Hidden;
                    labRent.Visibility = Visibility.Hidden;

                    labLoan.Visibility = Visibility.Visible;
                    txbLoanPayments.Visibility = Visibility.Visible;

                    txbCarMake.Visibility = Visibility.Hidden;
                    labCarMake.Visibility = Visibility.Hidden;

                    txbMonthlyCostCar.Visibility = Visibility.Hidden;
                    labMonthlyCostOnCar.Visibility = Visibility.Hidden;

                    txbFinalAmt.Visibility = Visibility.Hidden;
                    labFinalAmt.Visibility = Visibility.Hidden;

                    txbModel.Visibility = Visibility.Hidden;
                    labModel.Visibility = Visibility.Hidden;

                    txbGoal.Visibility = Visibility.Hidden;
                    labGoalDescription.Visibility = Visibility.Hidden;

                    txbGoalRepay.Visibility = Visibility.Hidden;
                    labGoalRepayments.Visibility = Visibility.Hidden;



                    //Populating textboxes while using the foreach to get precise data
                    txbGrossSalary.Text = item.GrossSalary.ToString();
                    txbMonthlyExpenses.Text = (Math.Round(item.deductionCal(), 2) + item.MonthlyTax).ToString();
                    txbLoanPayments.Text = Math.Round(item.monthlyRepayment(), 2).ToString();
                    txbMoneyLeft.Text = Math.Round(item.mainTotalCalculationProp(), 2).ToString();
                    txbFinalFinalAmt.Text = Math.Round(item.mainTotalCalculationProp() , 2).ToString();


                    //Inserting data into the list that gets the values from monthlyRepayment , deductioncal and monthlyTax 
                    expenses.Insert(0, "Total Loan Installments : R" + Math.Round( item.monthlyRepayment(),2));
                    expenses.Insert(1, "Total Monthly Expenses : R" + Math.Round(item.deductionCal(), 2));
                    expenses.Insert(2, "Total Tax Deducted : R" + Math.Round( item.MonthlyTax , 2));



                    //Clearing the list in order to allow for multiple usages 
                    lbExpensesDesc.Items.Clear();

                }

                //Creating variable rentData that will obtain all the values from the homeLoanList from the worker class
                List<rent> rentData = worker.rentList;
                //Using LINQ to confine the entered data and then to populate the textbox 
                rentData = rentData.Where(x => x.Name.ToUpper() == itemSelect).ToList();


                foreach (rent item in rentData)
                {
                    //Making lables and textboxes hidden and visible when it fills the neccassary conditions 
                    txbRent.Visibility = Visibility.Visible;
                    labRent.Visibility = Visibility.Visible;

                    labLoan.Visibility = Visibility.Hidden;
                    txbLoanPayments.Visibility = Visibility.Hidden;

                    txbCarMake.Visibility = Visibility.Hidden;
                    labCarMake.Visibility = Visibility.Hidden;

                    txbMonthlyCostCar.Visibility = Visibility.Hidden;
                    labMonthlyCostOnCar.Visibility = Visibility.Hidden;

                    txbFinalAmt.Visibility = Visibility.Hidden;
                    labFinalAmt.Visibility = Visibility.Hidden;

                    txbModel.Visibility = Visibility.Hidden;
                    labModel.Visibility = Visibility.Hidden;

                    txbGoal.Visibility = Visibility.Hidden;
                    labGoalDescription.Visibility = Visibility.Hidden;

                    txbGoalRepay.Visibility = Visibility.Hidden;
                    labGoalRepayments.Visibility = Visibility.Hidden;


                    //Populating textboxes while using the foreach to get the correct data , this is why I use LINQ
                    txbGrossSalary.Text = item.GrossSalary.ToString();
                    txbMonthlyExpenses.Text = (Math.Round(item.deductionCal(), 2) + item.MonthlyTax).ToString();
                    txbRent.Text = item.MonthlyRent.ToString();
                    txbMoneyLeft.Text = Math.Round(item.mainTotalCalculationRent(), 2).ToString();
                    txbFinalFinalAmt.Text = Math.Round(item.mainTotalCalculationRent()).ToString();

                    //Inserting data into the list that gets the values from monthlyRent , deductioncal and monthlyTax
                    expenses.Insert(0, "Total Monthly Expenses : R" + Math.Round(item.deductionCal(), 2));
                    expenses.Insert(1, "Total Tax Deducted : R" + item.MonthlyTax);
                    expenses.Insert(2, "Total Monthly rent : R" + item.MonthlyRent);



                    //Clearing the list in order to allow for multiple usages 
                    lbExpensesDesc.Items.Clear();
                }

                //Creating variable vehData that will obtain all the values from the homeLoanList from the worker class
                List<vehicle> vehData = worker.vehList;
                //Using LINQ to confine the entered data and then to populate the textbox 
                vehData = vehData.Where(x => x.Name.ToUpper() == itemSelect).ToList();

                foreach (vehicle item in vehData)
                {
                    //Making lables and textboxes hidden and visible when it fills the neccassary conditions 
                    txbCarMake.Visibility = Visibility.Visible;
                    labCarMake.Visibility = Visibility.Visible;

                    txbMonthlyCostCar.Visibility = Visibility.Visible;
                    labMonthlyCostOnCar.Visibility = Visibility.Visible;

                    txbFinalAmt.Visibility = Visibility.Visible;
                    labFinalAmt.Visibility = Visibility.Visible;

                    txbModel.Visibility = Visibility.Visible;
                    labModel.Visibility = Visibility.Visible;

                    txbGoal.Visibility = Visibility.Hidden;
                    labGoalDescription.Visibility = Visibility.Hidden;

                    txbGoalRepay.Visibility = Visibility.Hidden;
                    labGoalRepayments.Visibility = Visibility.Hidden;



                    //Creating varaibles to get the values from the moneyleft textbox and creating a value that calculates the money the user is left with 
                    double mainTotal = Convert.ToDouble(txbMoneyLeft.Text);
                    double finalAmt = mainTotal - Math.Round(item.vehicleRepaymentsCal(), 2);

                    //Populating textboxes while using the foreach to get precise data
                    txbCarMake.Text = item.Make;
                    txbMonthlyCostCar.Text = Math.Round( item.vehicleRepaymentsCal() , 2).ToString();
                    txbFinalAmt.Text = Math.Round( finalAmt , 2).ToString();
                    txbModel.Text = item.Model;
                    txbFinalFinalAmt.Text = Math.Round( finalAmt , 2).ToString();

                    //Inserting data into the list that gets the values from vehicleRepaymentCal
                    expenses.Insert(3, "Total Vehicle Installments : R" + Math.Round(item.vehicleRepaymentsCal(), 2));



                    //Clearing the list in order to allow for multiple usages 
                    lbExpensesDesc.Items.Clear();

                }
                //Creating variable goalData that will obtain all the values from the homeLoanList from the worker class
                List<goals> goalData = worker.goalList;

                goalData = goalData.Where(x => x.Name.ToUpper() == itemSelect).ToList();

                foreach (goals item in goalData)
                {
                    txbGoal.Visibility = Visibility.Visible;
                    labGoalDescription.Visibility = Visibility.Visible;

                    txbGoalRepay.Visibility = Visibility.Visible;
                    labGoalRepayments.Visibility = Visibility.Visible;

                    double FinalAmt = Convert.ToDouble(txbFinalAmt.Text);
                    double finalFinalAmt = FinalAmt - Math.Round(item.monthlyRepaymentGoal(), 2);

                    txbGoal.Text = item.Description;
                    txbGoalRepay.Text = Math.Round(item.monthlyRepaymentGoal() , 2).ToString();
                    txbFinalFinalAmt.Text = Math.Round(finalFinalAmt , 2).ToString();

                    expenses.Insert(4, "Monthly savings : R" + Math.Round(item.monthlyRepaymentGoal(), 2));
                }

                ////Code atrribution.
                ////Webiste: StackOverFlow
                ////Topic: Sorting a list of strings that contain numbers 
                ////Link:https://stackoverflow.com/questions/15055971/c-sharp-sorting-a-list-of-strings-that-contains-numbers

                //Using linq to assemble the expenses in descending or in the listbox, parse double allows for the 
                //expense values to be used in this line of code , the .orderbydescending allows for the descending output to occur 
                var expensesDesc = expenses.Select(s => new { Str = s, Split = s.Split('R') }).OrderByDescending(x => double.Parse(x.Split[1]))
                .ThenBy(x => x.Split[0]).Select(x => x.Str).ToList();

                //Populating the lisbox using the expensesDesc varaible so it runs through the linq code 
                for (int i = 0; i < expensesDesc.Count; i++)
                {
                    lbExpensesDesc.Items.Add(expensesDesc[i]);
                }

                alertMsgService ams = new alertMsgService();
                worker r = new worker();
                ams.collectExpenses(r);

            }

            catch (NullReferenceException)
            {
                //Displaying message if exception is thrown 
                MessageBox.Show("Please Select a user");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter in correct details");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Clearing the textboxes and listbox to allow for the user to return back to the main page and re-enter details 
            txbCarMake.Clear();
            txbFinalAmt.Clear();
            txbFinalFinalAmt.Clear();
            txbGoal.Clear();
            txbGoalRepay.Clear();
            txbGrossSalary.Clear();
            txbLoanPayments.Clear();
            txbModel.Clear();
            txbMoneyLeft.Clear();
            txbMonthlyCostCar.Clear();
            txbMonthlyExpenses.Clear();
            txbRent.Clear();
            lbExpensesDesc.Items.Clear();
     



        }
    }
}
