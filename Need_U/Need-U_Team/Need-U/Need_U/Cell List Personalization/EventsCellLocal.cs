using FFImageLoading.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Need_U.Cell_List_Personalization
{
    public class EventsCellLocal : ViewCell
    
         {

        public EventsCellLocal()

        {


            Grid grid = new Grid
            {
                Padding = 5,

                RowDefinitions =
                {
                    new RowDefinition { },

                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(30, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(70, GridUnitType.Star) },

                }


            };
            //Grid Left Side 

            Grid leftSide = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(70, GridUnitType.Star)},
                    new RowDefinition { Height = new GridLength(30, GridUnitType.Star)},

                },


            };


            // Display event icon image


            CachedImage DisplayImage = new CachedImage()
            {
                Aspect = Aspect.AspectFill,
                DownsampleHeight = 300,
                DownsampleWidth = 300,
                Source = "events.png"
            };

            //var bnd = new Binding("EventImage", BindingMode.Default, new ArrayToImageConverter());
            //DisplayImage.SetBinding(CachedImage.SourceProperty, bnd);




            Label IsEventToday = new Label()
            {
                TextColor = Color.Red,
                HorizontalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),

            };
            IsEventToday.SetBinding(Label.TextProperty, new Binding("TodayEvent"));


            Grid gridRightPart = new Grid
            {

                RowDefinitions =
                {
                    new RowDefinition {  },
                    new RowDefinition {  },
                    new RowDefinition {  },

                },
                ColumnDefinitions =
                {
                    new ColumnDefinition {  },

                }


            };

            Label titlePreview = new Label()
            {
                TextColor = Color.Blue,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                Text = "Titre de la question ici"
            };
            titlePreview.SetBinding(Label.TextProperty, new Binding("Title"));


            Label authorNamePreview = new Label()
            {
                TextColor = Color.Black,
                Text = "Djkl"
            };
            authorNamePreview.SetBinding(Label.TextProperty, new Binding("NickName"));


            Label farAwayPreview = new Label()
            {
                TextColor = Color.Black,
                Text = "2 km"
            };
            farAwayPreview.SetBinding(Label.TextProperty, new Binding("Km", stringFormat: "{0:0.00} Km"));



            leftSide.Children.Add(DisplayImage, 0, 1, 0, 2);
            leftSide.Children.Add(IsEventToday, 0, 1);

            grid.Children.Add(leftSide, 0, 0);
            grid.Children.Add(gridRightPart, 1, 0);



            gridRightPart.Children.Add(titlePreview, 0, 0);
            gridRightPart.Children.Add(authorNamePreview, 0, 1);
            gridRightPart.Children.Add(farAwayPreview, 0, 2);


            this.View = grid;

            

        }

    }
}
