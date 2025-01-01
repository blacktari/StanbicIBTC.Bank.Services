using System;

namespace StanbicIBTC.Bank.Services.Exceptions
{
    public class AccountCreationException : Exception
    {
        // Define the StatusCode property to hold the HTTP status code
        public int StatusCode { get; }

        // Constructor with message and status code
        public AccountCreationException(string message, int statusCode)
            : base(message) // Pass message to the base Exception class
        {
            StatusCode = statusCode;
        }

        // Constructor with message, status code, and inner exception (optional)
        public AccountCreationException(string message, int statusCode, Exception innerException)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}
