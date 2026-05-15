using System;
using BankSystem.Core;
using BankSystem.Models;

namespace BankSystem
{
    class Program
    {
        //  (Event Handler)
        static void HandleLargeWithdrawal(string message)
        {
            Console.WriteLine("[Alert] " + message);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(" Welcome to the bank system \n");

            // إنشاء البنك
            Bank bank = new Bank("Syria");

            // إنشاء الحسابات
            SavingsAccount savings = new SavingsAccount("ACC001", " Ahmad Mohammad ", 5000, 3.5m);
            CurrentAccount current = new CurrentAccount("ACC002", " Mohammad Al_Abber ", 10000, 2000);
            InvestmentAccount investment = new InvestmentAccount("ACC003", " Rahaf AL_Zain", 20000, 5, 12);

            // ربط الحدث  
            savings.OnLargeWithdrawal += HandleLargeWithdrawal;
            current.OnLargeWithdrawal += HandleLargeWithdrawal;
            investment.OnLargeWithdrawal += HandleLargeWithdrawal;

            // إضافة الحسابات للبنك
            bank.AddAccount(savings);
            bank.AddAccount(current);
            bank.AddAccount(investment);

            // عرض جميع الحسابات
            bank.PrintAllAccounts();

            // إجراء عمليات
            Console.WriteLine("\n Banking transactions ");
            bank.PerformDeposit("ACC001", 1000);
            bank.PerformWithdrawal("ACC002", 1500);
            bank.PerformWithdrawal("ACC003", 5000); // سيطلق الحدث

            // عرض الفوائد
            bank.PrintAllInterests();

            // عرض سجل العمليات
            savings.PrintTransactions();
            current.PrintTransactions();
            investment.PrintTransactions();

            Console.WriteLine("\n Thank you for using the bank system ");
           
        }
    }
}