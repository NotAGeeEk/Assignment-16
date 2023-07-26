using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAssignment16
{
    public class BankAccount
    {
        private static int accountNumberCounter = 1000; //It is Used to generate unique account numbers

        public int AccountNumber { get; } // Create a Read-only property for the account number
        public string AccountHolderName { get; set; } 

        private double balance; 

        public double Balance // Property for the balance (Its encapsulated through the property)
        {
            get { return balance; }
            private set { balance = value; }
        }

        //I am using a  Constructor to initialize the account holder's name and set initial balance to zero
        public BankAccount(string accountHolderName, double initialBalance)
        {
            AccountNumber = GenerateAccountNumber();
            AccountHolderName = accountHolderName;
            Balance = initialBalance;
        }

        // A Method to generate a unique account number
        private int GenerateAccountNumber()
        {
            return ++accountNumberCounter;
        }

        //A  Method to deposit an amount into the account
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Deposited {amount:C}. New balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("Invalid deposit amount. Please enter a positive value.");
            }
        }

        // Its  a method to withdraw an amount from the account
        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawn {amount:C}. New balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount. Please enter a valid amount.");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Enter the account holder's name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the initial balance: ");
            double initialBalance = double.Parse(Console.ReadLine());

            // Create an instance of the BankAccount class with user-provided data(user can give the data here )
            BankAccount account = new BankAccount(name, initialBalance);

            Console.Write("Enter the deposit amount: ");
            double depositAmount = double.Parse(Console.ReadLine());

            // Through this its deposit the provided amount
            account.Deposit(depositAmount);

            // Print account details after the deposit
            Console.WriteLine("\nAccount Details:");
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Account Holder Name: {account.AccountHolderName}");
            Console.WriteLine($"Balance: {account.Balance:C}");

            Console.ReadLine();
        }
    }
}