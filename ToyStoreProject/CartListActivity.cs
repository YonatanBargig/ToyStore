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
using ToyStoreProject.Resources.layout;

namespace ToyStoreProject
{
    [Activity(Label = "CartListActivity")]
    public class CartListActivty : Activity, ListView.IOnItemLongClickListener
    {
        public static List<Toy> CartList { get; set; }

        ListView lvmylist;
        TextView payment;
        CartAdapter listadapter;
        public static List<Toy> lvmklist { get; set; }
        string pic = "";
        int h = 0, j =0 ,k =0;
        string age = "", name = "", price = "0", username = "";
        Toy t;
       // public static string dbname = "dbTest10";
       // string path;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CartList);
           // CartList = Getalltoys();
            //הצהרה על המשתנים
            lvmylist = FindViewById<ListView>(Resource.Id.lvmylist);
            payment = FindViewById<TextView>(Resource.Id.payment);
            //קבלת הנתונים מהמסך הקודם
            pic = Intent.GetStringExtra("pic");
            name = Intent.GetStringExtra("title");
            price = Intent.GetStringExtra("price");
            age = Intent.GetStringExtra("age");
            j = int.Parse(price);
            k = int.Parse(age);
            t = new Toy("",name, j, "", k);
           /* path = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbname);
            var db = new SQLiteConnection(path);//create db object
            db.CreateTable<Toy>();*/

           var db = new SQLiteConnection(Helper.Path());
            db.CreateTable<Toy>();//יצירת הטבלה
            db.Insert(t);//הוספת השורה לטבלה
            
            string strsql = string.Format("SELECT * FROM toys");//בוחר מתוך הטבלה את כל השורות
            var ptrs = db.Query<Toy>(strsql);
            CartList = new List<Toy>();
            if (ptrs.Count > 0)
            {
                foreach (var item in ptrs)
                {
                    CartList.Add(item);//מוסיף לרשימה
                }
            
               // lvmklist = Getalltoys();
            listadapter = new CartAdapter(this, CartList);
            lvmylist.Adapter = listadapter;
            lvmylist.OnItemLongClickListener = this;
            //חיבור המחירים של כל המוצרים ששמורים בטבלה
            for (int i = 0; i < CartList.Count; i++)
            {
                h += CartList[i].GetPrice();
            }
            payment.Text = h.ToString();
            //username = Intent.GetStringExtra("username");
        }
        /*public List<Toy> Getalltoys()
        {//מראה את כל הרשימה ששמורה בטבלה
            var db = new SQLiteConnection(Helper.Path());
            string strsql = string.Format("SELECT * FROM toys");//בוחר מתוך הטבלה את כל השורות
            var ptrs = db.Query<Toy>(strsql);
            lvmklist = new List<Toy>();
            if (ptrs.Count > 0)
            {
                foreach (var item in ptrs)
                {
                    lvmklist.Add(item);//מוסיף לרשימה
                }
            }
           */ //return lvmklist;//מציג את הרשימה
        }
        public bool OnItemLongClick(AdapterView parent, View view, int position, long id)
        {//מחיקת המוצר ברגע שלוחצים לחיצה ארוכה
            var db = new SQLiteConnection(Helper.Path());
            //הורדת המחיר של המוצר מהמחיר הכולל
            h = h - CartList[position].GetPrice();
            payment.Text = h.ToString();
            db.Delete(CartList[position]);//מחיקת המוצר מהטבלה
            CartList.RemoveAt(position);//מחיקת המוצר מהרשימה
            listadapter.NotifyDataSetChanged();
            return true;
        }


        //phase 2 - add to array list
        /*  pos = Intent.GetIntExtra("pos", -1);
          temp = SportToyActivity.SporttoyList[pos];
          Open.CartList = new System.Collections.Generic.List<Toy>();
          //CartList.Add(pos);
          //phase 3 - create adapter
          CartAdapter = new CartAdapter(this, CartList);
          //phase 4 reference to listview
          iv = FindViewById<ImageView>(Resource.Id.iv);
          CartList.Add(temp);
          lv = FindViewById<ListView>(Resource.Id.lv);
          lv.Adapter = CartAdapter;
      }
  }
}

         /* var b1 = new SQLiteConnection(Helper.Path());
          string strsql1 = string.Format("Select * from SportToy");
          var s1 = b1.Query<SportToy>(strsql1);
          CartList = new List<Toy>();
          //List<Toy> ToyList = new List<Toy>();
          if (s1.Count > 0)
          {
              foreach (var item in s1)
              {
                  CartList.Add(item);
              }
          }
         // return ToyList;
      }
  }
}
     /* public List<Toy> GetAllToys()
      {
          var db = new SQLiteConnection(Helper.Path_Shopingcart());
          var SportToy = db.Table<SportToy>().ToList<SportToy>();
          List<Toy> ToyList = new List<Toy>();
          if(SportToy.Count > 0)
          {
              foreach (var item in SportToy)
              {
                 ToyList.Add(item);
              }
          }
         return ToyList;
      }
  }
}*/
    }
}
