using System;
using BankSystem.Core;
using BankSystem.Models;

namespace BankSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== مرحباً بك في نظام البنك ===\n");

            // إنشاء البنك
            Bank bank = new Bank(" سورية");

            // إنشاء الحسابات
            SavingsAccount savings = new SavingsAccount("ACC001", "أحمد محمد", 5000, 3.5m);
            CurrentAccount current = new CurrentAccount("ACC002", "سارة علي", 10000, 2000);
            InvestmentAccount investment = new InvestmentAccount("ACC003", "خالد حسن", 20000, 5, 12);

            // ربط الحدث
            savings.OnLargeWithdrawal += message => Console.WriteLine($"[تنبيه] {message}");
            current.OnLargeWithdrawal += message => Console.WriteLine($"[تنبيه] {message}");
            investment.OnLargeWithdrawal += message => Console.WriteLine($"[تنبيه] {message}");

            // إضافة الحسابات للبنك
            bank.AddAccount(savings);
            bank.AddAccount(current);
            bank.AddAccount(investment);

            // عرض جميع الحسابات
            bank.PrintAllAccounts();

            // إجراء عمليات
            Console.WriteLine("\n=== العمليات المصرفية ===");
            bank.PerformDeposit("ACC001", 1000);
            bank.PerformWithdrawal("ACC002", 1500);
            bank.PerformWithdrawal("ACC003", 5000); // سيطلق الحدث

            // عرض الفوائد
            bank.PrintAllInterests();

            // عرض سجل العمليات
            savings.PrintTransactions();
            current.PrintTransactions();
            investment.PrintTransactions();

            Console.WriteLine("\n=== شكراً لاستخدامك نظام البنك ===");
            Console.ReadLine();
        }
    }
}