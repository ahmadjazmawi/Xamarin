using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility.Logs;
using Xamarin.Forms;

namespace SqliteWithTabbForm.ViewModels
{
    public partial class ItemsViewModel
    {
        bool LoadItemsIsBusy = false;

        public Command LoadItemsCommand { get; set; }

        async Task ExecuteLoadItemsCommand()
        {
            if (LoadItemsIsBusy)
                return;

            LoadItemsIsBusy = true;

            try
            {

                Items.Clear();
                var items = await MainTableDataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                LogsHandler.WriteException(ex);
            }
            finally
            {
                LoadItemsIsBusy = false;
            }
        }
    }
}
