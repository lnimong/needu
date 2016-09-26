using PCLStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Need_U
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            CheckIfUserLogInExist();

            App.PostSuccessFacebookAction = /*async*/ token =>
            {
                //you can use this token to authenticate to the server here
                //call your FacebookLoginService.LoginToServer(token)
                //I'll just navigate to a screen that displays the token:

                CheckIfUserLogInExist();

                //App.Current.MainPage = new NavigationPage(new MainPage());
                //await Navigation.PopToRootAsync();
           

            };



        }



        public LoginPage(int IsFromMainPage)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

                       

        }


        private async void CheckIfUserLogInExist()
        {
            bool fileCreated = false;

            while(fileCreated == false)
            { 

            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("NeedUFolder",
                CreationCollisionOption.OpenIfExists);
            var Checking = await folder.CheckExistsAsync("emailUser.txt");

                if (Checking == ExistenceCheckResult.FileExists)
                {
                    fileCreated = true;

                }

            }


            App.Current.MainPage = new NavigationPage(new MainPage());

            try
            {
               await Navigation.PopToRootAsync();
            }
            catch (Exception)
            {

                throw;
            }
           


            //System.InvalidOperationException: Sequence contains no elements

            // // SQLITE METHOD
            // LocalDB_User DBUser = new LocalDB_User();

            //var IsUserLogIn = DBUser.GetItems();

            // if(IsUserLogIn != null)
            // {
            //     App.Current.MainPage = new NavigationPage(new MainPage());
            //     await Navigation.PopToRootAsync();
            // }
        }

    }
}
