using System.Runtime.Serialization;

namespace EmailingProject.Models
{
    [DataContract]
    public class MailingModel
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string EmailTo { get; set; }

        [DataMember]
        public int Hours { get; set; }
        

    }
}
