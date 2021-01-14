using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Data.Services
{
    public class IdentificationTypeService:IIdentificationTypeService
    {
        private readonly RentCarDbContext _dbContext;

        public IdentificationTypeService(RentCarDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<bool> Create(IdentificationType entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(IdentificationType entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<IdentificationType>> GetAll()
        {
            return await _dbContext.IdentificationTypes.ToListAsync();
        }

        public Task<IdentificationType> GetSingleById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}