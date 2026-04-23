using System;
using System.Collections.Generic;
using BankSystem.Interfaces;

namespace BankSystem.Models
{
    // Delegate للتبليغ عن العمليات المهمة
    public delegate void AccountEventHandler(string message);

    // الفئة المجردة الأساسية لجميع أنواع الحسابات
    public abstract class Account : IBankAccount
    {
        // حقول خاصة - Encapsulation
        private readonly string _accountNumber;
        private readonly string _ownerName;
        private decimal _balance;
        private readonly List<Transaction> _transactions;

        // Event يُطلق عند السحب الكبير
        public event AccountEventHandler OnLargeWithdrawal;

        // Constructor
        protected Account(string accountNumber, string ownerName, decimal initialBalance)
        {
            _accountNumber = accountNumber;
            _ownerName = ownerName;
            _balance = initialBalance;
            _transactions = new List<Transaction>();
        }

        // Properties
        public string AccountNumber => _accountNumber;
        public string OwnerName => _ownerName;
        public decimal Balance => _balance;
        public List<Transaction> Transactions => _transactions;

        // Deposit - تنفيذ من الواجهة
        public void Deposit(decimal amount)
        {
            _balance += amount;
            _transactions.Add(new Transaction(amount, "Deposit", "تم الإيداع"));
        }

        // Withdraw - تنفيذ من الواجهة
        public void Withdraw(decimal amount)
        {
            if (amount > _balance)
            {
                Console.WriteLine("رصيد غير كافٍ!");
                return;
            }

            _balance -= amount;
            _transactions.Add(new Transaction(amount, "Withdrawal", "تم السحب"));

            // إطلاق الحدث عند السحب الكبير
            if (amount > 1000)
            {
                OnLargeWithdrawal?.Invoke($"تحذير: تم سحب مبلغ كبير {amount:C} من الحساب {_accountNumber}");
            }
        }

        // دالة مجردة - كل فئة فرعية تطبقها بطريقتها
        public abstract decimal CalculateInterest();

        // دالة مجردة من الواجهة
        public abstract string GetAccountInfo();

        // عرض سجل العمليات
        public void PrintTransactions()
        {
            Console.WriteLine($"\n--- سجل عمليات الحساب {_accountNumber} ---");
            foreach (var t in _transactions)
                Console.WriteLine(t);
        }
    }
}