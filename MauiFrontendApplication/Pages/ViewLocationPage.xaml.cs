using MauiFrontendApplication.DataServices;
using MauiFrontendApplication.Models;
using System.Diagnostics;

namespace MauiFrontendApplication.Pages;

[QueryProperty(nameof(LocationModel), "LocationModel")]
public partial class ViewLocationPage : ContentPage
{
    private readonly ILocationsDataService _dataService;
    public LocationModel LocationModel { get; set; }

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

        await _dataService.DeleteLocationAsync(LocationModel.Id);
    }
}