using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RojoAPI.Domains;
using RojoAPI.Interfaces;
using RojoAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RojoAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _TipoUsuarioRepository = new TipoUsuarioRepository();
        }
        //CADASTRAR
        [HttpPost]
      //  [Authorize(Roles = "1 , 3")]
        public IActionResult Post(TipoUsuario NovoTipoUsuario)
        {
            try
            {
                _TipoUsuarioRepository.Cadastrar(NovoTipoUsuario);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }


        //DELETAR
        [HttpDelete("{id}")]
        //[Authorize(Roles = "1, 3")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método
                _TipoUsuarioRepository.Deletar(id);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        //LISTAR TODOS
        [HttpGet]
        //[Authorize(Roles = "1, 3")]
        public IActionResult GetAll()
        {
            try
            {
                List<TipoUsuario> ListarTodos = _TipoUsuarioRepository.Listar();

                return Ok(ListarTodos);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        //BUSCAR POR ID
        [HttpGet("{id}")]
       // [Authorize(Roles = "1, 3")]
        public IActionResult GetById(int id)
        {
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método
                return Ok(_TipoUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
