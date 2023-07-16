using System.Collections.Generic;

namespace MabnaDBTest.Domain.DTOs.Exceptions;

public class Result
{
    public readonly IEnumerable<string> Errors;
    public readonly bool Success;
    
    public Result(bool success, IEnumerable<string> errors)
    {
        Success = success;
        Errors = errors;
    }
}