using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Data.Services
{
    public class VehicleTypeService:IVehicleTypeService
    {
        private readonly RentCarDbContext _dbContext;

        public VehicleTypeService(RentCarDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(VehicleType entity)
        {
            if (entity == null) return false;

            entity.CreationDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entity.Active = true;

            await _dbContext.AddAsync(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;

        }

        public async Task<bool> Update(VehicleType entity)
        {
            if (entity == null) return false;
            var entityToChange = await GetSingleById(entity.Id);
            if (entityToChange == null) return false;
            entityToChange.Description = entity.Description;
            entityToChange.UpdateDate = DateTime.Now;
            _dbContext.VehicleTypes.Update(entityToChange);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
            
        }

        public async Task<List<VehicleType>> GetAll()
        {
            return await _dbContext.VehicleTypes.Where(x => x.Active).ToListAsync();
        }

        public async Task<VehicleType> GetSingleById(int id)
        {
            return await _dbContext.VehicleTypes.FindAsync(id);
        }

        public async Task<bool> Delete(int? id)
        {
            if (id == null) return false;

            var entity = await GetSingleById(id.Value);
            if (entity == null) return false;
            entity.Active = false;
            return await Update(entity);
        }
    }
}