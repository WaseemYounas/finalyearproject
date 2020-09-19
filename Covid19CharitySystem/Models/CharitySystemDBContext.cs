using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Covid19CharitySystem.Models
{
    public class CharitySystemDBContext:DbContext
    {
        public CharitySystemDBContext(): base("DataContext")
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Donation> Donation { get; set; }
        public DbSet<Task> Task { get; set; }
    }
}