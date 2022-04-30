using CatalogApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CatalogApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddBookPage), typeof(AddBookPage));

            Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
        }
    }
}