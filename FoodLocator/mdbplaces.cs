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
using MongoDB.Bson;

namespace FoodLocator
{
    class mdbplaces
    {
        public ObjectId _id { get; set; }
        //public int id { get; set; }
        public string placename { get; set; }
        public string mark { get; set; }
        public string imageURL { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string menus { get; set; }
    }
}