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
using SQLite;

namespace ToyStoreProject.Resources.layout
{
    [Activity(Label = "ShopingCartActivity")]
    public class ShopingCartActivity : Activity, ListView.IOnItemLongClickListener, Android.Views.View.IOnClickListener
    {
        public static List<ToySql> ToyList;
        ToyAdapter toyAdapter;
        ListView lv;
        ToySql t;
        TextView tvtitle, payment,username;
        string name, pic,usern;
        int pos = -1, pos1 = -1, pos2 = -1,price =0,h=0,a=0,price1=0;
        EditText etamount;
        Button btnSendEmail,btnClean,btnBack;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ShopingCart);
            tvtitle = FindViewById<TextView>(Resource.Id.tvtitle);
            payment = FindViewById<TextView>(Resource.Id.payment);
           etamount = FindViewById<EditText>(Resource.Id.etamount);
            username = FindViewById<TextView>(Resource.Id.username);
            btnSendEmail = FindViewById<Button>(Resource.Id.btnemail);
            btnSendEmail.SetOnClickListener(this);
            btnClean = FindViewById<Button>(Resource.Id.btnclean);
            btnClean.SetOnClickListener(this);
            btnBack = FindViewById<Button>(Resource.Id.btnback);
            btnBack.SetOnClickListener(this);
            usern = LoginActivity.y;
            username.Text = usern;
            // //קליטה מאיזה רשימה
            pos = Intent.GetIntExtra("pos", -1);
            pos1 = Intent.GetIntExtra("pos1", -1);
            pos2 = Intent.GetIntExtra("pos2", -1);
            price1 = Intent.GetIntExtra("price1", -1);
            if (pos != -1)
            {
                name = SportToyActivity.SporttoyList[pos].GetName();
                pic = SportToyActivity.SporttoyList[pos].GetPic();
                price = SportToyActivity.SporttoyList[pos].GetPrice();
                t = new ToySql(name, price, pic);
            }
            if (pos1 != -1)
            {
                name = WarToyActivity.WarToyList[pos1].GetName();
                pic = WarToyActivity.WarToyList[pos1].GetPic();
                price = WarToyActivity.WarToyList[pos1].GetPrice();
                t = new ToySql(name, price, pic);
            }
            if (pos2 != -1)
            {
                name = BoxGamesActivity.boxgamesList[pos2].GetName();
                pic = BoxGamesActivity.boxgamesList[pos2].GetPic();
                price = BoxGamesActivity.boxgamesList[pos2].GetPrice();
                t = new ToySql(name, price, pic);
            }
            var db = new SQLiteConnection(Helper.Path());
            db.CreateTable<ToySql>();
            db.Insert(t);
            Toast.MakeText(this, "new toy", ToastLength.Short).Show();
            ToyList = GetAllToySql();
            lv = FindViewById<ListView>(Resource.Id.lv);
            toyAdapter = new ToyAdapter(this, ToyList);
            lv.Adapter = toyAdapter;
            lv.OnItemLongClickListener = this;
             // a = int.Parse(etamount.Text);
            //חיבור המחירים של כל המוצרים ששמורים בטבלה
            for (int i = 0; i < ToyList.Count; i++)
            {
                h += price1;
            }
            payment.Text = h.ToString();
        }
            public List<ToySql> GetAllToySql()
        {
            var db = new SQLiteConnection(Helper.Path());
            string strsql = string.Format("SELECT * FROM ToySql");
            var fa = db.Query<ToySql>(strsql);
            ToyList = new List<ToySql>();
            if (fa.Count > 0)
            {
                foreach (var item in fa)
                {
                    ToyList.Add(item);
                }

            }
            return ToyList;
        }
        public void OnClick(Android.Views.View view)

        {

            if (btnSendEmail == view)

            {

                String[] emails = { "zionbargig@gmail.com" };

                Intent intent = new Intent(Intent.ActionSend);

                intent.SetType("text/plain");

                intent.PutExtra(Intent.ExtraEmail, emails);

                intent.PutExtra(Intent.ExtraSubject, "The Order");

                intent.PutExtra(Intent.ExtraText,"user name that ordered:"+ username.Text+""+"the price is:" + payment.Text);

                StartActivity(Intent.CreateChooser(intent, "Send Email"));

            }
            if (btnClean == view)
            {
                payment.Text = "0";
                h = 0;
                var db = new SQLiteConnection(Helper.Path());
                db.DeleteAll<ToySql>();
                ToyList.Clear();
                lv.Adapter = null;
            }
            if (btnBack == view)
            {
                Intent intent = new Intent(this, typeof(CustomerActivity));
                StartActivity(intent);
            }
        }
        public bool OnItemLongClick(AdapterView parent, View view, int position, long id)
        {
            var db = new SQLiteConnection(Helper.Path());
            //הורדת המחיר של המוצר מהמחיר הכולל
            h = h - ToyList[position].Price;
            payment.Text = h.ToString();
            db.Delete(ToyList[position]);//מחיקת המוצר מהטבלה
            ToyList.RemoveAt(position);//מחיקת המוצר מהרשימה
            toyAdapter.NotifyDataSetChanged();
            return true;
        }
    }
}