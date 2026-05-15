using System;
using System.Collections.Generic;
using BankSystem.Interfaces;

namespace BankSystem.Models
{
    //  للتبليغ عن العمليات 
    public delegate void AccountEventHandler(string message);

    //    لجميع أنواع الحسابات
    public abstract class Account : IBankAccount
    {
        private string _accountNumber;
        private string _ownerName;
        private decimal _balance;
        private List<Transaction> _transactions;

        //  يُطلق عند السحب الكبير
        public event AccountEventHandler OnLargeWithdrawal;

        protected Account(string accountNumber, string ownerName, decimal initialBalance)
        {
            _accountNumber = accountNumber;
            _ownerName = ownerName;
            _balance = initialBalance;
            _transactions = new List<Transaction>();
        }

        public string AccountNumber
        {
            get { return _accountNumber; }
        }

        public string OwnerName
        {
            get { return _ownerName; }
        }

        public decimal Balance
        {
            get { return _balance; }
            protected set { _balance = value; }
        }

     public IReadOnlyList<Transaction> Transactions
{
    get { return _transactions.AsReadOnly(); }
}

        public void Deposit(decimal amount)
        {
            Balance = Balance + amount;
            AddTransaction(new Transaction(amount, "Deposit", "Deposit completed"));
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds!");
                return;
            }

            Balance = Balance - amount;
            AddTransaction(new Transaction(amount, "Withdrawal", "Withdrawal completed"));

            if (amount > 1000)
            {
                OnLargeWithdrawalHandler(amount);
            }
        }

        protected virtual void OnLargeWithdrawalHandler(decimal amount)
        {
            if (OnLargeWithdrawal != null)
            {
                OnLargeWithdrawal("Warning: Large withdrawal of " + amount.ToString("C") + " from account " + AccountNumber);
            }
        }

        //       
        public abstract decimal CalculateInterest();

        public abstract string GetAccountInfo();

        // عرض سجل العمليات
        public void PrintTransactions()
        {
            Console.WriteLine("\n--- The record of withdrawals " + _accountNumber + " ---");
            foreach (Transaction t in _transactions)
            {
                Console.WriteLine(t.ToString());
            }
        }

        protected void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

    }
}