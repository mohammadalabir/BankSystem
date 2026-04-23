using System;

namespace BankSystem.Models
{
    // الحساب الجاري - الفئة الفرعية الثانية
    public class CurrentAccount : Account
    {
        private decimal _overdraftLimit;

        public decimal OverdraftLimit => _overdraftLimit;

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

        // تطبيق دالة عرض معلومات الحساب
        public override string GetAccountInfo()
        {
            return $"[حساب جاري] رقم: {AccountNumber} | المالك: {OwnerName} | الرصيد: {Balance:C} | حد السحب على المكشوف: {_overdraftLimit:C}";
        }
    }
}