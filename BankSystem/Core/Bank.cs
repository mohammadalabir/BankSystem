using System;
using System.Collections.Generic;
using BankSystem.Models;
using BankSystem.Utilities;

namespace BankSystem.Core
{
    //  تحتوي على قائمة الحسابات
    public class Bank
    {
        private string _bankName;
        private List<Account> _accounts;

        public static int TotalAccounts { get; private set; }

        public Bank(string bankName)
        {
            _bankName = bankName;
            _accounts = new List<Account>();
        }

        public string BankName
        {
            get { return _bankName; }
        }

        public List<Account> Accounts
        {
            get { return _accounts; }
        }

        // إضافة حساب جديد
        public void AddAccount(Account account)
        {
            if (account == null)
            {
                Console.WriteLine("The amount is invalid!");
                return;
            }

            _accounts.Add(account);
            TotalAccounts = TotalAccounts + 1;
            Console.WriteLine(" the account has been added " + account.AccountNumber + " successfully!");
        }

        // البحث عن حساب برقمه
        public Account FindAccount(string accountNumber)
        {
            foreach (Account account in _accounts)
            {
                if (account.AccountNumber == accountNumber)
                    return account;
            }
            Console.WriteLine("Account not found!");
            return null;
        }

        // إجراء عملية إيداع
        public void PerformDeposit(string accountNumber, decimal amount)
        {
            if (!BankValidator.ValidateAmount(amount))
            {
                Console.WriteLine("The amount is invalid!");
                return;
            }

            Account account = FindAccount(accountNumber);
            if (account != null)
            {
                account.Deposit(amount);
                Console.WriteLine(" The amount has been deposited " + amount.ToString("C") + " into the account" + accountNumber);
            }
        }

        // إجراء عملية سحب
        public void PerformWithdrawal(string accountNumber, decimal amount)
        {
            if (!BankValidator.ValidateAmount(amount))
            {
                Console.WriteLine("Account is invalid!");
                return;
            }

            Account account = FindAccount(accountNumber);
            if (account != null)
            {
                
                account.Withdraw(amount);
                Console.WriteLine(" has been withdrawn " + amount.ToString("C") + " from the account " + accountNumber);
            }
        }

        // عرض جميع الحسابات 
        public void PrintAllAccounts()
        {
            Console.WriteLine("\n Bank " + _bankName + " ");
            Console.WriteLine("Total account : " + TotalAccounts);
            Console.WriteLine("------------------------");
            foreach (Account account in _accounts)
            {
                Console.WriteLine(account.GetAccountInfo());
            }
        }

        // حساب الفوائد لجميع الحسابات 
        public void PrintAllInterests()
        {
            Console.WriteLine("\n Bank accounts interest " + _bankName + " ");
            foreach (Account account in _accounts)
            {
                Console.WriteLine("account " + account.AccountNumber + " | interest: " + account.CalculateInterest().ToString("C"));
            }
        }
    }
}