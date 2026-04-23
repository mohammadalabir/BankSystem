using System;

namespace BankSystem.Models
{
    // حساب التوفير - الفئة الفرعية الأولى
    public class SavingsAccount : Account
    {
        private decimal _interestRate;

        public decimal InterestRate => _interestRate;

        public SavingsAccount(string accountNumber, string ownerName, decimal initialBalance, decimal interestRate)
            : base(accountNumber, ownerName, initialBalance)
        {
            _interestRate = interestRate;
        }

        // تطبيق دالة حساب الفائدة بطريقة حساب التوفير
        public override decimal CalculateInterest()
        {
            return Balance * _interestRate / 100;
        }

        // تطبيق دالة عرض معلومات الحساب
        public override string GetAccountInfo()
        {
            return $"[حساب توفير] رقم: {AccountNumber} | المالك: {OwnerName} | الرصيد: {Balance:C} | الفائدة: {_interestRate}%";
        }
    }
}