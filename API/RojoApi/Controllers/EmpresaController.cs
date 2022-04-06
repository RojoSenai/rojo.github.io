using Microsoft.AspNetCore.Authorization;
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
    public class EmpresaController : Controller
    {
            private IEmpresaRepository _EmpresaRepository { get; set; }

        public EmpresaController()
        {
            _EmpresaRepository = new EmpresaRepository();
        }

        //CADASTRAR
        [HttpPost]
        [Authorize(Roles = "3")]
        public IActionResult Post(Empresa NovaEmpresa)
        {
            try
            {
                _EmpresaRepository.Cadastrar(NovaEmpresa);

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
                _EmpresaRepository.Deletar(id);

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
                List<Empresa> ListarTodos = _EmpresaRepository.Listar();

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
                return Ok(_EmpresaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        //Atualizar Usuario
        [HttpPut("{id}")]
        [Authorize(Roles = "1, 2, 3")]
        public IActionResult Put(int id, Empresa EmpresaAtualizada)
        {
            try
            {
                // Faz a chamada para o método
                _EmpresaRepository.Atualizar(id, EmpresaAtualizada);

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
