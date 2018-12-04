using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Bumptech.Glide;

namespace FoodLocator
{
    [Activity(Label = "PlaceDetail")]
    public class PlaceDetail : AppCompatActivity
    {
        ImageView image;
        string imageURL;
        TextView PlaceName;
        TextView Phone;
        TextView Address;
        TextView Menus;
        string Placename;
        Button mapLocation;
        Button addReview;

        private MongoDBService mdb;
        //static LayoutInflater layoutMapviewDialog;
        Android.Support.V7.App.AlertDialog.Builder builder;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.placedetail);
            Android.Support.V7.App.ActionBar actionBar = this.SupportActionBar;

            actionBar.SetHomeButtonEnabled(true);
            actionBar.SetDisplayHomeAsUpEnabled(true);

            image = FindViewById<ImageView>(Resource.Id.imageView1);
            PlaceName = FindViewById<TextView>(Resource.Id.placename);
            Phone = FindViewById<TextView>(Resource.Id.phone);
            Address = FindViewById<TextView>(Resource.Id.address);
            Menus = FindViewById<TextView>(Resource.Id.menus);
            mapLocation = FindViewById<Button>(Resource.Id.location);
            addReview = FindViewById<Button>(Resource.Id.addreview);

            Placename = Intent.GetStringExtra("placename");

            showDetails(Placename);

            addReview.Click += delegate
            {
                var intent = new Intent(this, typeof(AddReview));

                intent.PutExtra("placename", PlaceName.Text);
                StartActivity(intent);
            };

            mapLocation.Click += delegate
            {
                var intent = new Intent(this, typeof(ShowMap));

                intent.PutExtra("placename", PlaceName.Text);
                StartActivity(intent);
            };

            //mapLocation.Click += mapShow;
        }

        private void showDetails(string Placename)
        {
            mdb = new MongoDBService();
            List<mdbplaces> mdbdata = mdb.GetPlaceDetails(Placename);

            foreach (var place in mdbdata)
            {

                PlaceName.Text = place.placename;
                Phone.Text = place.mark;
                Address.Text = place.address;
                Menus.Text = place.menus;
                imageURL = place.imageURL;
            }
            Glide.With(this).Load(imageURL).Into(image);
        }

        public void mapShow(object sender, EventArgs e)
        {

            View mView = LayoutInflater.Inflate(Resource.Layout.showmap, null);

            builder = new Android.Support.V7.App.AlertDialog.Builder(this);
            builder.SetView(mView);
            builder.SetTitle(PlaceName.Text);

            //ViewGmap gmap = new ViewGmap();
            ShowMap gmap = new ShowMap();
        

            builder.SetCancelable(false)
            .SetNegativeButton("Cancel", delegate
            {
                builder.Dispose();
            });

            Android.Support.V7.App.AlertDialog mapdialog = builder.Create();
            mapdialog.Show();

        }
    }
}