using ApiService.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApiService
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PostsPage();
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
