using MauiFrontendApplication.DataServices;
using MauiFrontendApplication.Models;
using System.Diagnostics;

namespace MauiFrontendApplication.Pages;

[QueryProperty(nameof(LocationModel), "LocationModel")]
public partial class ManageLocationPage : ContentPage
{
    private LocationModel _locationModel;
    private readonly ILocationsDataService _dataService;

    public LocationModel LocationModel
    {
        get => _locationModel;
        set
        {
            _locationModel = value;
            OnPropertyChanged();
        }
    }

    public ManageLocationPage(ILocationsDataService dataService)
    {
        InitializeComponent();
        BindingContext = this;
        _dataService = dataService;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        bool success;
        if (IsNew(LocationModel))
        {
            Debug.WriteLine("---> Create an Item");
            LocationModel = await _dataService.CreateLocationAsync(LocationModel);
            success = LocationModel != default;
        }
        else
        {
            Debug.WriteLine("---> Update an Item");
            success = await _dataService.UpsertLocationAsync(LocationModel);
        }

        if(success)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(LocationModel), LocationModel }
            };

            await Shell.Current.GoToAsync("..", navigationParameter);
        } else
        {
            await DisplayAlert("Save failed", "Failed to save location", "OK");
        }

    }

    async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        if (IsNew(LocationModel))
        {
            await Shell.Current.GoToAsync("../..");
        }
        else
        {
            //We should use a view model for this view, but since we are not, let's fetch from db to get unmodified model
            var location = await _dataService.GetLocationAsync(LocationModel.Id);

            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(LocationModel), location }
            };

            await Shell.Current.GoToAsync("..", navigationParameter);
        }
    }

    private static bool IsNew(LocationModel locationModel)
    {
        return locationModel.Id == Guid.Empty;
    }
}