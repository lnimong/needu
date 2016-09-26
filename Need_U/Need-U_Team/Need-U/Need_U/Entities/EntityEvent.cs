namespace Need_U.Entities
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class EntityEvent
    {
        [DataMember]
        public long IdEvent { get; set; }

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
        public double Latitude { get; set; }

        [DataMember]
        public double Longitude { get; set; }

        [DataMember]
        public double? Km { get; set; }

        public string TodayEvent { get { return IsEventToday(); }}

       private string IsEventToday()
        {
            if(DateTime.Now.Date >= DateStart.Value.Date && DateTime.Now.Date <= DateEnd.Value.Date)
            {
                return "Today !";
            }

            return null;


        }

    }
}
