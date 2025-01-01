﻿using Microsoft.EntityFrameworkCore;
using StanbicIBTC.Bank.Services.Models;

namespace StanbicIBTC.Bank.Services.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }

        // Override OnModelCreating to set column precision for Balance
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set precision and scale for the Balance property of Account
            modelBuilder.Entity<Account>()
                .Property(a => a.Balance)
                .HasColumnType("decimal(18, 2)"); // Specify precision of 18 and scale of 2
        }
    }
}