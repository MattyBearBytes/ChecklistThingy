using WebMatrix.WebData;

namespace ChecklistThingy
{
    public static class SecurityConfig
    {
        public static void RegisterSecurity()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
        }
    }
}