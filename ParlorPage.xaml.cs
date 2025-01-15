using Microsoft.Maui.Devices.Sensors;
using Plugin.LocalNotification;
using ProiectMAUI.Models;

namespace ProiectMAUI;

public partial class ParlorPage : ContentPage
{
	public ParlorPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var parlor = (Parlor)BindingContext;
        await App.Database.SaveParlorAsync(parlor);
        await Navigation.PopAsync();
    }
    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var parlor = (Parlor)BindingContext;
        var address = parlor.Adress;
       // var locations = await Geocoding.GetLocationsAsync(address);

        var options = new MapLaunchOptions{ Name = "Salonul meu preferat" };
        //var parlorlocation = locations?.FirstOrDefault(); ///Android
        var parlorlocation = new Location(46.7492379, 23.5745597);
        //var myLocation = await Geolocation.GetLocationAsync(); ///Android
        var myLocation = new Location(46.771251, 23.625991);

        var distance = myLocation.CalculateDistance(parlorlocation, DistanceUnits.Kilometers);
        /* var parlorlocation= new Location(46.7492379, 23.5745597);//pentru
        Windows Machine */
        if(distance < 5)
        {
            var request = new NotificationRequest
            {
                Title = "Salonul este in apropiere!",
                Description = address,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1)
                }
            };
            LocalNotificationCenter.Current.Show(request);
        }
        await Map.OpenAsync(parlorlocation, options);
        }
}