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

namespace ToyStoreProject.Resources.layout
{
    [Activity(Label = "CustomerActivity")]
    public class CustomerActivity : Activity
    {
        Button btnSporttoy,btnboxgames, btnwartoy, btnAboutUs,btnCart;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Customer);
            btnSporttoy = FindViewById<Button>(Resource.Id.btnsporttoy);
            btnSporttoy.Click += BtnSporttoy_Click;
            btnboxgames = FindViewById<Button>(Resource.Id.btnsboxgames);
            btnboxgames.Click += Btnboxgames_Click;
            btnwartoy = FindViewById<Button>(Resource.Id.btnwartoy);
            btnwartoy.Click += Btnwartoy_Click;
            btnAboutUs = FindViewById<Button>(Resource.Id.btnAbout);
            btnAboutUs.Click += btnAboutUs_Click;
            btnCart = FindViewById<Button>(Resource.Id.btncart);
            btnCart.Click += btnCart_Click;
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ShopingCartActivity));
            StartActivity(intent);
        }

        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AboutUSActivity));
            StartActivity(intent);
        }

        private void Btnwartoy_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(WarToyActivity));
            StartActivity(intent);
        }

        private void Btnboxgames_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(BoxGamesActivity));
            StartActivity(intent);
        }

        private void BtnSporttoy_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SportToyActivity));
            StartActivity(intent);
        }
    }
}