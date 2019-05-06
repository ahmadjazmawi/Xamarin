using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DataModel.Models
{
    public static partial class Lookup
    {
        public static ObservableCollection<SelectableData> Interests = new ObservableCollection<SelectableData>
        {
            new SelectableData("Cycling", false),
            new SelectableData("Running", false)
        };
    }
}
