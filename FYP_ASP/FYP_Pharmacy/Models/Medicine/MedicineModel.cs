using System;

namespace Models.Medicine
{
    public class MedicineModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string QRCode { get; set; }
        public DateTime ExpiryDate { get;set;}
        public DateTime MfgDate { get; set; }
        public string BatchNo { get; set; }
        public string RegistrationNbr { get; set; }
        public double Price { get; set; }
    }
}
