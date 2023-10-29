namespace ObiletCase.UI.Helpers
{
    public static class SessionHelper
    {
        public static void Set(this ISession session, string key, string value)
        {
            session.SetString(key, value);
        }

        public static string Get(this ISession session, string key)
        {
             return session.GetString(key) ?? "";
        }
    }
}