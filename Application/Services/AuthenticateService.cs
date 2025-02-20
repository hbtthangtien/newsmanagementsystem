using Application.Interface;
using Microsoft.AspNetCore.Http;
using Persistences.Entities;
using Persistences.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly ISystemAccount _systemAccount;
        public AuthenticateService(ISystemAccount systemAccount)
        {
            _systemAccount = systemAccount;
        }
        public Task<bool> LoginUser(SystemAccount dto)
        {
            throw new NotImplementedException();
        }
    }
}
