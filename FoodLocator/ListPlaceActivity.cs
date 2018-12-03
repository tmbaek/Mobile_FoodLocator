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

namespace FoodLocator
{
    [Activity(Label = "ListPlaceActivity")]
    public class ListPlaceActivity : Activity
    {
        ListView mylist;
        ProgressBar progressBar;
        ListPlaceAdapter myadapter;
        MongoDBService mdb;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.listplace);
            mylist = FindViewById<ListView>(Resource.Id.listView1);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);
            showData();

        }

        private List<ListPlace> GenerateListData()
        {
            List<ListPlace> data = new List<ListPlace>();
            mdb = new MongoDBService();
            List<mdbplaces> mdbdata = mdb.GetMongoData();
            int i = 0;
            foreach (var place in mdbdata)
            {                
                ListPlace obj = new ListPlace();
                obj.Id = i;
                obj.PlaceName = place.placename;
                obj.ReviewMark = place.mark;
                obj.Image = place.imageURL;
                //db.InsertItem(obj);
                data.Add(obj);
                i++;
            }
            
            return data;
        }

        private void showData()
        {
            List<ListPlace> dataList;
            progressBar.Visibility = ViewStates.Visible;

            dataList = GenerateListData();
            progressBar.Visibility = ViewStates.Gone;
            myadapter = new ListPlaceAdapter(this, dataList);
            mylist.Adapter = myadapter;
        }
    }
}