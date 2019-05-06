using DataModel.Models;
using SqliteWithTabbForm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteWithTabbForm.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemInterestPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemInterestPage()
        {
            InitializeComponent();
        }

        public ItemInterestPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            Title = "Intreset";

            BindingContext = this.viewModel = viewModel;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddAndUpdateItem", viewModel);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        //private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var item = (SelectableData)e.SelectedItem;

        //    // now you can reference item.Name, item.Location, etc
        //    item.Selected = !item.Selected;
        //}

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;

            // Deselect the item.
            if (sender is ListView lv) lv.SelectedItem = null;
        }
    }
}