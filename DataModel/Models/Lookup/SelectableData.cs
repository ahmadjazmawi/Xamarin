using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Models
{
    public class SelectableData
    {
        public SelectableData(String name, bool selected)
        {
            Name = name;
            Selected = selected;
        }

        public String Name { get; set; }
        public bool Selected { get; set; }
    }
}
