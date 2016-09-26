namespace WebApiNeedU.Deal.Entities
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract]
    internal class EntitieOptionQuestion
    {
        [DataMember]
        public long? idQuestion { get; set; }

        [DataMember]
        public byte[] image { get; set; }

        [DataMember]
        public string textOption { get; set; }
    }
}