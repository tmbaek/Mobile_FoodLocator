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
    class MongoDBService
    {
        MongoClient client;
        public List<mdbplaces> GetMongoData()
        {

            string connectionString = "mongodb+srv://tmbaek:etech1234@cluster0-frtj2.mongodb.net/test?retryWrites=true";
            client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("BestPlace");

            IMongoCollection<mdbplaces> collection = db.GetCollection<mdbplaces>("places");
            //string filter = "FilterDefinition<BsonDocument>.Empty";
            List<mdbplaces> list = collection.Find(FilterDefinition<mdbplaces>.Empty)
                .ToList();

            return list;
        }

        public void InsertMongoData()
        {

            string connectionString = "mongodb+srv://tmbaek:etech1234@cluster0-frtj2.mongodb.net/test?retryWrites=true";
            client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("BestPlace");

            var collection = db.GetCollection<BsonDocument>("places");
            // Insert document
            BsonDocument place = new BsonDocument
            {
                {"placename", "Ivan's Bruito House"},
                {"mark", "*****"}
            };

            collection.InsertOne(place);


        }
    }

    
}