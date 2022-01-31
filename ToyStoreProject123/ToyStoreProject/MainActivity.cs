using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace ToyStoreProject
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button btnstart;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            btnstart = FindViewById<Button>(Resource.Id.btnstart);
            btnstart.Click += Btnstart_Click; 
        }

        private void Btnstart_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(LoginActivity));
        }

    }
}