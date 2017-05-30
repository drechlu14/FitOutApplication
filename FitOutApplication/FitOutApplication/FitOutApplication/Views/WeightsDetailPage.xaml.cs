
using FitOutApplication.ViewModels;
using System;
using Xamarin.Forms;

namespace FitOutApplication.Views
{
    public partial class WeightsDetailPage : ContentPage
    {
        public int x;
        SetupViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public WeightsDetailPage()
        {
            InitializeComponent();
        }

        public WeightsDetailPage(SetupViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
        private void ButtonEdit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SetupPage());
        }

        private void ButtonReps_Clicked(object sender, EventArgs e)
        {
            x++;
            if (x == 1)
            {
                EntryReps.IsVisible = true;
            }
            else
            {
                EntryReps.IsVisible = true;
                string reps = EntryReps.Text;
                if (reps == "")
                {
                    ActualReps.Text = "Add data!!";
                }
                /*else
                {
                    bool isIn = true;

                    int n;
                    bool isNumeric = int.TryParse(reps, out n);
                    if (isNumeric)
                    {
                        var Fats = App.DatabaseBelly.QueryCustom().Result;
                        foreach (var Fatty in Fats)
                        {
                            Pass = Fatty.Begin;
                            isIn = false;
                        }
                        if (isIn)
                        {
                            Classes.Belly Body = new Classes.Belly();
                            Body.Begin = CM;
                            Body.Actual = CM;
                            App.DatabaseBelly.SaveItemAsync(Body);
                            show();
                        }
                        else
                        {
                            Classes.Belly Body = new Classes.Belly();
                            Body.Begin = Pass;
                            Body.Actual = CM;
                            App.DatabaseBelly.SaveItemAsync(Body);
                            show();
                        }
                }*/
                else
                {
                    ActualReps.Text = "Just number!!";
                }
            }
        }
        private void ButtonWeight_Clicked(object sender, EventArgs e)
        {

        }
    }
}
