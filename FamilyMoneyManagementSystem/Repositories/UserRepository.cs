using FamilyMoneyManagementSystem.Data;
using FamilyMoneyManagementSystem.Models;
using FamilyMoneyManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FamilyMoneyManagementSystem.Repositories
{
	public class UserRepository
	{
		private readonly MoneySystemDbContext _context;
		private readonly HttpContext _httpContext;

		public UserRepository(MoneySystemDbContext context, IHttpContextAccessor httpContextAccessor)
		{
			this._context = context;
			this._httpContext = httpContextAccessor.HttpContext;
		}

		public async Task<User> GetUser(string username)
		{
			return await this._context.Users.FindAsync(username);
		}

		public string GetUsername()
		{
			return this._httpContext.User.FindFirst("Username")?.Value;
		}

		public async Task<User> RegistrationAsync(UserRegistrationVM userRegistration)
		{
			bool usernameExists = await CheckIfUsernameExistsAsync(userRegistration.Username);

			if (usernameExists)
			{
				return GetUserWithoutUsername(userRegistration);
			}

			return await AddUserAsync(userRegistration);
		}

		public async Task<User> LoginAsync(UserLoginVM userLogin)
		{
			User user = await GetUserFromLoginAsync(userLogin.Username, userLogin.Password);

			if (user != null)
			{
				return user;
			}

			return null;
		}

		public async Task LogoutAsync()
		{
			await this._httpContext.SignOutAsync();
		}

		public async Task GenerateUserClaimsAsync(string username, string firstName)
		{
			var claims = new List<Claim>
			{
				new Claim("Username", username),
				new Claim(ClaimTypes.Name, firstName)
			};

			var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			var principal = new ClaimsPrincipal(identity);
			var properties = new AuthenticationProperties();

			await this._httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, properties);
		}

		private async Task<User> AddUserAsync(UserRegistrationVM user)
		{
			User newUser = new User()
			{
				Username = user.Username,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Age = user.Age,
				Password = user.Password
			};

			await this._context.Users.AddAsync(newUser);
			await this._context.SaveChangesAsync();

			return newUser;
		}

		private async Task<bool> CheckIfUsernameExistsAsync(string username)
		{
			return await this._context.Users.AnyAsync(u => u.Username == username);
		}

		private async Task<User> GetUserFromLoginAsync(string username, string password)
		{
			return await this._context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
		}

		private User GetUserWithoutUsername(UserRegistrationVM user)
		{
			return new User()
			{
				Username = null,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Age = user.Age,
				Password = user.Password
			};
		}
	}
}
