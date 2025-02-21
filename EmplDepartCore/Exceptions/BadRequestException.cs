using System.Net;
using EmplDepartCore.Exceptions;

namespace EmplDepartCore.Exceptions;

public class BadRequestException(string message) : BaseException(message)
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}
