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
    public partial class ProgressPage : ContentPage
    {
        public int x;
        public string Pass;
        ItemsViewModel viewModel;
        public ProgressPage()
        {
            InitializeComponent();
            //Navigation.PushModalAsync(new SetupPage());
            show();
        }
       public void show()
        {
            var fat = App.DatabaseFat.QueryCustom().Result;
            var weight = App.DatabaseWeight.QueryCustom().Result;
            var belly = App.DatabaseBelly.QueryCustom().Result;
            foreach(var fats in fat)
            {
                int x;
                int y;
                Int32.TryParse(fats.Begin, out x);
                Int32.TryParse(fats.Actual, out y);
                int myInt = x - y;
                string myString = myInt.ToString();
                AtBeginFat.Text = "Fat at start: "+  fats.Begin;
                ActualFat.Text = "Current fat: "+ fats.Actual;
                ProgressFat.Text = "Progress:" + myString;
            }
            foreach(var Weights in weight)
            {
                int x;
                int y;
                Int32.TryParse(Weights.Begin, out x);
                Int32.TryParse(Weights.Actual, out y);
                int myInt = x - y;
                string myString = myInt.ToString();
                AtBeginWeight.Text = "Weight at start: "+ Weights.Begin;
                ActualWeight.Text = "Current weight: " + Weights.Actual;
                Progress.Text = "Progress: "+ myString;
            }
            foreach (var bellys in belly)
            {
                int x;
                int y;
                Int32.TryParse(bellys.Begin, out x);
                Int32.TryParse(bellys.Actual, out y);
                int myInt = x - y;
                string myString = myInt.ToString();
                AtBeginCM.Text = "Belly at start: "+ bellys.Begin;
                ActualCM.Text = "Current CM: "+ bellys.Actual;
                ProgressCM.Text = "Progress:" + myString;
            }
        }

        private void AddWeight_Clicked(object sender, EventArgs e)
        {
          
            x++;
            if (x == 1)
            {
                EntryWeight.IsVisible = true;
            }
            else
            {
                EntryWeight.IsVisible = true;
                string Weight = EntryWeight.Text;
                if (Weight == "")
                {
                    Progress.Text = "Add data!!";
                }
                else
                {
                    bool isIn = true;
                    
                    int n;
                    bool isNumeric = int.TryParse(Weight, out n);
                    if (isNumeric)
                    {
                        var weight = App.DatabaseWeight.QueryCustom().Result;
                        foreach (var Weights in weight)
                        {
                            Pass = Weights.Begin;
                            isIn = false;
                        }
                        if (isIn)
                        {
                            Classes.Weight Body = new Classes.Weight();
                            Body.Begin = Weight;
                            Body.Actual = Weight;
                            App.DatabaseWeight.SaveItemAsync(Body);
                            show();
                        }
                        else
                        {
                            Classes.Weight Body = new Classes.Weight();
                            Body.Begin = Pass;
                            Body.Actual = Weight;
                            App.DatabaseWeight.SaveItemAsync(Body);
                            show();
                        }
                    }
                    else
                    {
                        Progress.Text = "Just number!!";
                    }
                }
            }
        }

        private void AddFat_Clicked(object sender, EventArgs e)
        {

            x++;
            if (x == 1)
            {
                EntryFat.IsVisible = true;
            }
            else
            {
                EntryFat.IsVisible = true;
                string Fat = EntryFat.Text;
                if (Fat == "")
                {
                    ProgressFat.Text = "Add data!!";
                }
                else
                {
                    bool isIn = true;

                    int n;
                    bool isNumeric = int.TryParse(Fat, out n);
                    if (isNumeric)
                    {
                        var Fats = App.DatabaseFat.QueryCustom().Result;
                        foreach (var Fatty in Fats)
                        {
                            Pass = Fatty.Begin;
                            isIn = false;
                        }
                        if (isIn)
                        {
                            Classes.Fat Body = new Classes.Fat();
                            Body.Begin = Fat;
                            Body.Actual = Fat;
                            App.DatabaseFat.SaveItemAsync(Body);
                            show();
                        }
                        else
                        {
                            Classes.Fat Body = new Classes.Fat();
                            Body.Begin = Pass;
                            Body.Actual = Fat;
                            App.DatabaseFat.SaveItemAsync(Body);
                            show();
                        }
                    }
                    else
                    {
                        ProgressFat.Text = "Just number!!";
                    }
                }
            }
        }

        private void AddCM_Clicked(object sender, EventArgs e)
        {
            x++;
            if (x == 1)
            {
                EntryCM.IsVisible = true;
            }
            else
            {
                EntryCM.IsVisible = true;
                string CM = EntryCM.Text;
                if (CM == "")
                {
                    ProgressCM.Text = "Add data!!";
                }
                else
                {
                    bool isIn = true;

                    int n;
                    bool isNumeric = int.TryParse(CM, out n);
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
                    }
                    else
                    {
                        ProgressCM.Text = "Just number!!";
                    }
                }
            }
        }
    }
}
