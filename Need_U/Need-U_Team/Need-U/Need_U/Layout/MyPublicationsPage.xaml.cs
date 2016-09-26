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

namespace Need_U.Layout
{
    public partial class MyPublicationsPage : ContentPage
    {

        List<EntityEvent> ListEvents;
        List<EntityQuestion> ListQuestions;
       
        EntityUser TheUser;

        bool IsListQuestions;
        bool IsListEvents;

            


        public MyPublicationsPage(EntityUser theUser)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            TheUser = theUser;
            CreatingListQuestion();


            ListMyPublicationQuestion.IsVisible = true;
            ListMyPublicationQuestion.IsEnabled = true;
            ListMyPublicationEvent.IsVisible = false;
            ListMyPublicationEvent.IsEnabled = false;

            IsListQuestions = true;
            IsListEvents = false;

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


        private async void OnItemTap(object sender, SelectedItemChangedEventArgs e)
        {

            if (IsListQuestions == true)
            {
                var ItemSelected = (EntityQuestion)e.SelectedItem;
                var IdQuestionSelected = ItemSelected.IdQuestion;
                await Navigation.PushAsync(new FinalQuestion(IdQuestionSelected, TheUser));
            }


            if (IsListEvents == true)
            {
                var ItemSelected = (EntityEvent)e.SelectedItem;
                var IdEventSelected = ItemSelected.IdEvent;
                await Navigation.PushAsync(new FinalInvitation(IdEventSelected, TheUser));
            }



        }

        private async void onTapQuestion(object sender, EventArgs e)
        {
            YellowBoxViewQuestion.IsVisible = true;
            YellowBoxViewEvent.IsVisible = false;

            ListMyPublicationQuestion.IsVisible = true;
            ListMyPublicationQuestion.IsEnabled = true;
            ListMyPublicationEvent.IsVisible = false;
            ListMyPublicationEvent.IsEnabled = false;

            if (ListQuestions == null)
            {
                CreatingListQuestion();
            }
            ListMyPublicationQuestion.ItemsSource = ListQuestions;
            ListMyPublicationQuestion.ItemTemplate = new DataTemplate(typeof(QuestionsCell));

            IsListQuestions = true;
            IsListEvents = false;
        }

        private async void onTapEvent(object sender, EventArgs e)
        {
            YellowBoxViewQuestion.IsVisible = false;
            YellowBoxViewEvent.IsVisible = true;

            ListMyPublicationQuestion.IsVisible = false;
            ListMyPublicationQuestion.IsEnabled = false;
            ListMyPublicationEvent.IsVisible = true;
            ListMyPublicationEvent.IsEnabled = true;

            if (ListEvents == null)
            {
                GettingEvents();
            }

            ListMyPublicationEvent.ItemsSource = ListEvents;
            ListMyPublicationEvent.ItemTemplate = new DataTemplate(typeof(EventsCell));

        

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

  
 // Getting List Question by User

        private async void CreatingListQuestion()
        {
            theActivityIndicator.IsRunning = true;
            ListQuestions = new List<EntityQuestion>();
            ListQuestions = await new RestQuestion().QuestionsByUser(TheUser.IdUser);

            ListMyPublicationQuestion.ItemsSource = ListQuestions;
            ListMyPublicationQuestion.ItemTemplate = new DataTemplate(typeof(QuestionsCell));
            theActivityIndicator.IsRunning = false;
        }


        // Gtting List Event

        private async void GettingEvents()
        {
            theActivityIndicator.IsRunning = true;

            ListEvents = new List<EntityEvent>();
            ListEvents = await new RestEvent().SelectEvents(TheUser.IdUser);

            ListMyPublicationEvent.ItemsSource = ListEvents;
            ListMyPublicationEvent.ItemTemplate = new DataTemplate(typeof(EventsCell));

            theActivityIndicator.IsRunning = false;

        }


     private void RefrechingQuestion(object sender, EventArgs e)
        {
            CreatingListQuestion();
            ListMyPublicationQuestion.EndRefresh();
        }

        private void RefrechingEvent(object sender, EventArgs e)
        {
            GettingEvents();
            ListMyPublicationEvent.EndRefresh();
        }



    }
}
