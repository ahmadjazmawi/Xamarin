using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DataStore
{
    public interface IDataStore<T>
    {
        Task<bool> AddAndUpdateItemAsync(T item);
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(int id);
        Task<T> GetItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        Task DeleteAllItemsAsync(bool forceRefresh = false);
    }
}
