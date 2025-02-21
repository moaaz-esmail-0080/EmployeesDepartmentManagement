using System.Net;

namespace EmplDepartCore.Exceptions;

public class InternalServerException(string message, string? details = null) : BaseException(message, details)
{
    public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;
}
