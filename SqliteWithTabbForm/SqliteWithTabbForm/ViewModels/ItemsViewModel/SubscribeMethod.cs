using SqliteWithTabbForm.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SqliteWithTabbForm.ViewModels
{
    public partial class ItemsViewModel
    {
        void SubscribeAddAndUpdateMethod()
        {
            MessagingCenter.Subscribe<ItemDetailPage, ItemDetailViewModel>(this, "AddAndUpdateItem", async (obj, itemViewModel) =>
            {
                await AddAndUpdateItem(itemViewModel);
            });

            MessagingCenter.Subscribe<ItemInterestPage, ItemDetailViewModel>(this, "AddAndUpdateItem", async (obj, itemViewModel) =>
            {
                await AddAndUpdateItem(itemViewModel);
            });
            
        }
    }
}
