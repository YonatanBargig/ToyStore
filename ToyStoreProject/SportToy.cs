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
using SQLite;

namespace ToyStoreProject
{
  
    public class SportToy : Toy
    {

        private string sporttype; //משתנה סוג ספורט
        public SportToy()// פעולה בונה ריקה
        {

        }
        public SportToy(string toyid,string name, int price, string bitmap, int age, string sporttype) : base(toyid,name, price,bitmap, age)// פעולה בונה פרמטרים
        {
            this.name = name;
            this.price = price;
            this.bitmap = bitmap;
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

    }
}