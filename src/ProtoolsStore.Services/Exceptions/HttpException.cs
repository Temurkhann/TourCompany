using System.Net;

namespace ProtoolsStore.Services;

/// <summary>
/// Represents errors that occur during HTTP requests
/// </summary>
[Serializable]
public class HttpException : Exception
{
    /// <summary>
    /// The HTTP status code associated with this exception
    /// </summary>
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// The HTTP status code numeric associated with this exception
    /// </summary>
    public int StatusCodeNumeric { get; set; }

    /// <summary>
    /// Initializes a new instance of the HttpException class
    /// </summary>
    public HttpException() : base() { }

    /// <summary>
    /// Initializes a new instance of the HttpException class with a specified error message
    /// </summary>
    /// <param name="message">The message that describes the error</param>
    public HttpException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the HttpException class with a specified error message and HTTP status code
    /// </summary>
    /// <param name="message">The message that describes the error</param>
    /// <param name="statusCode">The HTTP status code associated with this exception</param>
    public HttpException(string message, HttpStatusCode statusCode) : base(message)
    {
        StatusCode = statusCode;
        StatusCodeNumeric = (int)statusCode;
    }

    /// <summary>
    /// Initializes a new instance of the HttpException class with a specified error message, HTTP status code and ASP.NET status
    /// </summary>
    /// <param name="message">The message that describes the error</param>
    /// <param name="statusCode">The HTTP status code associated with this exception</param>
    public HttpException(string message, int statusCode) : base(message)
    {
        StatusCodeNumeric = statusCode;
        if (Enum.TryParse<HttpStatusCode>(statusCode.ToString(), out HttpStatusCode st))
            StatusCode = st;

    }

    /// <summary>
    /// Initializes a new instance of the HttpException class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public HttpException(string message, Exception innerException) : base(message, innerException)
    { }
}