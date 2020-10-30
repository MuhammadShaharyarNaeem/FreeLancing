using System;

namespace Models.Generic
{
    public class PharmaCompany
    {
        public string name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

    }

    public class Operator
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public string Description { get; set; }

    }

    public class Medicine
    {
        public string Name { get; set; }
        public string QR_Code { get; set; }
        public DateTime Expiry_Date { get; set; }
        public DateTime MFG_Date { get; set; }
        public double Total_Quantity { get; set; }
        public string Batch_no { get; set; }
        public string Registration_no { get; set; }
        public string Registrant { get; set; }
        public double price { get; set; }

    }

    public class Pharmacy
    {
        public string Registration_ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Purchase_Details
    {
        public string Medicine_ID { get; set; }
        public string Medicine_Name { get; set; }
        public string price { get; set; }
        public DateTime Payment_Date { get; set; }
        public double Payment_Amount { get; set; }
    }
    public class Customer
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
