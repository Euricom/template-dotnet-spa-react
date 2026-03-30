namespace Api.Common.Models;

public record ApiResponse<T>(T Data, string Message = "Success");
