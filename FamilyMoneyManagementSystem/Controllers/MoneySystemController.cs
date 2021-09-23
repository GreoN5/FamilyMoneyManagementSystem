using FamilyMoneyManagementSystem.Models;
using FamilyMoneyManagementSystem.Models.Money;
using FamilyMoneyManagementSystem.Repositories;
using FamilyMoneyManagementSystem.ViewModels.MoneyVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FamilyMoneyManagementSystem.Controllers
{
	[Authorize]
	public class MoneySystemController : Controller
	{
		private readonly UserRepository _repositoryUser;
		private readonly MoneySystemRepository _repositoryMoney;

		public MoneySystemController(UserRepository repositoryUser, MoneySystemRepository repositoryMoney)
		{
			this._repositoryUser = repositoryUser;
			this._repositoryMoney = repositoryMoney;
		}

		public IActionResult Index()
		{
			string username = this._repositoryUser.GetUsername();
			decimal income = this._repositoryMoney.GetIncomeSumPerUserThisMonth(username);
			decimal expense = this._repositoryMoney.GetExpensesSumPerUserThisMonth(username);

			ViewBag.Money = income - expense;
			ViewBag.Incomes = income;
			ViewBag.Expenses = expense;

			return View();
		}

		public IActionResult AddIncome()
		{
			return View();
		}

		public IActionResult AddExpense()
		{
			return View();
		}

		public async Task<IActionResult> AddRepeatedIncome()
		{
			string username = this._repositoryUser.GetUsername();
			List<MoneyTax> income = await this._repositoryMoney.GetIncomeListForUserPreviousMonthSameDayAsync(username);
			ViewBag.ListOfIncome = income;

			return View();
		}

		public async Task<IActionResult> AddRepeatedExpense()
		{
			string username = this._repositoryUser.GetUsername();
			List<MoneyTax> expenses = await this._repositoryMoney.GetExpenseListForUserPreviousMonthSameDayAsync(username);
			ViewBag.ListOfExpense = expenses;

			return View();
		}

		public async Task<IActionResult> GetIncomeListForThisMonth()
		{
			string username = this._repositoryUser.GetUsername();
			List<MoneyTax> incomes = await this._repositoryMoney.GetIncomeListForUserThisMonthAsync(username);
			ViewBag.ListOfIncomes = incomes;

			return View();
		}

		public async Task<IActionResult> GetExpenseListForThisMonth()
		{
			string username = this._repositoryUser.GetUsername();
			List<MoneyTax> expenses = await this._repositoryMoney.GetExpenseListForUserThisMonthAsync(username);
			ViewBag.ListOfExpenses = expenses;

			return View();
		}

		public async Task<IActionResult> EditIncome(int ID)
		{
			MoneyTax income = await this._repositoryMoney.GetMoneyIncomeAsync(ID);

			if (income == null)
			{
				return RedirectToAction("GetIncomeListForThisMonth");
			}

			MoneyTaxEditVM editIncome = new MoneyTaxEditVM()
			{
				ID = income.ID,
				Name = income.Name,
				Description = income.Description,
				Amount = income.Amount,
				TimeAdded = income.TimeAdded
			};

			return View(editIncome);
		}

		public async Task<IActionResult> EditExpense(int ID)
		{
			MoneyTax expense = await this._repositoryMoney.GetMoneyExpenseAsync(ID);

			if (expense == null)
			{
				return RedirectToAction("GetExpenseListForThisMonth");
			}

			MoneyTaxEditVM editExpense = new MoneyTaxEditVM()
			{
				ID = expense.ID,
				Name = expense.Name,
				Description = expense.Description,
				Amount = expense.Amount,
				TimeAdded = expense.TimeAdded
			};

			return View(editExpense);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddIncome([FromForm] MoneyVM income)
		{
			if (ModelState.IsValid)
			{
				User user = await this._repositoryUser.GetUser(this._repositoryUser.GetUsername());
				MoneyTax moneyIncome = await this._repositoryMoney.AddIncomeAsync(income);

				if (user != null)
				{
					await this._repositoryMoney.AddMoneyToUser(user, moneyIncome);

					return RedirectToAction("Index", "MoneySystem");
				}
			}

			return View(income);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddExpense([FromForm] MoneyVM expense)
		{
			if (ModelState.IsValid)
			{
				string username = this._repositoryUser.GetUsername();
				User user = await this._repositoryUser.GetUser(username);
				MoneyTax moneyExpense = await this._repositoryMoney.AddExpenseAsync(expense);

				if (user != null)
				{
					await this._repositoryMoney.AddMoneyToUser(user, moneyExpense);

					return RedirectToAction("Index", "MoneySystem");
				}
			}

			return View(expense);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddRepeatedIncome([FromForm] MoneyVM repeatedIncome)
		{
			string username = this._repositoryUser.GetUsername();
			User user = await this._repositoryUser.GetUser(username);
			MoneyTax repeatedIncomeTax = await this._repositoryMoney.AddRepeatedIncomeAsync(repeatedIncome);

			if (user != null)
			{
				await this._repositoryMoney.AddMoneyToUser(user, repeatedIncomeTax);

				return RedirectToAction("Index", "MoneySystem");
			}

			return RedirectToAction("Login", "Home");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddRepeatedExpense([FromForm] MoneyVM repeatedExpense)
		{
			string username = this._repositoryUser.GetUsername();
			User user = await this._repositoryUser.GetUser(username);
			MoneyTax repeatedIncomeTax = await this._repositoryMoney.AddRepeatedExpenseAsync(repeatedExpense);

			if (user != null)
			{
				await this._repositoryMoney.AddMoneyToUser(user, repeatedIncomeTax);

				return RedirectToAction("Index", "MoneySystem");
			}

			return RedirectToAction("Login", "Home");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditIncome(MoneyTaxEditVM incomeEdit)
		{
			if (!ModelState.IsValid)
			{
				return View(incomeEdit);
			}

			string username = this._repositoryUser.GetUsername();
			MoneyTax income = await this._repositoryMoney.EditIncomeAsync(username, incomeEdit);

			if (income == null)
			{
				return View(incomeEdit);
			}

			return RedirectToAction("GetIncomeListForThisMonth");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditExpense(MoneyTaxEditVM expenseEdit)
		{
			if (!ModelState.IsValid)
			{
				return View(expenseEdit);
			}

			string username = this._repositoryUser.GetUsername();
			MoneyTax expense = await this._repositoryMoney.EditExpenseAsync(username, expenseEdit);

			if (expense == null)
			{
				return View(expenseEdit);
			}

			return RedirectToAction("GetExpenseListForThisMonth");
		}

		public async Task<IActionResult> DeleteIncome(int ID)
		{
			MoneyTax income = await this._repositoryMoney.GetMoneyIncomeAsync(ID);
			await this._repositoryMoney.DeleteMoneyTax(income);

			return RedirectToAction("GetIncomeListForThisMonth");
		}

		public async Task<IActionResult> DeleteExpense(int ID)
		{
			MoneyTax expense = await this._repositoryMoney.GetMoneyExpenseAsync(ID);
			await this._repositoryMoney.DeleteMoneyTax(expense);

			return RedirectToAction("GetExpenseListForThisMonth");
		}

		public async Task<IActionResult> Logout()
		{
			await this._repositoryUser.LogoutAsync();
			return RedirectToAction("Index", "Home");
		}

		public async Task<IActionResult> GetMoneyIncome(int ID)
		{
			var data = await this._repositoryMoney.GetMoneyIncomeAsync(ID);

			return Json(data);
		}

		public async Task<IActionResult> GetMoneyExpense(int ID)
		{
			var data = await this._repositoryMoney.GetMoneyExpenseAsync(ID);

			return Json(data);
		}
	}
}
