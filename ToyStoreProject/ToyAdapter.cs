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
    class ToyAdapter :BaseAdapter<ToySql>//לוקח רשימה ומחלק אותה לתאים לפי תכונות
    {
        Android.Content.Context context;
        List<ToySql> objects;
        public ToyAdapter(Android.Content.Context context, System.Collections.Generic.List<ToySql> objects)
        {

            this.context = context;

            this.objects = objects;

        }



        public List<ToySql> GetList()

        {

            return this.objects;

        }



        public override long GetItemId(int position)

        {

            return position;

        }

        public override View GetView(int position, View convertView, ViewGroup parent)//הפעולה שיוצרת את התאים של הרשימה
        {
           
            Android.Views.LayoutInflater layoutInflater = ((ShopingCartActivity)context).LayoutInflater;

            Android.Views.View view = layoutInflater.Inflate(Resource.Layout.Custom4, parent, false);//מנפח את התא

            TextView tvTitle = view.FindViewById<TextView>(Resource.Id.tvName);


            TextView tvPrice = view.FindViewById<TextView>(Resource.Id.tvPrice);

            ImageView ivProduct = view.FindViewById<ImageView>(Resource.Id.ivProduct);
            ivProduct.Click += delegate
            {
                Toast.MakeText(Application.Context, "num of click" + position, ToastLength.Short).Show();
            };

            ToySql temp = objects[position];//שולף את האיבר במקום הפוסישין

            if (temp != null)

            {
                //אם התנאי מתקיים אז הוא מקבל ומציג את התכונות

                Bitmap bitmap = Helper.Base64ToBitmap(temp.pic);
                ivProduct.SetImageBitmap(bitmap);

                tvPrice.Text = "" + temp.Price;

                tvTitle.Text = temp.name;

                

            }

            return view;//מחזיר התא למקום
        }

        public override int Count

        {

            get { return this.objects.Count; }

        }



        public override ToySql this[int position]
        {


            get { return this.objects[position]; }
        }
    }
}
