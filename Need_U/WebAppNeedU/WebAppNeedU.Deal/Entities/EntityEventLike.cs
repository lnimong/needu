namespace WebAppNeedU.Deal.Entities
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
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
