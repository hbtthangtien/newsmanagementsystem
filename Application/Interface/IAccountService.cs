using Persistences.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IAccountService
    {
        public Task<SystemAccount> GetAccountByIdAsync(short id);

        public Task UpdateAccount(SystemAccount account);

        public Task<IEnumerable> GetAllAccountAsync();

        public Task UpdateAccountAdmin(SystemAccount account);

        public Task AddAccountAsync(SystemAccount account);
    }
}
