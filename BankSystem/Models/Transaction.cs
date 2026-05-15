using System;

namespace BankSystem.Models
{
    // سجل عملية مصرفية واحدة
   public class Transaction
    {
        private decimal _amount;
        private string _type;
        private DateTime _date;
        private string _description;

        public Transaction(decimal amount, string type, string description)
        {
            _amount = amount;
            _type = type;
            _date = DateTime.Now;
            _description = description;
        }

        public decimal Amount
        {
            get { return _amount; }
        }

        public string Type
        {
            get { return _type; }
        }

        public DateTime Date
        {
            get { return _date; }
        }

        public string Description
        {
            get { return _description; }
        }

        // عرض تفاصيل العملية  
        public override string ToString()
        {
            return "[" + _date.ToString("yyyy-MM-dd HH:mm") + "] " + _type + ": " + _amount.ToString("C") + " - " + _description;
        }
    }
}