using System.Web.Security;

namespace Mvc5App.WebUI.Infrastructure
{
    public class FormsAuthProvider : IAuthProvider
    {

        public bool Authenticate(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password);

            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }

            return result;
        }
    }
}