using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Need_U
{
    class FakeChoices
    {
        public OptionChoice Choice1 { get; set; }
        public OptionChoice Choice2 { get; set; }
        public OptionChoice Choice3 { get; set; }
        public OptionChoice Choice4 { get; set; }
        public OptionChoice Choice5 { get; set; }
        public OptionChoice Choice6 { get; set; }


        Image imageChoice;

        public FakeChoices()
        {

            FakeChoice1();
            FakeChoice2();
            FakeChoice3();
            FakeChoice4();
            FakeChoice5();
            FakeChoice6();

        }

        private void FakeChoice1()
        {
            Choice1 = new OptionChoice();
            Choice1.TxtChoice = "This is the super Choice !! ";

        }

        private void FakeChoice2()
        {
            Choice2 = new OptionChoice();
            Choice2.TxtChoice = "This is the Amazing Choice !! ";

        }

        private void FakeChoice3()
        {
            Choice3 = new OptionChoice();
            Choice3.TxtChoice = "This is the Awesome Choice !! ";

        }

        private void FakeChoice4()
        {
            Choice4 = new OptionChoice();

            imageChoice = new Image();
            imageChoice.Source = "choice1.jpg";
            Choice4.ImageChoice = imageChoice;           
            
        }

        private void FakeChoice5()
        {
            Choice5 = new OptionChoice();

            imageChoice = new Image();
            imageChoice.Source = "choice2.jpg";
            Choice5.ImageChoice = imageChoice;

        }

        private void FakeChoice6()
        {
            Choice6 = new OptionChoice();

            imageChoice = new Image();
            imageChoice.Source = "choice3.jpg";
            Choice6.ImageChoice = imageChoice;

        }



    }
}
