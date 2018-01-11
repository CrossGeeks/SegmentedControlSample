﻿using Xamarin.Forms;

namespace SegmentedControlSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SegmentedControlSamplePage(){Title="Segmented Control Sample"}){BarBackgroundColor=Color.DarkGray, BarTextColor=Color.White};
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
