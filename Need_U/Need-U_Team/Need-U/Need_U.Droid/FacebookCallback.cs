using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Org.Json;
using Java.Lang;
using Need_U.Entities;
using Newtonsoft.Json;
using Need_U.Service;
using PCLStorage;
using Acr.UserDialogs;

namespace Need_U.Droid


{

    public class FacebookCallback<TResult> : Java.Lang.Object, GraphRequest.IGraphJSONObjectCallback, IFacebookCallback where TResult : Java.Lang.Object
    {
        public Action HandleCancel { get; set; }
        public Action<FacebookException> HandleError { get; set; }
        public Action<TResult> HandleSuccess { get; set; }

        public void OnCancel()
        {
            var c = HandleCancel;
            if (c != null)
                c();
        }

        public void OnError(FacebookException error)
        {
            var c = HandleError;
            if (c != null)
                c(error);
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            var c = HandleSuccess;
            if (c != null)
                c(result.JavaCast<TResult>());


            GraphRequest request = new GraphRequest();

            request = GraphRequest.NewMeRequest(AccessToken.CurrentAccessToken, this);
            

            Bundle parameters = new Bundle();
            parameters.PutString("fields", "first_name,last_name,name,picture{url},email,birthday,gender,location,locale");
            request.Parameters = parameters;
            request.ExecuteAsync();




        }
        

        public async void OnCompleted(JSONObject p0, GraphResponse p1)
        {

            Console.WriteLine(p0.ToString());

            EntityUser theUser = new EntityUser();

            FacebookUser theUserFromFacebook = new FacebookUser();            
            theUserFromFacebook =  JsonConvert.DeserializeObject<FacebookUser>(p0.ToString());



            // Insert User in DataBase


            theUser.FirstName = theUserFromFacebook.first_name;
            theUser.LastName = theUserFromFacebook.last_name;

            if (theUserFromFacebook.gender == "male")
            {
                theUser.Sex = true;
            }

            if (theUserFromFacebook.gender == "female")
            {
                theUser.Sex = false;
            }



            if (string.IsNullOrWhiteSpace(theUserFromFacebook.gender) || string.IsNullOrEmpty(theUserFromFacebook.gender))
           {
                var result = await UserDialogs.Instance.ConfirmAsync(new ConfirmConfig
                {
                    Title = "Gender",
                    Message = "Are you a man ?",
                    OkText = "YES",
                    CancelText = "NO"
                    
                });

                if(result == true)
                {
                    theUser.Sex = true;
                }

                if (result == false)
                {
                    theUser.Sex = false;
                }

            }
            
            theUser.NickName = theUserFromFacebook.name;


            if (string.IsNullOrEmpty(theUser.NickName) || string.IsNullOrWhiteSpace(theUser.NickName))
            {
                // Show dialog box to ask email 
                var result = await UserDialogs.Instance.PromptAsync(new PromptConfig
                {
                    InputType = InputType.Default,
                    Title = "Your nickname",
                    Text = "",
                    IsCancellable = false
                });


                theUser.NickName = result.Text;
            }
            

            theUser.CodeCountry = theUserFromFacebook.locale.Substring(3, 2);

            FacebookUser.Location cityName = new FacebookUser.Location();
            cityName = theUserFromFacebook.location;
            theUser.City = cityName.name;

            string birthday = theUserFromFacebook.birthday;
            if (!string.IsNullOrEmpty(birthday))
            { 
            theUser.Birthday = DateTime.Parse(birthday);
            }

            theUser.Email = theUserFromFacebook.email;



            if (string.IsNullOrEmpty(theUser.Email) || string.IsNullOrWhiteSpace(theUser.Email))
            {
                // Show dialog box to ask email 
                var result = await UserDialogs.Instance.PromptAsync(new PromptConfig
                {
                    InputType = InputType.Email,
                    Title = "Your e-mail",
                    Text = "",
                    IsCancellable = false
                });


                theUser.Email = result.Text;
            }

            Console.WriteLine(theUser.ToString());
            await new RestUser().Insert(theUser);




            //PCL Method

            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("NeedUFolder",
                CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync("emailUser.txt",
                CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(theUser.Email);



            //SQL MEthod
            //LocalDB_User UserDB = new LocalDB_User();
            //UserDB.InsertUser(theUser);


        }
    }
}
