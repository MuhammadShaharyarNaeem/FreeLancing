using System;

namespace Models.Pharmacy
{
    public class PharmacyModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public string RegistrationNumber = Guid.NewGuid().ToString();

    }
}
