namespace Models.Users
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AccessLevel { get; set; }
        public string Password { get; set; }
        public string CompanyKey { get; set; }
    }
}
