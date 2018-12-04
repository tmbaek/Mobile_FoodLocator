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
    [Activity(Label = "AddReview")]
    public class AddReview : Activity
    {
        TextView placename;
        string reviewmark;
        
        EditText inputComment;
        Button submitReview;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.addreview);
            placename = FindViewById<TextView>(Resource.Id.textView3);
            placename.Text = Intent.GetStringExtra("placename");


            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner1);

            var adapter = ArrayAdapter.CreateFromResource(this,
                    Resource.Array.reviewMark, Android.Resource.Layout.SimpleSpinnerDropDownItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            spinner.ItemSelected += SpinnerItemSelected;


            inputComment = FindViewById<EditText>(Resource.Id.EditText1);
            submitReview = FindViewById<Button>(Resource.Id.button1);
            submitReview.Click += insertReview;            
        }

        private void insertReview(object sender, EventArgs e)
        {
            MongoDBService mdb = new MongoDBService();
            string DBname = "Review";
            string Collectionname = "user_reviews";
            BsonDocument place = new BsonDocument
            {
                {"placename", placename.Text},
                {"marks", reviewmark},
                {"comment", inputComment.Text}
            };

            try
            {
                mdb.InsertMongoData(DBname, Collectionname, place);
                Toast.MakeText(this, "Successfully Submitted. Thank you for your review", ToastLength.Long).Show();
            }
            catch
            {
                Toast.MakeText(this, "Failed", ToastLength.Short).Show();
            }

        }

        private void SpinnerItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            reviewmark = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, reviewmark + "selected", ToastLength.Long).Show();
        }
    }
}