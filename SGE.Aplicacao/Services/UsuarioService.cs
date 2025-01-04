using AutoMapper;
using SGE.Aplicacao.DTOs;
using SGE.Aplicacao.Interfaces;
using SGE.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Aplicacao.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IMapper _mapper;

        public async Task<UsuarioDTO> GetUsuario(string usuarioLogin)
        {
            var usuarioEntity = await _usuarioRepositorio.GetUsuarioPorLoginAsync(usuarioLogin);
            return _mapper.Map<UsuarioDTO>(usuarioEntity);
        }
    }
}
