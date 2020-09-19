using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covid19CharitySystem.Models
{
    public class Donation
    {
            public int Id { get; set; }
            public int IsAssigned { get; set; }
            public int Status { get; set; }
            public string Type { get; set; }
            public string PickLocation { get; set; }
            public Nullable<int> User_Id { get; set; }
            public System.DateTime CreatedAt { get; set; }

            public virtual User User { get; set; }
    }
}