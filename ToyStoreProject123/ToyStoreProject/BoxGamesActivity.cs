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
    [Activity(Label = "BoxGamesActivity")]
    public class BoxGamesActivity : Activity, ListView.IOnItemClickListener, ListView.IOnItemLongClickListener
    {
        public static List<Boxgames> boxgamesList { get; set; }
        BoxgamesAdapter boxgamesAdapter;
        ListView lv;
        ImageView iv;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.Boxgames);
            Bitmap monopoly = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.monopoly);
            Bitmap taki = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.taki);
            Bitmap guesswho = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.guesswho);
            //  int monopoly = Resource.Drawable.monopoly;
            // int taki = Resource.Drawable.taki;
            // int guesswho = Resource.Drawable.guesswho;
            

            Boxgames St1 = new Boxgames("monopoly", 100, monopoly, 6,1,4);
            Boxgames St2 = new Boxgames("taki", 75, taki, 6,1,8);
            Boxgames St3 = new Boxgames("guesswho", 50, guesswho, 3,1,10);
            //phase 2 - add to array list
            boxgamesList = new System.Collections.Generic.List<Boxgames>();
            boxgamesList.Add(St1);
            boxgamesList.Add(St2);
            boxgamesList.Add(St3);
            //phase 3 - create adapter
            boxgamesAdapter = new BoxgamesAdapter(this, boxgamesList);
            //phase 4 reference to listview
            iv = FindViewById<ImageView>(Resource.Id.iv);

            lv = FindViewById<ListView>(Resource.Id.lv);
            lv.Adapter = boxgamesAdapter;
            lv.OnItemClickListener = this;     //update
            lv.OnItemLongClickListener = this;//delete 
        }
        public void OnItemClick(AdapterView parent, View view, int position, long id)
        {
            Intent intent = new Intent(this, typeof(UpdateActivity));
            intent.PutExtra("pos2", position);
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