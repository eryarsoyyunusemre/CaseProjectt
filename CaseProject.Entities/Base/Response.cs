using CaseProject.Entities.IBase;

namespace CaseProject.Entities.Base;

public class Response : IResponse
{
    public string Message { get; set; } = null!;
    public int StatusCode { get; set; }
    public object Data { get; set; } = null!;
}

public class Response<T> : Response, IResponse<T>
{
    public new T Data { get; set; } = default!;
}