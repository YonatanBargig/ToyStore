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

namespace ToyStoreProject
{
    [Activity(Label = "WarToyActivity")]
    public class WarToyActivity : Activity, ListView.IOnItemClickListener, ListView.IOnItemLongClickListener
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
            

            WarToy St1 = new WarToy("1","Nerf", 100, Helper.BitmapToBase64(nerf), 3, "Gun");
            WarToy St2 = new WarToy("2","soldiers", 75, Helper.BitmapToBase64(sol), 3, "Gun");
            WarToy St3 = new WarToy("3","Tank", 50, Helper.BitmapToBase64(tank), 3, "Cannon");
            //phase 2 - add to array list
            WarToyList = new System.Collections.Generic.List<WarToy>();
            WarToyList.Add(St1);
            WarToyList.Add(St2);
            WarToyList.Add(St3);
            //phase 3 - create adapter
            WarToyAdapter = new WarToyAdapter(this, WarToyList);
            //phase 4 reference to listview
            iv = FindViewById<ImageView>(Resource.Id.iv);

            lv = FindViewById<ListView>(Resource.Id.lv);
            lv.Adapter = WarToyAdapter;
            lv.OnItemClickListener = this;     //update
            lv.OnItemLongClickListener = this;//delete
            // Create your application here
        }
        public void OnItemClick(AdapterView parent, View view, int position, long id)
        {
            Intent intent = new Intent(this, typeof(UpdateActivity));
            intent.PutExtra("pos1", position);
            intent.PutExtra("kind", "war toy");
            /*Intent intent = new Intent(this, typeof(Open));
             intent.PutExtra("title", );
             intent.PutExtra("age", tvAge.Text);
             intent.PutExtra("pic", ivProduct);
             intent.PutExtra("price",TvPrice.Text );*/
            StartActivity(intent);
        }

        public bool OnItemLongClick(AdapterView parent, View view, int position, long id)
        {
            throw new NotImplementedException();
        }

    }
}