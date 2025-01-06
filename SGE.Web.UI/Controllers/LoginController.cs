using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Newtonsoft.Json;
using SGE.Aplicacao.DTOs;
using SGE.Aplicacao.Interfaces;
using SGE.Dominio.Entidades;

namespace SGE.Web.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarioService;      

        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;            
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string usuarioLogin, string senha)
        {
            
            var usuario = await _usuarioService.BuscarUsuarioAsync(usuarioLogin);            
            if (usuario != null)
            {
                return RedirectToAction("Lista", "Enderecos",new UsuarioDTO {UsuarioLogin = usuarioLogin, Senha = "", Id = 0 });
            }

            ModelState.AddModelError(string.Empty, "Login ou senha inválidos.");
            return View("Index");
        }

    }
}
