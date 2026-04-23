using System;

namespace BankSystem.Models
{
    // سجل عملية مصرفية واحدة
    public class Transaction
    {
        // حقول خاصة - Encapsulation
        private readonly decimal _amount;
        private readonly string _type;
        private readonly DateTime _date;
        private readonly string _description;

        // Constructor
        public Transaction(decimal amount, string type, string description)
        {
            _amount = amount;
            _type = type;
            _date = DateTime.Now;
            _description = description;
        }

        // Properties للقراءة فقط
        public decimal Amount => _amount;
        public string Type => _type;
        public DateTime Date => _date;
        public string Description => _description;

        // عرض تفاصيل العملية
        public override string ToString()
        {
            return $"[{_date:yyyy-MM-dd HH:mm}] {_type}: {_amount:C} - {_description}";
        }
    }
}