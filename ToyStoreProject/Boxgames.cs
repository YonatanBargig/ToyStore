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
    public class Boxgames : Toy
    {
        
        private int minpart { get; set; }//משתנה מספר משתתפים מינמלי
        private int maxpart { get; set; }//משתנה מספר משתתפים מקסימלי
        public Boxgames()//פעולה בונה ריקה 
        {
        }
        public Boxgames(string toyid,string name, int price, string bitmap, int age, int minpart, int maxpart):base(toyid,name, price,bitmap,age)//פעולה בונה עם פרמטרים
        {
            this.name = name;
            this.price = price;
            this.bitmap = bitmap;
            this.age = age;
            this.minpart = minpart;
            this.maxpart = minpart;
        }
        public int GetMinpart()
        {
            return minpart;
        }
        public void SetMinpart(int minpart)
        {
            this.minpart = minpart;
        }
        public int GetMaxpart()
        {
            return maxpart;
        }
        public void SetMaxpart(int maxpart)
        {
            this.maxpart = maxpart;
        }
        /* public override string Tostring()
         {
             return ("boxgame" + this.name + "this price is" + this.price);
         }*/
    }
}