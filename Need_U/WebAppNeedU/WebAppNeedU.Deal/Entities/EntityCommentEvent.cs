namespace WebAppNeedU.Deal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;

    public class EntityCommentEvent
    {
        [DataMember]
        public Int64 IdEvent
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
