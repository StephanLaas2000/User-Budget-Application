using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetApplicationV2.Classes
{
    class processExpense
    {
        //Code atrribution
        //Website: MyVC 
        //Author/lecturer:Ebrahim Adam
        //Topic: Delegates
        //Link:https://youtu.be/MFjlDbn7P8k

        //Creating a delegate 
        public delegate void ProcessExpenseDelegate(worker r);
        //Creating a event 
        public event ProcessExpenseDelegate ExpensesSubmitted;

        public void processTheExpenses(worker r)
        {
            alertMsgService ams = new alertMsgService();

            ExpensesSubmitted += ams.collectExpenses;

            OnExpnesesSubmitted(r);


        }

        protected virtual void OnExpnesesSubmitted(worker r)
        {
            //Creating an if statement to check if method is been run
            if (ExpensesSubmitted != null)
            {
                ExpensesSubmitted(r);
            }

        }
    }
}
