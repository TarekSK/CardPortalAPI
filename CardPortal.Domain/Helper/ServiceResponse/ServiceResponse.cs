using System.Net;

namespace CardPortal.Domain.Helper.ServiceResponse
{
    public class ServiceResponse
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;

        public List<string> Errors { get; set; } = new List<string>() { };

        #region ModelInit

        public ServiceResponse() { }

        public ServiceResponse(HttpStatusCode statusCode, List<string> errors)
        {
            StatusCode = statusCode;
            Errors = errors;
        }

        #endregion ModelInit
    }

    // In Case of Returning Data With Repsponse
    public class ServiceResponse<TData> : ServiceResponse
    {
        public TData Data { get; set; }

        public void SetData(TData data)
        {
            Data  = data;
        }

        public void SetStatusCode(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public void SetErrors(List<string> errors)
        {
            Errors = errors;
        }

        public void SetServiceResponse(HttpStatusCode statusCode, List<string> errors)
        {
            StatusCode = statusCode;
            Errors = errors;
        }

        public void SetServiceResponse(HttpStatusCode statusCode, TData data, List<string> errors)
        {
            StatusCode = statusCode;
            Data = data;
            Errors = errors;
        }

        #region ModelInit

        public ServiceResponse() { }

        public ServiceResponse(HttpStatusCode statusCode, TData data)
        {
            StatusCode = statusCode;
            Data = data;
        }

        public ServiceResponse(HttpStatusCode statusCode, TData data, List<string> errors)
        {
            StatusCode = statusCode;
            Data = data;
            Errors = errors;
        }

        #endregion ModelInit
    }
}
