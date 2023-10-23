using Microsoft.AspNetCore.Authorization;
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

    public class EmpresaController : ControllerBase
    {
        private IEmpresaRepository _empresaRepository { get; set; }

        public EmpresaController()
        {
            _empresaRepository = new EmpresaRepository();
        }

        //==================================================================

        /// <summary>
        /// CADASTRAR EMPRESA
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns></returns>
        [HttpPost("Cadastrar")]
        public IActionResult Post(Empresa empresa)
        {
            try
            {
                _empresaRepository.Cadastrar(empresa);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //==================================================================

        /// <summary>
        /// LISTAR EMPRESA
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Get()
        {
            try
            {

                List<Empresa> ListarEmpresas = _empresaRepository.Listar();

                return StatusCode(200, ListarEmpresas);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //==================================================================

        /// <summary>
        /// ATUALIZAR EMPRESA
        /// </summary>
        /// <param name="id"></param>
        /// <param name="empresa"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Empresa empresa)
        {
            try
            {
                _empresaRepository.Atualizar(id, empresa);

                return StatusCode(200);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //==================================================================

        /// <summary>
        /// DELETAR EMPRESA
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _empresaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
