﻿using System;
using System.Collections.Generic;
using System.IO;
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

namespace ToyStoreProject.Resources
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        EditText txtcreditcard;
        EditText txtusername;
        EditText txtPassword;
        Button btncreate;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Register);
            btncreate = FindViewById<Button>(Resource.Id.btn_reg_create);
            txtusername = FindViewById<EditText>(Resource.Id.txt_reg_username);
            txtPassword = FindViewById<EditText>(Resource.Id.txt_reg_password);
            txtcreditcard = FindViewById<EditText>(Resource.Id.txt_credit_card);
            btncreate.Click += Btncreate_Click; ;
            // Create your application here
        }

        private void Btncreate_Click(object sender, EventArgs e)//שמירת הנתונים לשימוש חוזר
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
                var db = new SQLiteConnection(dpPath);
                db.CreateTable<LoginTable>();
                LoginTable tbl = new LoginTable();  
                tbl.username = txtusername.Text;
                tbl.password = txtPassword.Text;
                tbl.creditcard = txtcreditcard.Text;
                db.Insert(tbl);
                Toast.MakeText(this, "Record Added Successfully...,", ToastLength.Short).Show();
                StartActivity(typeof(CustomerActivity));
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}