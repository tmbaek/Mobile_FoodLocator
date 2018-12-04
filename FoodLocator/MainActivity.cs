using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Xamarin.Facebook.Login.Widget;
using Xamarin.Facebook;
using System.Collections.Generic;
using System;
using Android.Content;

namespace FoodLocator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IFacebookCallback
    {
        private ICallbackManager mFBCallManager;
        private MyProfileTracker mprofileTracker;
        private TextView TxtFirstName;
        //private TextView TxtLastName;
        //private TextView TxtName;
        private ProfilePictureView mprofile;
        LoginButton BtnFBLogin;

        private ImageView btnBirth;
        private ImageView btnDating;
        private ImageView btnBrunch;
        private ImageView btnGroupMeal;
        //public string username;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);            

            FacebookSdk.SdkInitialize(this.ApplicationContext);
            mprofileTracker = new MyProfileTracker();
            mprofileTracker.mOnProfileChanged += mProfileTracker_mOnProfileChanged;
            mprofileTracker.StartTracking();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            BtnFBLogin = FindViewById<LoginButton>(Resource.Id.fblogin);
            TxtFirstName = FindViewById<TextView>(Resource.Id.TxtFirstname);
            //TxtLastName = FindViewById<TextView>(Resource.Id.TxtLastName);
            //TxtName = FindViewById<TextView>(Resource.Id.TxtName);
            mprofile = FindViewById<ProfilePictureView>(Resource.Id.ImgPro);
            BtnFBLogin.SetReadPermissions(new List<string> {
                "user_friends",
                "public_profile"
            });
            mFBCallManager = CallbackManagerFactory.Create();
            BtnFBLogin.RegisterCallback(mFBCallManager, this);

            btnBirth = FindViewById<ImageView>(Resource.Id.imageView1);
            btnBrunch = FindViewById<ImageView>(Resource.Id.imageView2);
            btnDating = FindViewById<ImageView>(Resource.Id.imageView3);            
            btnGroupMeal = FindViewById<ImageView>(Resource.Id.imageView4);

            btnBirth.Click += delegate
            {
                var intent = new Intent(this, typeof(ListPlaceActivity));
                //var intent = new Intent(this, typeof(DatafromMongo));
                intent.PutExtra("collection", "places");
                StartActivity(intent);
            };
            btnDating.Click += delegate
            {
                var intent = new Intent(this, typeof(ListPlaceActivity));
                //var intent = new Intent(this, typeof(DatafromMongo));
                intent.PutExtra("collection", "romantic");
                StartActivity(intent);
            };
            btnBrunch.Click += delegate
            {
                var intent = new Intent(this, typeof(ListPlaceActivity));
                //var intent = new Intent(this, typeof(DatafromMongo));
                intent.PutExtra("collection", "brunch");
                StartActivity(intent);
            };
            btnGroupMeal.Click += delegate
            {
                var intent = new Intent(this, typeof(ListPlaceActivity));
                //var intent = new Intent(this, typeof(DatafromMongo));
                intent.PutExtra("collection", "groupmeal");
                StartActivity(intent);
            };
        }

        public void OnCancel() { }
        public void OnError(FacebookException p0) { }
        public void OnSuccess(Java.Lang.Object p0) { }
        void mProfileTracker_mOnProfileChanged(object sender, OnProfileChangedEventArgs e)
        {
            if (e.mProfile != null)
            {
                try
                {
                    TxtFirstName.Text = "Welcome " + e.mProfile.FirstName;
                    //TxtLastName.Text = e.mProfile.LastName;
                    //TxtName.Text = e.mProfile.Name;
                    //username = e.mProfile.Name;
                    mprofile.ProfileId = e.mProfile.Id;
                }
                catch (Java.Lang.Exception ex) { }
            }
            else
            {
                TxtFirstName.Text = "Welcome";
                //TxtLastName.Text = "Last Name";
                //TxtName.Text = "Name";
                //username = "Unknown";
                mprofile.ProfileId = null;
            }
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Android.Content.Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            mFBCallManager.OnActivityResult(requestCode, (int)resultCode, data);
        }

        public class MyProfileTracker : ProfileTracker
        {
            public event EventHandler<OnProfileChangedEventArgs> mOnProfileChanged;
            protected override void OnCurrentProfileChanged(Profile oldProfile, Profile newProfile)
            {
                if (mOnProfileChanged != null)
                {
                    mOnProfileChanged.Invoke(this, new OnProfileChangedEventArgs(newProfile));
                }
            }
        }
        public class OnProfileChangedEventArgs : EventArgs
        {
            public Profile mProfile;
            public OnProfileChangedEventArgs(Profile profile)
            {
                mProfile = profile;
            }
            
        }

    }
}