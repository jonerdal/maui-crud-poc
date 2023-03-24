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
            //collectionView.ItemsSource = new List<LocationModel> { new LocationModel {Name = "Test", Description = "Test Descr", Id = Guid.NewGuid() } };
            collectionView.ItemsSource = await _dataService.GetLocationsAsync();
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("OnSelecctionCahnged clicked");
            var navigationParameter = new Dictionary<string, object>
                {
                    { nameof(LocationModel), e.CurrentSelection.FirstOrDefault() as LocationModel }
                };

            await Shell.Current.GoToAsync(nameof(ManageLocationsPage), navigationParameter);
        }
    }
}