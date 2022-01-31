using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace ToyStoreProject
{
    [Activity(Label = "AboutUSActivity")]
    public class AboutUSActivity : Activity
    {
        Button btnBack;

      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.aboutus);//קישור לאקסמל
            btnBack = FindViewById<Button>(Resource.Id.btnback);
            btnBack.Click += btnBack_Click;
            // Create your application here
        }

        private void btnBack_Click(object sender, EventArgs e)//כפתור חזרה
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        
    }
}