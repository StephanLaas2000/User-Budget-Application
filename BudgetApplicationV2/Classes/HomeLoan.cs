using System;
using System.Collections.Generic;
using System.Text;
using BudgetApplicationV2.MVVM;
using BudgetApplicationV2.MVVM.View;

namespace BudgetApplicationV2.Classes
{
    class HomeLoan : Expense
    {

        //Declaring variables 
        private double propertyPrice;
        private double deposit;
        private double interestRate;
        private int repayments;


        private double mainTotalProp;

        public HomeLoan()
        {

        }

        //Creating constructor
        public HomeLoan(double propertyPrice, double deposit, double interestRate, int repayments, double grossSalary, double monthlyTax, string name, List<double> expensesMonthly)

            : base(grossSalary, monthlyTax, name, expensesMonthly)
        {
            this.PropertyPrice = propertyPrice;
            this.Deposit = deposit;
            this.InterestRate = interestRate;
            this.Repayments = repayments;
        }


        //Creatting getters and setters
        public double PropertyPrice { get => propertyPrice; set => propertyPrice = value; }
        public double Deposit { get => deposit; set => deposit = value; }
        public double InterestRate { get => interestRate; set => interestRate = value; }
        public int Repayments { get => repayments; set => repayments = value; }


        //Create a method that calculates the monthly repayments on loan
        public double monthlyRepayment()
        {
            //Code attribution .
            //Author: Unkown
            //Website: Siyavula
            //Topic: Calculations using simple and compound interest 
            //Link: https://www.siyavula.com/read/maths/grade-10/finance-and-growth/09-finance-and-growth-03
            double n = repayments / 12;
            double p = PropertyPrice - Deposit;
            double i = interestRate / 100;
            double RepaymentMonthly = (p * (1 + i * n) / repayments);

            if (RepaymentMonthly > (GrossSalary / 3))
            {

                RepaymentMonthly = 0;

            }
            return RepaymentMonthly;
        }

        //Create a method that calculates the final amount when property is selected 
        public double mainTotalCalculationProp()
        {

            mainTotalProp = GrossSalary - MonthlyTax - deductionCal() - monthlyRepayment();

            return mainTotalProp;

        }

        //Creating a method that shows an alert msg if the monthly loan repayments exceed 1/3 of the gross salary 
        public string alertMsg()
        {
            string alert = "";

            if (monthlyRepayment() == 0)
            {
                alert = ("Alert: Your home loan repayments is one third of your gross salary");

            }

            return alert;
        }

    }
}
