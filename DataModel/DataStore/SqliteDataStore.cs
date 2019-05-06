using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DataStore
{
    public class SqliteDataStore<T> : IDataStore<T> where T : Models.Contracts.IBusinessEntity, new()
    {
        public SqliteDataStore()
        {
        }

        public async Task<bool> AddAndUpdateItemAsync(T item)
        {
            DAL.Repository.Database.SaveItem<T>(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> AddItemAsync(T item)
        {
            DAL.Repository.Database.SaveItem<T>(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(T item)
        {
            DAL.Repository.Database.SaveItem<T>(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            DAL.Repository.Database.DeleteItem<T>(id);

            return await Task.FromResult(true);
        }

        public async Task<T> GetItemAsync(int id)
        {
            return await Task.FromResult(DAL.Repository.Database.GetItem<T>(id));
        }

        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(new List<T>(DAL.Repository.Database.GetItems<T>()));
        }

        public async Task DeleteAllItemsAsync(bool forceRefresh = false)
        {
            await Task.FromResult(DAL.Repository.Database.DeleteAll<T>());
        }
    }
}
