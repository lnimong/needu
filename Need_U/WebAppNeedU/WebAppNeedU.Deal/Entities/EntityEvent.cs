namespace WebAppNeedU.Deal.Entities
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract]
    public class EntityEvent
    {
        [DataMember]
        public long? IdEvent { get; set; }

        [DataMember]
        public long? IdUser { get; set; }

        [DataMember]
        public string NickName { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime? DateStart { get; set; }

        [DataMember]
        public DateTime? DateEnd { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public double? Latitude { get; set; }

        [DataMember]
        public double? Longitude { get; set; }

        [DataMember]
        public double? Km { get; set; }
    }
}
