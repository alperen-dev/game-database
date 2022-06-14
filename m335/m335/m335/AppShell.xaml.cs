using Xamarin.Forms;
using m335.Views;

namespace m335
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(GameEntryPage), typeof(GameEntryPage));
        }
    }
}