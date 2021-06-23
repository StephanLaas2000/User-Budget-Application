using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetApplicationV2.Classes
{
    class vehicle :Expense
    {
        //Creating varaibles to store values from the purchase vehicle form 
        private string model;
        private string make;
        private double purchasePrice;
        private double deposit;
        private double interestRate;
        private double insurance;

        private double monthlyLoanRepaymentsOnCar;

        public vehicle()
        {

        }


        //Creating a constructor for the varaibles 
        public vehicle(string model, string make, double purchasePrice, double deposit,
            double interestRate, double insurance, double grossSalary, double monthlyTax, string name, List<double> expensesMonthly)
            : base(grossSalary, monthlyTax, name, expensesMonthly)
        {
            this.model = model;
            this.make = make;
            this.purchasePrice = purchasePrice;
            this.deposit = deposit;
            this.interestRate = interestRate;
            this.insurance = insurance;
        }

        //Creating the getters and setters
        public string Model { get => model; set => model = value; }
        public string Make { get => make; set => make = value; }
        public double PurchasePrice { get => purchasePrice; set => purchasePrice = value; }
        public double Deposit { get => deposit; set => deposit = value; }
        public double InterestRate { get => interestRate; set => interestRate = value; }
        public double Insurance { get => insurance; set => insurance = value; }

        //Creating a method to calculate the monthly loan on the car where i create 2 varaibles to allow a simplified version
        //of the calculation.
        public double vehicleRepaymentsCal()
        {

            double p = PurchasePrice - Deposit;
            double i = InterestRate / 100;


            monthlyLoanRepaymentsOnCar = (p * (1 + i * 5)) / 60 + Insurance;


            return monthlyLoanRepaymentsOnCar;
        }
    }
}
