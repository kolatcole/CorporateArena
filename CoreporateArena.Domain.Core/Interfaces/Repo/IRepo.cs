using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public interface IRepo<T>
    {
        Task<int> insertAsync(T data);
        Task<int> insertListAsync(List<T> data);
        Task<int> deleteAsync(T data);
        Task<int> updateAsync(T data);
        Task<T> getAsync(int ID);
        Task<List<T>> getAllAsync();
    }
}
