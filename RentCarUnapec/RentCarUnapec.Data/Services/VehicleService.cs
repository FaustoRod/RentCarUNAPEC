using Microsoft.EntityFrameworkCore;
using RentCarUnapec.Core.Enums;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCarUnapec.Data.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly RentCarDbContext _dbContext;

        public VehicleService(RentCarDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Vehicle entity)
        {
            if (entity == null) return false;

            entity.VehicleStateId = (int)VehicleStateEnum.Disponible;
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

        public async Task<List<Vehicle>> GetAll()
        {
            return await _dbContext.Vehicles
                .Include(v => v.Model)
                    .ThenInclude(m => m.Manufacturer)
                .Include(v => v.Color)
                .Include(v => v.VehicleType)
                .Where(x => x.Active).ToListAsync();

        }

        public async Task<List<Vehicle>> GetListByState(VehicleStateEnum state)
        {
            return await _dbContext.Vehicles.Include(v => v.Model).ThenInclude(m => m.Manufacturer).Where(x => x.Active && x.VehicleStateId.Equals((int)state)).ToListAsync();
        }

        public async Task<List<Vehicle>> GetListByModel(int modelId)
        {
            try
            {
                return await _dbContext.Vehicles.Include(v => v.Model)
                    .ThenInclude(m => m.Manufacturer)
                    .Include(v => v.Color)
                    .Include(v => v.VehicleType)
                    .Where(x => x.Active && x.ModelId.Equals(modelId) && x.VehicleStateId == (int)VehicleStateEnum.Disponible).ToListAsync();
            }
            catch (Exception e)
            {
                return new List<Vehicle>();
            }

        }

        public async Task<List<Vehicle>> GetListByManufacturer(int manufacturerId)
        {
            return await _dbContext.Vehicles.Include(v => v.Model)
                .ThenInclude(m => m.Manufacturer)
                .Include(v => v.Color)
                .Include(v => v.VehicleType)
                .Where(x => x.Active && x.Model.ManufacturerId.Equals(manufacturerId) && x.VehicleStateId == (int)VehicleStateEnum.Disponible).ToListAsync();
        }

        public async Task<bool> UpdateState(int vehicleId, VehicleStateEnum state)
        {
            var vehicle = await GetSingleById(vehicleId);
            if (vehicle == null) return false;
            vehicle.VehicleStateId = (int) state;
            return await Update(vehicle);
        }

        public async Task<Vehicle> GetSingleById(int id)
        {
            return await _dbContext.Vehicles
                .Include(v => v.Model).ThenInclude(m => m.Manufacturer)
                .Include(v => v.Color)
                .Include(v => v.VehicleType)
                .Include(v=> v.TransmissionType)
                .Include(v => v.FuelType).SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<bool> Update(Vehicle entity)
        {
            if (entity == null) return false;
            var entityToChange = await GetSingleById(entity.Id);
            if (entityToChange == null) return false;

            entityToChange.ChassisNumber = entity.ChassisNumber;
            entityToChange.ColorId = entity.ColorId;
            entityToChange.EngineNumber = entity.EngineNumber;
            entityToChange.FuelTypeId = entity.FuelTypeId;
            entityToChange.PlateNumber = entity.PlateNumber;
            entityToChange.TransmissionTypeId = entity.TransmissionTypeId;
            entityToChange.VehicleTypeId = entity.VehicleTypeId;
            entityToChange.ModelId = entity.ModelId;

            entityToChange.UpdateDate = DateTime.Now;

            _dbContext.Vehicles.Update(entityToChange);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
