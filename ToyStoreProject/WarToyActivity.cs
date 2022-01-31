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
using ToyStoreProject.Resources.layout;

namespace ToyStoreProject
{
    [Activity(Label = "WarToyActivity")]
    public class WarToyActivity : Activity, ListView.IOnItemClickListener
    {
        public static List<WarToy> WarToyList { get; set; }

        WarToyAdapter WarToyAdapter;
        ListView lv;
        ImageView iv;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.WarToy);
            Bitmap nerf = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.nerfg);
            Bitmap sol = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.sol);
            Bitmap tank = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.Tank);
            Bitmap lego = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.lego);
            Bitmap plain = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.plain);
            Bitmap ship = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.ship);
            Bitmap robo = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.robotrick);
            WarToy St1 = new WarToy("1","Nerf", 100, Helper.BitmapToBase64(nerf), 3, "Gun");
            WarToy St2 = new WarToy("2","soldiers", 75, Helper.BitmapToBase64(sol), 3, "Gun");
            WarToy St3 = new WarToy("3","Tank", 50, Helper.BitmapToBase64(tank), 3, "Cannon");
            WarToy St4 = new WarToy("20", "lego", 60, Helper.BitmapToBase64(lego), 3, "starwars");
            WarToy St5 = new WarToy("21", "plain", 70, Helper.BitmapToBase64(plain), 3, "air");
            WarToy St6 = new WarToy("22", "ship", 99, Helper.BitmapToBase64(ship), 3, "war");
            WarToy St7 = new WarToy("3", "robo", 50, Helper.BitmapToBase64(robo), 3, "trick");
            //phase 2 - add to array list
            WarToyList = new System.Collections.Generic.List<WarToy>();
            WarToyList.Add(St1);
            WarToyList.Add(St2);
            WarToyList.Add(St3);
            WarToyList.Add(St4);
            WarToyList.Add(St5);
            WarToyList.Add(St6);
            WarToyList.Add(St7);
            //phase 3 - create adapter
            WarToyAdapter = new WarToyAdapter(this, WarToyList);
            //phase 4 reference to listview
            iv = FindViewById<ImageView>(Resource.Id.iv);

            lv = FindViewById<ListView>(Resource.Id.lv);
            lv.Adapter = WarToyAdapter;
            lv.OnItemClickListener = this;     //update
           
            // Create your application here
        }
        public void OnItemClick(AdapterView parent, View view, int position, long id)
        {
            Intent intent = new Intent(this, typeof(UpdateActivity));
            intent.PutExtra("pos1", position);
            Intent intent1 = new Intent(this, typeof(ShopingCartActivity));
            intent1.PutExtra("pos1", position);
            StartActivity(intent);
        }

       

    }
}