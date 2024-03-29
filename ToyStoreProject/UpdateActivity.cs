﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ToyStoreProject.Resources.layout;

namespace ToyStoreProject
{
    [Activity(Label = "UpdateActivity")]
    public class UpdateActivity : Activity, Android.Views.View.IOnClickListener
    {
        ImageView ivProduct;
        TextView tvTitle, tvAge, tvPrice, tvpayment;
        Button btncalculate, btnaddtomylist, btncancle;
        EditText etamount;
        int pos = -1, pos1 = -1, pos2 = -1;
        SportToy temp;
        WarToy temp1;
        Boxgames temp2;
        string pw1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.updateamount);
            // Create your application here
            ivProduct = FindViewById<ImageView>(Resource.Id.ivProduct);
            tvTitle = FindViewById<TextView>(Resource.Id.tvTitle);
            tvAge = FindViewById<TextView>(Resource.Id.tvprudactid);
            tvPrice = FindViewById<TextView>(Resource.Id.tvPrice);
            tvpayment = FindViewById<TextView>(Resource.Id.tvpayment);
            etamount = FindViewById<EditText>(Resource.Id.etamount);
            btnaddtomylist = FindViewById<Button>(Resource.Id.btnaddtomylist);
            btnaddtomylist.SetOnClickListener(this);
            btncalculate = FindViewById<Button>(Resource.Id.btncalculate);
            btncalculate.SetOnClickListener(this);
            btncancle = FindViewById<Button>(Resource.Id.btncancle);
            btncancle.SetOnClickListener(this);
            //קליטה מאיזה רשימה
            pos = Intent.GetIntExtra("pos", -1);
            pos1 = Intent.GetIntExtra("pos1", -1);
            pos2 = Intent.GetIntExtra("pos2", -1);
            if (pos != -1)//בדיקה מאיזה רשימה
            {
                temp = SportToyActivity.SporttoyList[pos];
                pw1 = temp.GetPic();
                ivProduct.SetImageBitmap(Helper.Base64ToBitmap(pw1));
                tvAge.Text = temp.GetAge().ToString();
                tvTitle.Text = temp.GetName();
                tvPrice.Text = temp.GetPrice().ToString();
                tvpayment.Text = "0";

            }
           else if (pos1 != -1)
            {
                temp1 = WarToyActivity.WarToyList[pos1];
                pw1 = temp1.GetPic();
                ivProduct.SetImageBitmap(Helper.Base64ToBitmap(pw1));
                tvAge.Text = temp1.GetAge().ToString();
                tvTitle.Text = temp1.GetName();
                tvPrice.Text = temp1.GetPrice().ToString();
                tvpayment.Text = "0";
            }
            else if (pos2 != -1)
            {
                temp2 = BoxGamesActivity.boxgamesList[pos2];
                pw1 = temp2.GetPic();
               ivProduct.SetImageBitmap(Helper.Base64ToBitmap(pw1));
                tvAge.Text = temp2.GetAge().ToString();
                tvTitle.Text = temp2.GetName();
                tvPrice.Text = temp2.GetPrice().ToString();
                tvpayment.Text = "0";
            }
           
        }
        public void OnClick(View v)
        {
            if (btncancle == v)
            {
                Intent intent = new Intent(this, typeof(SportToyActivity));
                StartActivity(intent);
            }
            if (btncalculate == v)//חישוב הכמות
            {
                int x = int.Parse(tvPrice.Text);
                int y = int.Parse(etamount.Text);
                tvpayment.Text = (x * y).ToString();
            }
            if (btnaddtomylist == v)//העברת עצמים לרשימת קניות
            {
                Intent intent = new Intent(this, typeof(ShopingCartActivity));
                int p = int.Parse(tvpayment.Text);
                 intent.PutExtra("pos",pos);
                intent.PutExtra("pos1", pos1);
                intent.PutExtra("pos2", pos2);
                intent.PutExtra("price1", p);          
                StartActivity(intent);
            }
        }
    }
    }
