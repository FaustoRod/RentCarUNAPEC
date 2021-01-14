using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentCarUnapec.Data.Interfaces
{
    public interface IServiceBase<T>
    {
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int? id);
        Task<List<T>> GetAll();
        Task<T> GetSingleById(int id);

    }
}