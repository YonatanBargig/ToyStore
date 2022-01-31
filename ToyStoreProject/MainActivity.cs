using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using Android.Telephony;
using Android;
using Android.Support.V4.App;
using Android.Content.PM;

namespace ToyStoreProject
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnstart;
        private BroadcastTelephony broadcastTelephony;//משתנים של ברוקאסט טלפון
        TextView tv;//הצגת הסוללה
        BroadcastBattery broadCastBattery;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btnstart = FindViewById<Button>(Resource.Id.btnstart);
            btnstart.Click += Btnstart_Click;
            tv = FindViewById<TextView>(Resource.Id.tv);
            broadCastBattery = new BroadcastBattery(tv);//תיאום הבורדקאסט עם הטקסט ויאו שבו יוצג הסוללה
            broadcastTelephony = new BroadcastTelephony();//הגדרת הברוקאסט טלפוניה

            var permissions = new string[]
            {
			// מבקש הרשאה לספר טלפונים בשביל הטלפוניה
                Manifest.Permission.ReadPhoneState
            };
            ActivityCompat.RequestPermissions(this, permissions, 1);

        }
         public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)//יצירת תפריט

         {

             MenuInflater.Inflate(Resource.Menu.menu,menu);//ניפוח התפריט

             return true;

         }
        public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)//מימוש התפריט

        {
            
            switch(item.ItemId)//מחליף את האיף ועוזר לקצר את הקוד באמצעות סוויץ על לחיצה על האיטם אידי 
            {
                case Resource.Id.action_start://וקייס כדי לממש את התנאי באיידי הספציפי
                    { 
                Intent intent = new Intent(this, typeof(FirstService));// הפעלת הפונקציה
                 StartService(intent);
                Toast.MakeText(this, "you started the music", ToastLength.Long).Show();
                 return true;
            }

                
                case Resource.Id.action_stop://עצירת השיר
                    {
                        Intent intent = new Intent(this, typeof(FirstService));
                        StopService(intent);
                        Toast.MakeText(this, "you stop the music", ToastLength.Long).Show();

                        return true;
                    }
            }
             
                  
                    return base.OnOptionsItemSelected(item);

        }
        private void Btnstart_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(LoginActivity));//מעבר ללוגין אקטיביטי
        }

        protected override void OnResume()//מפעיל את הברודקאסטים
        {
            base.OnResume();
            IntentFilter callIntentFilter = new IntentFilter(TelephonyManager.ActionPhoneStateChanged);
            RegisterReceiver(broadcastTelephony , callIntentFilter);
            RegisterReceiver(broadCastBattery, new IntentFilter(Intent.ActionBatteryChanged));
        }


        protected override void OnPause()//עוצר את הברודקאסטים
        {
            UnregisterReceiver(broadcastTelephony);
            UnregisterReceiver(broadCastBattery);
            base.OnPause();
        }

        public override void OnRequestPermissionsResult(int requestCode,string[] permissions,[GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            //פעולה הממשת את הבקשה לשימוש בספר טלפונים כאשר מתקשרים
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);


            if (requestCode == 1 && grantResults.Length > 0 && grantResults[0] == Permission.Granted)
            {
                RegisterReceiver(broadcastTelephony,
        new IntentFilter(TelephonyManager.ActionPhoneStateChanged));
            }
        }




    }
}