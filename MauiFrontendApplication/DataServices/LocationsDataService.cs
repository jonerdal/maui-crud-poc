﻿using Locations.Contracts;
using MauiFrontendApplication.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace MauiFrontendApplication.DataServices
{
    public class LocationsDataService : ILocationsDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public LocationsDataService()
        {
            //TODO this should be done with DI
            _httpClient = new HttpClient();

            //Since running https locally on android is not super easy, we'll do http now since this is only for dev anyway.
            _baseAddress = "http://localhost:5220";
            _url = $"{_baseAddress}/api/locations";

            //This should perhaps be handled globally and not not on class level.. 
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task CreateLocationAsync(LocationModel location)
        {
            var createRequest = new CreateLocationRequest(location.Name, location.Description);
            var content = new StringContent(JsonSerializer.Serialize(createRequest, _jsonSerializerOptions), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_url, content);

            if(response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Successfully created location");
            } else
            {
                Debug.WriteLine($"Failed creating location: {response.StatusCode}");
            }
        }

        public async Task DeleteLocationAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{_url}/{id}");

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Successfully deleted location");
            }
            else
            {
                Debug.WriteLine($"Failed deleting location: {response.StatusCode}");
            }
        }

        public async Task<List<LocationModel>> GetLocationsAsync()
        {
            var locations = new List<LocationModel>();

            var response = await _httpClient.GetAsync(_url);

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Successfully fetched location");

                string content = await response.Content.ReadAsStringAsync();
                var getLocationsResponse = JsonSerializer.Deserialize<GetLocationsResponse>(content, _jsonSerializerOptions);

                locations.AddRange(getLocationsResponse.Locations.Select(location => new LocationModel { Id = location.Id, Name = location.Name, Description = location.Description }));
            }
            else
            {
                Debug.WriteLine($"Failed fetching location: {response.StatusCode}");
            }

            return locations;
        }

        public async Task UpsertLocationAsync(LocationModel location)
        {
            var upsertRequest = new UpsertLocationRequest(location.Name, location.Description);
            var content = new StringContent(JsonSerializer.Serialize(upsertRequest, _jsonSerializerOptions), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_url}/{location.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine($"Successfully upserted location: {response.StatusCode}");
            }
            else
            {
                Debug.WriteLine($"Failed upserting location: {response.StatusCode}");
            }
        }
    }
}
