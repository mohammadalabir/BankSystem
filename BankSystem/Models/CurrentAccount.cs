using System;

namespace BankSystem.Models
{
    public class CurrentAccount : Account
    {
        private decimal _overdraftLimit;

        public decimal OverdraftLimit
        {
            get { return _overdraftLimit; }
        }

        public CurrentAccount(string accountNumber, string ownerName, decimal initialBalance, decimal overdraftLimit)
            : base(accountNumber, ownerName, initialBalance)
        {
            _overdraftLimit = overdraftLimit;
        }

        // الحساب الجاري لا يعطي فائدة
        public override decimal CalculateInterest()
        {
            return 0;
        }

        //   عرض معلومات الحساب
        public override string GetAccountInfo()
        {
            return "[current account] number: " + AccountNumber + " | the owner: " + OwnerName + " | balance: " + Balance.ToString("C") + " | overdraft Limit : " + _overdraftLimit.ToString("C");
        }

        public override void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount!");
                return;
            }

            if (amount > Balance + _overdraftLimit)
            {
                Console.WriteLine("Exceeds overdraft limit!");
                return;
            }

            Balance = Balance - amount;
            AddTransaction(new Transaction(amount, "Withdrawal", "Withdrawal completed"));

            if (amount > 1000)
            {
                OnLargeWithdrawalHandler(amount);
            }
        }

    }
}