using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Geolocator;
using Need_U.Objects;
using FFImageLoading.Forms;
using Plugin.Geolocator.Abstractions;
using GeoCoordinatePortable;

namespace Need_U
{
    public class Event : PublicationInterface
    {
        public int IdEvent { get; set; }
        public string TitleEvent { get; set; }
        public DateTime StartEvent { get; set; }
        public DateTime EndEvent { get; set; }
        public string DescriptionEvent { get; set; }
        public string AddressEvent { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int NumberLikeEvent { get; set; }
        public int NumberDislikeEvent { get; set; }
        public string AuthorEvent { get; set; }
        public CachedImage EventImage { get; set; }
        public string DistanceFromUser { get; set; }


        public Event()
        {

        }


        public Event(User UserAuthor)
        {
            AuthorEvent = UserAuthor.UserNickname;
            EventImage.Source = "Female.png";
        }

        public Event(Position ViewerPosition )
        {

            DistanceFromUser = distance(ViewerPosition.Latitude, ViewerPosition.Longitude, Latitude, Longitude, 'K').ToString("00.00 Km");
            //CalculteDistancePositions2(ViewerPosition.Latitude, ViewerPosition.Longitude, Latitude, Longitude);




        }







        private double distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            if (unit == 'K')
            {
                dist = dist * 1.609344;
            }
            else if (unit == 'N')
            {
                dist = dist * 0.8684;
            }
            return (dist);
        }


        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }
        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }




        // method 2

        private void CalculteDistancePositions2(double lat1, double lon1, double lat2, double lon2)
        {
            double latA = lat1;
            double longA = lon1;
            double latB = lat2;
            double longB = lon2;

            var locA = new GeoCoordinate(latA, longA);
            var locB = new GeoCoordinate(latB, longB);
            double distance = locA.GetDistanceTo(locB); // metres
            DistanceFromUser = (distance/1000).ToString("00.00 Km");
            
        }

   



    }
}
