using FamilyMoneyManagementSystem.Models;
using FamilyMoneyManagementSystem.Repositories;
using FamilyMoneyManagementSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FamilyMoneyManagementSystem.Controllers
{
	public class HomeController : Controller
	{
		private readonly UserRepository _repository;

		public HomeController(UserRepository repository)
		{
			this._repository = repository;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login([FromForm] UserLoginVM userLogin)
		{
			if (ModelState.IsValid)
			{
				User user = await this._repository.LoginAsync(userLogin);

				if (user != null)
				{
					await this._repository.GenerateUserClaimsAsync(user.Username, user.FirstName);
					return RedirectToAction("Index", "MoneySystem");
				}
			}

			return View(userLogin);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register([FromForm] UserRegistrationVM userRegistration)
		{
			if (ModelState.IsValid)
			{
				User user = await this._repository.RegistrationAsync(userRegistration);

				if (user.Username == null)
				{
					ModelState.AddModelError("Username", "Username already exists!");
					return View(userRegistration);
				}

				return RedirectToAction("Login", "Home");
			}

			return View(userRegistration);
		}
	}
}
