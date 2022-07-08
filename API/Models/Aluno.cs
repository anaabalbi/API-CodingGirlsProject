using API.Context;

namespace API.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public int TurmaID { get; set; }
        public int Faltas { get; set; }

        public List<Aluno> AlunoAtivo(List<Aluno> alunos, List<Turma> turmas)
        {
            List<Aluno> alunosAtivos = new();
            Turma turmaAtivas = new Turma();
            foreach(Turma turma in turmaAtivas.TurmasAtivas(turmas))
            {
                foreach (Aluno aluno in alunos)
                {
                    if (turma.Id == aluno.TurmaID)
                    {
                        alunosAtivos.Add(new Aluno { Id = aluno.Id, Nome = aluno.Nome, DataNascimento = aluno.DataNascimento, Sexo = aluno.Sexo, TurmaID = aluno.TurmaID, Faltas = aluno.Faltas });
                    }
                }
            }
           
            return alunosAtivos;
        }

    }


}



