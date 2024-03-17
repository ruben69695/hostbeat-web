using System.Net;

namespace HostbeatWeb.Services.Results;

public enum ConfirmEmailErrorCodes
{
    AlreadyConfirmed,
}

public class ConfirmEmailResult : Result
{
    public static ConfirmEmailResult Ok()
    {
        return new ConfirmEmailResult
        {
            Success = true,
        };
    }

    public static ConfirmEmailResult Failure(HttpStatusCode code)
    {
        return new ConfirmEmailResult
        {
            Success = false,
            FailureCode = code == HttpStatusCode.Conflict
                ? (int)ConfirmEmailErrorCodes.AlreadyConfirmed
                : (int)ResultErrorCodes.Unknown
        };
    }
}