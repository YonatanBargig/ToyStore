using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace ToyStoreProject
{
    public class WarToy : Toy
    {
        
        private string weapon { get; set; } //משתנה סוג כלי נשק
        public WarToy()//פעולה בונה ריקה
        {
        }
        public WarToy(string toyid,string name, int price, string bitmap, int age,string weapon) : base(toyid,name, price, bitmap, age)//פעולה בונה עם פרמטרים
        {
            this.name = name;
            this.price = price;
            this.bitmap = bitmap;
            this.age = age;
            this.weapon = weapon;
        }
        public string GetWeapon()
        {
            return weapon;
        }
        public void SetWeapon(string wepon)
        {
            this.weapon = weapon;
        }

      /*  public override string Tostring()
        {
            return ("WarToy" + this.name + "this price is" + this.price);
        }*/
    }
}