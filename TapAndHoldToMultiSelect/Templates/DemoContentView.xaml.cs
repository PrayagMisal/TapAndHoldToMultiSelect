using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TapAndHoldToMultiSelect.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DemoContentView : ContentView
    {
        public DemoContentView()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(DemoContentView), false);
        public bool IsSelected
        {
            get => (bool)GetValue(IsSelectedProperty);
            set
            {
                SetValue(IsSelectedProperty, value);
            }
        }
    }
}