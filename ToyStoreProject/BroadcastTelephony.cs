using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Telephony;
using Android.Views;
using Android.Widget;

namespace ToyStoreProject
{
    public class BroadcastTelephony : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)//הפעולה מעפילה את הברוקדקאסט בשביל שישלח התראה בעת קבלת שיחה
        {

            // ensure there is information
            if (intent.Extras != null)
            {
                // מקבל את מצב השיחה
                string state = intent.GetStringExtra(TelephonyManager.ExtraState);

                // check the current state בדיקה של המצב
                if (state == TelephonyManager.ExtraStateRinging)
                {

                    // read the incoming call telephone number... פרטי המתקשר
                    string chanel_id = "chanel_id";
                    string chanel_name = "chanel-name";
                    if (Build.VERSION.SdkInt >= BuildVersionCodes.O)

                    {
                        NotificationChannel notificationChannel = new NotificationChannel(chanel_id, chanel_name,NotificationImportance.Default);

                        //מפעיל את האור בהתרעה
                        notificationChannel.EnableLights(true);

                        //מפעיל את הרטט 
                        notificationChannel.EnableVibration(true);

                        //צבע ההתרעה
                        notificationChannel.LightColor = Color.White;    

                        // קצב הרטט
                        // with the format {delay,play,sleep,play,sleep...}פורמט הרטט
                        notificationChannel.SetVibrationPattern(new long[] { 500, 500, 500, 500, 500 });

                        //מגדיר אם הודעות מהערוץ הזה צריכות להיות גלויות על מסך הנעילה ובמקרה הזה כן
                        notificationChannel.LockscreenVisibility = NotificationVisibility.Public;

                        NotificationManager manager =(NotificationManager)context.GetSystemService(Context.NotificationService);
                        manager.CreateNotificationChannel(notificationChannel);

                    }


                    string telephone = intent.GetStringExtra(TelephonyManager.ExtraIncomingNumber);
                    Toast.MakeText(Android.App.Application.Context, telephone, ToastLength.Short).Show();//יוצר טוסט
                    // בדוק את הטלפון מחדש
                    if (string.IsNullOrEmpty(telephone))
                        telephone = string.Empty;
                    Notification.Builder builder = new Notification.Builder(context, chanel_id);//יצירת ההתראה ופרטיה
                    builder.SetContentTitle(telephone);
                    builder.SetContentText("you got an incoming phone call from" + telephone);
                    builder.SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Notification));


                    builder.SetSmallIcon(Android.Resource.Drawable.StarOn);
                    Notification notification = builder.Build();//בנייתו
                    const int not_id = 101;//האידי
                    NotificationManager notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
                    NotificationManagerCompat notificationManagerCompat = NotificationManagerCompat.From(context);

                    notificationManager.Notify(not_id, notification);//הנוטיפרישין עצמו
                }
                else if (state == TelephonyManager.ExtraStateOffhook)
                {
                    // incoming call answer
                    Toast.MakeText(Android.App.Application.Context, "you answerd the pohne", ToastLength.Short).Show();


                }
                else if (state == TelephonyManager.ExtraStateIdle)//השיחה הסתיימה
                {

                    Toast.MakeText(Android.App.Application.Context, "call as ended continue to play", ToastLength.Long).Show();

                }
            }
        }


    }
}