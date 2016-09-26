namespace Need_U.Entities
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class EntityEventLike
    {
        [DataMember]
        public Int64 IdEvent { get; set; }

        [DataMember]
        public Int64? IdUser { get; set; }

        [DataMember]
        public bool? Like { get; set; }

        [DataMember]
        public int? NumberOfLike { get; set; }

        [DataMember]
        public int? NumberOfDisLike { get; set; }
    }
}
