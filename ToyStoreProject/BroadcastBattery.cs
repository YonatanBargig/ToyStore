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
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { Intent.ActionBatteryChanged })]
    public class BroadcastBattery : BroadcastReceiver
    {
        TextView tv;
        public BroadcastBattery()//פעולה בונה ריקה
        {
        }
        public BroadcastBattery(TextView tv)//פעולה בונה עם תכונות
        {
            this.tv = tv;
        }
        public override void OnReceive(Context context, Intent intent)//פעולה שמפעילה את הברודרקאסט 
        {
            int battery = intent.GetIntExtra("level", 0);
            tv.Text = "" + battery;
        }
    }
}