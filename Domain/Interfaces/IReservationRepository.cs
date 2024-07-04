﻿using Core.Entities;
using FitnessSystem.Core.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        Task<Reservation> GetByIdAsync(int id);
        Task<Reservation> CreateAsync(Reservation reservation);
        Task<Reservation> DeleteAsync(int id);
    }
}
