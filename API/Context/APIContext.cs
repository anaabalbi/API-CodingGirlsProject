using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class APIContext :DbContext

    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {

        }

        public virtual DbSet<Aluno>? Aluno { get; set; }
        public virtual DbSet<Turma>? Turma { get; set; }


    }
}
