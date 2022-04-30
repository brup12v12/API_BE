using Charpter.WebApi.Models;
using Charpter.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Charpter.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    [Authorize] //[Authorize(Roles = "0")] 
    public class LivroController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;

        public LivroController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_livroRepository.Listar());

            }
            catch (Exception e)
            {
                {

                    throw new Exception(e.Message);
                }


            }
        }


        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Livro livroBuscado = _livroRepository.BuscarPorId(id);

                if (livroBuscado == null)
                {
                    return NotFound();
                }

                return Ok(livroBuscado);

            }
            catch (Exception e)
            {
                {

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Livro livro)
        {
            try
            {
                _livroRepository.Cadastrar(livro);

                //return Ok("livro Cadastrado");

                return StatusCode(201);
            }
            catch (Exception e)
            {
                {

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpPut("{Id}")]

        public IActionResult Cadastrar(int id, Livro livro)
        {
            try
            {
                _livroRepository.Atualizar(id, livro);

                return StatusCode(204);
            }
            catch (Exception e)
            {
                {

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpDelete("{Id}")]

        public IActionResult Deletar(int id)
        {
            try
            {
                _livroRepository.Deletar(id);

                return Ok("Livro deletado com sucesso.");
            }
            catch (Exception e)
            {
                {

                    throw new Exception(e.Message);
                }
            }
        }
    }
}
