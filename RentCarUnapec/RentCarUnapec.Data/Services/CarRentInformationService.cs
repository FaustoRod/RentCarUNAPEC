using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentCarUnapec.Core.Enums;

namespace RentCarUnapec.Data.Services
{
    public class CarRentInformationService : ICarRentInformationService
    {
        private readonly RentCarDbContext _dbContext;
        private readonly IVehicleService _vehicleService;

        public CarRentInformationService(RentCarDbContext dbContext,IVehicleService vehicleService)
        {
            _dbContext = dbContext;
            _vehicleService = vehicleService;
        }

        public async Task<bool> Create(CarRentInformation entity)
        {
            if (entity == null) return false;
            entity.RentSequence = Guid.NewGuid().ToString().ToUpper();
            entity.RentStateId = (int)RentStateEnum.CheckWaiting;
            entity.CreationDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entity.Active = true;

            await using var contextTransaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                await _dbContext.CarRentInformation.AddAsync(entity);
                var result = await _dbContext.SaveChangesAsync();
                if (result > 0)
                {
                    var resultVehicle = await _vehicleService.UpdateState(entity.VehicleId, VehicleStateEnum.EsperaCheck);
                    if (resultVehicle)
                    {
                        await contextTransaction.CommitAsync();
                        return true;
                    }

                    await contextTransaction.RollbackAsync();
                }
            }
            catch (Exception e)
            {
                await contextTransaction.RollbackAsync();
                return false;
            }

            return true;
        }

        public Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CarRentInformation>> GetAll() =>
            await _dbContext.CarRentInformation
                .Include(c => c.RentState)
                .Include(c => c.Client)
                .Include(c => c.Vehicle)
                    .ThenInclude(v => v.Model)
                        .ThenInclude(m => m.Manufacturer)
                .Where(x => x.Active).ToListAsync();

        public async Task<CarRentInformation> GetSingleById(int id) => await _dbContext.CarRentInformation
            .Include(c => c.RentState)
            .Include(c => c.Client)
            .Include(c => c.Employee)
            .Include(c => c.Vehicle)
                .ThenInclude(v => v.Model)
                    .ThenInclude(m => m.Manufacturer)
            .SingleOrDefaultAsync(x => x.Id.Equals(id));

        public async Task<List<CarRentInformation>> GetByState(RentStateEnum state) =>
            await _dbContext.CarRentInformation
                .Include(c => c.Client)
                .Include(c => c.Vehicle)
                .ThenInclude(v => v.Model)
                .ThenInclude(m => m.Manufacturer)
                .Where(x => x.RentStateId == (int)state).ToListAsync();

        public async Task<bool> ChangeState(int carRentId, RentStateEnum state)
        {
            var carRent = await GetSingleById(carRentId);
            if (carRent == null) return false;
            if (carRent.RentStateId == (int)RentStateEnum.CheckComplete && state == RentStateEnum.Canceled)
            {
                var vehicleCheckService = new VehicleCheckService(_dbContext,this);
                await vehicleCheckService.Delete(carRentId);

            }
            carRent.RentStateId = (int)state;
            return await Update(carRent);
        }
        
        public async Task<List<CarRentInformation>> GetAllNotCanceled() =>
            await _dbContext.CarRentInformation
                .Include(c => c.RentState)
                .Include(c => c.Client)
                .Include(c => c.Vehicle)
                .ThenInclude(v => v.Model)
                .ThenInclude(m => m.Manufacturer)
                .Where(x => x.RentStateId != (int)RentStateEnum.Canceled).ToListAsync();

        public async Task<List<CarRentInformation>> SearchRecords(int manufacturerId, int modelId, int stateId)
        {
            if (manufacturerId.Equals(0))
            {
                return await _dbContext.CarRentInformation
                    .Include(c => c.RentState)
                    .Include(c => c.Client)
                    .Include(c => c.Vehicle)
                    .ThenInclude(v => v.Model)
                    .ThenInclude(m => m.Manufacturer)
                    .Where(x => x.Active && (stateId == 0 || x.RentStateId.Equals(stateId))).ToListAsync();
            }

            return await _dbContext.CarRentInformation
                .Include(c => c.RentState)
                .Include(c => c.Client)
                .Include(c => c.Vehicle)
                .ThenInclude(v => v.Model)
                .ThenInclude(m => m.Manufacturer)
                .Where(x => x.Active && (modelId > 0 ? x.Vehicle.ModelId.Equals(modelId) : x.Vehicle.Model.ManufacturerId.Equals(manufacturerId))
                                     && (stateId == 0 || x.RentStateId.Equals(stateId))).ToListAsync();
        }

        public async Task<List<CarRentInformation>> SearchRecords(int manufacturerId, int modelId, int stateId, int clientId, DateTime fromDate, DateTime toDate)
        {
            if (manufacturerId.Equals(0))
            {
                return await _dbContext.CarRentInformation
                    .Include(c => c.RentState)
                    .Include(c => c.Client)
                    .Include(c => c.Vehicle)
                    .ThenInclude(v => v.Model)
                    .ThenInclude(m => m.Manufacturer)
                    .Where(x => x.Active && (!x.RentStateId.Equals((int)RentStateEnum.Canceled)) 
                    && (clientId.Equals(0) || x.ClientId.Equals(clientId))
                    && (stateId.Equals(0) || x.Vehicle.VehicleTypeId.Equals(stateId))
                    && (x.RentDay >= fromDate && x.RentDay <= toDate)).ToListAsync();
            }

            return await _dbContext.CarRentInformation
                .Include(c => c.RentState)
                .Include(c => c.Client)
                .Include(c => c.Vehicle)
                .ThenInclude(v => v.Model)
                .ThenInclude(m => m.Manufacturer)
                .Where(x => x.Active && (modelId > 0
                                         ? x.Vehicle.ModelId.Equals(modelId)
                                         : x.Vehicle.Model.ManufacturerId.Equals(manufacturerId))
                                     && (!x.RentStateId.Equals((int)RentStateEnum.Canceled))
                                     && (clientId.Equals(0) || x.ClientId.Equals(clientId))
                                     && (stateId.Equals(0) || x.Vehicle.VehicleTypeId.Equals(stateId))
                                     && (x.RentDay >= fromDate && x.RentDay <= toDate)).ToListAsync();
        }

        public async Task<bool> Update(CarRentInformation entity)
        {
            if (entity == null) return false;

            var entityUpdate = await GetSingleById(entity.Id);
            if (entityUpdate == null) return false;

            entityUpdate.RentStateId = entity.RentStateId;
            entityUpdate.AmountPerDay = entity.AmountPerDay;
            entityUpdate.ClientId = entity.ClientId;
            entityUpdate.Comment = entity.Comment;
            entityUpdate.RentDays = entity.RentDays;
            entityUpdate.ReturnDay = entity.ReturnDay;
            entityUpdate.UpdateDate = DateTime.Now;
            entityUpdate.Active = entity.Active;

            using (var contextTransaction = await _dbContext.Database.BeginTransactionAsync())
            {
                _dbContext.CarRentInformation.Update(entityUpdate);

                try
                {
                    var result = await _dbContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        var vehicleResult =(RentStateEnum) entity.RentStateId switch
                        {
                            RentStateEnum.CheckWaiting => await _vehicleService.UpdateState(entity.VehicleId,
                                VehicleStateEnum.EsperaCheck),

                            RentStateEnum.Active => await _vehicleService.UpdateState(entity.VehicleId,
                                VehicleStateEnum.Rentado),

                            RentStateEnum.Canceled => await _vehicleService.UpdateState(entity.VehicleId,
                                VehicleStateEnum.Disponible),

                            RentStateEnum.Delivered => await _vehicleService.UpdateState(entity.VehicleId,
                                VehicleStateEnum.Disponible),

                            RentStateEnum.WaitingDelivery => await _vehicleService.UpdateState(entity.VehicleId,
                                VehicleStateEnum.EnEsperaEntrega),

                            RentStateEnum.CheckComplete => await _vehicleService.UpdateState(entity.VehicleId,
                                VehicleStateEnum.Chequeado),
                            _ => true
                        };

                        if (!vehicleResult)
                        {
                            await contextTransaction.RollbackAsync();
                        }
                    }
                    await contextTransaction.CommitAsync();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    await contextTransaction.RollbackAsync();
                    return false;
                }
                
                return true;
            }
            
        }

    }
}
