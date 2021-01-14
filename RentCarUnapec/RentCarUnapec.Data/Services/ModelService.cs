﻿using Microsoft.EntityFrameworkCore;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCarUnapec.Data.Services
{
    public class ModelService : IModelService
    {
        private readonly RentCarDbContext _dbContext;

        public ModelService(RentCarDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Model entity)
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

        public async Task<List<Model>> GetAll()
        {
            return await _dbContext.Models.Include(x => x.Manufacturer).Where(x => x.Active).ToListAsync();

        }

        public async Task<List<Model>> GetModelByManufacturer(int manufacturerId)
        {
            return await _dbContext.Models.Include(x => x.Manufacturer).Where(x => x.Active && (manufacturerId > 0 && x.ManufacturerId.Equals(manufacturerId))).ToListAsync();

        }

        public async Task<Model> GetSingleById(int id)
        {
            return await _dbContext.Models.Include(x => x.Manufacturer).SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<bool> Update(Model entity)
        {
            if (entity == null) return false;
            var entityToChange = await GetSingleById(entity.Id);
            if (entityToChange == null) return false;

            entityToChange.ManufacturerId = entity.ManufacturerId;
            entityToChange.Description = entity.Description;
            entityToChange.UpdateDate = DateTime.Now;

            _dbContext.Models.Update(entityToChange);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
