namespace RESTful.Catalog.API.Infrastructure.Helpers
{
    public class Response
    {
        public bool Success { get; set; }
    }

    public class Error
    {
        public string InternalMessage { get; set; }
        public string DisplayMessage { get; set; }
    }

    public class ResponseError : Response
    {
        public Error Error { get; set; }

        public static ResponseError Create(string displayMessage, string internalMessage = null)
        {
            var response = new ResponseError()
            {
                Success = false,
                Error = new Error()
                {
                    InternalMessage = internalMessage,
                    DisplayMessage = displayMessage
                }
            };       
          
            return response;
        }
    }

    public class ResponseSuccess : Response
    {
        public object Data { get; set; }
        public object Message { get; set; }
        public static ResponseSuccess Create(object data, string message)
        {
            var response = new ResponseSuccess()
            {
                Success = true,
                Data = data,
                Message = message
            };           

            return response;
        }

        public static ResponseSuccess Create(object data)
        {
            return Create(data, null);
        }

        public static ResponseSuccess Create(string message)
        {
            return Create(null, message);
        }
    }
}
