using BudgetApplicationV2.MVVM.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetApplicationV2.Classes
{
    class rent :Expense
    {
        //Declaring variables
        private double monthlyRent;



        //Creating constructor 
        public rent(double monthlyRent, double grossSalary, double monthlyTax, string name, List<double> expensesMonthly)
            : base(grossSalary, monthlyTax, name, expensesMonthly)
        {
            this.MonthlyRent = monthlyRent;

        }

        //Creating getters and setters
        public double MonthlyRent { get => monthlyRent; set => monthlyRent = value; }

        //Creating a method that calculates Final total when rent is selected 
        public double mainTotalCalculationRent()
        {
            //Calculations for final total 
            double mainTotalRent = GrossSalary - MonthlyTax - deductionCal() - MonthlyRent;

            return mainTotalRent;
        }
    }
}
