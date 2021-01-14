using Microsoft.EntityFrameworkCore;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCarUnapec.Data.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly RentCarDbContext _dbContext;

        public EmployeeService(RentCarDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Employee entity)
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

        public async Task<List<Employee>> GetAll()
        {
            return await _dbContext.Employees.Where(x => x.Active).ToListAsync();

        }

        public async Task<Employee> GetSingleById(int id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        public async Task<bool> Update(Employee entity)
        {
            if (entity == null) return false;
            var entityToChange = await GetSingleById(entity.Id);
            if (entityToChange == null) return false;

            entityToChange.Name = entity.Name;
            entityToChange.LastName = entity.LastName;
            entityToChange.ShiftTypeId = entity.ShiftTypeId;
            entityToChange.IdentityNumber = entity.IdentityNumber;
            entityToChange.BaseSalary = entity.BaseSalary;
            entityToChange.Commission = entity.Commission;
            entityToChange.UpdateDate = DateTime.Now;

            _dbContext.Employees.Update(entityToChange);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
