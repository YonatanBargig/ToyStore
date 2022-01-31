using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using ToyStoreProject.Resources.layout;

namespace ToyStoreProject
{
    [Activity(Label = "BoxGamesActivity")]
    public class BoxGamesActivity : Activity, ListView.IOnItemClickListener
    {
        public static List<Boxgames> boxgamesList { get; set; }//הגדרת הרשימה
        BoxgamesAdapter boxgamesAdapter;
        ListView lv;
        ImageView iv;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.Boxgames);
            //שמירת התמונות במשתנים
            Bitmap monopoly = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.monopoly);
            Bitmap taki = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.taki);
            Bitmap guesswho = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.guesswho);
            Bitmap poker = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.poker);
             Bitmap rps = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.rps);
              Bitmap chesss = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.chess);
            //יצירת עצמים
            Boxgames St1 = new Boxgames("7","monopoly", 100, Helper.BitmapToBase64(monopoly), 6,1,1);
            Boxgames St2 = new Boxgames("8","taki", 75, Helper.BitmapToBase64(taki), 6,1,8);
            Boxgames St3 = new Boxgames("9","guesswho", 50, Helper.BitmapToBase64(guesswho), 3,1,1);
            Boxgames St4 = new Boxgames("30", "poker", 100, Helper.BitmapToBase64(poker), 16, 1, 1);
            Boxgames St5 = new Boxgames("31", "rps", 10, Helper.BitmapToBase64(rps), 3, 1, 1);
            Boxgames St6 = new Boxgames("32", "chess", 50, Helper.BitmapToBase64(chesss), 5, 1, 1);
            //phase 2 - add to array list
            boxgamesList = new System.Collections.Generic.List<Boxgames>();
            boxgamesList.Add(St1);
            boxgamesList.Add(St2);
            boxgamesList.Add(St3);
            boxgamesList.Add(St4);
            boxgamesList.Add(St5);
            boxgamesList.Add(St6);
            //phase 3 - create adapter
            boxgamesAdapter = new BoxgamesAdapter(this, boxgamesList);
            //phase 4 reference to listview
            iv = FindViewById<ImageView>(Resource.Id.iv);

            lv = FindViewById<ListView>(Resource.Id.lv);
            lv.Adapter = boxgamesAdapter;//קישור לאדפטר
            lv.OnItemClickListener = this;     //update
           
        }
        public void OnItemClick(AdapterView parent, View view, int position, long id)//לחיצה על האיטים מעבירה למסך עדכון
        {
            Intent intent = new Intent(this, typeof(UpdateActivity));
            intent.PutExtra("pos2", position);
            Intent intent1 = new Intent(this, typeof(ShopingCartActivity));
            intent1.PutExtra("pos2", position);
            StartActivity(intent);
           
            
        }

       
    }
}