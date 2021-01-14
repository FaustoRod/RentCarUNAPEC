using RentCarUnapec.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentCarUnapec.Data.Interfaces
{
    public interface IModelService:IServiceBase<Model>
    {
        Task<List<Model>> GetModelByManufacturer(int manufacturerId); 
    }
}
