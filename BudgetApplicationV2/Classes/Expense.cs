using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetApplicationV2.Classes
{
    //Code attribution.
    //Author: Unknown
    //Webiste: Microsoft Docs
    //Topic: Inheritence in c#
    //Link: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/inheritance

    //Creating an abstract class called expense 
    abstract class Expense
    {
        //Declaring variables
        private double grossSalary;
        private double monthlyTax;
        private string name;

        List<double> expensesMonthlyList;

        public Expense()
        {

        }

        //Creating a constructor to pass the varaibles through 
        protected Expense(double grossSalary, double monthlyTax, string name, List<double> expensesMonthly)
        {
            this.GrossSalary = grossSalary;
            this.MonthlyTax = monthlyTax;
            this.Name = name;
            this.ExpensesMonthly = expensesMonthly;
        }

        //Creating the getters and setters 
        public double GrossSalary { get => grossSalary; set => grossSalary = value; }
        public double MonthlyTax { get => monthlyTax; set => monthlyTax = value; }
        public string Name { get => name; set => name = value; }
        public List<double> ExpensesMonthly { get => expensesMonthlyList; set => expensesMonthlyList = value; }

        //A method to calculate the monthly expenses by add all the values in the monthly expenses in the list
        public double deductionCal()
        {

            double deductions = 0;

            for (int i = 0; i < expensesMonthlyList.Count; i++)
            {
                deductions += expensesMonthlyList[i];
            }

            return deductions;



        }
    }
}
