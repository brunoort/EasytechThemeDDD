using Domain.Entidades;
using Infra.CrossCutting.Identity.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;

namespace Infra.CrossCutting.Identity.Models
{
    public class AuthAD
    {
        private static string _path = ConfigurationManager.AppSettings["PartySmart_AD"].ToString();
        private static string _domain = ConfigurationManager.AppSettings["PartySmart_DOMAIN"].ToString();
        private static string _filterAttribute = "";
        private static string[] _groups = null;

        public bool GetGroups(string username, string password)
        {
            bool autorizado = false;
            List<string> Groups = new List<string>();

            // Split the LDAP Uri
            var uri = new Uri(_path);
            var host = uri.Host;
            var container = uri.Segments.Count() >= 1 ? uri.Segments[1] : "";

            // Create context to connect to AD
            var princContext = new PrincipalContext(ContextType.Domain, host, container, username, password);

            // Get User
            UserPrincipal user = UserPrincipal.FindByIdentity(princContext, IdentityType.SamAccountName, username);

            //Salvando o objeto na sessão
            UsuarioAD userAD = new UsuarioAD
            {
                Nome = user.Name.ToString(),
                Sobrenome = user.Surname.ToString(),
                NomeCompleto = user.GivenName.ToString(),
                UltimoAcesso = Convert.ToDateTime(user.LastLogon.ToString()),
                Login = username
            };

            HttpContext.Current.Session["Usuario"] = userAD;
            
            foreach (GroupPrincipal group in user.GetGroups())
            {
                if(group.Name == "SIS_Seguranca")
                {
                    autorizado = true;
                }               
            }

            return autorizado;        
        }


    }
}
