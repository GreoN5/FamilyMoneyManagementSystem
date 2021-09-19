using System.ComponentModel.DataAnnotations;

namespace FamilyMoneyManagementSystem.ViewModels
{
	public class UserRegistrationVM
	{
		[Required(ErrorMessage = "Username is required!")]
		public string Username { get; set; }

		[Display(Name = "First name")]
		[Required(ErrorMessage = "First name is required!")]
		public string FirstName { get; set; }

		[Display(Name = "Last name")]
		[Required(ErrorMessage = "Last name is required!")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Age is required!")]
		public byte Age { get; set; }

		[Required(ErrorMessage = "Password is required!")]
		[RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{6,}$",
		ErrorMessage = "The password should be at least 6 symbols, containing lowercase letter(s), uppercase letter(s) and digits without spaces!")]
		public string Password { get; set; }
	}
}
