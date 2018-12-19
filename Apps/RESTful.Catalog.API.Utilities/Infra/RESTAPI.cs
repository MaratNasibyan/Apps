namespace RESTful.Catalog.API.Utilities.Infra
{
    public class RESTAPI
    {
        public static class Log
        {
            public static string DataWasNotFound()
            {
                return "Data wasn't found in Db";
            }

            public static string DataWasNotFound(int id)
            {
                return $"Data with {id} wasn't found in Db";
            }
        }

        public static class Route
        {
            public static string BASE_URI = "http://localhost:5012";
            public static string GET_GATALOGS = "GetCatalogs";          
        }
    }
}
