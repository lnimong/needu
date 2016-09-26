using Need_U.Cell_List_Personalization;
using Need_U.Entities;
using Need_U.Layout;
using Need_U.Service;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Need_U
{
    public partial class CrowdPage : ContentPage
    {

        List<EntityQuestion> ListQuestions;
       
        EntityUser TheUser;
      
        
        
        public CrowdPage(EntityUser theUser)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            TheUser = theUser;
            //GetUserPosition();
            GetQuetion();
            

        }


        
        #region Navigation
        // Navigation

        private async void onTapbackButtonCrowd(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }

        private async void onTapNavButtonCrowd(object sender, EventArgs args)
        {
            await Navigation.PopToRootAsync();
        }

        private async void OnItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            var ItemSelected = (EntityQuestion)e.SelectedItem;
            var IdQuestionSelected = ItemSelected.IdQuestion;
            await Navigation.PushAsync(new FinalQuestion(IdQuestionSelected, TheUser));

        }


        #endregion


        //user position


        private async void GetUserPosition()
        {

            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync(timeoutMilliseconds: 15000);
                TheUser.Latitude = position.Latitude;
                TheUser.Longitude = position.Longitude;
            }
            catch (Exception ex)
            {
                return;
            }
            

        }

        private async void GetQuetion()
        {
            theActivityIndicator.IsRunning = true;

            ListQuestions = new List<EntityQuestion>();
            ListQuestions = await new RestQuestion().QuestionsByCountry(TheUser.IdUser);


            CrowdListViewQuestion.ItemsSource = ListQuestions;
            CrowdListViewQuestion.ItemTemplate = new DataTemplate(typeof(QuestionsCell));

            theActivityIndicator.IsRunning = false;

        }

        // Refresh List
        private void RefreshList(object sender,  EventArgs e)
        {
            GetQuetion();
            CrowdListViewQuestion.EndRefresh();
        }




        }
    }
