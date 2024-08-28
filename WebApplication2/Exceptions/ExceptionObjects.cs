using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Exceptions
{
    public class ExceptionObjects
    {
        public ExceptionDetails GetExceptionDetails(Exception ex)
        {
            return ex switch
            {
                FormatException => new ExceptionDetails(StatusCodes.Status400BadRequest, "Bad Request", "Invalid input format.", ex.Message, LogLevel.Warning),
                OverflowException => new ExceptionDetails(StatusCodes.Status400BadRequest, "Bad Request", "Numeric overflow occurred.", ex.Message, LogLevel.Warning),
                EmployeeNotFoundException => new ExceptionDetails(StatusCodes.Status404NotFound, "Not Found", "Employee not found.", ex.Message, LogLevel.Information),
                ArgumentOutOfRangeException => new ExceptionDetails(StatusCodes.Status400BadRequest, "Bad Request", "Argument out of range.", ex.Message, LogLevel.Warning),
                SqlException => new ExceptionDetails(StatusCodes.Status500InternalServerError, "Internal Server Error", "A database connection error occurred.", ex.Message, LogLevel.Error),
                DbUpdateException => new ExceptionDetails(StatusCodes.Status500InternalServerError, "Internal Server Error", "A database update error occurred.", ex.Message, LogLevel.Error),
                DivideByZeroException => new ExceptionDetails(StatusCodes.Status400BadRequest, "Bad Request", "Division by zero is not allowed.", ex.Message, LogLevel.Warning),
                _ => new ExceptionDetails(StatusCodes.Status500InternalServerError, "Internal Server Error", "An unexpected error occurred.", ex.Message, LogLevel.Error)
            };
        }

    }
}
