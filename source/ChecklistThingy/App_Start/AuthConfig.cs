using Microsoft.Web.WebPages.OAuth;

namespace ChecklistThingy
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            OAuthWebSecurity.RegisterMicrosoftClient(
                clientId: "asfd",
                clientSecret: "asf");

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "asf",
                consumerSecret: "asf");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "648995925117562",
                appSecret: "e4f6bed3ceb08b673d186bc0096d1ce9");

            OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
