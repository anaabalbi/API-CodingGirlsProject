using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class APIContext :DbContext

    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {

        }

        public DbSet<Aluno>? Aluno { get; set; }
        public DbSet<Turma>? Turma { get; set; }


    }
}
