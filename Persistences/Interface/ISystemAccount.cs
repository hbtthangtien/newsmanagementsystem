﻿using Persistences.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistences.Interface
{
    public interface ISystemAccount : IGenericRepository<SystemAccount>
    {
        public Task<SystemAccount> LoginSystem(SystemAccount account);
    }
}
