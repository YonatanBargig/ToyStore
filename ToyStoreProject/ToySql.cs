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
    [Table("ToySql")]
   public class ToySql
    {
        [PrimaryKey, AutoIncrement, Column("_id")]//מפתח ראשי שמסיפרו עולה באופן אוטומטי על ידי המחשב
        public int Id { get; set; }//idשל מוצר 
        public int Price { get; set; }//מחיר
        public string name { get; set; }//שם צעצוע
        public string pic { get; set; }//תמונה
        


        public ToySql()//פעולה בונה ריקה
        {



        }
        public ToySql( String Name, int price, string Pic)//פעולה בונה עם פרמטרים
        {
            name = Name;
            Price = price;
            pic = Pic;
        }
        
    }
}