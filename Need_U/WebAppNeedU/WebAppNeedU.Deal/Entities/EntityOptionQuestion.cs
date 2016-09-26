namespace WebAppNeedU.Deal.Entities
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract]
    public class EntityOptionQuestion
    {
        [DataMember]
        public long? IdOptionQuestion { get; set; }

        [DataMember]
        public long? IdQuestion { get; set; }

        [DataMember]
        public byte[] Image { get; set; }

        [DataMember]
        public string TextOption { get; set; }
    }
}