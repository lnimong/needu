using Need_U.Cell_List_Personalization;
using Need_U.Fake;
using Need_U.Layout.Invitations;
using Need_U.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFImageLoading.Forms;
using Plugin.Geolocator;
using Xamarin.Forms;
using Plugin.Geolocator.Abstractions;
using Need_U.Entities;
using Need_U.Service;

namespace Need_U
{
    public partial class LocalPage : MasterDetailPage
    {
        List<EntityEvent> ListEvents;
        List<EntityQuestion> ListQuestions;
        CrossGeolocator GeoUser;
        EntityUser TheUser;

           
       

        public LocalPage(EntityUser theUser)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            TheUser = theUser;
            GetUserPosition();

            //Method to call the questions
            SliderQuestionkm.Value = 15f;
            QuestionIsShowing();

          

        }

        //Navigation

        #region Navigation
        private async void onTapbackButtonCrowd(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }

        private async void onTapNavButtonCrowd(object sender, EventArgs args)
        {
            await Navigation.PopToRootAsync();
        }


        private  void onTapMenuButton(object sender, EventArgs e)
        {
        if (IsPresented == false) {   IsPresented = true; }
        if (IsPresented == true) { IsPresented = false; }
        }

        #endregion


        private async void OnItemTappedQuestion(object sender, SelectedItemChangedEventArgs e)
        {            
                var ItemSelected = (EntityQuestion)e.SelectedItem;
                var IdQuestionSelected = ItemSelected.IdQuestion;
                await Navigation.PushAsync(new FinalQuestion(IdQuestionSelected, TheUser));
         
        }

        private async void OnItemTappedEvent(object sender, SelectedItemChangedEventArgs e)
        {

            var ItemSelected = (EntityEvent)e.SelectedItem;
            var IdEventSelected = ItemSelected.IdEvent;
            await Navigation.PushAsync(new FinalInvitation(IdEventSelected, TheUser));

        }

        private async void onTapQuestion(object sender, EventArgs e)
        {
            YellowBoxViewQuestion.IsVisible = true;
            YellowBoxViewEvent.IsVisible = false;

            QuestionIsShowing();

            if (ListQuestions == null)
            {
                GettingQuestion();
            }
            
        }

        private async void onTapEvent(object sender, EventArgs e)
        {
            YellowBoxViewQuestion.IsVisible = false;
            YellowBoxViewEvent.IsVisible = true;

            SliderEventKm.Value = 15f;

            EventIsShowing();

            if (ListEvents == null)
            {
                GettingEvents();
            }

          
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

        // Fire when Slider Value Change

            private void SliderQuestionValueChange(object sender, EventArgs e)
        {
                GettingQuestion();
            
        }


        private void SliderEventValueChange(object sender, EventArgs e)
        {
          
                GettingEvents();
           
        }


        // Getting the questions

        private async void GettingQuestion()
        {
            theActivityIndicator.IsRunning = true;

            short km = Convert.ToInt16(SliderQuestionkm.Value);

            ListQuestions = new List<EntityQuestion>();
            ListQuestions = await new RestQuestion().ByKmSelect(km, TheUser.Latitude, TheUser.Longitude);

            ListLocalQuestion.ItemsSource = ListQuestions;
            ListLocalQuestion.ItemTemplate = new DataTemplate(typeof(QuestionsCellLocal));

            theActivityIndicator.IsRunning = false;
        }


        // Getting the events
        private async void GettingEvents()
        {
            theActivityIndicator.IsRunning = true;

            short km = Convert.ToInt16(SliderEventKm.Value);

            ListEvents = new List<EntityEvent>();
            ListEvents = await new RestEvent().EventsByKm(km, TheUser.Latitude, TheUser.Longitude);

            ListLocalEvent.ItemsSource = ListEvents;
            ListLocalEvent.ItemTemplate = new DataTemplate(typeof(EventsCellLocal));

            theActivityIndicator.IsRunning = false;
        }




        // Refreching List

        private void RefrechingQuestion(object sender, EventArgs e)
        {
            GettingQuestion();
            ListLocalQuestion.EndRefresh();
        }


        private void RefrechingEvent(object sender, EventArgs e)
        {
            GettingEvents();
            ListLocalEvent.EndRefresh();
        }


        private void EventIsShowing()
        {
            // Showing the List
            
            ListLocalQuestion.IsVisible = false;
            ListLocalQuestion.IsEnabled = false;

            ListLocalEvent.IsVisible = true;
            ListLocalEvent.IsEnabled = true;


            // Showing the slider

            SliderEventKm.IsEnabled = true;
            SliderEventKm.IsVisible = true;
            LabelEventkm.IsVisible = true;
            LabelEventkm.IsEnabled = true;

            SliderQuestionkm.IsEnabled = false;
            SliderQuestionkm.IsVisible = false;
            LabelQuestionkm.IsVisible = false;
            LabelQuestionkm.IsEnabled = false;


        }


        private void QuestionIsShowing()
        {
            // Showing the List

            ListLocalQuestion.IsVisible = true;
            ListLocalQuestion.IsEnabled = true;

            ListLocalEvent.IsVisible = false;
            ListLocalEvent.IsEnabled = false;


            // Showing the slider

            SliderEventKm.IsEnabled = false;
            SliderEventKm.IsVisible = false;
            LabelEventkm.IsVisible = false;
            LabelEventkm.IsEnabled = false;

            SliderQuestionkm.IsEnabled = true;
            SliderQuestionkm.IsVisible = true;
            LabelQuestionkm.IsVisible = true;
            LabelQuestionkm.IsEnabled = true;


        }

    }
}
