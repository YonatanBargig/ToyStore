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
    class CartAdapter : BaseAdapter<Toy>
    {
        Android.Content.Context context;
        List<Toy> objects;
        public CartAdapter(Android.Content.Context context, System.Collections.Generic.List<Toy> objects)
        {

            this.context = context;

            this.objects = objects;

        }



        public List<Toy> GetList()

        {

            return this.objects;

        }



        public override long GetItemId(int position)

        {

            return position;

        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
           // LayoutInflater layoutInflater = LayoutInflater.From(context);
            Android.Views.LayoutInflater layoutInflater = ((CartListActivty)context).LayoutInflater;

            Android.Views.View view = layoutInflater.Inflate(Resource.Layout.Custom4, parent, false);

            TextView tvTitle = view.FindViewById<TextView>(Resource.Id.tvName);


            TextView tvAge = view.FindViewById<TextView>(Resource.Id.tvAge);

            TextView tvPrice = view.FindViewById<TextView>(Resource.Id.tvPrice);

            ImageView ivProduct = view.FindViewById<ImageView>(Resource.Id.ivProduct);
            ivProduct.Click += delegate
            {
                Toast.MakeText(Application.Context, "num of click" + position, ToastLength.Short).Show();
            };
            
                Toy temp = objects[position];
            
            if (temp != null)

            {

                Bitmap bitmap = Helper.Base64ToBitmap(temp.bitmap);
                ivProduct.SetImageBitmap(bitmap);

                tvPrice.Text = "" + temp.GetPrice();

                tvTitle.Text = temp.GetName();

                tvAge.Text = "" + temp.GetAge();

            }

            return view;
        }

        public override int Count

        {

            get { return this.objects.Count; }

        }

        

        public override Toy this[int position]
        {


            get { return this.objects[position]; }
        }
    }
}