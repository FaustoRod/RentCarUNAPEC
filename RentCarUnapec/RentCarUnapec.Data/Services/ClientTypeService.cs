using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Data.Services
{
    public class ClientTypeService:IClientTypeService
    {
        private readonly RentCarDbContext _dbContext;

        public ClientTypeService(RentCarDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<bool> Create(ClientType entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(ClientType entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int? id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ClientType>> GetAll()
        {
            return await _dbContext.ClientTypes.Where(x => x.Active).ToListAsync();
        }

        public Task<ClientType> GetSingleById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}