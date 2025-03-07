﻿using System.Net;

namespace EmplDepartCore.Exceptions;

public abstract class BaseException : Exception
{
    public abstract HttpStatusCode StatusCode { get; }
    public string? ErrorCode { get; set; }

    protected BaseException(string message, string? errorCode = null) : base(message)
    {
        ErrorCode = errorCode;
    }
}
