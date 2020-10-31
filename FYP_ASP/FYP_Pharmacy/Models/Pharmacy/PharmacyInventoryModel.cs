namespace Models.Pharmacy
{
    public class PharmacyInventoryModel
    {
        public int ID { get; set; }
        public int MedicineID { get; set; }
        public int PharmacyID { get; set; }
        public int Quantity { get; set; }
    }
}
