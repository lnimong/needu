using Need_U.Objects;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace Need_U
{
    public class Question : PublicationInterface
    {
        public int IdQuestion { get; set; }
        public User AuthorQuestion { get; set; }
        public String TitleQuestion { get; set; }
        public string DescriptionQuestion { get; set; }
        public string GeolocationQuestion { get; set; }
        public OptionChoice Choice1 { get; set; }
        public OptionChoice Choice2 { get; set; }
        public OptionChoice Choice3 { get; set; }

        public Question() { }

        public Question(OptionChoice choice1, OptionChoice choice2, OptionChoice choice3)
        {
                    
           

        }
      

    }
}
