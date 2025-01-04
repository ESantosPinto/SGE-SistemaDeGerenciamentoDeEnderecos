using SGE.Aplicacao.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacao.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> GetUsuario(string usuarioLogin);
    }
}
