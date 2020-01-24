using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App_RP.Services;
using App_RP.Views;
using App_RP.DataBaseLocal;
using System.Collections.Generic;
using System.IO;

namespace App_RP
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        //To debug on Android emulators run the web backend against .NET Core not IIS
        //If using other emulators besides stock Google images you may need to adjust the IP address
        public static string AzureBackendUrl =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000";
        public static bool UseMockDataStore = true;
        public static string MessageGlobal { get; private set; }
        static RP_DataBase database;
        public static RP_DataBase Database
        {
            get
            {
                try
                {
                    if (database == null)
                    {
                        database = new RP_DataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RPDB.db3"));
                    }

                }
                catch (Exception exMs)
                {
                    MessageGlobal = "Error. 100; " + exMs.Message;
                    Console.WriteLine(MessageGlobal);
                    App_RP.App.Current.MainPage.DisplayAlert("¡Ops!", "Surgio un error, Consulte soporte técnico", "Confirmar");
                    throw;
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
                if (UseMockDataStore)
                    DependencyService.Register<MockDataStore>();
                else
                    DependencyService.Register<AzureDataStore>();
            MainPage = new MainPage();           
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
