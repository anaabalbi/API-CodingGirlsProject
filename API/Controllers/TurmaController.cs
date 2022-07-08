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
    public class TurmaController : ControllerBase
    {
        private Turma turma= new Turma();
        private readonly APIContext _context;

        public TurmaController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Turma
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turma>>> GetTurma()
        {
          if (_context.Turma == null)
          {
              return NotFound();
          }
                List<Turma>  turmas= await _context.Turma.ToListAsync();                
                if(turma.TurmasAtivas(turmas).Count == 0)
                {
                    return Content("Não há turma ativa.");
                }
                return turma.TurmasAtivas(turmas);
            
         
        }

        // GET: api/Turma/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Turma>> GetTurma(int id)
        {
          if (_context.Turma == null)
          {
              return NotFound();
          }
            var turma = await _context.Turma.FindAsync(id);

            if (turma == null)
            {
                return NotFound("Não há turma relacionada a esse id.");
            }

            return turma;
        }

        // PUT: api/Turma/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurma(int id, Turma turma)
        {
            if (id != turma.Id)
            {
                return BadRequest();
            }

            _context.Entry(turma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurmaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Content($"Turma atualizada com sucesso!");
        }

        // POST: api/Turma
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Turma>> PostTurma(Turma turma)
        {
          if (_context.Turma == null)
          {
              return Problem("Entity set 'APIContext.Turma'  is null.");
          }
            _context.Turma.Add(turma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTurma", new { id = turma.Id }, turma);
        }

        // DELETE: api/Turma/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurma(int id)
        {
            if (_context.Turma == null)
            {
                return NotFound();
            }
            var turmaID = await _context.Turma.FindAsync(id);
            if (turmaID == null)
            {
                return NotFound();
            }
            else {
                List<Aluno> alunos = await _context.Aluno.ToListAsync();


                if (turma.TemAlunos(turmaID.Id, alunos))
                {
                    return Content("Turma não pode ser deletada por conter alunos.");
                }

                _context.Turma.Remove(turmaID);
                await _context.SaveChangesAsync();
            }
            
         
            return Content("Turma deletada com sucesso!");
        }

        private bool TurmaExists(int id)
        {
            return (_context.Turma?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
