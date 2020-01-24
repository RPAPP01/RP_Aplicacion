using App_RP.ViewModels;
using Xamarin.Forms;

namespace App_RP.Views
{
    public partial class CommunityView : ContentPage
    {
        public CommunityView()
        {
            InitializeComponent();
            BindingContext = new CommunityViewModel();
        }
    }
}