using System;



namespace BankSystem.Interfaces
{
    // الواجهة الأساسية التي تحدد العمليات الجوهرية لأي حساب بنكي
    public interface IBankAccount
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        string GetAccountInfo();
    }
}