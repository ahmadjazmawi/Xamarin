using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SqliteWithTabbForm.ViewModels
{
    public partial class ItemDetailViewModel
    {
        public ObservableCollection<SelectableData> Interests => Lookup.Interests;
    }
}
