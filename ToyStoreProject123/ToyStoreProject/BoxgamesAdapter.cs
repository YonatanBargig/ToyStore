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

namespace ToyStoreProject
{
    class BoxgamesAdapter : BaseAdapter<Boxgames>
    {
        Android.Content.Context context;
        List<Boxgames> objects;
        public BoxgamesAdapter(Android.Content.Context context, System.Collections.Generic.List<Boxgames> objects)
        {

            this.context = context;

            this.objects = objects;

        }



        public List<Boxgames> GetList()

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
            Android.Views.LayoutInflater layoutInflater = ((BoxGamesActivity )context).LayoutInflater;

            Android.Views.View view = layoutInflater.Inflate(Resource.Layout.Custom2, parent, false);

            TextView tvTitle = view.FindViewById<TextView>(Resource.Id.tvName);

            TextView tvmin = view.FindViewById<TextView>(Resource.Id.tvmin);

            TextView tvmax = view.FindViewById<TextView>(Resource.Id.tvmax);

            TextView tvAge = view.FindViewById<TextView>(Resource.Id.tvAge);

            TextView tvPrice = view.FindViewById<TextView>(Resource.Id.tvPrice);

            ImageView ivProduct = view.FindViewById<ImageView>(Resource.Id.ivProduct);

            Boxgames temp = objects[position];

            if (temp != null)

            {


                ivProduct.SetImageBitmap(temp.GetPic());

                tvPrice.Text = "" + temp.GetPrice();

                tvTitle.Text = temp.GetName();

                tvmin.Text = "" + temp.GetMinpart();

                tvmax.Text = "" + temp.GetMaxpart();

                tvAge.Text = "" + temp.GetAge();

            }

            return view;
        }

        public override int Count

        {

            get { return this.objects.Count; }

        }

        public override Boxgames this[int position] 
        {


            get { return this.objects[position]; }


        }
    }
}