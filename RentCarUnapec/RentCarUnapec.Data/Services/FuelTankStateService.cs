using Microsoft.EntityFrameworkCore;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCarUnapec.Data.Services
{
    public class FuelTankStateService : IFuelTankStateService
    {
        private readonly RentCarDbContext _dbContext;

        public FuelTankStateService(RentCarDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(FuelTankState entity)
        {
            if (entity == null) return false;

            entity.CreationDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entity.Active = true;

            await _dbContext.AddAsync(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Delete(int? id)
        {
            if (id == null) return false;

            var entity = await GetSingleById(id.Value);
            entity.Active = false;
            return await Update(entity);
        }

        public async Task<List<FuelTankState>> GetAll()
        {
            return await _dbContext.FuelTankStates.Where(x => x.Active).ToListAsync();

        }

        public async Task<FuelTankState> GetSingleById(int id)
        {
            return await _dbContext.FuelTankStates.FindAsync(id);
        }

        public async Task<bool> Update(FuelTankState entity)
        {
            if (entity == null) return false;
            var entityToChange = await GetSingleById(entity.Id);
            if (entityToChange == null) return false;
            entityToChange.Description = entity.Description;
            entityToChange.UpdateDate = DateTime.Now;
            _dbContext.FuelTankStates.Update(entityToChange);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
