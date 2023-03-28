using MauiFrontendApplication.DataServices;
using MauiFrontendApplication.Models;
using System.Diagnostics;

namespace MauiFrontendApplication.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly ILocationsDataService _dataService;

        public MainPage(ILocationsDataService dataService)
        {
            InitializeComponent();
            _dataService = dataService;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await _dataService.GetLocationsAsync();
        }

        async void OnAddLocationClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("OnAddLocationClicked clicked");

            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(LocationModel), new LocationModel() }
            };

            await Shell.Current.GoToAsync(nameof(ManageLocationPage), navigationParameter);
        }

        async void OnRefreshClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("refreshing data");
            collectionView.ItemsSource = await _dataService.GetLocationsAsync();
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Debug.WriteLine("OnSelecctionCahnged clicked");
                var navigationParameter = new Dictionary<string, object>
                {
                    { nameof(LocationModel), e.CurrentSelection.FirstOrDefault() as LocationModel }
                };

                await Shell.Current.GoToAsync(nameof(ViewLocationPage), navigationParameter);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}