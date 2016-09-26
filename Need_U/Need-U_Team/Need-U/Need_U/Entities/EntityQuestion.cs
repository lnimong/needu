namespace Need_U.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Xamarin.Forms;
    using System.Linq;

    [DataContract]
    public class EntityQuestion
    {
        [DataMember]
        public long IdQuestion { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public double? Latitude { get; set; }

        [DataMember]
        public double? Longitud { get; set; }

        [DataMember]
        public long? IdUser { get; set; }

        [DataMember]
        public string NickName { get; set; }

        [DataMember]
        public double? Km { get; set; }

        [DataMember]
        public List<EntityOptionQuestion> OptionsQuestion { get; set; }




        // image or text to display in the list

     
       
        public string OptiontoShowText { get { return GetOptionTextToDisplay(); } }

        private string GetOptionTextToDisplay()
        {
            EntityOptionQuestion choiceToDisplay = this.OptionsQuestion.FirstOrDefault();

            if (choiceToDisplay.Image == null)
            {
                return choiceToDisplay.TextOption;

            }

            return null;

        }


        
        public byte[] OptiontoShowImage { get { return GetOptionImageToDisplay(); } }

        private byte[] GetOptionImageToDisplay()
        {
            EntityOptionQuestion choiceToDisplay = this.OptionsQuestion.FirstOrDefault();

            if (choiceToDisplay.Image != null)
            {

                return choiceToDisplay.Image;
            }

            return null;
        }






    }

    

}
