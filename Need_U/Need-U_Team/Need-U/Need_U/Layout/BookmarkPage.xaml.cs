using Need_U.Cell_List_Personalization;
using Need_U.Entities;
using Need_U.Fake;
using Need_U.Layout.Invitations;
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
    public partial class BookmarkPage : ContentPage
    {

        List<EntityEvent> ListEvents;
        List<EntityQuestion> ListQuestions;
        EntityUser TheUser;

        bool IsListQuestions;
        bool IsListEvents;




        public BookmarkPage(EntityUser theUser)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);


            TheUser = theUser;
            //GetUserPosition();
            GettingQuestionList();

            
            IsListQuestions = true;
            IsListEvents = false;


            ListBookmarkQuestion.IsVisible = true;
            ListBookmarkQuestion.IsEnabled = true;
            ListBookmarkEvent.IsVisible = false;
            ListBookmarkEvent.IsEnabled = false;

        }

        //Navigation

        #region Navigation
        private async void onTapbackButton(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }

        private async void onTapNavButton(object sender, EventArgs args)
        {
            await Navigation.PopToRootAsync();
        }




        #endregion


        private async void OnItemTapQuestion(object sender, SelectedItemChangedEventArgs e)
        {

                var ItemSelected = (EntityQuestion)e.SelectedItem;
                var IdQuestionSelected = ItemSelected.IdQuestion;
                await Navigation.PushAsync(new FinalQuestion(IdQuestionSelected, TheUser));
           

        }


        private async void OnItemTapEvent(object sender, SelectedItemChangedEventArgs e)
        {

            
                var ItemSelected = (EntityEvent)e.SelectedItem;
                var IdEventSelected = ItemSelected.IdEvent;
                await Navigation.PushAsync(new FinalInvitation(IdEventSelected, TheUser));
       

        }

        private async void onTapQuestion(object sender, EventArgs e)
        {
            YellowBoxViewQuestion.IsVisible = true;
            YellowBoxViewEvent.IsVisible = false;

            ListBookmarkQuestion.IsVisible = true;
            ListBookmarkQuestion.IsEnabled = true;
            ListBookmarkEvent.IsVisible = false;
            ListBookmarkEvent.IsEnabled = false;

            if (ListQuestions == null)
            {
                GettingQuestionList();
            }
            ListBookmarkQuestion.ItemsSource = ListQuestions;
            ListBookmarkQuestion.ItemTemplate = new DataTemplate(typeof(QuestionsCellBookmark));

            IsListQuestions = true;
            IsListEvents = false;
        }

        private async void onTapEvent(object sender, EventArgs e)
        {
            YellowBoxViewQuestion.IsVisible = false;
            YellowBoxViewEvent.IsVisible = true;

            ListBookmarkQuestion.IsVisible = false;
            ListBookmarkQuestion.IsEnabled = false;
            ListBookmarkEvent.IsVisible = true;
            ListBookmarkEvent.IsEnabled = true;

            if (ListEvents == null)
            {
                GettingEventList();
            }


            ListBookmarkEvent.ItemsSource = ListEvents;
            ListBookmarkEvent.ItemTemplate = new DataTemplate(typeof(EventsCellBookmark));

            IsListQuestions = false;
            IsListEvents = true;
        }


        // End Navigation

        // Methods


        private async void GetUserPosition()
        {
            try
            {

                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
                TheUser.Latitude = position.Latitude;
                TheUser.Longitude = position.Longitude;

            }
            catch (Exception ex)
            {
                return;
            }

        }


        private async void GettingQuestionList()
        {
            theActivityIndicator.IsRunning = true;
            ListQuestions = new List<EntityQuestion>();
            ListQuestions = await new RestFavorite().FavoriteQuestionSelect(TheUser.IdUser);

            ListBookmarkQuestion.ItemsSource = ListQuestions;
            ListBookmarkQuestion.ItemTemplate = new DataTemplate(typeof(QuestionsCellBookmark));
            theActivityIndicator.IsRunning = false;
        }

        private async void GettingEventList()
        {
            theActivityIndicator.IsRunning = true;

            ListEvents = new List<EntityEvent>();
            ListEvents = await new RestFavorite().FavoriteEventSelect(TheUser.IdUser);

            ListBookmarkEvent.ItemsSource = ListEvents;
            ListBookmarkEvent.ItemTemplate = new DataTemplate(typeof(EventsCellBookmark));

            theActivityIndicator.IsRunning = false;
        }


        
        private void RefrechingQuestion(object sender, EventArgs e)
        {
            GettingQuestionList();
            ListBookmarkQuestion.EndRefresh();
        }


        private void RefrechingEvent(object sender, EventArgs e)
        {
            GettingEventList();
            ListBookmarkEvent.EndRefresh();
        }





    }
}
