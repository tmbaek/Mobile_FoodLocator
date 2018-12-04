using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FoodLocator
{
    [Activity(Label = "ShowMap")]
    public class ShowMap : Activity, IOnMapReadyCallback
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.showmap);
            // Create your application here

            MapFragment mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            LatLng location = new LatLng(43.7770931, -79.41465568);
            MarkerOptions markerOptions = new MarkerOptions();
            //markerOptions.SetPosition(new LatLng(30, 120));
            markerOptions.SetPosition(location);
            markerOptions.SetTitle("Ivan's Burrito House");
            googleMap.AddMarker(markerOptions);

            googleMap.MapType = GoogleMap.MapTypeHybrid;


            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(location);
            //builder.Zoom(18);

            CameraPosition cameraPosition = builder.Build();
            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

            googleMap.MoveCamera(cameraUpdate);

        }    
    }
}