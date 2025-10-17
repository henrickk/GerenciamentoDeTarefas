using AutoMapper;
using Gerenciamento.API.DTO;
using Gerenciamento.Business.Interfaces;
using Gerenciamento.Business.Models;
using Gerenciamento.Business.Services.Security;
using Gerenciamento.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Gerenciamento.API.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : MainController
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioRepository usuarioRepository,
                                 IUsuarioService usuarioService,
                                 IMapper mapper,
                                 INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("consultar-usuario")]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> ObterTodos()
        {
            var usuariosAtivos = await _usuarioRepository.Buscar(u => u.Ativo);

            if (usuariosAtivos == null || !usuariosAtivos.Any())
                return NoContent();

            var usuariosDto = _mapper.Map<IEnumerable<UsuarioDto>>(usuariosAtivos);
            return Ok(usuariosDto);
        }

        [HttpPost("cadastro-usuario")]
        public async Task<ActionResult<UsuarioDto>> CadastroUsuario([FromBody] UsuarioRegistroDto registroDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (registroDto.Senha != registroDto.ConfirmarSenha)
            {
                ModelState.AddModelError("ConfirmarSenha", "As senhas não conferem.");
                return CustomResponse(ModelState);
            }

            var usuario = _mapper.Map<Usuario>(registroDto);
            usuario.SenhaHash = PasswordHasher.Hash(registroDto.Senha);
            usuario.DataCadastro = DateTime.UtcNow;

            await _usuarioService.Adicionar(usuario);

            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            return CustomResponse(HttpStatusCode.Created, usuarioDto);
        }


        [HttpPut("atualizar-usuario/{id:guid}")]
        public async Task<ActionResult<UsuarioDto>> AtualizarUsuario(Guid id, [FromBody] UsuarioAtualizarDto atualizarDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var usuario = await _usuarioRepository.ObterPorId(id);
            if (usuario == null) return NotFound();

            usuario.Nome = atualizarDto.Nome;
            usuario.Email = atualizarDto.Email;

            await _usuarioService.Atualizar(usuario);

            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            return CustomResponse(HttpStatusCode.OK, usuarioDto);
        }

        [HttpDelete("remover-usuario/{id:guid}")]
        public async Task<ActionResult> RemoverUsuario(Guid id)
        {
            var usuario = await _usuarioRepository.ObterPorId(id);

            if (usuario == null) return NotFound();

            await _usuarioService.Inativar(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }

    }
}
