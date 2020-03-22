using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IOTMobileApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        public MainPage(): base()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BarBackgroundColor = Color.FromHex("#DF1B3D");
            this.BarTextColor = Color.FromHex("#efc7d0"); 
            this.SelectedTabColor = Color.FromHex("#f9e03c");
            this.UnselectedTabColor = Color.White;

        }
    }
}