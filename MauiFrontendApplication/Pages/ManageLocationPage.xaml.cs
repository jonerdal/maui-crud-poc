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
        Debug.WriteLine("---> Update an Item");
        await _dataService.UpsertLocationAsync(LocationModel);

        //TODO check success before navigating back
        var navigationParameter = new Dictionary<string, object>
        {
            { nameof(LocationModel), LocationModel }
        };

        await Shell.Current.GoToAsync("..", navigationParameter);

    }

    async void OnCancelButtonClicked(object sender, EventArgs e)
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