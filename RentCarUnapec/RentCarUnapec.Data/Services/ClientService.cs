using Microsoft.EntityFrameworkCore;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCarUnapec.Data.Services
{
    public class ClientService : IClientService
    {
        private readonly RentCarDbContext _dbContext;

        public ClientService(RentCarDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Client entity)
        {
            if (entity == null) return false;

            entity.CreationDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entity.Active = true;
            try
            {
                await _dbContext.AddAsync(entity);
                var result = await _dbContext.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
        }

        public async Task<bool> Delete(int? id)
        {
            if (id == null) return false;

            var entity = await GetSingleById(id.Value);
            entity.Active = false;
            return await Update(entity);
        }

        public async Task<List<Client>> GetAll()
        {
            return await _dbContext.Clients.Where(x => x.Active).ToListAsync();

        }

        public async Task<Client> GetSingleById(int id)
        {
            return await _dbContext.Clients.FindAsync(id);
        }

        public async Task<IList<Client>> GetClientsByNameIdentification(string name, string identification)
        {
            return await _dbContext.Clients.Where(x => x.Active &&
                                                       ((!string.IsNullOrEmpty(name) &&
                                                         (x.Name.ToUpper().Contains(name.ToUpper()))) ||
                                                        (!string.IsNullOrEmpty(identification) && x.IdentityNumber.Equals(identification))))
                .ToListAsync();

        }
        
        public bool ValidateCedula(string cedula)
        {
            var cedulaParts = new string[3];
            var municipio = string.Empty;
            var digitoVerificador = string.Empty;

            if (cedula.Length < 11)
            {
                return false;
            }

            cedulaParts[0] = cedula.Substring(0, 3);
            cedulaParts[1] = cedula.Substring(3, 7);
            cedulaParts[2] = cedula.Substring(10, 1);

            municipio = cedulaParts[0] + cedulaParts[1];
            digitoVerificador = cedulaParts[2];

            try
            {
                Convert.ToInt32(digitoVerificador);
            }
            catch (Exception)
            {
                return false;
            }

            var suma = 0;

            for (int i = 0; i < municipio.Length; i++)
            {
                var mod = "";

                if ((i % 2) == 0)
                    mod = "1";
                else
                    mod = "2";

                var val = string.Empty;

                try
                {
                    var a = municipio.Substring(i, 1);
                    Convert.ToInt32(a);
                    val = a;
                }
                catch (Exception)
                {
                    return false;
                }

                var res = Convert.ToInt32(Convert.ToInt32(val) * Convert.ToInt32(mod));

                if (res > 9)
                {
                    var res1 = res.ToString();
                    var uno = res1.Substring(0, 1);
                    var dos = res1.Substring(1, 1);
                    res = Convert.ToInt32(uno) + Convert.ToInt32(dos);
                }

                suma += res;
            }

            var elNumero = (10 - (suma % 10) % 10);

            if (elNumero == Convert.ToInt32(digitoVerificador) && cedulaParts[0] != "000")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(Client entity)
        {
            if (entity == null) return false;
            var entityToChange = await GetSingleById(entity.Id);
            if (entityToChange == null) return false;

            entityToChange.Name = entity.Name;
            entityToChange.IdentificationType = entity.IdentificationType;
            entityToChange.IdentityNumber = entity.IdentityNumber;
            entityToChange.CreditCardNumber = entity.CreditCardNumber;
            entityToChange.CreditLimit = entity.CreditLimit;
            entityToChange.UpdateDate = DateTime.Now;

            _dbContext.Clients.Update(entityToChange);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
