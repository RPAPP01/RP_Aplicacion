using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Xamarin.Forms.Maps;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Essentials;

namespace App_RP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapsPage : ContentPage
    {
        //readonly Pin _pinTokyo = new Pin()
        //{
        //    Type = PinType.Place,
        //    Label = "Tokyo SKYTREE",
        //    Address = "Sumida-ku, Tokyo, Japan",
        //    Position = new Position(24.0226824, -104.7177652)
        //};


        //readonly Pin _pinTokyo2 = new Pin()
        //{
        //    Icon = BitmapDescriptorFactory.DefaultMarker(Color.Gray),
        //    Type = PinType.Place,
        //    Label = "Second Pin",
        //    Position = new Position(24.0226824, -104.9177652),
        //    ZIndex = 5
        //};

        [Obsolete]
        public MapsPage()
        {
            InitializeComponent();

            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(25.6487281, -100.373144), Distance.FromMiles(1)));

            var pin = new Pin()
            {

                Position = new Position(25.780137, -100.4474545),
                Label = "BAR ESC",
                Address = "Santa Cruz",
                Icon = BitmapDescriptorFactory.FromBundle("RPLS"),


                // Type = PinType.Place
            };
            pin.Clicked += async (sender, e) => {
                // await DisplayAlert(pin.Label, "" + pin.Address, "Cancel");
                //await NavigationPage(new ItemsPage());
                await Navigation.PushAsync(new CommunityView());
            };

            //pin.MarkerClicked += async (s, args) =>
            //{
            //    args.HideInfoWindow = true;
            //    string pinName = ((Pin)s).Label;
            //    await DisplayAlert("Pin Clicked", $"{pinName} was clicked.", "Ok");
            //};
            map.Pins.Add(pin);
            var pins = new Pin()
            {
                Position = new Position(25.6195015, -100.2864361),
                Label = "LIO BAR",
                Address = "Santa Cruz",
                Type = PinType.Place,
                Icon = BitmapDescriptorFactory.FromBundle("RPLS")

            };
            pins.Clicked += async (sender, e) => {
                // await DisplayAlert(pin.Label, "" + pin.Address, "Cancel");
                //await NavigationPage(new ItemsPage());
                await Navigation.PushAsync(new CommunityView());
            };
            map.Pins.Add(pins);
            var pin1 = new Pin()
            {
                Position = new Position(25.6616729, -100.3662586),
                Label = "Club Ejecutivo",
                Address = "Santa Cruz",
                Type = PinType.Place,
                Icon = BitmapDescriptorFactory.FromBundle("RPLS")

            };
            pin1.Clicked += async (sender, e) => {
                // await DisplayAlert(pin.Label, "" + pin.Address, "Cancel");
                //await NavigationPage(new ItemsPage());
                await Navigation.PushAsync(new CommunityView());
            };
            map.Pins.Add(pin1);
            //---------------------------------------------------------------------
            //---------------------------------------------------
      
            /*  MapView.MoveToRegion(
              MapSpan.FromCenterAndRadius(
              new Position(37, -122), Distance.FromMiles(1)));*/
        }
        private void Street_OnClicked(object sender, EventArgs e)
        {
          map.MapType = MapType.Street;
        }


        private void Hybrid_OnClicked(object sender, EventArgs e)
        {
            map.MapType = MapType.Hybrid;
        }

        private void Satellite_OnClicked(object sender, EventArgs e)
        {
            map.MapType = MapType.Satellite;
        }

    }
}