namespace CleanCode2
{
    public class EmailMessage
    {
        public string From { get; internal set; }
        public string To { get; internal set; }
        public string Subject { get; internal set; }
        public string Body { get; internal set; }
    }
}