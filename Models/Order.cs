using System;

namespace PremiumLivingSystem.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string StaffID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public string Status { get; set; }
    }
}