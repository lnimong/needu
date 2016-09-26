namespace WebAppNeedU.Deal.Entities
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
    }
}
