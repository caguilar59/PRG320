using System;

class SimpleBankSystem
{
    static double balance = 1000.0;
    static int pin = 1234;

    static void Main(string[] args)
    {
        int attempts = 0;
        bool loggedIn = false;

        // Login System
        while (attempts < 3)
        {
            Console.Write("Enter your PIN: ");
            int enteredPin = Convert.ToInt32(Console.ReadLine());

            if (enteredPin == pin)
            {
                loggedIn = true;
                break;
            }
            else
            {
                attempts++;
                Console.WriteLine("Incorrect PIN. Attempts left: " + (3 - attempts));
            }
        }

        if (!loggedIn)
        {
            Console.WriteLine("Too many incorrect attempts. Account locked.");
            return;
        }

        int choice = 0;

        // Main Banking Loop
        while (choice != 4)
        {
            Console.WriteLine("\n---Simple Bank System---");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Deposit();
                    break;

                case 2:
                    Withdraw();
                    break;

                case 3:
                    CheckBalance();
                    break;

                case 4:
                    Console.WriteLine("Thank you for using the bank system.");
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void Deposit()
    {
        Console.Write("Enter deposit amount: ");
        double amount = Convert.ToDouble(Console.ReadLine());

        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine("Deposit successful. New balance: $" + balance);
        }
        else
        {
            Console.WriteLine("Deposit must be a positive amount.");
        }
    }

    static void Withdraw()
    {
        Console.Write("Enter withdrawal amount: ");
        double amount = Convert.ToDouble(Console.ReadLine());

        // Check if the amount is valid
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal must be positive.");
            return;
        }

        // Check if the user has enough money
        if (amount > balance)
        {
            Console.WriteLine("Insufficient funds.");
            return;
        }

        // Subtract the money from the balance
        balance -= amount;

        Console.WriteLine("Withdrawal successful. New balance: $" + balance);
    }

    static void CheckBalance()
    {
        Console.WriteLine("Your current balance is: $" + balance);
        Console.WriteLine("Press any key to return to the menu...");// Add this line to deplay in the terminal
        Console.ReadKey();
    }
}