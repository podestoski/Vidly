﻿using System.Data.Entity;

namespace Vidly.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}