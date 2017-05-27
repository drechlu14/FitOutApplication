﻿using System;

using FitOutApplication.Models;
using FitOutApplication.ViewModels;

using Xamarin.Forms;

namespace FitOutApplication.Views
{
    public partial class SetupPage : ContentPage
    {
        ItemsViewModel viewModel;

        public SetupPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new WeightsPage());

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
