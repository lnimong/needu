namespace WebApiNeedU.Deal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract]
    public class EntitieQuestion
    {
        [DataMember]
        public long? idQuestion { get; set; }

        [DataMember]
        public string title { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public double? latitude { get; set; }

        [DataMember]
        public double? longitud { get; set; }

        [DataMember]
        public long? idUser { get; set; }

        [DataMember]
        public string nickName { get; set; }

        [DataMember]
        public double? km { get; set; }

        [DataMember]
        internal IEnumerable<EntitieOptionQuestion> OptionQuestion { get; set; }
    }
}