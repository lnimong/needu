using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Xamarin.Facebook;
using Xamarin.Forms;
using Android.Content;
using FFImageLoading.Forms.Droid;
using Acr.UserDialogs;

namespace Need_U.Droid


{
    [Activity(Label = "Need-U", Icon = "@drawable/logoNav",  ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        public static ICallbackManager CallbackManager = CallbackManagerFactory.Create();
        public static readonly string[] PERMISSIONS = new[] { "public_profile", "email", "user_birthday", "user_location" };

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            FacebookSdk.SdkInitialize(this.ApplicationContext);
            Forms.Init(this, bundle);
            LoadApplication(new App());


            Xamarin.FormsMaps.Init(this, bundle);
            CachedImageRenderer.Init();
            UserDialogs.Init(this);

            //if(isLoggedIn() == true)
            //{

            //}


        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            CallbackManager.OnActivityResult(requestCode, (int)resultCode, data);
        }


        public bool isLoggedIn()
        {
            AccessToken accessToken = AccessToken.CurrentAccessToken;
            return accessToken != null;
        }


    }
}

