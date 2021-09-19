using FamilyMoneyManagementSystem.Models.Money;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyMoneyManagementSystem.ViewModels.MoneyVM
{
	public class MoneyTaxEditVM
	{
		public int ID { get; set; }

		[Required(ErrorMessage = "Name is required!")]
		public string Name { get; set; }

		public string Description { get; set; }

		[Required(ErrorMessage = "Amount is required!")]
		public decimal Amount { get; set; }

		[Display(Name = "Time added")]
		[Required(ErrorMessage = "Time added is required!")]
		public DateTime TimeAdded { get; set; }
	}
}
