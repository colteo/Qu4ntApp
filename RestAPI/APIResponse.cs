namespace RestAPI
{
    public class APIResponse<T> where T : class
    {
        public APIResponseStatus Status { get; set; }
        public T Result { get; set; }
    }

    public class APIResponseStatus
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
