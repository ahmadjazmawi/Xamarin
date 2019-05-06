using System;
using DataModel.Models;
using DataModel.Models.Tables;
using SqliteWithTabbForm.Models;

namespace SqliteWithTabbForm.ViewModels
{
    public partial class ItemDetailViewModel : BaseViewModel
    {
        public MainTable Item { get; set; }
        public ItemDetailViewModel(MainTable item = null)
        {
            Item = item;

            Lookup.FillStringInList(Interests, Item.Interests);
        }
    }
}
