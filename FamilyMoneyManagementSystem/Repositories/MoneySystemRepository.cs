using FamilyMoneyManagementSystem.Data;
using FamilyMoneyManagementSystem.Models;
using FamilyMoneyManagementSystem.Models.Money;
using FamilyMoneyManagementSystem.ViewModels.MoneyVM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyMoneyManagementSystem.Repositories
{
	public class MoneySystemRepository
	{
		private readonly MoneySystemDbContext _context;

		public MoneySystemRepository(MoneySystemDbContext context)
		{
			this._context = context;
		}

		public decimal GetIncomeSumPerUserThisMonth(string username)
		{
			return this._context.Money.Where(m => m.Type == MoneyType.Income &&
											 m.User.Username == username &&
											 m.TimeAdded.Month == DateTime.Now.Month).Sum(m => m.Amount);
		}

		public decimal GetExpensesSumPerUserThisMonth(string username)
		{
			return this._context.Money.Where(m => m.Type == MoneyType.Expense &&
											 m.User.Username == username &&
											 m.TimeAdded.Month == DateTime.Now.Month).Sum(m => m.Amount);
		}

		public async Task AddMoneyToUser(User user, MoneyTax money)
		{
			user.Money.Add(money);
			money.User = user;

			await this._context.SaveChangesAsync();
		}

		public async Task<MoneyTax> AddIncomeAsync(MoneyVM income)
		{
			return await AddMoneyTaxAsync(income, MoneyType.Income);
		}

		public async Task<MoneyTax> AddExpenseAsync(MoneyVM expense)
		{
			return await AddMoneyTaxAsync(expense, MoneyType.Expense);
		}

		public async Task<MoneyTax> AddRepeatedIncomeAsync(MoneyVM repeatedIncome)
		{
			return await AddRepeatedMoneyTaxAsync(repeatedIncome, MoneyType.Income);
		}

		public async Task<MoneyTax> AddRepeatedExpenseAsync(MoneyVM repeatedExpense)
		{
			return await AddRepeatedMoneyTaxAsync(repeatedExpense, MoneyType.Expense);
		}

		public async Task<MoneyTax> GetMoneyIncomeAsync(int ID)
		{
			return await this._context.Money.Where(m => m.Type == MoneyType.Income).FirstAsync(m => m.ID == ID);
		}

		public async Task<MoneyTax> GetMoneyExpenseAsync(int ID)
		{
			return await this._context.Money.Where(m => m.Type == MoneyType.Expense).FirstAsync(m => m.ID == ID);
		}

		public async Task<List<MoneyTax>> GetIncomeListForUserThisMonthAsync(string username)
		{
			return await this._context.Money.Where(m => m.Type == MoneyType.Income &&
												   m.User.Username == username &&
												   m.TimeAdded.Month == DateTime.Now.Month).ToListAsync();
		}

		public async Task<List<MoneyTax>> GetExpenseListForUserThisMonthAsync(string username)
		{
			return await this._context.Money.Where(m => m.Type == MoneyType.Expense &&
												   m.User.Username == username &&
												   m.TimeAdded.Month == DateTime.Now.Month).ToListAsync();
		}

		public async Task<List<MoneyTax>> GetIncomeListForUserPreviousMonthSameDayAsync(string username)
		{
			return await this._context.Money.Where(m => m.TimeAdded.Month == (DateTime.Now.Month - 1) &&
												   m.TimeAdded.Day == DateTime.Now.Day &&
												   m.Type == MoneyType.Income &&
												   m.User.Username == username).ToListAsync();
		}

		public async Task<List<MoneyTax>> GetExpenseListForUserPreviousMonthSameDayAsync(string username)
		{
			return await this._context.Money.Where(m => m.TimeAdded.Month == (DateTime.Now.Month - 1) &&
												   m.TimeAdded.Day == DateTime.Now.Day &&
												   m.Type == MoneyType.Expense &&
												   m.User.Username == username).ToListAsync();
		}

		public async Task<MoneyTax> EditIncomeAsync(string username, MoneyTaxEditVM incomeEdit)
		{
			return await EditMoneyAsync(username, incomeEdit, MoneyType.Income);
		}

		public async Task<MoneyTax> EditExpenseAsync(string username, MoneyTaxEditVM expeseEdit)
		{
			return await EditMoneyAsync(username, expeseEdit, MoneyType.Expense);
		}

		public async Task DeleteMoneyTax(MoneyTax money)
		{
			this._context.Money.Remove(money);
			this._context.Entry(money).State = EntityState.Deleted;

			await this._context.SaveChangesAsync();
		}

		private async Task<MoneyTax> AddMoneyTaxAsync(MoneyVM moneyTax, MoneyType type)
		{
			MoneyTax newTaxMoney = new MoneyTax()
			{
				Name = moneyTax.Name,
				Description = moneyTax.Description,
				Amount = moneyTax.Amount,
				TimeAdded = moneyTax.TimeAdded,
				Type = type
			};

			await this._context.Money.AddAsync(newTaxMoney);
			await this._context.SaveChangesAsync();

			return newTaxMoney;
		}

		private async Task<MoneyTax> AddRepeatedMoneyTaxAsync(MoneyVM repeatedMoneyTax, MoneyType type)
		{
			MoneyTax repeatedTax = new MoneyTax()
			{
				Name = repeatedMoneyTax.Name,
				Description = repeatedMoneyTax.Description,
				Amount = repeatedMoneyTax.Amount,
				TimeAdded = repeatedMoneyTax.TimeAdded.AddMonths(1),
				Type = type
			};

			await this._context.Money.AddAsync(repeatedTax);
			await this._context.SaveChangesAsync();

			return repeatedTax;
		}

		private async Task<MoneyTax> EditMoneyAsync(string username, MoneyTaxEditVM money, MoneyType type)
		{
			MoneyTax moneyEdit = new MoneyTax()
			{
				ID = money.ID,
				Name = money.Name,
				Description = money.Description,
				Amount = money.Amount,
				TimeAdded = money.TimeAdded,
				Type = type,
				User = await GetUser(username)
			};

			if (moneyEdit.User == null)
			{
				return null;
			}

			this._context.Entry(moneyEdit).State = EntityState.Modified;
			await this._context.SaveChangesAsync();

			return moneyEdit;
		}

		private async Task<User> GetUser(string username)
		{
			return await this._context.Users.FindAsync(username);
		}
	}
}
