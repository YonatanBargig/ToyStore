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
   
    public class Toy
    {
        [PrimaryKey, Column("_id")] //מפתח ראשי שמסיפרו עולה באופן אוטומטי על ידי המחשב
        public string toyid { get; set; }//משתנה ת.ז
        public string name; //משתנה שם
        public int price;//משתנה מחיר
        public string bitmap;//משתנה תמונה
        public int age;//משתנה גיל 
        public Toy()//פעולה בונה ריקה
        {
        }
        public Toy(string toyid,string name, int price, string bitmap, int age)//פעולה בונה עם פרמטרים
        {
            this.toyid = toyid;
            this.name = name;
            this.price = price;
            this.bitmap = bitmap;
            this.age = age;
        }
        public void setToy(string toyid, string name, int price, string bitmap, int age)
        {

            this.toyid = toyid;
            this.name = name;
            this.price = price;
            this.bitmap = bitmap;
            this.age = age;

        }
        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public int GetPrice()
        {
            return price;
        }
        public void SetPrice(int price)
        {
            this.price = price;
        }
        public string GetPic()
        {
            return bitmap;
        }
        public void SetPic(string pic)
        {
            this.bitmap = pic;
        }


        public int GetAge()
        {
            return age;
        }
        public void SetAge(int age)
        {
            this.age = age;
        }

        
        
    }

}
    