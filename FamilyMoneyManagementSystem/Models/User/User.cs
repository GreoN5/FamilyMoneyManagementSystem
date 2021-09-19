using FamilyMoneyManagementSystem.Models.Money;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyMoneyManagementSystem.Models
{
	public class User
	{
		[Key]
		[Column(TypeName = "varchar(250)")]
		public string Username { get; set; }

		[Required]
		[Column(TypeName = "varchar(200)")]
		public string FirstName { get; set; }

		[Required]
		[Column(TypeName = "varchar(200)")]
		public string LastName { get; set; }

		[Required]
		[Column(TypeName = "tinyint")]
		public byte Age { get; set; }

		[Required]
		[Column(TypeName = "varchar(250)")]
		public string Password { get; set; }

		public List<MoneyTax> Money { get; set; } = new List<MoneyTax>();
	}
}
