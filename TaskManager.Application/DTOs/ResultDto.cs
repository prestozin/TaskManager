namespace TaskManager.Application.DTOs;

public class ResultDto<T>
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public List<string>? Errors { get; set; }


    private ResultDto(bool isSuccess, string? message, T? data)
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
    }

    public static ResultDto<T> Success(T? data, string? message = "Operation completed successfully")
    {
        return new ResultDto<T>(true, message, data);
    }

    public static ResultDto<T> Success(string? message = "Operation completed successfully")
    {
        return new ResultDto<T>(true, message, default);
    }

    public static ResultDto<T> Failure(T? data, string? message = "Operation failed")
    {
        return new ResultDto<T>(false, message, data);
    }

    public static ResultDto<T> Failure(string? message = "Operation failed")
    {
        return new ResultDto<T>(false, message, default);
    }

    public static ResultDto<T> ValidationFailure(IEnumerable<FluentValidation.Results.ValidationFailure> errors)
    {
        return new ResultDto<T>(false, "Erro de validação", default)
        {
            Errors = errors.Select(x => x.ErrorMessage).ToList()
        };
    }
}
