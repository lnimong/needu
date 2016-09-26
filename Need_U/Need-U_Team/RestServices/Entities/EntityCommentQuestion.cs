namespace WebAppNeedU.Deal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;

    [DataContract]
    public class EntityCommentQuestion
    {
        [DataMember]
        public Int64 IdQuestion
        {
            get;
            set;
        }

        [DataMember]
        public Int64? IdUser
        {
            get;
            set;
        }

        [DataMember]
        public string NickNameUser
        {
            get;
            set;
        }

        [DataMember]
        public string Comment
        {
            get;
            set;
        }

        [DataMember]
        public DateTime Date
        {
            get;
            set;
        }
    }
}
