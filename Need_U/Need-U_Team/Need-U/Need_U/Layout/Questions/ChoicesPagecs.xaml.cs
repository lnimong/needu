using FFImageLoading.Forms;
using Need_U.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Need_U.Layout.Questions
{
    public partial class ChoicesPagecs : CarouselPage
    {
        EntityOptionQuestion option1;
        EntityOptionQuestion option2;
        EntityOptionQuestion option3;




        public ChoicesPagecs(EntityOptionQuestion option1, EntityOptionQuestion option2, EntityOptionQuestion option3, int choice)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);


            if(choice == 1)   { CurrentPage = Page1; }
            if (choice == 2) { CurrentPage = Page2; }
            if (choice == 3) { CurrentPage = Page3; }

            this.option1 = option1;
            this.option2 = option2;
            this.option3 = option3;

            FillUpChoicesLabelPlus();


            //FillUpChoices(LabelChoice1, ImageChoice1, option1);
            //FillUpChoices(LabelChoice2, ImageChoice2, option2);
            //FillUpChoices(LabelChoice3, ImageChoice3, option3);

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

        #endregion

        private void FillUpChoices(Label LabelToFill, CachedImage ImageToFill, EntityOptionQuestion OptionToCheck)
        {
            if (OptionToCheck.Image != null)
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



        // Fill Up choices longMethod for LabelPlus

            private void FillUpChoicesLabelPlus()
        {
            // Choice1 


            if (option1.Image != null)
            {
                ImageChoice1.Source = ArraytoImage(option1.Image);
                Grid_Choice1Label.IsVisible = false;
                Grid_Choice1Label.IsEnabled = false;
            }

            else
            {
                AwesomeHyperLinkLabel LabelPlus1 = new AwesomeHyperLinkLabel();                
                LabelPlus1.Text = option1.TextOption;
                LabelPlus1.TextColor = Color.Black;
                LabelPlus1.HorizontalTextAlignment = TextAlignment.Center;
                LabelPlus1.VerticalTextAlignment = TextAlignment.Center;
                LabelPlus1.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                LabelPlus1.HorizontalOptions = LayoutOptions.CenterAndExpand ;
                LabelPlus1.VerticalOptions = LayoutOptions.CenterAndExpand;

                Grid_Choice1Label.Children.Add(LabelPlus1);
                Grid_Choice1Image.IsEnabled = false;
                Grid_Choice1Image.IsVisible = false;
            }

            //Choice2

            if (option2.Image != null)
            {
                ImageChoice2.Source = ArraytoImage(option2.Image);
                Grid_Choice2Label.IsVisible = false;
                Grid_Choice2Label.IsEnabled = false;
            }

            else
            {
                AwesomeHyperLinkLabel LabelPlus2 = new AwesomeHyperLinkLabel();
                LabelPlus2.Text = option2.TextOption;
                LabelPlus2.TextColor = Color.Black;
                LabelPlus2.HorizontalTextAlignment = TextAlignment.Center;
                LabelPlus2.VerticalTextAlignment = TextAlignment.Center;
                LabelPlus2.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                LabelPlus2.HorizontalOptions = LayoutOptions.CenterAndExpand;
                LabelPlus2.VerticalOptions = LayoutOptions.CenterAndExpand;
                Grid_Choice2Label.Children.Add(LabelPlus2);
                Grid_Choice2Image.IsEnabled = false;
                Grid_Choice2Image.IsVisible = false;
            }




            //Choice3

            if (option3.Image != null)
            {
                ImageChoice3.Source = ArraytoImage(option3.Image);
                Grid_Choice3Label.IsVisible = false;
                Grid_Choice3Label.IsEnabled = false;
            }

            else
            {
                AwesomeHyperLinkLabel LabelPlus3 = new AwesomeHyperLinkLabel();
                LabelPlus3.Text = option3.TextOption;
                LabelPlus3.TextColor = Color.Black;
                LabelPlus3.HorizontalTextAlignment = TextAlignment.Center;
                LabelPlus3.VerticalTextAlignment = TextAlignment.Center;
                LabelPlus3.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                LabelPlus3.HorizontalOptions = LayoutOptions.CenterAndExpand;
                LabelPlus3.VerticalOptions = LayoutOptions.CenterAndExpand;
                Grid_Choice3Label.Children.Add(LabelPlus3);
                Grid_Choice3Image.IsEnabled = false;
                Grid_Choice3Image.IsVisible = false;
            }




        }


        // Get Image from Array
        private ImageSource ArraytoImage(Byte[] Image)
        {
            byte[] bmp = Image as byte[];
            if (bmp == null)
                return null;

            return ImageSource.FromStream(() => new MemoryStream(bmp));
        }


    }
}
