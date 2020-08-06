namespace CleanCode2
{
    public interface ILogger
    {
        void Error(string v);
        void Info(string v);
        void Exception(object p);
    }
}