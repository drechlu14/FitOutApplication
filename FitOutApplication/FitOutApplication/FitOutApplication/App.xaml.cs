using FitOutApplication.Classes;
using FitOutApplication.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FitOutApplication
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();
        }

        public static void SetMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Calendar",
                        Icon = Device.OnPlatform("tab_feed.png",null,null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "Exercises",
                        Icon = Device.OnPlatform("tab_about.png",null,null)
                    },
                    new NavigationPage(new ProgressPage())
                    {
                        Title = "Progress",
                        Icon = Device.OnPlatform("tab_about.png",null,null)
                    },
                }
            };
        
        
    }
        private static ExcerciseDatabase _Excercise;

        public static ExcerciseDatabase DatabaseExcercise
        {
            get
            {
                if (_Excercise == null)
                {
                    _Excercise = new ExcerciseDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
                }
                return _Excercise;
            }
        }
        private static BellyDatabase _Belly;

        public static BellyDatabase DatabaseBelly
        {
            get
            {
                if (_Belly == null)
                {
                    _Belly = new BellyDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
                }
                return _Belly;
            }
        }
        private static FatDatabase _Fat;

        public static FatDatabase DatabaseFat
        {
            get
            {
                if (_Fat == null)
                {
                    _Fat = new FatDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
                }
                return _Fat;
            }
        }
        private static WeightDatabase _Weight;

        public static WeightDatabase DatabaseWeight
        {
            get
            {
                if (_Weight == null)
                {
                    _Weight = new WeightDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
                }
                return _Weight;
            }
        }

    }
}
