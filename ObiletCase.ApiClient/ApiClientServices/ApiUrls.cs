namespace ObiletCase.ApiClient.ApiClientServices
{
    public static class ApiUrls
    {
        public static class ClientServiceUrl
        {
            public static string GetSession => "client/getsession";
        }

        public static class LocationServiceUrl
        {
            public static string GetBusLocations => "location/getbuslocations";
        }

        public static class JourneyServiceUrl
        {
            public static string GetBusJourneys => "journey/getbusjourneys";
        }
    }
}