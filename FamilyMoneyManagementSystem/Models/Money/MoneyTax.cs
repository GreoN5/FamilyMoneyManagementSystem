using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyMoneyManagementSystem.Models.Money
{
	public class MoneyTax
	{
		[Key]
		public int ID { get; set; }

		[Required]
		[Column(TypeName = "varchar(100)")]
		public string Name { get; set; }

		[Column(TypeName = "varchar(MAX)")]
		public string Description { get; set; }

		[Required]
		[Column(TypeName = "decimal(8, 2)")]
		public decimal Amount { get; set; }

		[Required]
		[Column(TypeName = "datetime2")]
		public DateTime TimeAdded { get; set; }

		[Required]
		[Column(TypeName = "varchar(10)")]
		public MoneyType Type { get; set; }

		public User User { get; set; }
	}
}
