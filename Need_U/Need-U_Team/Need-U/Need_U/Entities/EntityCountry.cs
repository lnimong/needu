using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Need_U.Entities
{
    public class EntityCountry
    {
        [DataMember]
        public string CodeCountry { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Position { get; set; }

    }
}
