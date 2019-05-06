using DataModel.DataStore;
using DataModel.Models.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SqliteWithTabbForm.ViewModels
{
    public partial class BaseViewModel
    {
        public IDataStore<MainTable> MainTableDataStore => DependencyService.Get<IDataStore<MainTable>>() ?? new SqliteDataStore<MainTable>();
    }
}
