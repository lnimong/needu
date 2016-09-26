using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Need_U.Entities
{
    public class EntityUser
    {
        public Int64 IdUser { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public DateTime? Birthday { get; set; }

        public string Job { get; set; }

        public string City { get; set; }

        public string CodeCountry { get; set; }

        public string NameCountry { get; set; }

        public bool Sex { get; set; }

        public int ConexionNumber { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Email { get; set; }

        public string PhotoUrl { get; set; }

    }
}
