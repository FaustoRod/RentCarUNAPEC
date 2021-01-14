using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Data.Services
{
    public class RentStateService:IRentStateService
    {
        private readonly RentCarDbContext _dbContext;

        public RentStateService(RentCarDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<bool> Create(RentState entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(RentState entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<RentState>> GetAll()
        {
            return await _dbContext.RentStates.ToListAsync();
        }

        public Task<RentState> GetSingleById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}