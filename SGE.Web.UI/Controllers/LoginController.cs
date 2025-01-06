using Microsoft.AspNetCore.Mvc;
using SGE.Aplicacao.DTOs;
using SGE.Aplicacao.Interfaces;

namespace SGE.Web.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: /Login/
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Login/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string usuarioLogin, string senha)
        {
            if (string.IsNullOrWhiteSpace(usuarioLogin) || string.IsNullOrWhiteSpace(senha))
            {
                ModelState.AddModelError(string.Empty, "Login e senha são obrigatórios.");
                return View("Index");
            }

            try
            {
                var usuario = await _usuarioService.BuscarUsuarioAsync(usuarioLogin);

                if (usuario != null && usuario.Senha == senha) // Verifique se a senha confere
                {
                    // Redireciona para a página de endereços passando o usuário como parâmetro
                    var usuarioDTO = new UsuarioDTO
                    {
                        UsuarioLogin = usuarioLogin,
                        Id = usuario.Id
                    };
                    return RedirectToAction("Index", "Enderecos", usuarioDTO);
                }

                ModelState.AddModelError(string.Empty, "Login ou senha inválidos.");
                return View("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Erro ao processar o login: {ex.Message}");
                return View("Index");
            }
        }
    }
}
