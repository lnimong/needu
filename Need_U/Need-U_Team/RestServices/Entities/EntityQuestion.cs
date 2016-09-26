namespace WebAppNeedU.Deal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
  
    [DataContract]
    public class EntityQuestion
    {
        [DataMember]
        public long? IdQuestion { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public double? Latitude { get; set; }

        [DataMember]
        public double? Longitud { get; set; }

        [DataMember]
        public long? IdUser { get; set; }

        [DataMember]
        public string NickName { get; set; }

        [DataMember]
        public double? Km { get; set; }

        [DataMember]
        public List<EntityOptionQuestion> OptionsQuestion { get; set; }
    }
}