using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RH360.Data.DTO;
using RH360.Data.Interfaces;
using RH360.Domain.Entities;
using RH360.InfraStructure.ConnectionFactory;

namespace RH360.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _Usuario;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuario Usuario, IMapper mapper)
        {
            _Usuario = Usuario;
            _mapper = mapper;
        }

        [HttpGet("/getusuarios")]
        public IActionResult GetUsuarios()
        {
            try
            {
                var usuarios = _Usuario.GetUsuarios();

                if (usuarios == null)
                {
                    return NotFound(new { message = "Nenhum usuário encontrado." });
                }

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("/getusuariobyid/{id}")]
        public IActionResult GetUsuarioById(int id)
        {
            try
            {
                var usuario = _Usuario.GetUsuarioById(id);

                if (usuario == null)
                {
                    return NotFound(new { message = "Usuário não encontrado." });
                }

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("/inserir")]
        public IActionResult Inserir(UsuarioDTO dto)
        {
            try
            {

                var user = _mapper.Map<Usuario>(dto);

                _Usuario.AddUser(user);

                return Ok(new { mensagem = "Usuário criado com sucesso!", status = "200", idusuario= user.UserID, nome = user.Nome});
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut("/editar")]
        public IActionResult EditUser(UsuarioDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = _mapper.Map<Usuario>(dto);
                
                _Usuario.UpdateUser(user);

                return Ok(new { mensagem = "Empresa cadastrada com sucesso!", status = "200", idusuario = user.UserID, nome = user.Nome });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpDelete("/delete")]
        public IActionResult DeleteUser(int id)
        {
            try
            {

                _Usuario.DeleteUser(id);

                return Ok(new { mensagem = "Usuário/Empresa excluído com sucesso!", status = "200" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
