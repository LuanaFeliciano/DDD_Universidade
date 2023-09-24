using DDD.Domain.SecretariaContext;
using DDD.Infra.SqlServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        readonly IProfessorRepository _professorRepository;

        //Dependency Injection
        public ProfessorController(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        // GET: api/<AlunosController>
        [HttpGet]
        public ActionResult<List<Professor>> Get()
        {
            return Ok(_professorRepository.GetProfessores());
        }

        [HttpGet("{id}")]
        public ActionResult<Professor> GetById(int id)
        {
            return Ok(_professorRepository.GetProfessorById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Professor> CreateProfessor(Professor professor)
        {
            if (professor.Nome.Length < 3 || professor.Nome.Length > 30)
            {
                return BadRequest("Nome deve ser maior que 3 e menor que 30 caracteres.");
            }
            _professorRepository.InsertProfessor(professor);
            return CreatedAtAction(nameof(GetById), new { id = professor.UserId }, professor);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Professor professor)
        {
            try
            {
                if (professor == null)
                    return NotFound();

                _professorRepository.UpdateProfessor(professor);
                return Ok("Professor Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Professor professor)
        {
            try
            {
                if (professor == null)
                    return NotFound();

                _professorRepository.UpdateProfessor(professor);
                return Ok("Professor Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
