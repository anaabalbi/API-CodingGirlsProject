using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Context;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly APIContext _context;
        Turma turmas = new Turma();

        public AlunoController(APIContext context)
        {
            _context = context;
        }

     

        // GET: api/Aluno
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAluno()
        {
          if (_context.Aluno == null)
          {
              return NotFound();
          }
            List<Aluno> alunos = await _context.Aluno.ToListAsync();
            List<Turma> turmas = await _context.Turma.ToListAsync();
            Aluno aluno = new Aluno();
            if (aluno.AlunoAtivo(alunos, turmas).Count == 0)
            {
                return Content("Não há alunos ativos.");
            }
            return aluno.AlunoAtivo(alunos, turmas);
        }

        // GET: api/Aluno/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
          if (_context.Aluno == null)
          {
              return NotFound();
          }
            var aluno = await _context.Aluno.FindAsync(id);

            if (aluno == null)
            {
                return NotFound("Não há aluno relacionado a esse id.");
            }

            return aluno;
        }

        // PUT: api/Aluno/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                var turma = await _context.Turma.FindAsync(aluno.TurmaID);

                if (turma.Ativo)
                {
                    await _context.SaveChangesAsync();
                }

                else
                {
                    return Content("Não foi possível mudar o aluno de turma, pois a turma selecionada não existe ou não está ativa");


                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
                {
                    return NotFound("Não há aluno correspondente a esse id");
                }
                else
                {
                    throw;
                }
            }

            return Content($"{aluno.Nome} foi atualizado com sucesso!");
        }

        // POST: api/Aluno
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {
          if (_context.Aluno == null)
          {
              return Problem("Entity set 'APIContext.Aluno'  is null.");
          }
            else
            {
                var turma = await _context.Turma.FindAsync(aluno.TurmaID);

                if (turma.Ativo || turma== null)
                {
                    _context.Aluno.Add(aluno);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return Content("Não foi possível cadastrar o aluno na turma selecionada, pois ela não está ativa ou não existe");
                }
            }
            

            return CreatedAtAction("GetAluno", new { id = aluno.Id }, aluno);
        }

        // DELETE: api/Aluno/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            if (_context.Aluno == null)
            {
                return NotFound();
            }
            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();

            return Content("Aluno deletado com sucesso!");
        }

        private bool AlunoExists(int id)
        {
            return (_context.Aluno?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
