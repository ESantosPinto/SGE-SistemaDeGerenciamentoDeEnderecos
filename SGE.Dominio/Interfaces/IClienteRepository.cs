using SGE.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Dominio.Interfaces
{
    public interface IClienteRepository
    {
        Task<Endereco> GetUsuarioPorLoginAsync(string usuarioLogin);
    }
}
