using MauiFrontendApplication.Pages;

namespace MauiFrontendApplication
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ManageLocationsPage), typeof(ManageLocationsPage));
        }
    }
}