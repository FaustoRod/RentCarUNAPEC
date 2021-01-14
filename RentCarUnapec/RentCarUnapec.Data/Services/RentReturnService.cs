using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentCarUnapec.Core.Enums;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Data.Services
{
    public class RentReturnService : IRentReturnService
    {
        private readonly RentCarDbContext _rentCarDbContext;
        private readonly ICarRentInformationService _carRentInformationService;

        public RentReturnService(RentCarDbContext rentCarDbContext,
            ICarRentInformationService carRentInformationService)
        {
            _rentCarDbContext = rentCarDbContext;
            _carRentInformationService = carRentInformationService;
        }

        public async Task<bool> Create(RentReturn entity)
        {
            if (entity == null) return false;

            entity.Active = true;
            entity.CreationDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            
            try
            {
                await _rentCarDbContext.RentReturns.AddAsync(entity);
                var result = await _rentCarDbContext.SaveChangesAsync();
                if (result > 0)
                {
                    var carRent =
                        await _carRentInformationService.ChangeState(entity.CarRentInformationId, RentStateEnum.Delivered);
                    return carRent;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public Task<bool> Update(RentReturn entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<RentReturn>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<RentReturn> GetSingleById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}