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
    [Table("toys")]
    public class Toy
    {
        [PrimaryKey, AutoIncrement, Column("_id")] //מפתח ראשי שמסיפרו עולה באופן אוטומטי על ידי המחשב
        public int id { get; set; }//משתנה ת.ז
        public string name; //משתנה שם
        public int price;//משתנה מחיר
        public string PicS;
       public Bitmap Pic;//משתנה תמונה
        public int age;//משתנה גיל 
        public Toy()//פעולה בונה ריקה
        {
        }                               
        public Toy(string name, int price, Bitmap pic, int age)//פעולה בונה עם פרמטרים
        {
            this.name = name;
            this.price = price;
            this.Pic = pic;
            this.age = age;
        }
        public Toy(string name, int price, string pics, int age)//פעולה בונה עם פרמטרים
        {
            this.name = name;
            this.price = price;
            this.PicS = pics;
            this.age = age;
        }
        public void setToy(int id, string name, int price, Bitmap pic, int age)
        {

            this.id = id;
            this.name = name;
            this.price = price;
            this.Pic = pic;
            this.age = age;

        }
        public void setToy(int id, string name, int price, string picS, int age)
        {

            this.id = id;
            this.name = name;
            this.price = price;
            this.PicS = picS;
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
        public Bitmap GetPic()
        {
            return Pic;
        }
        public void SetPic(Bitmap pic)
        {
            this.Pic = pic;
        }
        public string GetPicS()
        {
            return PicS;
        }
        public void SetPicS(string pic)
        {
            this.PicS = pic;
        }


        public int GetAge()
        {
            return age;
        }
        public void SetAge(int age)
        {
            this.age = age;
        }

        //public string Tostring();
        
    }

}
    