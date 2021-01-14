using System.Collections.Generic;
using System.Threading.Tasks;
using RentCarUnapec.Core.Models;

namespace RentCarUnapec.Data.Interfaces
{
    public interface IManufacturerService:IServiceBase<Manufacturer>
    {
        Task<List<Manufacturer>> GetAllWithModels();
    }
}
