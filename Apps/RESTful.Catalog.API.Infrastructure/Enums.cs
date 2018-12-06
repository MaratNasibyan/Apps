namespace RESTful.Catalog.API.Infrastructure
{
    public class Enums
    {
        public enum ResultCode
        {
            Success = 0,
        }

        public enum ResourceUriType : byte
        {
            PreviousPage,
            NextPage
        }
    }
}
