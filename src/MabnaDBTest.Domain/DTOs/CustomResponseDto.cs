using System.Text.Json.Serialization;

namespace MabnaDBTest.Domain.DTOs;

            
public class CustomResponseDto<T>
{
    public T? Data { get; set; }

    [JsonIgnore] public int StatusCode { get; set; }

    public List<ErrorDto> Errors { get; set; }

    public static CustomResponseDto<T> Success(int statusCode, T data)
    {
        return new CustomResponseDto<T> { Data = data, StatusCode = statusCode };
    }

    public static CustomResponseDto<T> Success(int statusCode)
    {
        return new CustomResponseDto<T> { StatusCode = statusCode };
    }

    public static CustomResponseDto<T> Fail(int statusCode, List<ErrorDto> errors)
    {
        return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors };
    }

    public static CustomResponseDto<T> Fail(int statusCode, ErrorDto error)
    {
        return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<ErrorDto> { error } };
    }
}