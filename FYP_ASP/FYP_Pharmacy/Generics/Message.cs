namespace Generics
{
    public class Message
    {
        public string Context { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Function { get; set; }
        public string WebPage { get; set; }
        public bool isError { get; set; }
        public Enum.LogType LogType { get; set; }
        public string Query { get; set; }
        public Enum.QueryType QueryType { get; set; }
        
    }
}
