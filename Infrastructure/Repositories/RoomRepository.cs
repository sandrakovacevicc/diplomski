﻿using Core.Entities;
using Core.Interfaces;
using FitnessSystem.Data;
using FitnessSystem.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessSystem.Infrastructure.Repositories
{
    public class RoomRepository : Repository<Room>,IRoomRepository
    {
        public RoomRepository(AppDbContext dbContext) : base(dbContext)
        {
        }


        public async Task<Room> DeleteAsync(int id)
        {
            var room = await _dbContext.Rooms.FindAsync(id);
            if (room == null)
            {
                return null;
            }

            _dbContext.Rooms.Remove(room);
            await _dbContext.SaveChangesAsync();

            return room;
        }

        public async Task<Room?> GetByIdAsync(int id)
        {
            return await _dbContext.Rooms.FirstOrDefaultAsync(r => r.RoomId == id);
        }
    }
}
