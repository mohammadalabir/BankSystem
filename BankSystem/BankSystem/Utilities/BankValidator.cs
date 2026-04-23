using System;

namespace BankSystem.Utilities
{
    // فئة ساكنة للتحقق من صحة البيانات
    public static class BankValidator
    {
        // التحقق من صحة المبلغ
        public static bool ValidateAmount(decimal amount)
        {
            return amount > 0;
        }

        // التحقق من كفاية الرصيد
        public static bool ValidateBalance(decimal balance, decimal amount)
        {
            return balance >= amount;
        }

        // التحقق من صحة رقم الحساب
        public static bool ValidateAccountNumber(string accountNumber)
        {
            return !string.IsNullOrEmpty(accountNumber) && accountNumber.Length >= 6;
        }

        // التحقق من صحة اسم المالك
        public static bool ValidateOwnerName(string ownerName)
        {
            return !string.IsNullOrEmpty(ownerName) && ownerName.Length >= 3;
        }
    }
}