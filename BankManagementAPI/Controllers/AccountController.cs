using BankManagementAPI.DTOs;
using BankManagementAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Authorize(Roles = "bankstaff")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateAccount(AccountDto accountDto)
        {
            try
            {
                var result = await _accountService.CreateAccountAsync(accountDto);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccount(int id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);
            return Ok(account);
        }
    }
}
