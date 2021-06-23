using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using BudgetApplicationV2.MVVM;
using BudgetApplicationV2.MVVM.View;

namespace BudgetApplicationV2.Classes
{
    class worker
    {
        public static List<HomeLoan> homeLoanList = new List<HomeLoan>();
        public static List<rent> rentList = new List<rent>();
        public static List<vehicle> vehList = new List<vehicle>();
        public static List<goals> goalList = new List<goals>();

        public string totalExpenseCal()
        {
            List<double> totalExpenses = new List<double>();

            foreach (HomeLoan item in worker.homeLoanList)
            {
                totalExpenses.Insert(0, item.deductionCal());
                totalExpenses.Insert(1, item.MonthlyTax);
                totalExpenses.Insert(2, item.monthlyRepayment());
            }

            foreach (rent item in worker.rentList)
            {
                totalExpenses.Insert(0, item.deductionCal());
                totalExpenses.Insert(1, item.MonthlyTax);
                totalExpenses.Insert(2, item.MonthlyRent);
            }

            foreach (vehicle item in worker.vehList)
            {
                totalExpenses.Insert(3, item.vehicleRepaymentsCal());
            }

            double alertExpense = 0;

            for (int i = 0; i < totalExpenses.Count; i++)
            {
                alertExpense += totalExpenses[i];
            }

            if (alertExpense > (userGrossSalaryAndExpenses.grossSalary * 3 / 4))
            {
                alertExpense = 0;
            }

            string alert = "";


            if (alertExpense == 0)
            {
                alert = ("Alert: Your Total Expenses are exceeding 75% of your income");

            }

            if (alertExpense == 0)
            {
                MessageBox.Show(alert);
            }

            return alert;

        }
    }
}
