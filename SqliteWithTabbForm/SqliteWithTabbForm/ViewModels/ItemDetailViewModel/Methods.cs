using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SqliteWithTabbForm.ViewModels
{
    public partial class ItemDetailViewModel
    {
        public async Task RefreshItemLookups()
        {
            Item.Interests = await Task.FromResult(Lookup.FillListInString(Interests));
        }
    }
}
