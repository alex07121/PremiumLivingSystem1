using System;

namespace PremiumLivingSystem.Models
{
    public class Staff
    {
        public string StaffID { get; set; }
        public string StaffName { get; set; }
        public string JobID { get; set; }
        public string PasswordHash { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
    }
}