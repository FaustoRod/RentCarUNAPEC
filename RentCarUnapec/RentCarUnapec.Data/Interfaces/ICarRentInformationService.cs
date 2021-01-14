using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentCarUnapec.Core.Enums;
using RentCarUnapec.Core.Models;

namespace RentCarUnapec.Data.Interfaces
{
    public interface ICarRentInformationService:IServiceBase<CarRentInformation>
    {
        Task<List<CarRentInformation>> GetByState(RentStateEnum state);
        Task<bool> ChangeState(int carRentId,RentStateEnum state);
        Task<List<CarRentInformation>> GetAllNotCanceled();
        Task<List<CarRentInformation>> SearchRecords(int manufacturerId,int modelId,int stateId);
        Task<List<CarRentInformation>> SearchRecords(int manufacturerId,int modelId,int stateId,
            int clientId,DateTime fromDate,DateTime toDate);
    }
}
