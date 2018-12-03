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
using MongoDB.Driver;

namespace FoodLocator
{
    [Activity(Label = "DatafromMongo")]
    public class DatafromMongo : Activity
    {
        ImageButton imagebutton1;
        //TextView review;
        TextView place_name;
        TextView marks;
        MongoClient client;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.layout1);

            imagebutton1 = FindViewById<ImageButton>(Resource.Id.imageButton1);
            //review = FindViewById<TextView>(Resource.Id.textView3);
            place_name = FindViewById<TextView>(Resource.Id.textView1);
            marks = FindViewById<TextView>(Resource.Id.textView3);
            imagebutton1.Click += GetMongoData;

        }

        private void GetMongoData(object sender, EventArgs e)
        {

            string connectionString = "mongodb+srv://tmbaek:etech1234@cluster0-frtj2.mongodb.net/test?retryWrites=true";
            client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("BestPlace");
            //Places place = new Places
            //{
            //    Id = 1,
            //    PlaceName = "Ivan's Bruito House",
            //    Mark = "*****"
            //};
            //var collection = db.GetCollection<Places>("places");
            //collection.InsertOne(place);

            //// Insert many document
            //var collection = db.GetCollection<BsonDocument>("places");
            //BsonDocument place1 = new BsonDocument
            //{
            //    {"id", 1},
            //    {"placename", "Ivan's Bruito House"},
            //    {"mark", "*****"}
            //};
            //BsonDocument place2 = new BsonDocument
            //{
            //    {"id", 2},
            //    {"placename", "Burger King"},
            //    {"mark", "****"}
            //};
            //BsonDocument place3 = new BsonDocument
            //{
            //    {"id", 2},
            //    {"placename", "KEG Steak House"},
            //    {"mark", "*****"}
            //};
            //List<BsonDocument> place = new List<BsonDocument>();
            //place.Add(place1);
            //place.Add(place2);
            //place.Add(place3);

            //try
            //{
            //    collection.InsertMany(place);

            //    //review.Text = "Sucess";
            //    Toast.MakeText(this, "Successfully Added", ToastLength.Short).Show();
            //}
            //catch
            //{
            //    review.Text = "Fail";
            //    Toast.MakeText(this, "Failed", ToastLength.Short).Show();
            //}

            IMongoCollection<Place> collection = db.GetCollection<Place>("places");
            string filter = "{mark: '****'}";
            List<Place> list = collection.Find(filter)
                .ToList();

            foreach (var place in list)
            {
                place_name.Text = place.placename;
                marks.Text = place.mark;
            }
        }

        
        public class Place
        {
            public ObjectId _id { get; set; }
            //public int id { get; set; }
            public string placename { get; set; }
            public string mark { get; set; }
        }
    

    }
}