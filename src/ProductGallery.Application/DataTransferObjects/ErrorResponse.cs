﻿using ProductGallery.Domain.Enums;
namespace MyClean.Application.Common.Models;

public class ErrorResponse
{
    public AppStatusCode Code { get; set; }
    public string Id { get; set; }
    public string Message { get; set; }
    public List<ErrorDetail>? Errors { get; set; }

    public ErrorResponse(AppStatusCode code, string message)
    {
        Id = Guid.NewGuid().ToString();
        Code = code;
        Message = message;
    }

    public static ErrorResponse Failure(AppStatusCode code, string message) => new(code, message);
}

public class ErrorDetail
{
    public string ErrorCode { get; set; } = AppStatusCode.UnexpectedError.ToString();
    public string Message { get; set; } = string.Empty;
    public string? Path { get; set; }
    public Uri? uri { get; set; }
}

