using System;

namespace BankSystem.Models
{
    // حساب الاستثمار 
    public class InvestmentAccount : Account
    {
        private decimal _interestRate;
        private int _investmentPeriodMonths;

        public decimal InterestRate
        {
            get { return _interestRate; }
        }

        public int InvestmentPeriodMonths
        {
            get { return _investmentPeriodMonths; }
        }

        public InvestmentAccount(string accountNumber, string ownerName, decimal initialBalance, decimal interestRate, int investmentPeriodMonths)
            : base(accountNumber, ownerName, initialBalance)
        {
            _interestRate = interestRate;
            _investmentPeriodMonths = investmentPeriodMonths;
        }

        // حساب الفائدة  للحساب الاستثماري
        public override decimal CalculateInterest()
        {
            return Balance * (_interestRate / 100) * _investmentPeriodMonths / 12;
        }

        //  عرض معلومات الحساب
        public override string GetAccountInfo()
        {
            return "[investment account] number: " + AccountNumber + " | the owner: " + OwnerName + " | balance: " + Balance.ToString("C") + " | interest: " + _interestRate.ToString() + "% | Period : " + _investmentPeriodMonths.ToString() + " month";
        }
    }
}