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
using SQLite;

namespace ToyStoreProject
{
    [Table("Toys")]
    class ToySql
    {
        [PrimaryKey, AutoIncrement, Column("_id")]//מפתח ראשי שמסיפרו עולה באופן אוטומטי על ידי המחשב
        public int Id { get; set; }
        public int Price { get; set; }
        public String name { get; set; }
        public int pic { get; set; }
        public int age { get; set; }


        public ToySql()
        {



        }
        public ToySql( String Name, int price, int Pic, int Age)
        {
            name = Name;
            Price = price;
            pic = Pic;
            age = Age;


        }
        public void SetToySql(int id, String Name, int price, int Pic, int Age)
        {
            this.Id = id;
            this.name = Name;
            this.Price = price;
            this.pic = Pic;
            this.age = Age;

        }
    }
}