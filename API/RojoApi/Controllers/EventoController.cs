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
    public class EventoController : ControllerBase
    {
        private IEventoRepository _EventoRepository { get; set; }

        public EventoController()
        {
            _EventoRepository = new EventoRepository();
        }

        //CADASTRAR
        [HttpPost]
        [Authorize(Roles = "3")]
        public IActionResult Post(Evento NovaEvento)
        {
            try
            {
                _EventoRepository.Cadastrar(NovaEvento);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }


        //DELETAR
        [HttpDelete("{id}")]
        [Authorize(Roles = "1, 3")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método
                _EventoRepository.Deletar(id);

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
        [Authorize(Roles = "1, 3")]
        public IActionResult GetAll()
        {
            try
            {
                List<Evento> ListarTodos = _EventoRepository.Listar();

                return Ok(ListarTodos);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        //BUSCAR POR ID
        [HttpGet("{id}")]
        [Authorize(Roles = "1, 3")]
        public IActionResult GetById(int id)
        {
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método
                return Ok(_EventoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        //Atualizar Usuario
        [HttpPut("{id}")]
        [Authorize(Roles = "1, 2, 3")]
        public IActionResult Put(int id, Evento EventoAtualizado)
        {
            try
            {
                // Faz a chamada para o método
                _EventoRepository.Atualizar(id, EventoAtualizado);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
