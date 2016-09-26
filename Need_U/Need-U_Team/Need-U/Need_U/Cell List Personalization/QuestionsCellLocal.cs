using FFImageLoading.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Need_U.Cell_List_Personalization
{
    class QuestionsCellLocal : ViewCell
    {
        public QuestionsCellLocal()

        {



            Grid grid = new Grid
            { Padding = 5,
                
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

            // Display let icon image

            CachedImage DisplayImage = new CachedImage() {
                Aspect = Aspect.AspectFill,
                DownsampleHeight = 300,
                DownsampleWidth = 300,
                
                
                //Source = "choice1.jpg",
            };

            var bnd = new Binding("OptiontoShowImage", BindingMode.Default, new ArrayToImageConverter());
            DisplayImage.SetBinding(CachedImage.SourceProperty, bnd);

            //Display left icon label

            Label DisplayLabel = new Label()
            {
                TextColor = Color.Black,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            DisplayLabel.SetBinding(Label.TextProperty, new Binding("OptiontoShowText"));


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

            if(DisplayImage != null)
            { 
            grid.Children.Add(DisplayImage, 0, 0);
            }
            if(DisplayLabel != null)
            { 
            grid.Children.Add(DisplayLabel, 0, 0);
            }



            grid.Children.Add(gridRightPart, 1, 0);

            gridRightPart.Children.Add(titlePreview, 0, 0);
            gridRightPart.Children.Add(authorNamePreview, 0, 1);
            gridRightPart.Children.Add(farAwayPreview, 0, 2);
           

            this.View = grid;


            var moreAction = new MenuItem { Text = "More" };

      
           

        }


    }



    


}
