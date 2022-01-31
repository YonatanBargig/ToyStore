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
    public class SportToyActivity : Activity, ListView.IOnItemClickListener, ListView.IOnItemLongClickListener
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
           /* int football = Resource.Drawable.football;
            int tenis = Resource.Drawable.ball;
            int basketball = Resource.Drawable.basketball;*/
            
              Bitmap football = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.football);
              Bitmap tenis = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.ball);
              Bitmap basketball = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.basketball);
           
            SportToy St1 = new SportToy( "ball",100, football,3,"Football");
            SportToy St2 = new SportToy("ball",75, basketball, 3, "Basketball");
            SportToy St3 = new SportToy("ball", 50, tenis, 3, "Tenis");
            //phase 2 - add to array list
            SporttoyList = new System.Collections.Generic.List<SportToy>();
            SporttoyList.Add(St1);
            SporttoyList.Add(St2);
            SporttoyList.Add(St3);
            //phase 3 - create adapter
            SporttoyAdapter = new SportToyAdapter(this, SporttoyList);
            //phase 4 reference to listview
            iv = FindViewById<ImageView>(Resource.Id.iv);
           
            lv = FindViewById<ListView>(Resource.Id.lv);
            lv.Adapter = SporttoyAdapter;
            lv.OnItemClickListener = this;     //update
            lv.OnItemLongClickListener = this;//delete 
        }
        protected override void OnResume()
        {
            base.OnResume();

            Toast.MakeText(this, "ON RESUME NOT CALLED", ToastLength.Long).Show();
            SporttoyAdapter.NotifyDataSetChanged();
        }
            public void OnItemClick(AdapterView parent, View view, int position, long id)
        {
            //  throw new NotImplementedException();
            Intent intent = new Intent(this, typeof(UpdateActivity));
             intent.PutExtra("pos", position);
           /*Intent intent = new Intent(this, typeof(Open));
            intent.PutExtra("title", );
            intent.PutExtra("age", tvAge.Text);
            intent.PutExtra("pic", ivProduct);
            intent.PutExtra("price",TvPrice.Text );*/
            StartActivity(intent);

        }

        public bool OnItemLongClick(AdapterView parent, View view, int position, long id)
        {
            //throw new NotImplementedException();
            SporttoyList.RemoveAt(position);
            SporttoyAdapter.NotifyDataSetChanged();
            return true;
        }
    }
}