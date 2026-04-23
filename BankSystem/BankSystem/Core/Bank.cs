using System;
using System.Collections.Generic;
using BankSystem.Models;
using BankSystem.Utilities;

namespace BankSystem.Core
{
    // الفئة الرئيسية للبنك - تحتوي على قائمة الحسابات
    public class Bank
    {
        // حقول خاصة
        private readonly string _bankName;
        private readonly List<Account> _accounts;

        // خاصية ساكنة لحساب عدد الحسابات الكلي
        public static int TotalAccounts { get; private set; }

        // Constructor
        public Bank(string bankName)
        {
            _bankName = bankName;
            _accounts = new List<Account>();
        }

        // Properties
        public string BankName => _bankName;
        public List<Account> Accounts => _accounts;

        // إضافة حساب جديد
        public void AddAccount(Account account)
        {
            if (account == null)
            {
                Console.WriteLine("الحساب غير صالح!");
                return;
            }

            _accounts.Add(account);
            TotalAccounts++;
            Console.WriteLine($"تم إضافة الحساب {account.AccountNumber} بنجاح!");
        }

        // البحث عن حساب برقمه
        public Account FindAccount(string accountNumber)
        {
            foreach (var account in _accounts)
            {
                if (account.AccountNumber == accountNumber)
                    return account;
            }
            Console.WriteLine("الحساب غير موجود!");
            return null;
        }

        // إجراء عملية إيداع
        public void PerformDeposit(string accountNumber, decimal amount)
        {
            if (!BankValidator.ValidateAmount(amount))
            {
                Console.WriteLine("المبلغ غير صالح!");
                return;
            }

            Account account = FindAccount(accountNumber);
            if (account != null)
            {
                account.Deposit(amount);
                Console.WriteLine($"تم إيداع {amount:C} في الحساب {accountNumber}");
            }
        }

        // إجراء عملية سحب
        public void PerformWithdrawal(string accountNumber, decimal amount)
        {
            if (!BankValidator.ValidateAmount(amount))
            {
                Console.WriteLine("المبلغ غير صالح!");
                return;
            }

            Account account = FindAccount(accountNumber);
            if (account != null)
            {
                if (!BankValidator.ValidateBalance(account.Balance, amount))
                {
                    Console.WriteLine("رصيد غير كافٍ!");
                    return;
                }
                account.Withdraw(amount);
                Console.WriteLine($"تم سحب {amount:C} من الحساب {accountNumber}");
            }
        }

        // عرض جميع الحسابات - Polymorphism
        public void PrintAllAccounts()
        {
            Console.WriteLine($"\n=== بنك {_bankName} ===");
            Console.WriteLine($"إجمالي الحسابات: {TotalAccounts}");
            Console.WriteLine("------------------------");
            foreach (var account in _accounts)
            {
                Console.WriteLine(account.GetAccountInfo());
            }
        }

        // حساب الفوائد لجميع الحسابات - Polymorphism
        public void PrintAllInterests()
        {
            Console.WriteLine($"\n=== فوائد حسابات بنك {_bankName} ===");
            foreach (var account in _accounts)
            {
                Console.WriteLine($"الحساب {account.AccountNumber} | الفائدة: {account.CalculateInterest():C}");
            }
        }
    }
}