using FitOutApplication.Models;

namespace FitOutApplication.ViewModels
{
    public class SetupViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public SetupViewModel(Item item = null)
        {
            Title = item.Text;
            Item = item;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}
