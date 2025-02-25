using Application.Interface;
using Persistences.Entities;
using Persistences.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly ISystemAccount _systemAccount;
        public AccountService(ISystemAccount systemAccount)
        {
            _systemAccount = systemAccount;
        }
        public async Task<SystemAccount?> GetAccountByIdAsync(short id)
        {
            return await _systemAccount.GetBySingleAsync(u => u.AccountId==id);
        }

        public async Task UpdateAccount(SystemAccount account)
        {
            var data = await _systemAccount.GetBySingleAsync(a => a.AccountId==account.AccountId);
            data.AccountName = account.AccountName;
            data.AccountPassword = account.AccountPassword;
            _systemAccount.Update(data);
            await _systemAccount.SaveChangeAsync();
        }
    }
}
