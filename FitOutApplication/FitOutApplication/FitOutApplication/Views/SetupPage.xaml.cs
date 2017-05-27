using System;

using FitOutApplication.Models;
using FitOutApplication.ViewModels;

using Xamarin.Forms;

namespace FitOutApplication.Views
{
    public partial class SetupPage : ContentPage
    {
        WeightsViewModel viewModel;

        public SetupPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new WeightsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushModalAsync(new WeightsDetailPage(new SetupViewModel(item)));

            // Manually deselect item
            ItemsListView2.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
