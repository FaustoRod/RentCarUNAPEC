using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentCarUnapec.Core.Enums;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Data.Services
{
    public class VehicleCheckService : IVehicleCheckService
    {
        private readonly RentCarDbContext _dbContext;
        private readonly ICarRentInformationService _carRentInformationService;

        public VehicleCheckService(RentCarDbContext dbContext,ICarRentInformationService carRentInformationService)
        {
            _dbContext = dbContext;
            _carRentInformationService = carRentInformationService;
        }

        public async Task<bool> Create(VehicleCheck entity)
        {
            if (entity == null) return false;

            entity.Active = true;
            entity.CreationDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;

            try
            {
                await _dbContext.VehicleChecks.AddAsync(entity);
                var result = await _dbContext.SaveChangesAsync();
                if (result > 0)
                {
                    return await _carRentInformationService.ChangeState(entity.CarRentInformationId,
                        RentStateEnum.Active);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return false;
        }

        public async Task<bool> Update(VehicleCheck entity)
        {
            if (entity == null) return false;
            var entityToUpdate = await GetSingleById(entity.Id);
            entityToUpdate.FuelTankId = entity.FuelTankId;
            entityToUpdate.HasBrokenWind = entity.HasBrokenWind;
            entityToUpdate.HasJackScrew = entity.HasJackScrew;
            entityToUpdate.HasScratch = entity.HasScratch;
            entityToUpdate.HasSpare = entity.HasSpare;
            entityToUpdate.LeftBottomTire = entity.LeftBottomTire;
            entityToUpdate.LeftUpperTire = entity.LeftUpperTire;
            entityToUpdate.RightBottomTire = entity.RightBottomTire;
            entityToUpdate.RightUpperTire = entity.RightUpperTire;
            entityToUpdate.UpdateDate = DateTime.Now;

            _dbContext.VehicleChecks.Update(entityToUpdate);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Delete(int? id)
        {
            if (id == null) return false;
            _dbContext.VehicleChecks.Remove(await GetSingleById(id.Value));
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<VehicleCheck>> GetAll() => await _dbContext.VehicleChecks.Include(vc => vc.CarRentInformation)
            .ThenInclude(c => c.Vehicle)
                .ThenInclude(v => v.Model)
                    .ThenInclude(m => m.Manufacturer)
            .Include(vc => vc.CarRentInformation)
                .ThenInclude(cli => cli.Client)
            .Where(x => x.Active && x.CarRentInformation.RentStateId != (int)RentStateEnum.Canceled).ToListAsync();
        
        public async Task<VehicleCheck> GetSingleById(int id) =>
            await _dbContext.VehicleChecks.Include(vc => vc.CarRentInformation)
                .ThenInclude(c => c.Vehicle)
                .ThenInclude(v => v.Model)
                .ThenInclude(m => m.Manufacturer)
                .Include(vc => vc.CarRentInformation)
                .ThenInclude(cli => cli.Client)
                .Include(vc => vc.FuelTank)
                .Where(x => x.Active && x.Id.Equals(id)).SingleOrDefaultAsync();

    }
}