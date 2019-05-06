using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using SqliteWithTabbForm.Models;
using SqliteWithTabbForm.Views;
using DataModel.Models.Tables;

namespace SqliteWithTabbForm.ViewModels
{
    public partial class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<MainTable> Items { get; set; }

        public ItemsViewModel() : base()
        {
            Title = "Items";

            Items = new ObservableCollection<MainTable>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            SubscribeAddAndUpdateMethod();
        }
    }
}