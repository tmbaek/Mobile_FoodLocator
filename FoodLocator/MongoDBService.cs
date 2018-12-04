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

        public List<mdbplaces> GetMongoData(string collection_name)
        {

            string connectionString = "mongodb+srv://tmbaek:etech1234@cluster0-frtj2.mongodb.net/test?retryWrites=true";
            client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("BestPlace");

            //IMongoCollection<mdbplaces> collection = db.GetCollection<mdbplaces>("places");
            IMongoCollection<mdbplaces> collection = db.GetCollection<mdbplaces>(collection_name);
            //string filter = "FilterDefinition<BsonDocument>.Empty";
            List<mdbplaces> list = collection.Find(FilterDefinition<mdbplaces>.Empty)
                .ToList();

            return list;
        }

        public List<mdbplaces> GetPlaceDetails(string Placename)
        {

            string connectionString = "mongodb+srv://tmbaek:etech1234@cluster0-frtj2.mongodb.net/test?retryWrites=true";
            client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("BestPlace");

            IMongoCollection<mdbplaces> collection = db.GetCollection<mdbplaces>("places");
            var filter = new BsonDocument("placename", Placename);
            List<mdbplaces> list = collection.Find(filter)
                .ToList();
            //.FirstOrDefault();

            return list;
        }

        public void InsertMongoData(string DBname, string Collectionname, BsonDocument place)
        {

            string connectionString = "mongodb+srv://tmbaek:etech1234@cluster0-frtj2.mongodb.net/test?retryWrites=true";
            client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase(DBname);

            var collection = db.GetCollection<BsonDocument>(Collectionname);
            collection.InsertOne(place);
        }
    }

    
}