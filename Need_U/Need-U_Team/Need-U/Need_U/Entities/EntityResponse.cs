using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Need_U.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;

    [DataContract]
    public class EntityResponse
    {
        [DataMember]
        public long? IdOptionQuestion { get; set; }

        [DataMember]
        public long? IdUser { get; set; }

        [DataMember]
        public DateTime? Date { get; set; }

        [DataMember]
        public double? Percentage { get; set; }
    }
}
