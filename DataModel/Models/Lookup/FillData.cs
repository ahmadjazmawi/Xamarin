using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public static partial class Lookup
    {
        public static String FillListInString(ObservableCollection<SelectableData> List)
        {
            String ListToString = String.Empty;

            List.Where(x => x.Selected).ToList<SelectableData>().ForEach(x => ListToString = String.Format("{0}{1};", ListToString, x.Name));

            return ListToString;
        }

        public static void FillStringInList(ObservableCollection<SelectableData> List, String Value)
        {
            List.ToList<SelectableData>().ForEach(x => x.Selected = false);

            if (!String.IsNullOrEmpty(Value))
                List.Where(x => Value.Contains(x.Name)).ToList<SelectableData>().ForEach(x => x.Selected = true);
        }
    }
}
