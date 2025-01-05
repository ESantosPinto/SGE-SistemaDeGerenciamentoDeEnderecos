using AutoMapper;
using SGE.Aplicacao.DTOs;
using SGE.Aplicacao.Interfaces;
using SGE.Dominio.Entidades;
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

        public async Task AdicionarEnderecoAsync(string login,EnderecoDTO endereco)
        {
            try
            {
                var usuario = _usuarioRepositorio.BuscarUsuarioPorLoginAsync(login).Result;
                if (usuario == null) {
                    throw new Exception("Usuario não encontrado");
                }

                usuario.Enderecos.Add(_mapper.Map<Endereco>(endereco));
                _usuarioRepositorio.AtualizarUsuarioAsync(usuario);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }

        public async Task<UsuarioDTO> BuscarUsuarioAsync(string usuarioLogin)
        {
            var usuarioEntity = await _usuarioRepositorio.BuscarUsuarioPorLoginAsync(usuarioLogin);
            return _mapper.Map<UsuarioDTO>(usuarioEntity);
        }

        public async Task<UsuarioDTO> CriarUsuarioAsync(UsuarioDTO usuarioDTO)
        {
            try
            {
                var usuario = await _usuarioRepositorio.BuscarUsuarioPorLoginAsync(usuarioDTO.UsuarioLogin);
                if (usuario != null)
                {
                    throw new Exception("Usuario já cadastrado");
                }


            var usuarioResultado =  _usuarioRepositorio.CriarUsuarioAsync(_mapper.Map<Usuario>(usuarioDTO)).Result;
                return _mapper.Map<UsuarioDTO>(usuarioResultado);

            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }
    }
}
