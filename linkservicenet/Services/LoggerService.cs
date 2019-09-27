    namespace linkservicenet 
    {
        public interface ILoggerService
        {
            void LogInfo(string message);
            void LogWarn(string message);
            void LogDebug(string message);
            void LogError(string message);
        }

        public class LoggerService : ILoggerService
        {
            public void LogInfo(string message ) {}
            public void LogWarn(string message) {}
            public void LogDebug(string message) {}
            public void LogError(string message) {}
        }
    }