using MauiFrontendApplication.DataServices;
using MauiFrontendApplication.Models;
using System.Diagnostics;

namespace MauiFrontendApplication.Pages;

[QueryProperty(nameof(LocationModel), "LocationModel")]
public partial class ViewLocationPage : ContentPage
{
    private readonly ILocationsDataService _dataService;
    private LocationModel _locationModel;
    public LocationModel LocationModel
    {
        get => _locationModel;
        set
        {
            _locationModel = value;
            OnPropertyChanged();
        }
    }

    public ViewLocationPage(ILocationsDataService dataService)
    {
        InitializeComponent();
        _dataService = dataService;
        BindingContext = this;
    }

    async void OnEditLocationClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("OnEditLocationClicked clicked");

        var navigationParameter = new Dictionary<string, object>
        {
            { nameof(LocationModel), LocationModel }
        };

        await Shell.Current.GoToAsync(nameof(ManageLocationPage), navigationParameter);
    }

    async void OnDeleteLocationClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("OnDeleteLocationClicked clicked");

        var success = await _dataService.DeleteLocationAsync(LocationModel.Id);

        if (success)
            await Shell.Current.GoToAsync("..");
        else
            await DisplayAlert("Deletion failed", "Failed to delete location", "OK");
    }
}