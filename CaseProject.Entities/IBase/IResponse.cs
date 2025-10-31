namespace CaseProject.Entities.IBase;

public interface IResponse
{
    string Message { get; set; }

    int StatusCode { get; set; }

    object Data { get; set; }
}

public interface IResponse<T> : IResponse
{
    new T Data { get; set; }
}

