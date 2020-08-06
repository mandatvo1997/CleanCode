namespace CleanCode_w4
{
    internal interface ILogger
    {
        void Error(string v, object p);
        void Error(string v);
    }
}