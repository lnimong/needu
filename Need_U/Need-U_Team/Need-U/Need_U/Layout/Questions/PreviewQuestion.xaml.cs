using System;
using System.Collections.Generic;
using Xamarin.Forms;
using FFImageLoading.Forms;
using Need_U.Entities;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System.Drawing;
using System.IO;
using Need_U.Service;
using Need_U.Objects;

namespace Need_U
{
    public partial class PreviewQuestion : ContentPage
    {
        public Question TheQuestion { get; set; }
        public OptionChoice Choice1 { get; set; }
        public OptionChoice Choice2 { get; set; }
        public OptionChoice Choice3 { get; set; }

        Position UserPosition;
        EntityUser TheUser;

        public PreviewQuestion(Question theQuestion, OptionChoice choice1, OptionChoice choice2, OptionChoice choice3, EntityUser theUser)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            TheUser = theUser;

            TheQuestion = new Question();
            Choice1 = new OptionChoice();
            Choice2 = new OptionChoice();
            Choice3 = new OptionChoice();

            TheQuestion = theQuestion;
            titleQuestionPreview.Text = TheQuestion.TitleQuestion;
            QuestionDescriptionPReview.Text = TheQuestion.DescriptionQuestion;

            FillUpChoice(choice1, Choice1, LabelChoice1, ImageChoice1);
            FillUpChoice(choice2, Choice2, LabelChoice2, ImageChoice2);
            FillUpChoice(choice3, Choice3, LabelChoice3, ImageChoice3);

            GetUserPosition();



        }

        

        //Navigation

        private async void onTapbackButton(object sender, EventArgs args)
        {
            TheQuestion = new Question();
            Choice1 = new OptionChoice();
            Choice2 = new OptionChoice();
            Choice3 = new OptionChoice();
            await Navigation.PopAsync();
        }

        private async void onTapNavButton(object sender, EventArgs args)
        {
            await Navigation.PopToRootAsync();
        }

        private async void SendButon_Clicked(object sender, EventArgs e)
        {
            theActivityIndicator.IsRunning = true;

            EntityQuestion question = new EntityQuestion();
            question.IdUser = TheUser.IdUser;
            question.Latitude = TheUser.Latitude;
            question.Longitud = TheUser.Longitude;
            question.Title = titleQuestionPreview.Text;
            question.Description = QuestionDescriptionPReview.Text;
            question.OptionsQuestion = new List<EntityOptionQuestion>();

         

            EntityOptionQuestion option = new EntityOptionQuestion();
            option.TextOption = LabelChoice1.Text;
            option.Image = ImageChoice1.GetImageAsPngAsync().Result;
            question.OptionsQuestion.Add(option);

            option = new EntityOptionQuestion();
            option.TextOption = LabelChoice2.Text;
            option.Image = ImageChoice2.GetImageAsPngAsync().Result;
            question.OptionsQuestion.Add(option);

            option = new EntityOptionQuestion();
            option.TextOption = LabelChoice3.Text;
            option.Image =  ImageChoice3.GetImageAsPngAsync().Result; /* GetBytes(ImageChoice3.ToString());*/
            question.OptionsQuestion.Add(option);


            string resultado = await new RestQuestion().Insert(question);

                theActivityIndicator.IsRunning = false;

            string message = new RandomList().NiceMessagesRnd();

            await DisplayAlert("Question sent !", message, "Ok");

             await Navigation.PopToRootAsync();
              

        }


        //Method  


        private void FillUpChoice (OptionChoice ChoiceEntry, OptionChoice ChoiceToFill, Label ChoiceToFillText, CachedImage ChoiceTofillImage)
        {

            if (String.IsNullOrEmpty(ChoiceEntry.TxtChoice) || String.IsNullOrWhiteSpace(ChoiceEntry.TxtChoice))
            {
                
                ChoiceToFill.ImageChoice = ChoiceEntry.ImageChoice;
                ChoiceTofillImage.Source = ChoiceToFill.ImageChoice.Source;
                
            }
            else
            {
                ChoiceToFill.TxtChoice = ChoiceEntry.TxtChoice;
                ChoiceToFillText.Text = ChoiceToFill.TxtChoice;
                ChoiceTofillImage.IsEnabled = false;
                ChoiceTofillImage.IsVisible = false;
            }

        }

        private void SettingVotesView(double vote1Result, double vote2Result, double vote3Result)
        {
            //Choice1
            GridResultVote1.Width = new GridLength(vote1Result, GridUnitType.Star);
            GridLeftSpaceVote1.Width = new GridLength(100 - vote1Result, GridUnitType.Star);
            ThisOneVote1.IsEnabled = false;
            ThisOneVote1.IsVisible = false;
            GridVote1Result.IsVisible = true;
            PercentChoice1Label.Text = vote1Result.ToString() + "%";

            //Choice2
            GridResultVote2.Width = new GridLength(vote2Result, GridUnitType.Star);
            GridLeftSpaceVote2.Width = new GridLength(100 - vote2Result, GridUnitType.Star);
            ThisOneVote2.IsEnabled = false;
            ThisOneVote2.IsVisible = false;
            GridVote2Result.IsVisible = true;
            PercentChoice2Label.Text = vote2Result.ToString() + "%";


            //Choice3
            GridResultVote3.Width = new GridLength(vote3Result, GridUnitType.Star);
            GridLeftSpaceVote3.Width = new GridLength(100 - vote3Result, GridUnitType.Star);
            ThisOneVote3.IsEnabled = false;
            ThisOneVote3.IsVisible = false;
            GridVote3Result.IsVisible = true;
            PercentChoice3Label.Text = vote3Result.ToString() + "%";
        }


        private async void GetUserPosition()
        {

            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync(timeoutMilliseconds: 15000);
                UserPosition = new Position();
                UserPosition = position;
                TheUser.Latitude = UserPosition.Latitude;
                TheUser.Longitude = UserPosition.Longitude;

            }
            catch (Exception ex)
            {
                
            }

            
        }



    }
}
