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
              return NotFound("Não há alunos ativos");
          }
            List<Aluno> alunos = await _context.Aluno.ToListAsync();
            List<Aluno> alunosAtivos = new();
            for(int i =0; i<alunos.Count; i++)
            {
                var turma = await _context.Turma.FindAsync(alunos[i].TurmaID);
                if(turma !=null )
                {
                    if (turma.Ativo == true) { 
                
                    alunosAtivos.Add(new Aluno { Id = alunos[i].Id, Nome = alunos[i].Nome, DataNascimento = alunos[i].DataNascimento, Sexo = alunos[i].Sexo, TurmaID = alunos[i].TurmaID, Faltas = alunos[i].Faltas }) ;
                    }
                }
            }
            return alunosAtivos;
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
                return NotFound();
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
                if(turma == null || turma.Ativo==false)
                {
                    return Content("Não foi possível mudar o aluno de turma, pois a turma selecionada não existe ou não está ativa");
                }
                else
                {
                    await _context.SaveChangesAsync();
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
            _context.Aluno.Add(aluno);
            await _context.SaveChangesAsync();

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

            return NoContent();
        }

        private bool AlunoExists(int id)
        {
            return (_context.Aluno?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
