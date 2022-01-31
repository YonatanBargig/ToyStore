using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ToyStoreProject.Resources.layout
{
    [Activity(Label = "SportToyActivity")]
    public class SportToyActivity : Activity, ListView.IOnItemClickListener
    {
        public static List<SportToy> SporttoyList { get; set; }        

        SportToyAdapter SporttoyAdapter;
        ListView lv;
        ImageView iv;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SportToy);
            Bitmap football = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.football);
            Bitmap tenis = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.ball);
            Bitmap basketball = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.basketball);
            Bitmap am = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.am);
            Bitmap bow = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.bow);
            Bitmap pol8 = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.pol8);
            Bitmap sfog = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.Sfog);
            Bitmap baseball = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.baseball);
            Bitmap ping = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.ping);
            SportToy St1 = new SportToy("4", "ball",100, Helper.BitmapToBase64(football),3,"Football");
            SportToy St2 = new SportToy("6","ball",75, Helper.BitmapToBase64(basketball), 3, "Basketball");
            SportToy St3 = new SportToy("5","ball", 50, Helper.BitmapToBase64(tenis), 3, "Tenis");
            SportToy St4 = new SportToy("11", "football", 60, Helper.BitmapToBase64(am), 6, "amarican");
            SportToy St5 = new SportToy("12", "ball", 10, Helper.BitmapToBase64(bow), 3, "bowling");
            SportToy St6 = new SportToy("13", "ball", 60, Helper.BitmapToBase64(pol8), 11, "pol8");
            SportToy St7 = new SportToy("14", "ball", 70, Helper.BitmapToBase64(sfog), 1, "sfog");
            SportToy St8 = new SportToy("15", "ball", 55, Helper.BitmapToBase64(baseball), 4, "base");
            SportToy St9 = new SportToy("16", "pong", 150, Helper.BitmapToBase64(ping), 6, "ping");
            //phase 2 - add to array list
            SporttoyList = new System.Collections.Generic.List<SportToy>();
            SporttoyList.Add(St1);
            SporttoyList.Add(St2);
            SporttoyList.Add(St3);
            SporttoyList.Add(St4);
            SporttoyList.Add(St5);
            SporttoyList.Add(St6);
            SporttoyList.Add(St7);
            SporttoyList.Add(St8);
            SporttoyList.Add(St9);
            //phase 3 - create adapter
            SporttoyAdapter = new SportToyAdapter(this, SporttoyList);
            //phase 4 reference to listview
            iv = FindViewById<ImageView>(Resource.Id.iv);
           
            lv = FindViewById<ListView>(Resource.Id.lv);
            lv.Adapter = SporttoyAdapter;
            lv.OnItemClickListener = this;     //update
            
        }
        protected override void OnResume()
        {
            base.OnResume();

            Toast.MakeText(this, "ON RESUME NOT CALLED", ToastLength.Long).Show();
            SporttoyAdapter.NotifyDataSetChanged();
        }
            public void OnItemClick(AdapterView parent, View view, int position, long id)
        {
           
            Intent intent = new Intent(this, typeof(UpdateActivity));
            intent.PutExtra("pos", position);
            Intent intent1 = new Intent(this, typeof(ShopingCartActivity));
            intent1.PutExtra("pos", position);
            StartActivity(intent);
        }

       
    }
}