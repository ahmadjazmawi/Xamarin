using DataModel.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteWithTabbForm.ViewModels
{
    public partial class ItemsViewModel
    {
        async Task AddAndUpdateItem(ItemDetailViewModel itemViewModel)
        {
            await itemViewModel.RefreshItemLookups();

            var TempItem = itemViewModel.Item as MainTable;

            bool IsNew = false;
            if (TempItem.ID == 0)
            {
                IsNew = true;
            }

            await MainTableDataStore.AddAndUpdateItemAsync(TempItem);

            if (IsNew)
                Items.Add(TempItem);
            else
            {
                MainTable Item = Items.Where(x => x.ID == TempItem.ID).First();

                Item = TempItem;
            }
        }
    }
}
