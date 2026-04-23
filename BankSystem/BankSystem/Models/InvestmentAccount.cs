using System;

namespace BankSystem.Models
{
    // حساب الاستثمار - الفئة الفرعية الثالثة
    public class InvestmentAccount : Account
    {
        private decimal _interestRate;
        private int _investmentPeriodMonths;

        public decimal InterestRate => _interestRate;
        public int InvestmentPeriodMonths => _investmentPeriodMonths;

        public InvestmentAccount(string accountNumber, string ownerName, decimal initialBalance, decimal interestRate, int investmentPeriodMonths)
            : base(accountNumber, ownerName, initialBalance)
        {
            _interestRate = interestRate;
            _investmentPeriodMonths = investmentPeriodMonths;
        }

        // حساب الفائدة المركبة للحساب الاستثماري
        public override decimal CalculateInterest()
        {
            return Balance * (_interestRate / 100) * _investmentPeriodMonths / 12;
        }

        // تطبيق دالة عرض معلومات الحساب
        public override string GetAccountInfo()
        {
            return $"[حساب استثماري] رقم: {AccountNumber} | المالك: {OwnerName} | الرصيد: {Balance:C} | الفائدة: {_interestRate}% | المدة: {_investmentPeriodMonths} شهر";
        }
    }
}