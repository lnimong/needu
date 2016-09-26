using FFImageLoading.Forms;
using Need_U.Cell_List_Personalization;
using Need_U.Entities;
using Need_U.Layout.Questions;
using Need_U.Objects;
using Need_U.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;

namespace Need_U
{
    public partial class FinalQuestion : ContentPage
    {
        EntityQuestion theQuestion;
        EntityUser theUser;

        EntityOptionQuestion option1;
        EntityOptionQuestion option2;
        EntityOptionQuestion option3;

        EntityResponse voteOption1;
        EntityResponse voteOption2;
        EntityResponse voteOption3;

        List<EntityResponse> theResults;

        List<EntityCommentQuestion> comments;

        AwesomeHyperLinkLabel LabelPlusVisibility;

        ActivityIndicator theActivityIndicator;

        public FinalQuestion(Int64 IdQuestion, EntityUser theUser)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
            this.theUser = theUser;

            theActivityIndicator = new ActivityIndicator();


            theActivityIndicator.IsRunning = true;
            // Calling the entire question by ID
            GetQuestionById(IdQuestion);
            theActivityIndicator.IsRunning = false;


        }


        #region Navigation
        // Navigation

        private async void onTapbackButton(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }

        private async void onTapNavButton(object sender, EventArgs args)
        {
            await Navigation.PopToRootAsync();
        }


        // Menu to bookmark and delete question

        private async void onTapMenuButton(object sender, EventArgs e)
        {
            if (theQuestion.IdUser != theUser.IdUser)
            {
                var action1 = await DisplayActionSheet("Question", "Cancel", null, "Bookmark");
                switch (action1)
                {
                    case "Bookmark":
                        await new RestFavorite().FavoriteQuestionInsert(theQuestion.IdQuestion, theUser.IdUser);
                        break;

                }
            }


            if (theQuestion.IdUser == theUser.IdUser )
            {
               
                var action2 = await DisplayActionSheet("Question", "Cancel", null, "Bookmark", "Delete");
                switch (action2)
                {
                    case "Bookmark":
                        await new RestFavorite().FavoriteQuestionInsert(theQuestion.IdQuestion, theUser.IdUser);
                        break;
                    case "Delete":
                        await new RestQuestion().Delete(theQuestion.IdQuestion);
                        break;
                }

    

            }


         
        }
        
            // Display Comment
        private void btnComment_Clicked(object sender, EventArgs e)
        {
            DisplayComments.IsVisible = true;
            DisplayComments.Opacity = 0;
            DisplayComments.FadeTo(1, 1500);
            DisplayComments.IsEnabled = true;

            LabelPlusVisibility.IsEnabled = false;
            LabelPlusVisibility.IsVisible = false;

            GettingComents();

        }

        private async void InsertComment(object sender, EventArgs e)
        {
            EntityCommentQuestion theComment = new EntityCommentQuestion();
            theComment.IdQuestion = theQuestion.IdQuestion;
            theComment.IdUser = theUser.IdUser;
            theComment.Date = DateTime.Now;
            theComment.Comment = entryComment.Text;
            theComment.NickNameUser = theUser.NickName;

            string  result = await new RestComment().InsertCommentQuestion(theComment);

            string message = new RandomList().NiceMessagesRnd();

            await DisplayAlert("Comment sent", message, "Ok");
            entryComment.Text = null;
            GettingComents();
        }

        private void onTapCloseButton(object sender, EventArgs e)
        {
            DisplayComments.IsEnabled = false;
            DisplayComments.IsVisible = false;

            LabelPlusVisibility.IsEnabled = true;
            LabelPlusVisibility.IsVisible = true;

        }

        private async void GettingComents()
        {
            comments = new List<EntityCommentQuestion>();
            comments = await new RestComment().SelectCommentsQuestion(theQuestion.IdQuestion);

            ListComments.ItemsSource = comments;
            ListComments.ItemTemplate = new DataTemplate(typeof(CommentsCellList));
        }


        // Zoom on choices

        private async void onTapChoice1(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChoicesPagecs(option1, option2, option3, 1));
        }
        private async void onTapChoice2(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChoicesPagecs(option1, option2, option3, 2));
        }
        private async void onTapChoice3(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChoicesPagecs(option1, option2, option3, 3));
        }

        #endregion

        // Voting system

        private async void onTapThisOne1(object sender, EventArgs e)
        {

            voteOption1 = new EntityResponse();
            voteOption1.IdUser = theUser.IdUser;
            voteOption1.IdOptionQuestion = option1.IdOptionQuestion;
            voteOption1.Date = DateTime.Now;
            await new RestResponse().Insert(voteOption1);

            GettingVotes();

        }


        private async void onTapThisOne2(object sender, EventArgs e)
        {
            voteOption2 = new EntityResponse();
            voteOption2.IdUser = theUser.IdUser;
            voteOption2.IdOptionQuestion = option2.IdOptionQuestion;
            voteOption2.Date = DateTime.Now;
            await new RestResponse().Insert(voteOption2);

            GettingVotes();


        }

        private async void onTapThisOne3(object sender, EventArgs e)
        {
            voteOption3 = new EntityResponse();
            voteOption3.IdUser = theUser.IdUser;
            voteOption3.IdOptionQuestion = option3.IdOptionQuestion;
            voteOption3.Date = DateTime.Now;
            await new RestResponse().Insert(voteOption3);

            GettingVotes();

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

        private async void IsUserAlreadyVoter()
        {
            EntityResponse response = new EntityResponse();
           response = await new RestResponse().ResponseByUser(theQuestion.IdQuestion, theUser.IdUser);

            if (response != null)
            {
                GettingVotes();
            }
            else return;
            
        }

        // Get list of votes

        private async void GettingVotes()
        {
            theResults = new List<EntityResponse>();
            theResults = await new RestResponse().Select(theQuestion.IdQuestion);

            double result1 = 0; if (theResults.ElementAtOrDefault(0) != null) { result1 = theResults[0].Percentage.Value; }
            double result2 = 0; if (theResults.ElementAtOrDefault(1) != null) { result2 = theResults[1].Percentage.Value; }
            double result3 = 0; if (theResults.ElementAtOrDefault(2) != null) { result3 = theResults[2].Percentage.Value; }

            SettingVotesView(result1, result2, result3);
        }

        //Rest method

        //Get Question by ID and the choices
        private async void GetQuestionById(Int64 idQuestion)
        {
          

               theQuestion = new EntityQuestion();
            theQuestion = await new RestQuestion().QuestionById(idQuestion);



            List<EntityOptionQuestion> options = new List<EntityOptionQuestion>();
            options = theQuestion.OptionsQuestion;
            this.option1 = new EntityOptionQuestion();
            option1 = options[0];
            this.option2 = new EntityOptionQuestion();
            option2 = options[1];
            this.option3 = new EntityOptionQuestion();
            option3 = options[2];
            

            FillUpQuestion();
            

            //Check if the user has already votes
            IsUserAlreadyVoter();
            
        }

        // delete Question
        private async void DeleteQuestion(Int64 idQuestion)
        {
            await new RestQuestion().Delete(theQuestion.IdQuestion);
        }

        // Fill up Question
        private void FillUpQuestion()
        {
            
            titleQuestion.Text = theQuestion.Title;
            //QuestionDescription.Text = theQuestion.Description;
            CreatingQuestionLabelPlus();

            AuthorQuestion.Text = theQuestion.NickName;
           
            FillUpChoices(LabelChoice1, ImageChoice1, option1);
            FillUpChoices(LabelChoice2, ImageChoice2, option2);
            FillUpChoices(LabelChoice3, ImageChoice3, option3);
            
        }
        
        //Method to fill choices
        private void FillUpChoices(Label LabelToFill, CachedImage ImageToFill, EntityOptionQuestion OptionToCheck)
        {
            if(OptionToCheck.Image != null)
            {
                ImageToFill.Source = ArraytoImage(OptionToCheck.Image);
                LabelToFill.IsVisible = false;
                LabelToFill.IsEnabled = false;
            }

            else
            {
                LabelToFill.Text = OptionToCheck.TextOption;
                ImageToFill.IsEnabled = false;
                ImageToFill.IsVisible = false;
            }



        }

        // Get Image from Array
        private ImageSource ArraytoImage (Byte[] Image)
        {
            byte[] bmp = Image as byte[];
            if (bmp == null)
                return null;

            return ImageSource.FromStream(() => new MemoryStream(bmp));
        }

      
        private void CreatingQuestionLabelPlus()
        {
            AwesomeHyperLinkLabel LabelPlus = new AwesomeHyperLinkLabel();
            LabelPlus.Text = theQuestion.Description;
            LabelPlus.TextColor = Color.Black;
            MainGrid.Children.Add(LabelPlus, 0, 3);
            LabelPlusVisibility = LabelPlus;


        }

    }
}
