using Application.Interfaces;
using System;
using System.Web;
using System.Web.Security;

namespace Application.Repositories
{
    public class UsuarioADRepository : IUsuarioAD
    {
        public bool ValidaAcessoUsuario(string pLogin)
        {
            var usuario = "";

            if (usuario != null)
            {
                var authTicket = new FormsAuthenticationTicket(1, pLogin, DateTime.Now, DateTime.Now.AddMinutes(30), true, "");
                string cookieContents = FormsAuthentication.Encrypt(authTicket);

                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
                {
                    Expires = authTicket.Expiration,
                    Path = FormsAuthentication.FormsCookiePath
                };

                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }

                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Teste()
        {
            return true;
        }
    }
}
