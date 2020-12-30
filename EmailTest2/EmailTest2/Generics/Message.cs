namespace EmailingProject.Generics
{
    public class Message
    {
        public string Context { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Function { get; set; }
        public bool isError { get; set; }
        public string Query { get; set; }
        public Enums.LogType LogType { get; set; }
    }
}
