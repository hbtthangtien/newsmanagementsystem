using Microsoft.EntityFrameworkCore;
using Persistences.Entities;
using Persistences.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistences.Repository
{
    public class SystemAccountRepository : GenericRepository<SystemAccount>, ISystemAccount
    {
        public SystemAccountRepository(FunewsManagementContext funewsManagementContext) : base(funewsManagementContext)
        {
        }

        public SystemAccount Login(SystemAccount account)
        {
            throw new NotImplementedException();
        }

        public async Task<SystemAccount?> LoginSystem(SystemAccount account)
        {
            var user =await _context.SystemAccounts.SingleOrDefaultAsync(a => a.AccountEmail == account.AccountEmail
                && a.AccountPassword == account.AccountPassword);
            return user;
        }
    }
}
