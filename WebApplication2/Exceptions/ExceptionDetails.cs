namespace WebApplication2.Exceptions
{
    public class ExceptionDetails
    {
        public int StatusCode { get; }
        public string ErrorTitle { get; }
        public string LogMessage { get; }
        public string Message { get; }
        public LogLevel LogLevel { get; }

        public ExceptionDetails(int statusCode, string errorTitle, string logMessage, string message, LogLevel logLevel)
        {
            StatusCode = statusCode;
            ErrorTitle = errorTitle;
            LogMessage = logMessage;
            Message = message;
            LogLevel = logLevel;
        }
    }
}
