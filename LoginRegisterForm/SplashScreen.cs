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

        private ImageView _mysplashImage;
        protected override async void OnResume()
        {
            base.OnResume();
            SetContentView(Resource.Layout.splashscreenlayout);
            _mysplashImage = FindViewById<ImageView>(Resource.Id.imageViewBaskinRobbins);
            var animation = AnimationUtils.LoadAnimation(this, Resource.Animation.animfadetrans);
            _mysplashImage.StartAnimation(animation);
            await SimulateStratup();

        }

        private async Task SimulateStratup()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            StartActivity(new Intent(this, typeof(MainActivity)));
        }
    }
}