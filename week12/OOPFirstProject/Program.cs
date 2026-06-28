using System;

namespace Bank
{
    enum AccountType { Savings, Checking, Buisness }
    class BankAccount
    {
        private int _accountNumber;
        private string _ownerName;
        private double _balance;
        private string _accountType;
        private bool _isActive = true;
        private List<string> _transactionHistory = new List<string>();


        public int AccountNumber
        {
            get => _accountNumber;
        }
        public string OwnerName
        {
            get => _ownerName;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    _ownerName = "Unknowen";
                else _ownerName = value;
            }

        }
        public double Balance
        {
            get => _balance;
            set
            {
                if (value < 0) _balance = 0;
                else _balance = value;
            }
        }
        public string AccountType
        {
            get => _accountType;
            set
            {
                if (!Enum.TryParse<AccountType>(value, true, out AccountType result)) _accountType = "Checking";
                else _accountType = result.ToString();
            }
        }


        public bool IsActive
        {
            get => _isActive;
            private set
            {
                _isActive = value;
            }
        }
        public BankAccount(int accountNumber, string ownerName, double balance, string accountType)
        {
            _accountNumber = accountNumber;
            OwnerName = ownerName;
            Balance = balance;
            AccountType = accountType;

        }

        public BankAccount(int accountNumber, string ownerName)

            : this(accountNumber, ownerName, 0.0, "Checking") { }

        public BankAccount(int accountNumber, string ownerName, double initialDeposit)

            : this(accountNumber, ownerName, initialDeposit, "Checking") { }

        public override string ToString()
        => $"Account: {AccountNumber} | Owner: {OwnerName} | Balance: {Balance} | Type: {AccountType}";

        public void Deposit(double amount)
        {
            if (IsActive != true) { Console.WriteLine("You cant deposite into in-active account"); }
            else if (amount < 0) Console.WriteLine("Error cant deposit negative amount!");
            else { Balance += amount;
                _transactionHistory.Add($"Deposited ${amount}");
            }

        }

        public bool Withdraw(double amount)
        {   
            if (IsActive != true)
            {
                Console.WriteLine("You cant withdraw form un-active account");
                return false;
            }
            else if (amount < 0)
            {
                Console.WriteLine("Error cant withdraw negative anount");
                return false;
            }
            else if (Balance < amount)
            {
                Console.WriteLine("The Account doesnt have enought money");
                return false;
            }
            else
            {
                Balance -= amount;
                {
                    Console.WriteLine($"{amount} withdrow The remain amount: {Balance}");
                    _transactionHistory.Add($"Withdrowed ${amount}");
                    return true;
                }
            }
        }


        public void ApplyInterest()
        {
            if (AccountType == "Saving") Balance *= 1.02; 
        }

        public void PrintTransactionHistory()
        {
            foreach(string line in _transactionHistory)
            {
                Console.WriteLine(line);
            }
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public static bool Transfer(BankAccount from , BankAccount to, double amount)
        {
            if (!to.IsActive)
            {
                Console.WriteLine("The destination account is un-active");
                return false;
            }
            if (!from.Withdraw(amount))
            {
                Console.WriteLine("The action failed");
                return false;
            }
            
            to.Deposit(amount);
            return true;
        }
    }

     class Bank
    {
        static void Main()
        {

        }
    }   



}

