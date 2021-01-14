using Microsoft.EntityFrameworkCore;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCarUnapec.Data.Services
{
    public class VehicleColorService : IVehicleColorService
    {
        private readonly RentCarDbContext _dbContext;

        public VehicleColorService(RentCarDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(VehicleColor entity)
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

        public async Task<List<VehicleColor>> GetAll()
        {
            return await _dbContext.VehicleColors.Where(x => x.Active).ToListAsync();

        }

        public async Task<VehicleColor> GetSingleById(int id)
        {
            return await _dbContext.VehicleColors.FindAsync(id);
        }

        public async Task<bool> Update(VehicleColor entity)
        {
            if (entity == null) return false;
            var entityToChange = await GetSingleById(entity.Id);
            if (entityToChange == null) return false;
            entityToChange.Description = entity.Description;
            entityToChange.UpdateDate = DateTime.Now;
            _dbContext.VehicleColors.Update(entityToChange);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
