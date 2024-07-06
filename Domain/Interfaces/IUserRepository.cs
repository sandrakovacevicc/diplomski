﻿using Core.Entities;
using FitnessSystem.Core.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByIdAsync(string JMBG);
        Task<User> DeleteAsync(string JMBG);    
    }
}
