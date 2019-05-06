using System;
using System.Collections.Generic;
using System.Text;

namespace SqliteWithTabbForm.ViewModels
{
    public partial class BaseViewModel
    {
        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}
