using TapAndHoldToMultiSelect.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TapAndHoldToMultiSelect.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }
    }
}