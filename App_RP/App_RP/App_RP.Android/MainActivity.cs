using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Octane.Xamarin.Forms.VideoPlayer.Android;
using Android;
using Xamarin.Forms.GoogleMaps.Android;

namespace App_RP.Droid
{


    [Activity(Label = "RP_APP", Icon = "@drawable/LogRPTrasp", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        
        const int RequestLocationId = 0;
        readonly string[] PermissionsLocation = { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation };

        protected override void OnCreate(Bundle savedInstanceState)
        {

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);

            var platformConfig = new PlatformConfig
            {
                BitmapDescriptorFactory = new BitmapConfig()
            };
            Xamarin.FormsGoogleMaps.Init(this, savedInstanceState, platformConfig);

            Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);;
            Xamarin.FormsGoogleMaps.Init(this, savedInstanceState);
            FormsVideoPlayer.Init();
            LoadApplication(new App());

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        }
    }
}