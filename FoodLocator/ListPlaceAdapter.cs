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
using Bumptech.Glide;

namespace FoodLocator
{
    class ListPlaceAdapter : BaseAdapter<ListPlace>
    {
        private List<ListPlace> listData;
        private Activity context;
        private PopupMenu mypopup;
        private ListPlace clickedItem;
        //Database db;
        public ListPlaceAdapter(Activity listActivity, List<ListPlace> listData) : base()
        {
            this.context = listActivity;
            this.listData = listData;
            //db = new Database();
        }


        public override ListPlace this[int position]
        {
            get
            {
                return listData[position];
            }
        }

        public override int Count
        {
            get
            {
                return listData.Count;
            }

        }


        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if (convertView == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.restaurantsList, null, false);
            }
            ListPlace item = this[position];
            view.FindViewById<TextView>(Resource.Id.textView1).Text = item.PlaceName;
            view.FindViewById<TextView>(Resource.Id.textView3).Text = item.ReviewMark;

            ImageView myimage = view.FindViewById<ImageView>(Resource.Id.imageButton1);
            Glide.With(context).Load(item.Image).Into(myimage);

            return view;
        }
    }
}