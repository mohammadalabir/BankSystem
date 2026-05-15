using System;

namespace BankSystem.Models
{
    // حساب التوفير 
    public class SavingsAccount : Account
    {
        private decimal _interestRate;

        public decimal InterestRate
        {
            get { return _interestRate; }
        }

        public SavingsAccount(string accountNumber, string ownerName, decimal initialBalance, decimal interestRate)
            : base(accountNumber, ownerName, initialBalance)
        {
            _interestRate = interestRate;
        }

        //   حساب الفائدة بطريقة حساب التوفير
        public override decimal CalculateInterest()
        {
            return Balance * _interestRate / 100;
        }

        //   عرض معلومات الحساب
        public override string GetAccountInfo()
        {
            return "[Saving account] Number: " + AccountNumber + " | owner: " + OwnerName + " | balance: " + Balance.ToString("C") + " | interest: " + _interestRate.ToString() + "%";
        }
    }
}