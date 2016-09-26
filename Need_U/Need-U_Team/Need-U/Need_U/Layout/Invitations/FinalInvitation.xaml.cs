using Need_U.Cell_List_Personalization;
using Need_U.Entities;
using Need_U.Objects;
using Need_U.Service;
using Plugin.ExternalMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Need_U.Layout.Invitations
{


    public partial class FinalInvitation : ContentPage
    {
        EntityUser TheUser;
        List<EntityCommentEvent> ListOfComments;
        EntityEvent TheEvent;
        
        

        public FinalInvitation(Int64 IdEventSelected, EntityUser theUser)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            TheUser = theUser;

            EventById(IdEventSelected);
            
            
        }
       
        

        // Navigation Area
        private async void onTapbackButton(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }

        private async void onTapNavButton(object sender, EventArgs args)
        {
            await Navigation.PopToRootAsync();
        }


        // Menu Bookmark and Delete
        public async void onTapMenuButton(object sender, EventArgs e)
        {
            if (TheEvent.IdUser != TheUser.IdUser)
            {
                var action1 = await DisplayActionSheet("Question", "Cancel", null, "Bookmark");
                switch (action1)
                {
                    case "Bookmark":
                        await new RestFavorite().FavoriteEventInsert(TheEvent.IdEvent, TheUser.IdUser);
                        break;

                }
            }


            if (TheEvent.IdUser == TheUser.IdUser)
            {

                var action2 = await DisplayActionSheet("Question", "Cancel", null, "Bookmark", "Delete");
                switch (action2)
                {
                    case "Bookmark":
                        await new RestFavorite().FavoriteEventInsert(TheEvent.IdEvent, TheUser.IdUser);
                        break;
                    case "Delete":
                        await new RestEvent().Delete(TheEvent.IdEvent);
                        break;
                }


            }
        }


        // Send to GPS
        private async void onTapGoButton(object sender, EventArgs e)
        {
            var success = await CrossExternalMaps.Current.NavigateTo("La direction donde vas", TheEvent.Latitude, TheEvent.Longitude);

        }

      
        // Voting system
        private async void onTapLikeButton(object sebder, EventArgs e)
        {

            EntityEventLike Ilike = new EntityEventLike();
            Ilike.IdEvent = TheEvent.IdEvent;
            Ilike.IdUser = TheEvent.IdUser;
            Ilike.Like = true;

            await new RestEvent().InsertEventLike(Ilike);
            GettingTheVotesResults();

        }

        private async void onTapDislikeButton(object sebder, EventArgs e)
        {

            EntityEventLike Idislike = new EntityEventLike();
            Idislike.IdEvent = TheEvent.IdEvent;
            Idislike.IdUser = TheEvent.IdUser;
            Idislike.Like = false;

            await new RestEvent().InsertEventLike(Idislike);
            GettingTheVotesResults();

        }
        

        private async void GettingTheVotesResults()
        {
            EntityEventLike voteResult = new EntityEventLike();
            voteResult = await new RestEvent().SelectEventLike(TheEvent.IdEvent);

            int totalOfVotes = voteResult.NumberOfLike.Value + voteResult.NumberOfDisLike.Value;

            double votelikePercent = Convert.ToDouble(voteResult.NumberOfLike * 100 / totalOfVotes);
            double voteDislikePercent = 100 - votelikePercent;

            SettingVotesView(votelikePercent, voteDislikePercent);
        }

        private void SettingVotesView(double voteLike, double voteDislike)
        {
            //Like
            GridResultLike.Width = new GridLength(voteLike, GridUnitType.Star);
            GridLeftSpaceLike.Width = new GridLength(100 - voteLike, GridUnitType.Star);
            GridVoteResultLike.IsVisible = true;
            PercentLikeLabel.Text = voteLike.ToString() + "%";

            //Choice2
            GridResultDislike.Width = new GridLength(voteDislike, GridUnitType.Star);
            GridLeftSpaceDislike.Width = new GridLength(100 - voteDislike, GridUnitType.Star);
            GridVoteResultDislike.IsVisible = true;
            PercentDislikeLabel.Text = voteDislike.ToString() + "%";

        }



        // Comments Area

        private void onTapCloseButton(object sender, EventArgs e)
        {
            DisplayComments.IsEnabled = false;
            DisplayComments.IsVisible = false;

        }

        private void btnComment_Clicked(object sender, EventArgs e)
        {
            DisplayComments.IsVisible = true;
            DisplayComments.Opacity = 0;
            DisplayComments.FadeTo(1, 1500);
            DisplayComments.IsEnabled = true;

            GettingListComent();


        }

        private async void InsertComment(object sender, EventArgs e)
        {

            EntityCommentEvent theComent = new EntityCommentEvent();
            theComent.Comment = entryComment.Text;
            theComent.IdUser = TheUser.IdUser;
            theComent.IdEvent = TheEvent.IdEvent;
            theComent.NickNameUser = TheUser.NickName;
            theComent.Date = DateTime.Now;


            string result = await new RestComment().InsertCommentEvent(theComent);

            string message = new RandomList().NiceMessagesRnd();

            await DisplayAlert("Comment sent", message, "Ok");

            GettingListComent();
            entryComment.Text = "";
            

        }

        private async void GettingListComent()
        {
            ListOfComments = new List<EntityCommentEvent>();
            ListOfComments = await new RestComment().SelectCommentsEvent(TheEvent.IdEvent);

            ListComments.ItemsSource = ListOfComments;
            ListComments.ItemTemplate = new DataTemplate(typeof(CommentsCellList));
        }

        // Methods

            // Fill invitation with datas
        private void FillInvitation()
        {

            LabelAuthorName.Text = TheEvent.NickName;
            LabeltitleQuestion.Text = TheEvent.Title;
            EventDescription.Text = TheEvent.Description;
            AddressEvent.Text = TheEvent.Address;

            string date;
            date = String.Format("{0:dddd d MMM yyyy}", TheEvent.DateStart) + " - " + String.Format("{0:dddd d MMM yyyy}", TheEvent.DateEnd);
            DateEvent.Text = date;


        }


            // Getting The Event By ID

       private async void EventById(Int64 IdEvent)
        {
            TheEvent = new EntityEvent();
            TheEvent = await new RestEvent().SelectEventById(IdEvent);
            FillInvitation();
            IsUserAVoter();


        }
       
        
        //Check if the user had already voted
        private async void  IsUserAVoter()
        {
            EntityEventLike reponse = new EntityEventLike();

            reponse = await new RestEvent().EventLikeByUser(TheEvent.IdEvent, TheUser.IdUser);

            if (reponse != null)
            {
                GettingTheVotesResults();
            }

            else return;
           
        }

        
    }
}
