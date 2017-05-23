using System;

using FitOutApplication.Models;
using FitOutApplication.ViewModels;

using Xamarin.Forms;

namespace FitOutApplication.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SetupPage());
        }

    }
}
