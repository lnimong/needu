using Need_U.Cell_List_Personalization;
using Need_U.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Need_U
{
    public partial class CrowdPage : ContentPage
    {

        List<Question> QuestionsList;
        FakeQuestions fakeQuestions;
        
        public CrowdPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            QuestionsList = new List<Question>();
            fakeQuestions = new FakeQuestions();

            QuestionsList.Add(fakeQuestions.Question1);
            QuestionsList.Add(fakeQuestions.Question2);
            QuestionsList.Add(fakeQuestions.Question3);
            QuestionsList.Add(fakeQuestions.Question4); 

            CrowdListView.ItemsSource = QuestionsList;
            CrowdListView.ItemTemplate = new DataTemplate(typeof(CrowdCellList));
            
            

        }


        
        #region Navigation
        // Navigation

        private async void onTapbackButtonCrowd(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }

        private async void onTapNavButtonCrowd(object sender, EventArgs args)
        {
            await Navigation.PopToRootAsync();
        }

        private async void OnTapItemList(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FinalQuestion());

        }



        #endregion




    }
}
