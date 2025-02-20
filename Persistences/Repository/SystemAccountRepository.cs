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
    }
}
