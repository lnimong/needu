using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Need_U
{
    class FakeQuestions
    {
        public Question Question1 { get; set; }
        public Question Question2 { get; set; }
        public Question Question3 { get; set; }
        public Question Question4 { get; set; }

        FakeUsers fakeUsers;
        FakeChoices fakeChoices;

        public FakeQuestions()
        {
            fakeUsers = new FakeUsers();
            fakeChoices = new FakeChoices();
            FakeQuestion1();
            FakeQuestion2();
            FakeQuestion3();
            FakeQuestion4();

        }

        private void FakeQuestion1()
        {
            Question1 = new Question();
            Question1.AuthorQuestion = fakeUsers.Seb;
            Question1.TitleQuestion = "This is my super question !! ";
            Question1.DescriptionQuestion = "I was wondering if you know what would be the best choice for me ?";
            Question1.Choice1 = fakeChoices.Choice1;
            Question1.Choice2 = fakeChoices.Choice5;
            Question1.Choice3 = fakeChoices.Choice6;
        }

        private void FakeQuestion2()
        {
            Question2 = new Question();
            Question2.AuthorQuestion = fakeUsers.Anna;
            Question2.TitleQuestion = "This is my super question !! ";
            Question2.DescriptionQuestion = "I was wondering if you know what would be the best choice for me ?";
            Question2.Choice1 = fakeChoices.Choice3;
            Question2.Choice2 = fakeChoices.Choice4;
            Question2.Choice3 = fakeChoices.Choice1;
        }

        private void FakeQuestion3()
        {
            Question3 = new Question();
            Question3.AuthorQuestion = fakeUsers.Andres;
            Question3.TitleQuestion = "This is my super question !! ";
            Question3.DescriptionQuestion = "I was wondering if you know what would be the best choice for me ?";
            Question3.Choice1 = fakeChoices.Choice4;
            Question3.Choice2 = fakeChoices.Choice3;
            Question3.Choice3 = fakeChoices.Choice2;
        }

        private void FakeQuestion4()
        {
            Question4 = new Question();
            Question4.AuthorQuestion = fakeUsers.Andres;
            Question4.TitleQuestion = "This is my super question !! ";
            Question4.DescriptionQuestion = "I was wondering if you know what would be the best choice for me ?";
            Question4.Choice1 = fakeChoices.Choice4;
            Question4.Choice2 = fakeChoices.Choice3;
            Question4.Choice3 = fakeChoices.Choice2;
        }

    }
}
