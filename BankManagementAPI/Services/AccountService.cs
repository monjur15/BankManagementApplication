using BankManagementAPI.Data;
using BankManagementAPI.DTOs;
using BankManagementAPI.Models;

namespace BankManagementAPI.Services
{
    public interface IAccountService
    {
        Task<AccountDto> CreateAccountAsync(AccountDto accountDto);
        Task<AccountDto> GetAccountByIdAsync(int id);
    }
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;

        public AccountService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AccountDto> CreateAccountAsync(AccountDto accountDto)
        {
            var account = new Account
            {
                AccountNumber = accountDto.AccountNumber,
                Balance = accountDto.Balance,
                UserId = accountDto.UserId
            };

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return accountDto;
        }

        public async Task<AccountDto> GetAccountByIdAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            return account == null ? null : new AccountDto
            {
                AccountNumber = account.AccountNumber,
                Balance = account.Balance,
                UserId = account.UserId
            };
        }
    }
}
