using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Need_U
{
   public class FacebookUser
    {
        

        public class Data
        {
            public string url { get; set; }
        }

        public class Picture
        {
            public Data data { get; set; }

            public Picture()
            {
                data = new Data();
            }
        }

        public class Location
        {
            public string id { get; set; }
            public string name { get; set; }
        }

      
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string name { get; set; }
            public Picture picture { get; set; }
            public string email { get; set; }
            public string birthday { get; set; }
            public string gender { get; set; }
            public Location location { get; set; }
            public string locale { get; set; }
            public string id { get; set; }
            public string cityName { get; set; }


        public FacebookUser()
        {
            location = new Location();
            cityName = location.name;
            //location = new Location();
            //picture = new Picture();
            
        }



    }
}
