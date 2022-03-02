using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegisterForm
{
    [Activity(Label = "@string/app_name", Theme = "@style/SplashTheme", MainLauncher = true, NoHistory = true)]
    public class SplashScreen : Activity
    {

        private ImageView splashImage;
        protected override async void OnResume()
        {
            base.OnResume();
            SetContentView(Resource.Layout.splashscreenlayout);
            splashImage = FindViewById<ImageView>(Resource.Id.imageviewbaskinrobbins);
            var animation = AnimationUtils.LoadAnimation(this, Resource.Animation.animfadetrans);
            splashImage.StartAnimation(animation);
            await SimulateStratup();

        }

        private async Task SimulateStratup()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            StartActivity(new Intent(this, typeof(MainActivity)));
        }
    }
}