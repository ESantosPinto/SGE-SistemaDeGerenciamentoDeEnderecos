using Microsoft.AspNetCore.Mvc;
using SGE.Aplicacao.DTOs;
using SGE.Aplicacao.Interfaces;

namespace SGE.Web.UI.Controllers
{
    public class CadastroUsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public CadastroUsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(UsuarioDTO usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioValid = await _usuarioService.BuscarUsuarioAsync(usuario.UsuarioLogin);

                if (string.IsNullOrEmpty(usuarioValid.UsuarioLogin))
                {
                    var usuarioCadastrado = await _usuarioService.CriarUsuarioAsync(usuario);

                    if (usuarioCadastrado.UsuarioLogin != null)
                    {
                        // Redireciona para a página de login ou home após o cadastro
                        return RedirectToAction("Index", "Login");
                    }

                }
                else {

                    ModelState.AddModelError(string.Empty, "Usuário já cadastrado.");
                    return View("Index");
                }

                ModelState.AddModelError(string.Empty, "Erro ao cadastrar usuário.");
            }

            return RedirectToAction("Index","Login");
        }
    }
}
