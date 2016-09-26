using FFImageLoading.Forms;
using FFImageLoading.Work;
using FFImageLoading.Transformations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Need_U.Objects;

namespace Need_U.Cell_List_Personalization
{
    class CommentsCellList : ViewCell
    {
        public CommentsCellList() { 

        Grid grid = new Grid
        {
            Padding = 5,

            RowDefinitions =
                {
                    new RowDefinition { },

                },
            ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(20, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(80, GridUnitType.Star) },

                }


        };

        Grid gridCol1 = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition {Height = new GridLength(90, GridUnitType.Auto) },
                new RowDefinition { Height = new GridLength(10, GridUnitType.Auto)},
            },

            ColumnDefinitions =
            {

                new ColumnDefinition { },
            }
            
        };



            CachedImage imageUser = new CachedImage()
            {
                Aspect = Aspect.AspectFit,
                DownsampleHeight = 50,
                //DownsampleWidth = 50,
                Transformations = new System.Collections.Generic.List<ITransformation>()
            {
          //new GrayscaleTransformation(),
           new CircleTransformation(2, "#FF0000"),
           },

          Source = new RandomList().MixImageSourceRnd(),

            //Source = "Female.png",
        };

            //imageUser.SetBinding(CachedImage.SourceProperty, new Binding("PhotoUrl"));
            //if(imageUser.Source == null)
            //{
            //    imageUser.Source = "Female.png";
            //}



            Label AliasUser = new Label
            {
                Text = "UserNickname",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
            VerticalOptions = LayoutOptions.StartAndExpand,
            TextColor = Color.Gray,

        };
            AliasUser.SetBinding(Label.TextProperty, new Binding("NickNameUser"));
            




            Label ComentUSer = new Label
            {
                TextColor = Color.Black,
                Text = "This is a comment from a user !This is a comment from a user !This is a comment from a user !This is a comment from a user !This is a comment from a user !This is a comment from a user !This is a comment from a user !This is a comment from a user !This is a comment from a user !"
            };
            ComentUSer.SetBinding(Label.TextProperty, new Binding("Comment"));



            gridCol1.Children.Add(ComentUSer, 0, 0);
            gridCol1.Children.Add(AliasUser, 0, 1);

            grid.Children.Add(imageUser, 0, 0);
            grid.Children.Add(gridCol1, 1, 0);

            this.View = grid;


        }


    }
}
