using Need_U.Entities;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Need_U
{
    public partial class publicationTool : ContentPage
    {

        public Question TheQuestion { get; set; }
        public OptionChoice Choice1 { get; set; }
        public OptionChoice Choice2 { get; set; }
        public OptionChoice Choice3 { get; set; }

        EntityUser theUser;

      
        public publicationTool(EntityUser theUser)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            this.theUser = theUser;

            TheQuestion = new Question(Choice1, Choice2, Choice3);
            Choice1 = new OptionChoice();
            Choice2 = new OptionChoice();
            Choice3 = new OptionChoice();

            
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

        // Go to edit Invitation

        private async void inviteButton_OnClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new InviteTool(theUser));
        }
        
        private async void previewButton_OnClick(object sender, EventArgs args)
        {
            TheQuestion.TitleQuestion = EntryTitleQuestion.Text;
            TheQuestion.DescriptionQuestion = EditorQuestion.Text;
            
            //choice 1
            if(choice1Switch.IsToggled == true)
            {
                Choice1.ImageChoice = cameraImageChoice1;
                Choice1.TxtChoice = "";
                
            }
            if (choice1Switch.IsToggled == false)
            {
                Choice1.TxtChoice = choice1Entry.Text;
                Choice1.ImageChoice = null;
            }
            // choice2

            if (choice2Switch.IsToggled == true)
            {
                Choice2.ImageChoice = cameraImageChoice2;
                Choice2.TxtChoice = "";
            }
            if (choice2Switch.IsToggled == false)
            {
                Choice2.TxtChoice = choice2Entry.Text;
                Choice2.ImageChoice = null;
            }
            //choice 3
            if (choice3Switch.IsToggled == true)
            {
                Choice3.ImageChoice = cameraImageChoice3;
                Choice3.TxtChoice = "";
            }
            if (choice3Switch.IsToggled == false)
            {
                Choice3.TxtChoice = choice3Entry.Text;
                Choice3.ImageChoice = null;
            }

            await Navigation.PushAsync(new PreviewQuestion(TheQuestion, Choice1, Choice2, Choice3, theUser));

                   

        }
        #endregion

        #region Enable Preview
        // Logic to enable preview

        bool Title_Ok = false;
        bool Question_Ok = false;
        bool Choice1_OK = false;
        bool Choice2_OK = false;
        bool Choice3_OK = false;
        

        void TextChangedChoice1 (object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(choice1Entry.Text) || string.IsNullOrWhiteSpace(choice1Entry.Text))
            {
                Choice1_OK = false;
            }
            else { Choice1_OK = true; }

            if (Choice1_OK == true && Choice2_OK == true && Choice3_OK == true && Title_Ok == true && Question_Ok == true)
           {
                PreviewButton.IsEnabled = true;

           }
            else { PreviewButton.IsEnabled = false; }
        }

        void TextChangedChoice2(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(choice2Entry.Text) || string.IsNullOrWhiteSpace(choice2Entry.Text))
            {
                Choice2_OK = false;
            }
            else { Choice2_OK = true; }


            if (Choice1_OK == true && Choice2_OK == true && Choice3_OK == true && Title_Ok == true && Question_Ok == true)
            {
                PreviewButton.IsEnabled = true;
            }
            else { PreviewButton.IsEnabled = false; }
        }

        void TextChangedChoice3(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(choice3Entry.Text) || string.IsNullOrWhiteSpace(choice3Entry.Text))
            {
                Choice3_OK = false;
            }
            else { Choice3_OK = true; }

            if (Choice1_OK == true && Choice2_OK == true && Choice3_OK == true && Title_Ok == true && Question_Ok == true)
            {
                PreviewButton.IsEnabled = true;
            }
            else { PreviewButton.IsEnabled = false; }
        }

        void TitleTextChange(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EntryTitleQuestion.Text) || string.IsNullOrWhiteSpace(EntryTitleQuestion.Text))
            {
                Title_Ok = false;
            }
            else { Title_Ok = true; }

            if (Choice1_OK == true && Choice2_OK == true && Choice3_OK == true && Title_Ok == true && Question_Ok == true)
            {
                PreviewButton.IsEnabled = true;
            }
            else { PreviewButton.IsEnabled = false; }
        }
        void QuestionTexteChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EditorQuestion.Text) || string.IsNullOrWhiteSpace(EditorQuestion.Text))
            {
                Question_Ok = false;
            }
            else { Question_Ok = true; }

            if (Choice1_OK == true && Choice2_OK == true && Choice3_OK == true && Title_Ok == true && Question_Ok == true)
            {
                PreviewButton.IsEnabled = true;
            }
            else { PreviewButton.IsEnabled = false; }
        }



        #endregion
        
        #region Choices
        // Choices code

        //choice 1
        void choice1Switch_toggled(object sender, EventArgs e)
        {
            if(choice1Switch.IsToggled == true)
            {
                cameraImageChoice1.IsVisible = true;
                cameraImageChoice1.IsEnabled = true;
                choice1Entry.IsEnabled = false;
                choice1Entry.IsVisible = false;
                backGroundEntryChoice1.IsVisible = false;
            }

            else if(choice1Switch.IsToggled == false)
            {
                cameraImageChoice1.IsVisible = false;
                cameraImageChoice1.IsEnabled = false;
                choice1Entry.IsEnabled = true;
                choice1Entry.IsVisible = true;
                backGroundEntryChoice1.IsVisible = true;


            }
        }
        
        // Use Gallery image choice1
        private async void onTapCameraChoice1ToolButton(object sender, EventArgs args)
        {
            var file = await CrossMedia.Current.PickPhotoAsync();
            
            if (file == null)
                return;

            

           cameraImageChoice1.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                //file.Dispose();
                return stream;                
            });

           

            

            Choice1_OK = true;

            if (Choice1_OK == true && Choice2_OK == true && Choice3_OK == true && Title_Ok == true && Question_Ok == true)
            {
                PreviewButton.IsEnabled = true;
            }


        }


        //choice 2
        void choice2Switch_toggled(object sender, EventArgs e)
        {
            if (choice2Switch.IsToggled == true)
            {
                cameraImageChoice2.IsVisible = true;
                cameraImageChoice2.IsEnabled = true;
                choice2Entry.IsEnabled = false;
                choice2Entry.IsVisible = false;
                backGroundEntryChoice2.IsVisible = false;
            }

            else if (choice2Switch.IsToggled == false)
            {
                cameraImageChoice2.IsVisible = false;
                cameraImageChoice2.IsEnabled = false;
                choice2Entry.IsEnabled = true;
                choice2Entry.IsVisible = true;
                backGroundEntryChoice2.IsVisible = true;
            }
        }

        // Use Gallery image choice2
        private async void onTapCameraChoice2ToolButton(object sender, EventArgs args)
        {
            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
                return;

            cameraImageChoice2.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                //file.Dispose();
                return stream;
            });

            Choice2_OK = true;

            if (Choice1_OK == true && Choice2_OK == true && Choice3_OK == true && Title_Ok == true && Question_Ok == true)
            {
                PreviewButton.IsEnabled = true;
            }

        }

        // choice 3
        void choice3Switch_toggled(object sender, EventArgs e)
        {
            if (choice3Switch.IsToggled == true)
            {
                cameraImageChoice3.IsVisible = true;
                cameraImageChoice3.IsEnabled = true;
                choice3Entry.IsEnabled = false;
                choice3Entry.IsVisible = false;
                backGroundEntryChoice3.IsVisible = false;
            }

            else if (choice3Switch.IsToggled == false)
            {
                cameraImageChoice3.IsVisible = false;
                cameraImageChoice3.IsEnabled = false;
                choice3Entry.IsEnabled = true;
                choice3Entry.IsVisible = true;
                backGroundEntryChoice3.IsVisible = true;


            }
        }


        //USe Gallery choice3

        private async void onTapCameraChoice3ToolButton(object sender, EventArgs args)
        {
            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
                return;

            cameraImageChoice3.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                //file.Dispose();
                return stream;
            });

            Choice3_OK = true;

            if (Choice1_OK == true && Choice2_OK == true && Choice3_OK == true && Title_Ok == true && Question_Ok == true)
            {
                PreviewButton.IsEnabled = true;
            }

        }

#endregion



    }
}
