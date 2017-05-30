using FitOutApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitOutApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeightsDetailPage : ContentPage
    {
        public int x;
        SetupViewModel viewModel;

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
