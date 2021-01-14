using RentCarUnapec.Core.Enums;
using RentCarUnapec.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentCarUnapec.Data.Interfaces
{
    public interface IVehicleService:IServiceBase<Vehicle>
    {
        Task<List<Vehicle>> GetListByState(VehicleStateEnum state);
        Task<List<Vehicle>> GetListByModel(int modelId);
        Task<List<Vehicle>> GetListByManufacturer(int manufacturerId);
        Task<bool> UpdateState(int vehicleId, VehicleStateEnum state);
    }
}
