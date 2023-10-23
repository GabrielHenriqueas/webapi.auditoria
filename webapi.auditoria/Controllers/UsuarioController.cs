using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.auditoria.Domain;
using webapi.auditoria.Interfaces;
using webapi.auditoria.Repositories;

namespace webapi.auditoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        //==================================================================

        /// <summary>
        /// CADASTRAR USUÁRIO
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //==================================================================

        /// <summary>
        /// LISTAR USUÁRIOS
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                
                List<Usuario> ListarUsuarios = _usuarioRepository.Listar();

                return StatusCode(200, ListarUsuarios);

            }
            catch (Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }

        //==================================================================
        /// <summary>
        /// ATUALIZAR USUÁRIO
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Usuario usuario)
        {
            try
            {
                _usuarioRepository.Atualizar(id, usuario);

                return StatusCode(200);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //==================================================================
        /// <summary>
        /// DELETAR USUÁRIO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _usuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }
    }
}
