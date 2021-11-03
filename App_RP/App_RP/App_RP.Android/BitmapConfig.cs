﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using App_RP.Droid;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.GoogleMaps.Android.Factories;
using AndroidBitmapDescriptor = Android.Gms.Maps.Model.BitmapDescriptor;
using AndroidBitmapDescriptorFactory = Android.Gms.Maps.Model.BitmapDescriptorFactory;

namespace App_RP.Droid
{
    public sealed class BitmapConfig : IBitmapDescriptorFactory
    {
        public AndroidBitmapDescriptor ToNative(BitmapDescriptor descriptor)
        {
            int iconId = 0;
            switch (descriptor.Id)
            {
                case "RP":
                    iconId = Resource.Drawable.LogoRPS;
                    break;
                case "RPLS":
                    iconId = Resource.Drawable.LogoRPS;
                    break;
            }
            return AndroidBitmapDescriptorFactory.FromResource(iconId);
        }
    }
}