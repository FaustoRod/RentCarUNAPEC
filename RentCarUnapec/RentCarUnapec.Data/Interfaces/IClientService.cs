using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentCarUnapec.Core.Enums;
using RentCarUnapec.Core.Models;

namespace RentCarUnapec.Data.Interfaces
{
    public interface IClientService:IServiceBase<Client>
    {
        Task<IList<Client>> GetClientsByNameIdentification(string name, string identification);
        bool ValidateCedula(string cedula);
    }
}
