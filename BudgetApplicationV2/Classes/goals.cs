
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetApplicationV2.Classes
{
    class goals :Expense
    {
        //Creating varaibles to store the values that the user has entered 
        double savedAmt;
        string description;
        double year;
        double interestRat;

        //Generating a constructor to pass the values from the usercontrol 
        public goals(double savedAmt, string description, double year, double interestRat, double grossSalary, double monthlyTax, string name, List<double> expensesMonthly)
           : base(grossSalary, monthlyTax, name, expensesMonthly)
        {
            this.SavedAmt = savedAmt;
            this.Description = description;
            this.Year = year;
            this.InterestRat = interestRat;
        }
        //Creating getters and setters
        public double SavedAmt { get => savedAmt; set => savedAmt = value; }
        public string Description { get => description; set => description = value; }
        public double Year { get => year; set => year = value; }
        public double InterestRat { get => interestRat; set => interestRat = value; }

        //This method is to calculate the monthly savings , i created 4 varaibles to simplify the formuala 
        //The in interest varaible calculates the interest on the intial amount.
        //The repaymentMonthlyGoal varaible calculates the monthly amount by been divided by the numbers of months the user said
        public double monthlyRepaymentGoal()
        {

            double n = Year;
            double p = SavedAmt;
            double i = interestRat / 100;
            double x = Year * 12;

            double totalAmt = p * Math.Pow(1 + i, n);

            double  repaymentMonthlyGoal = totalAmt / x;

            double comInterest = totalAmt - p;

            double finalAmt = repaymentMonthlyGoal - (comInterest / x);

            return finalAmt;


        }

        //This method is used to display the interest earned on the savings 
        public double displayInterest()
        {
            double n = Year;
            double p = SavedAmt;
            double i = interestRat / 100;

            double totalAmt = p * Math.Pow(1 + i, n);

            double comInterest = totalAmt - p;

            return comInterest;
        }

        //This method is to display the final total earned on savings 
        public double displayTotal()
        {
            double n = Year;
            double p = SavedAmt;
            double i = interestRat / 100;

            double totalAmt = p * Math.Pow(1 + i, n);

            return totalAmt;
        }
    }
}
