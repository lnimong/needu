using Need_U.Entities;
using Need_U.Objects;
using Need_U.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Need_U
{
    public partial class InvitePreview : ContentPage
    {
        Event TheInvitation;
        EntityUser TheUser;


        public InvitePreview(Event theInvitation, EntityUser theUser)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            TheUser = theUser;

            titleQuestionPreview.Text = theInvitation.TitleEvent;
            EventDescriptionPreview.Text = theInvitation.DescriptionEvent;
            AddressEventPreview.Text = theInvitation.AddressEvent;

            TheInvitation = theInvitation;

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


        private async void SenButton_Clicked(object sender, EventArgs e)
        {
            theActivityIndicator.IsRunning = true;

            EntityEvent theEvent = new EntityEvent();
            theEvent.Title = TheInvitation.TitleEvent;
            theEvent.Description = TheInvitation.DescriptionEvent;
            theEvent.DateStart = TheInvitation.StartEvent;
            theEvent.DateEnd = TheInvitation.EndEvent;
            theEvent.Address = TheInvitation.AddressEvent;
            theEvent.Latitude = TheInvitation.Latitude;
            theEvent.Longitude = TheInvitation.Longitude;
            theEvent.NickName = TheInvitation.AuthorEvent;
            theEvent.IdUser = TheUser.IdUser;

            string result =  await new RestEvent().Insert(theEvent);

            string message = new RandomList().NiceMessagesRnd();

            theActivityIndicator.IsRunning = false;

            var Aftersending =  DisplayAlert("Invitation sent", message, "Ok");
            await Navigation.PopToRootAsync();
            
        }


        #endregion

    }
}
