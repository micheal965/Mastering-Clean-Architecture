namespace SchoolManagementSystem.Core.APIBases
{
    public class APIResponse<T>
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
        public T Data { get; set; }

        public APIResponse(T data, int statusCode, bool isSuccess, string? message)
        {
            Data = data;
            StatusCode = statusCode;
            IsSuccess = isSuccess;
            ErrorMessage = message;
        }


        //Factory Methods
        public static APIResponse<T> Success(T value, int StatusCode = 200) => new APIResponse<T>(value, StatusCode, true, null);
        public static APIResponse<T> Failure(string errorMessage, int statusCode) => new APIResponse<T>(default, statusCode, false, errorMessage);

    }
}
