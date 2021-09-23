using FamilyMoneyManagementSystem.Models;
using FamilyMoneyManagementSystem.Models.Money;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyMoneyManagementSystem.Data
{
	public class MoneySystemDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<MoneyTax> Money { get; set; }

		public MoneySystemDbContext(DbContextOptions<MoneySystemDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().Property(u => u.Username).ValueGeneratedNever();
			modelBuilder.Entity<MoneyTax>().HasOne(p => p.User).WithMany(b => b.Money);
		}
	}
}
