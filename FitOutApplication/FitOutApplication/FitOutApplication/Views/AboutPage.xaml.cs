using System;

using FitOutApplication.Models;
using FitOutApplication.ViewModels;

using Xamarin.Forms;
using System.Collections.Generic;

namespace FitOutApplication.Views
{
    public partial class AboutPage : ContentPage
    {
        ItemsViewModel viewModel;
        public List<string> ListOfExcercise = new List<string>();
        public AboutPage()
        {
            InitializeComponent();
            var dbConnection = App.DatabaseExcercise;
            BindingContext = viewModel = new ItemsViewModel();
     
      
        }
        /*public List<Classes.Excercise> list = new List<Classes.Excercise>();
        public void Show()
        {

            var ListOfExcercise = App.DatabaseExcercise.QueryCustom().Result;
            foreach ( var Excercises in ListOfExcercise)
            {
                this.ListOfExcercise.Add(Excercises.Name);
            }
           
            ItemsListView.ItemsSource = ListOfExcercise;
        }*/

        private static Classes.Excercise GetExcercise(Classes.Excercise Excercise)
        {
            return Excercise;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
           
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
