using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using App_RP.DataBaseLocal;
using Xamarin.Forms.Xaml;

using App_RP.Models;
using System.Linq;

namespace App_RP.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();
            Config();
            MasterBehavior = MasterBehavior.Popover;

           MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
           // MenuPages.Add((int)MenuItemType.Maps, (NavigationPage)Detail);
        }

        async void Config()
        {
            List<Perfil> lista = await App.Database.GetPerfilAsync();
            if (lista.Count() != 0)
            {
            } 
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.Maps:
                        MenuPages.Add(id, new NavigationPage(new MapsPage()));
                        break;
                    case (int)MenuItemType.Community:
                        MenuPages.Add(id, new NavigationPage(new CommunityView()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}