using BudgetApplicationV2.Classes;
using System;
using System.Windows;
using System.Windows.Controls;


namespace BudgetApplicationV2.MVVM.View
{
    /// <summary>
    /// Interaction logic for userGoal.xaml
    /// </summary>
    public partial class userGoal : UserControl
    {
        public userGoal()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            double savedAmt = Convert.ToDouble(txbSavings.Text);
            string description = txbDescription.Text;
            double years = Convert.ToDouble(txbYears.Text);
            double interestRate = Convert.ToDouble(txbInterestRate.Text);

            goals g = new goals(savedAmt, description, years, interestRate, userGrossSalaryAndExpenses.grossSalary, userGrossSalaryAndExpenses.monthlyTax,
                userGrossSalaryAndExpenses.UserName, userGrossSalaryAndExpenses.expensesMonthlyList);


            worker.goalList.Add(g);

            MessageBox.Show(userGrossSalaryAndExpenses.UserName + " " + "We have recevied all your information , you may view a summary report. \n \n"
                + "------------------------------------------------------------------------\n"
                + "Compounded interest on savings: R " + Math.Round(g.displayInterest() , 2) + "\n"
                + "Your total amount after saving for " + g.Year + " years: R " + Math.Round(g.displayTotal() , 2) + "\n"
                + "The total monthly savings you need to contribute: " + Math.Round(g.monthlyRepaymentGoal() , 2) + "\n"
                + "Your goal to achive is: " + g.SavedAmt + "\n"
                + "------------------------------------------------------------------------"
                );

            txbDescription.Clear();
            txbInterestRate.Clear();
            txbSavings.Clear();
            txbYears.Clear();
        }
    }
}
