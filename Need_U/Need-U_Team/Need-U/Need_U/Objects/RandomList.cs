using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Need_U.Objects
{
    class RandomList
    {

        

      public RandomList()
        {
            

        }


        public string maleImageSourceRnd()
        {

           List<string> imageMale = new List<string>();

            imageMale.Add("malePride.jpg");
            imageMale.Add("malePush.jpg");
            imageMale.Add("maleYo.jpg");
            imageMale.Add("femaleMaleLove.jpg");
                                  
            string source;

            Random rnd = new Random();
            int index = rnd.Next(0, imageMale.Count);

            source = imageMale[index];

            return source;
        }




        public string FemaleImageSourceRnd()
        {

            List<string> imageMale = new List<string>();

            imageMale.Add("femaleBoo.jpg");
            imageMale.Add("femaleGr.jpg");
            imageMale.Add("femaleMaleLove.jpg");
            imageMale.Add("femaleNeedU.jpg");
            

            string source;

            Random rnd = new Random();
            int index = rnd.Next(0, imageMale.Count);

            source = imageMale[index];

            return source;
        }


        public string MixImageSourceRnd()
        {

            List<string> imageMale = new List<string>();

            imageMale.Add("femaleBoo.jpg");
            imageMale.Add("femaleGr.jpg");
            imageMale.Add("femaleMaleLove.jpg");
            imageMale.Add("femaleNeedU.jpg");
            imageMale.Add("malePride.jpg");
            imageMale.Add("malePush.jpg");
            imageMale.Add("maleYo.jpg");
            


            string source;

            Random rnd = new Random();
            int index = rnd.Next(0, imageMale.Count);

            source = imageMale[index];

            return source;
        }


        public string NiceMessagesRnd()
        {

            List<string> listOfStrings = new List<string>();

            listOfStrings.Add("You are beautiful !");
            listOfStrings.Add("You are a winner !");
            listOfStrings.Add("You are smart !");
            listOfStrings.Add("You are a Super Hero !!");
            listOfStrings.Add("You are so cool !");
            listOfStrings.Add("You are so awesome !");
            listOfStrings.Add("You are great !");
            listOfStrings.Add("You are amazing !");
            listOfStrings.Add("I like your style !");
            listOfStrings.Add("Well done!");
            listOfStrings.Add("Way to go!");
            listOfStrings.Add("You are so charming !");
            listOfStrings.Add("Your smile is breath taking !");
            listOfStrings.Add(" We enjoy spending time with you !");
            listOfStrings.Add("I love the way you click !");
            listOfStrings.Add("You're so smart!");
            listOfStrings.Add("We love you !");
            listOfStrings.Add("My mom always asks me why I can't be more like you !");
            listOfStrings.Add("My super power is you !");
          
            

            string source;

            Random rnd = new Random();
            int index = rnd.Next(0, listOfStrings.Count);

            source = listOfStrings[index];

            return source;
        }




    }
}
