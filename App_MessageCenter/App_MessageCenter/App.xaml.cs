using App_MessageCenter.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_MessageCenter
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ExemploMessagePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
