namespace WebAppNeedU.Deal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract]
    public class EntityUser
    {
        [DataMember]
        public Int64 IdUser { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string NickName { get; set; }

        [DataMember]
        public DateTime? Birthday { get; set; }

        [DataMember]
        public string Job { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string CodeCountry { get; set; }

        [DataMember]
        public string NameCountry { get; set; }

        [DataMember]
        public bool Sex { get; set; }

        [DataMember]
        public int? ConexionNumber { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string PhotoUrl { get; set; }
    }
}
