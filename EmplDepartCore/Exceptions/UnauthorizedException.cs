using System.Net;

namespace EmplDepartCore.Exceptions;

public class UnauthorizedException(string message) : BaseException(message)
{
    public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
}
