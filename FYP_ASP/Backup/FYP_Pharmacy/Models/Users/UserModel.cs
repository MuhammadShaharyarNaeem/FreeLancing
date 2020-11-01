namespace Models.Users
{
    public class UserModel
    {
        public int ID { get; set; }
        public string loginName { get; set; }
        public int AccessLevel { get; set; }
        public string Password { get; set; }
        public string CompanyKey { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
    }
}
