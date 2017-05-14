using Android.App;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;

namespace Diabetic.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.Splash", Icon = "@drawable/mcdo", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle); 
            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
   
        }
    }
}