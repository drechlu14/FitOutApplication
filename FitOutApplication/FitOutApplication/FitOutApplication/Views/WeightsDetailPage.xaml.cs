
using FitOutApplication.ViewModels;

using Xamarin.Forms;

namespace FitOutApplication.Views
{
    public partial class WeightsDetailPage : ContentPage
    {
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
    }
}
