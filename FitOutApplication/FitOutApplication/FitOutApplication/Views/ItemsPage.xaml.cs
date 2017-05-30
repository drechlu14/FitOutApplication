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

        private void Button_Click(object sender, EventArgs e)
        {
            //Button ctrl = ((Button)sender);
            //switch (ctrl.BackgroundColor.Name)
            var button = (Button)sender;
            var classId = button.ClassId;
            button.BackgroundColor = Color.Yellow;
            Navigation.PushModalAsync(new SetupPage());
            //Button3.BackgroundColor = Color.Yellow;
        }

        private void ButtonInfo_Click(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new InfoPage());
        }
    }
}
