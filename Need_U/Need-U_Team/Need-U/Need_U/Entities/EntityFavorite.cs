namespace Need_U.Entities
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class EntityFavorite
    {
        [DataMember]
        public long? IdEvent { get; set; }

        [DataMember]
        public long? IdQuestion { get; set; }

        [DataMember]
        public long? IdUser { get; set; }


        [DataMember]
        public double? Km { get; set; }
    }
}
