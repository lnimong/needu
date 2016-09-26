using FFImageLoading.Transformations;
using FFImageLoading.Work;
using Need_U.Entities;
using Need_U.Layout;
using Need_U.Objects;
using Need_U.Service;
using PCLStorage;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Need_U
{
    public partial class MainPage : ContentPage
    {
        CrossGeolocator locatorUser;
        Position positionUser;
        EntityUser theUser;

      


        public MainPage()
        {
            InitializeComponent();



            locatorUser = new CrossGeolocator();
            positionUser = new Position();
            NavigationPage.SetHasNavigationBar(this, false);


            GetTheUser();

           


            // SQLITE MEthod

            //LocalDB_User LocalUserDb = new LocalDB_User();
            //List<EntityUser> UserRegister = new List<EntityUser>();
            //UserRegister = LocalUserDb.GetItems().ToList();
            //EntityUser theUserDevice = new EntityUser();
            //theUserDevice = UserRegister.FirstOrDefault();
            //string emailLocalUser = theUserDevice.Email;
            //theUser = new EntityUser();
            //GetTheUser(emailLocalUser);
            

        }

        //Navigation Menu Button

        public async void onTapMenuButton(object sender, EventArgs e)
        {
          
                var action1 = await DisplayActionSheet("Question", "Cancel", null, "Log out", "Profile");
                switch (action1)
                {
                    case "Log out":
                    await Navigation.PushAsync(new LoginPage(1));
                        break;

                case "Profile":
                    CreateUserProfilte();
                    Grid_ProfileUser.IsVisible = true;
                    Grid_ProfileUser.IsEnabled = true;
                    break;

            }



            }



        // Edit Tool
        private async void onTapPublicationToolButton(object sender, EventArgs args)
        {
            var locator = CrossGeolocator.Current;
            if (locator.IsGeolocationAvailable == true && locator.IsGeolocationEnabled == true && positionUser != null
                && theUser.Latitude !=0 && theUser.Longitude !=0)
            {
                await Navigation.PushAsync(new publicationTool(theUser));
            }
            else
            {
                await DisplayAlert("GPS", "Please activate the GPS", "Ok", "Cancel");

                if(positionUser != null  || theUser.Latitude != 0 || theUser.Longitude != 0) { GetUserPosition(); }
                
            }
        }


        //CROWD
        private async void onTapCrowdButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CrowdPage(theUser));

            //var locator = CrossGeolocator.Current;
            //if (locator.IsGeolocationAvailable == true && locator.IsGeolocationEnabled == true && positionUser != null)
            //{
            //    await Navigation.PushAsync(new CrowdPage(theUser));
            //}
            //else
            //{
            //    await DisplayAlert("GPS", "Please activate the GPS", "Ok", "Cancel");
            //    GetUserPosition();
            //}

        }

        // Local
       private async void onTapLocalButton (object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            if (locator.IsGeolocationAvailable == true && locator.IsGeolocationEnabled == true && positionUser != null
               && theUser.Latitude != 0 && theUser.Longitude != 0)
            {
                await Navigation.PushAsync(new LocalPage(theUser));
            }
            else
            {
                await DisplayAlert("GPS", "Please activate the GPS", "Ok", "Cancel");

                if (positionUser != null || theUser.Latitude != 0 || theUser.Longitude != 0) { GetUserPosition(); }

            }
        }


        //Bookmark
        private async void onTapBookmarkButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookmarkPage(theUser));

            //var locator = CrossGeolocator.Current;
            //if (locator.IsGeolocationAvailable == true && locator.IsGeolocationEnabled == true && positionUser != null)
            //{
            //    await Navigation.PushAsync(new BookmarkPage(theUser));
            //}
            //else
            //{
            //    await DisplayAlert("GPS", "Please activate the GPS", "Ok", "Cancel");
            //    GetUserPosition();
            //}
        }


        // My Publications

        private async void onTapMypublicationButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyPublicationsPage(theUser));

            //var locator = CrossGeolocator.Current;
            //if (locator.IsGeolocationAvailable == true && locator.IsGeolocationEnabled == true && positionUser != null )

            //{
            //    await Navigation.PushAsync(new MyPublicationsPage(theUser));
            //}
            //else { await DisplayAlert("GPS", "Please activate the GPS", "Ok", "Cancel");
            //    GetUserPosition();
            //        }
        }



        private async void GetUserPosition()
        {
            var locator = CrossGeolocator.Current;
            if (locator.IsGeolocationAvailable == true && locator.IsGeolocationEnabled == true )


            {

                try
                {
                    theActivityIndicator.IsRunning = true;

                    locator.DesiredAccuracy = 50;
                    var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
                    positionUser = position;
                    theUser.Latitude = positionUser.Latitude;
                    theUser.Longitude = positionUser.Longitude;
                    //theUser = new EntityUser() { NickName = "ocadavid", IdUser = 4, Latitude = positionUser.Latitude, Longitude = positionUser.Longitude };


                    theActivityIndicator.IsRunning = false;

                }
                catch (Exception)
                {

                    theActivityIndicator.IsRunning = false;
                }

               

            }

        }


       //Get the UserOfThe Device

        private async void GetTheUser()
        {
            theActivityIndicator.IsRunning = true;
            theUser = new EntityUser();
            //PCL Storage Method
            
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("NeedUFolder",
                CreationCollisionOption.OpenIfExists);
            IFile file = await folder.GetFileAsync("emailUser.txt");
            string email = "";

            while(string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
            {
              
                email = await file.ReadAllTextAsync();

            }

            theUser =  await new RestUser().Select(email);
            theActivityIndicator.IsRunning = false;

            GetUserPosition();

        }


        // User Profile

        bool IsUserAMan;
        List<EntityCountry> countriesList;
        RandomList rdnList;

        private async void CreateUserProfilte()
        {
           rdnList = new RandomList();

            ProfilePicture.Transformations = new System.Collections.Generic.List<ITransformation>()
            {
                    new CircleTransformation(),

            };

            if (theUser.Sex == true) { ProfilePicture.Source = rdnList.maleImageSourceRnd(); }
          if (theUser.Sex == false) { ProfilePicture.Source = rdnList.FemaleImageSourceRnd(); }


            //ProfilePicture.Source = "seb.jpg";



            Label_UserNickName.Text = theUser.NickName;


           
            if (theUser.Birthday == null)
            {
                DatePicker_UserBirthday.Date = new DateTime(1990,01,01);
            }
            else { DatePicker_UserBirthday.Date = theUser.Birthday.Value; }


            Entry_UserCity.Text = theUser.City;
            if (theUser.City == null)
            {
                Entry_UserCity.Placeholder = "Your city here";
                Entry_UserCity.PlaceholderColor = Color.Gray;
            }
           


            // Country Piker

            countriesList = new List<EntityCountry>();

            countriesList = await new RestCountry().Select();


            foreach (EntityCountry country in countriesList)
            {
                Picker_Countries.Items.Add(country.Name);
                country.Position = Picker_Countries.Items.Count() - 1;
            }

                       
            country_Label.Text = theUser.NameCountry;


            //End Country Picker

          


            if (theUser.Sex == true)
            {
                Grid_UserChooseSex.Children.Add(BoxView_SexChoice, 0, 0);
                IsUserAMan = true;
            }

            else
            if (theUser.Sex == false)
            {
                Grid_UserChooseSex.Children.Add(BoxView_SexChoice, 1, 0);
                IsUserAMan = false;
            }
            

        }


        private async void Update_Clicked(object sender, EventArgs e)
        {
            theUser.NickName = Label_UserNickName.Text;
            theUser.Birthday = DatePicker_UserBirthday.Date;
            theUser.City = Entry_UserCity.Text;


            if (Picker_Countries.SelectedIndex != -1)
            {
                string countrySelected = countriesList.FirstOrDefault(c => c.Position == Picker_Countries.SelectedIndex).CodeCountry;
                theUser.CodeCountry = countrySelected;
            };

            theUser.Sex = IsUserAMan;


          string result =    await new RestUser().Update(theUser);

            string message = new RandomList().NiceMessagesRnd();
            await  DisplayAlert("Updated", message, "Ok");



        }


        private void picker_ChangeCountry(object sender, EventArgs e)
        {

            string countrySelected;

            countrySelected = null;

            if (Picker_Countries.SelectedIndex != -1)
            {
               countrySelected = countriesList.FirstOrDefault(c => c.Position == Picker_Countries.SelectedIndex).Name;
            };

            theUser.NameCountry = countrySelected;
            country_Label.Text = theUser.NameCountry;
        }


       


        private void onTapCloseProfile(object sender, EventArgs e)
        {
            Grid_ProfileUser.IsVisible = false;
            Grid_ProfileUser.IsEnabled = false;
        }

        private void onTapMale(object sender, EventArgs e)
        {
            Grid_UserChooseSex.Children.Add(BoxView_SexChoice, 0, 0);
            IsUserAMan = true;
            ProfilePicture.Source = rdnList.maleImageSourceRnd();

        }

        private void onTapFemale(object sender, EventArgs e)
        {
            Grid_UserChooseSex.Children.Add(BoxView_SexChoice, 1, 0);
            IsUserAMan = false;
            ProfilePicture.Source = rdnList.FemaleImageSourceRnd();
        }

    }
}
