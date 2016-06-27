using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Profile;
using System.Web.Security;

namespace Domain.Entidades
{
    public class UsuarioAD
    {
        [Key]
        public int CodigoId { get; set; }


        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime? UltimoAcesso { get; set; }

        public string Login { get; set; }
    }


    public class UserProfile : ProfileBase
    {

        public static UserProfile GetProfileForUser(string userName)
        {
            var membershipUser = Membership.GetUser(userName);
            if (membershipUser != null)
            {
                return Create(membershipUser.UserName) as UserProfile;
            }
            return null;
        }

        public static UserProfile CurrentUser
        {
            get
            {
                var membershipUser = Membership.GetUser();
                if (membershipUser != null)
                {
                    return Create(membershipUser.UserName) as UserProfile;
                }
                return null;
            }
        }

        public static UserProfile NewUser
        {
            get { return System.Web.HttpContext.Current.Profile as UserProfile; }
        }

    }
}
