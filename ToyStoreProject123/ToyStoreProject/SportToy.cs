﻿using System;
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
using SQLite;

namespace ToyStoreProject
{
   // [Table("SportToy")]
    public class SportToy : Toy
    {

        private string sporttype; //משתנה סוג ספורט
        public SportToy()// פעולה בונה ריקה
        {

        }
        public SportToy(string name, int price, Bitmap pic, int age, string sporttype) : base(name, price, pic, age)// פעולה בונה פרמטרים
        {
            this.name = name;
            this.price = price;
            this.Pic = pic;
            this.age = age;
            this.sporttype = sporttype;
        }
        public string GetSportType()
        {
            return sporttype;
        }
        public void SetType(string type)
        {
            this.sporttype = type;
        }

       /* public override string Tostring()
        {
            return ("sport toy" + this.name + "this price is" + this.price);
        }*/
    }
}