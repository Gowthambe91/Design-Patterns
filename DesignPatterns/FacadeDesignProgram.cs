using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*https://www.dofactory.com/*/
namespace DesignPatterns
{
    /*FACADE comes under the Structural Design Pattern, which provides a simplified interface to a library, a framework or any other set of complex classes.
     Consider, we are using a third party library in our App which provides of dozens of features, but our App require only limited of its features, to make it simple we can create FACADE
     classes -  call the required funtionalities from it, so other classes from our just calls FACADE class and method for the funtionality, FACADE hides the complex functionalities and 
     provides the simple interface/method. 

        Also, added advantage is when we think about changing the framework/library we just need to modify FACADE, else it would have been change all over our App where and all library methods
        have been called.

        Credits: https://refactoring.guru/design-patterns/facade
         */


    /*Structural Code for FACADE Pattern*/ /*Further follows the Real world example*/
    class FacadeDesignProgram
    {
        static void Main(string[] args)
        {
            /*Structural Pattern*/
            Facade facade = new Facade();
            facade.methodA();
            facade.methodB();

            /*Real World Code Example*/
            Mortgage mortgage = new Mortgage();
            Customer customer = new Customer("Gowtham");

            Console.WriteLine("\nEnter the Loan amount to check your eligibility:");
            int loanAmount = Convert.ToInt32(Console.ReadLine());

            bool eligible = mortgage.isEligible(customer, loanAmount);

            if (eligible)
            {
                Console.WriteLine("\n {0} application has been " + (eligible ? "Approved":"Rejected"), customer.Name);
            }

            Console.ReadLine();
        }
    }


    /*FACADE class in our APP to simplified interface to access the complex subsystems of library*/
    class Facade
    {
        private SubSystemOne _subSystemOne;
        private SubSystemTwo _subSystemTwo;
        private SubSystemThree _subSystemThree;
        public Facade()
        {
            _subSystemOne = new SubSystemOne();
            _subSystemTwo = new SubSystemTwo();
            _subSystemThree = new SubSystemThree();
        }

        public void methodA()
        {
            Console.WriteLine("\nMethod A()..............");
            _subSystemOne.methodOne();
            _subSystemTwo.methodTwo();
        }

        public void methodB()
        {
            Console.WriteLine("\nMethod B()..............");
            _subSystemThree.methodThree();
        }
    }

    /*Consider these classes are from a Library or Complex subsystem of classes*/
    class SubSystemOne
    {
        public void methodOne()
        {
            Console.WriteLine("SubSytemOne Method");
        }
    }

    class SubSystemTwo
    {
        public void methodTwo()
        {
            Console.WriteLine("SubSystemTwo Method");
        }
    }

    class SubSystemThree
    {
        public void methodThree()
        {
            Console.WriteLine("SubSystemThree Method");
        }
    }
    /*Consider these classes are from a Library*/


    /*Real-world code in C#*/
    class Mortgage
    {
        private Bank _bank = new Bank();
        private Credit _credit = new Credit();
        private Loan _loan = new Loan();

        public bool isEligible(Customer customer, int loanAmount)
        {
            Console.WriteLine("{0} applies for {1:C} loan\n", customer.Name, loanAmount);

            bool eligible = true;

            if (!_bank.HasSufficientBalance(customer) || !_credit.HasGoodCredit(customer) || !_loan.HasNoBadLoans(customer))
            {
                eligible = false;
            }

            return eligible;
        }
    }

    class Customer
    {
        private string _name;
        public Customer(string name)
        {
            this._name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }

        }
    }
    class Bank
    {
        public bool HasSufficientBalance(Customer customer)
        {
            Console.WriteLine("\nCheck if Customer {0} has Sufficient Balance..", customer.Name);
            return true;
        }
    }

    class Credit
    {
        public bool HasGoodCredit(Customer customer)
        {
            Console.WriteLine("\nCheck if Customer {0} has Good Credit..", customer.Name);
            return true;
        }
    }

    class Loan
    {
        public bool HasNoBadLoans(Customer customer)
        {
            Console.WriteLine("\nCheck if Customer {0} has no bad loans..", customer.Name);
            return true;
        }
    }
}
