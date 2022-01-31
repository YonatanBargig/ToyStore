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
    class WarToyAdapter : BaseAdapter<WarToy>//לוקח רשימה ומחלק אותה לתאים לפי תכונות
    {
        Android.Content.Context context;
        List<WarToy> objects;
        public WarToyAdapter(Android.Content.Context context, System.Collections.Generic.List<WarToy> objects)
        {

            this.context = context;

            this.objects = objects;

        }



        public List<WarToy> GetList()

        {

            return this.objects;

        }



        public override long GetItemId(int position)

        {

            return position;

        }

        public override View GetView(int position, View convertView, ViewGroup parent)//הפעולה שיוצרת את התאים של הרשימה
        {
            
            Android.Views.LayoutInflater layoutInflater = ((WarToyActivity)context).LayoutInflater;

            Android.Views.View view = layoutInflater.Inflate(Resource.Layout.Custom3, parent, false);//מנפח את התא

            TextView tvTitle = view.FindViewById<TextView>(Resource.Id.tvName);

            TextView tvSubTitle = view.FindViewById<TextView>(Resource.Id.tvType);

            TextView tvAge = view.FindViewById<TextView>(Resource.Id.tvAge);

            TextView tvPrice = view.FindViewById<TextView>(Resource.Id.tvPrice);

            ImageView ivProduct = view.FindViewById<ImageView>(Resource.Id.ivProduct);

            Toy temp = objects[position];//שולף את האיבר במקום הפוסישין

            if (temp != null)

            {
                //אם התנאי מתקיים אז הוא מקבל ומציג את התכונות
                Bitmap bitmap = Helper.Base64ToBitmap(temp.bitmap);
                ivProduct.SetImageBitmap(bitmap);

                tvPrice.Text = "" + temp.GetPrice();

                tvTitle.Text = temp.GetName();

             

                tvAge.Text = "" + temp.GetAge();

            }

            return view;//מחזיר התא למקום
        }

        public override int Count

        {

            get { return this.objects.Count; }

        }

        public override WarToy this[int position]
        {
            get { return this.objects[position]; }
        }
    }
}