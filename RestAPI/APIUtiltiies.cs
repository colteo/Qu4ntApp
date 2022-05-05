namespace RestAPI
{
    public static class APIUtiltiies
    {
        public static APIResponse<T> WrapReponse<T>(int StatusCode, string Message, T result) where T : class => new()
        {
            Status = new APIResponseStatus()
            {
                StatusCode = StatusCode,
                Message = Message
            },
            Result = result
        };
    }
}
