namespace DM6To5Migrator
{
    public interface ILogger
    {
        ILogger WriteLine(string format, params object[] values);
        ILogger Write(string format, params object[] values);
    }


    public static class Logger
    {
        public static ILogger Instance;

        public static ILogger WriteLine(string format, params object[] values)
        {
            return Instance.WriteLine(format, values);
        }

        public static ILogger Write(string format, params object[] values)
        {
            return Instance.Write(format, values);
        }
    }
}