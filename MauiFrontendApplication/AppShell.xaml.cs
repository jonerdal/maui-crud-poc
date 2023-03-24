using MauiFrontendApplication.Pages;

namespace MauiFrontendApplication
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ViewLocationPage), typeof(ViewLocationPage));
            Routing.RegisterRoute(nameof(ManageLocationPage), typeof(ManageLocationPage));
        }
    }
}