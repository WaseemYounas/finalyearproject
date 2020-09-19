
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covid19CharitySystem.Models
{
    public class Task
    {
        public int Id { get; set; }
        public int Donation_Id { get; set; }
        public int User_Id { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }
        public int IsActive { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public virtual User User { get; set; }
    }
}