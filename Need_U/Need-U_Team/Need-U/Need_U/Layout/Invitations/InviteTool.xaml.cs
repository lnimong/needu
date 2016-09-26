using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using TK.CustomMap;
using System.Collections.ObjectModel;
using Need_U.Entities;

namespace Need_U
{
    public partial class InviteTool : ContentPage 
    {

        EntityUser TheUser;
        
        Event TheInvitation;
        TKCustomMap mapTk;
        private  ObservableCollection<TKCustomMapPin> _pins;
        TKCustomMapPin TkPin;

        bool geocodeAdress;


        private bool IsUserFound { get; set; }

       

        public InviteTool(EntityUser theUser)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            DatePickerStartInvitation.MinimumDate = DateTime.Now.Date;
            DatePickerEndInvitation.MinimumDate = DatePickerStartInvitation.Date;

            geocodeAdress = true;

            TheUser = theUser;

            TheInvitation = new Event();
            CreateTkMap();

            MoveMapToUserLocation(new Position(theUser.Latitude, theUser.Longitude));

            IsUserFound = false;          
            GetUserPosition();

            
               

        }
        
        #region Navigation

        private async void onTapLogoNavButton(object sender, EventArgs args)
        {
            await Navigation.PopToRootAsync();
        }

        private async void onTapBackNavButton(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }


        private async void Ask_OnClicked(object sender, EventArgs args)
        {
            var locator = CrossGeolocator.Current;
            if (locator.IsGeolocationAvailable == true && locator.IsGeolocationEnabled == true)
            {
                await Navigation.PopAsync();
            }
            else { await DisplayAlert("GPS", "Please activate the GPS", "Ok", "Cancel"); }
            
        }



        // Click on preview.

        private  void previewButton_Cliked(object send, EventArgs e)
        {
            TheInvitation.TitleEvent =  EntryTitleInvitation.Text;
            TheInvitation.StartEvent = DatePickerStartInvitation.Date;
            TheInvitation.EndEvent = DatePickerEndInvitation.Date;
            TheInvitation.AddressEvent = EditorAddressEnvent.Text;
            TheInvitation.Latitude = TkPin.Position.Latitude;
            TheInvitation.Longitude = TkPin.Position.Longitude;
            TheInvitation.DescriptionEvent = EditorDescriptionEnvent.Text;
            TheInvitation.NumberLikeEvent = 20;
            TheInvitation.NumberDislikeEvent = 2;
            TheInvitation.AuthorEvent = TheUser.NickName;
            Navigation.PushAsync(new InvitePreview(TheInvitation, TheUser));
           
        }

        #endregion





        // Map Methods

                // Get the user position

        private async void GetUserPosition()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync(timeoutMilliseconds: 15000);
                TheUser.Latitude = position.Latitude;
                TheUser.Longitude = position.Longitude;


                Position positionMap = new Position(position.Latitude, position.Longitude);

                MoveMapToUserLocation(positionMap);
            }
            catch (Exception)
            {

                
            }

           
           

        }


        // setting the date picker

            private void StartEvent_DateSelected(object sender, EventArgs e)
        {
            //DatePickerEndInvitation.IsEnabled = true;
            DatePickerEndInvitation.MinimumDate = DatePickerStartInvitation.Date;
        }


        private void EndEvent_DateSelected(object sender, EventArgs e)
        {
            
            DatePickerStartInvitation.MaximumDate = DatePickerEndInvitation.Date;
        }

      


        // Creating the Map and the Pin

        private void CreateTkMap()
        {
            mapTk = new TKCustomMap();
            mapTk.MapType = Xamarin.Forms.Maps.MapType.Hybrid;
            mapTk.IsShowingUser = false; 
            _pins = new ObservableCollection<TKCustomMapPin>();
            mapTk.CustomPins = _pins;
            TkPin = new TKCustomMapPin();
            TkPin.Title = "Here !";
            TkPin.IsVisible = true;
            TkPin.IsDraggable = true;
            _pins.Add(TkPin);

            GridMap.Children.Add(mapTk, 1, 2, 0, 2);

        }



        // Move the map the the correct position

        private void  MoveMapToUserLocation(Position positionMap)
        {
            Position position = new Position(positionMap.Latitude, positionMap.Longitude);
           
             mapTk.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(0.07)));

            
            TkPin.Position = position;
            
        }


        private void onTapMapButton(object sender, EventArgs e)
        {
          

            if (geocodeAdress == true)
            {
                MapButton.Source = "CheckButton.png";
                geocodeAdress = false;
            }

            else if (geocodeAdress == false)
            {
                MapButton.Source = "CheckButtonOff.png";
                geocodeAdress = true;
            }


        }


        // Geocode a written address

        private async void GeocodeAddress(string Address)
        {
            Geocoder geocoder = new Geocoder();
            string address = Address;
            var approximateLocations = await geocoder.GetPositionsForAddressAsync(address);

            if (approximateLocations != null && approximateLocations.GetEnumerator().MoveNext())
            {

                List<Position> positionsFromGeocode = new List<Position>();
                foreach (var position in approximateLocations)
                {
                    positionsFromGeocode.Add(position);

                }

                if (positionsFromGeocode.Count == 0) { return; }
                else { MoveMapToUserLocation(positionsFromGeocode[0]); }
            }

            
           
        }


        private async void GeocodePositionToAdress()
        {
            Geocoder geocoder = new Geocoder();

            Position position = new Position(TheUser.Latitude, TheUser.Longitude);
            var adresses = await geocoder.GetAddressesForPositionAsync(position);


            if (adresses!= null)
            {

                List<string> addresssFromGeocode = new List<string>();
                foreach (var adress in adresses)
                {
                    addresssFromGeocode.Add(adress);

                }

                if (addresssFromGeocode.Count == 0) { return; }
                else { EditorAddressEnvent.Text = addresssFromGeocode[0]; }
            }



        }

       

       
       


        #region Enable Preview

        //EnablePReview Attributes
        bool titleEvent = false;
        bool addressEvent = false;
        bool descriptionEVent = false;

        void TitleEvent_Change(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(EntryTitleInvitation.Text) || string.IsNullOrWhiteSpace(EntryTitleInvitation.Text))
            {
                titleEvent = false;
            }
            else { titleEvent = true; }
            CheckIfEnablePreview();
        }

        void EditorAddressEvent_TextChanged(Object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EditorAddressEnvent.Text) || string.IsNullOrWhiteSpace(EditorAddressEnvent.Text))
            {
                addressEvent = false;
            }


            else
            { addressEvent = true;

             string address = EditorAddressEnvent.Text;

                if (geocodeAdress == true) { GeocodeAddress(address); }

            }

            CheckIfEnablePreview();
        }




        void EditorDescriptionEvent_ChangedText(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EditorDescriptionEnvent.Text) || string.IsNullOrWhiteSpace(EditorDescriptionEnvent.Text))
            {
                descriptionEVent = false;
            }


            else { descriptionEVent = true;}

            CheckIfEnablePreview();


        }





        void CheckIfEnablePreview()
        {
            if (titleEvent == true && addressEvent == true && descriptionEVent == true)
            {
                PreviewButton.IsEnabled = true;
            }
            else { PreviewButton.IsEnabled = false; }
        }

        #endregion


      

    }

}
