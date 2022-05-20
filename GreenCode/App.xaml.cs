using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GreenCode
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            if (Properties.ContainsKey("SName"))
            {
                ((MainPage)MainPage).resumeData();
            }
        }

        protected override void OnSleep()
        {
            ((MainPage)MainPage).saveData();
        }

        protected override void OnResume()
        {
            ((MainPage)MainPage).resumeData();
        }
    }
}
