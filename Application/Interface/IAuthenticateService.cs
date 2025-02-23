
using Persistences.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IAuthenticateService
    {
        public Task<SystemAccount> LoginUser(SystemAccount dto);
    }
}
