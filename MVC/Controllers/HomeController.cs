
using Application.Interfaces;
using Domain.Entidades;
using System;
using System.Web.Mvc;
using System.Web.Security;
using RepositoryManager.Repository;

namespace SIS.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Repositorios
        //Variáveis de Repositoio
        private readonly IUsuarioAD _usuarioADRepository;
        UsuarioADCRUDRepository _usuarioRep = new UsuarioADCRUDRepository();

        //Controller de Repositorio
        public HomeController(IUsuarioAD _usuarioAD)
        {
            _usuarioADRepository = _usuarioAD;
        }
        #endregion

        #region ActionResult
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Painel()
        {
            var usuario = new UsuarioAD
            {
                Login = "brunoort",
                Nome = "Bruno", 
                Sobrenome = "Ortiz",
                NomeCompleto = "Bruno Gaya Ortiz",
                UltimoAcesso = DateTime.Now
               
            };

            _usuarioRep.Create(usuario);
            var teste2 = _usuarioADRepository.Teste();
            return View();
        }

        public ActionResult Teste()
        {
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(FormCollection collection)
        {
            //Capturando as variáveis
            var login = collection["Login"];
            var senha = collection["Senha"];
            var lembrar = Convert.ToBoolean(collection["Lembrar"]);

            //Validando o acesso do usuário no AD
            if (Membership.ValidateUser(login, senha))
            {
                FormsAuthentication.SetAuthCookie(login, lembrar);
                return RedirectToAction("Painel", "Home");
            }
            else
            {
                ViewData["Error"] = "Login ou senha inválidos.";
                return View("Login");
            }


        }

        //
        // POST: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
        #endregion
    }
}