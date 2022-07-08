namespace API.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }


        public List<Turma> TurmasAtivas(List<Turma> turmas)
        {
            List<Turma> turmasList = new();
            foreach(Turma turma in turmas)
            {
                if (turma.Ativo)
                {
                    turmasList.Add(new Turma { Id = turma.Id, Nome = turma.Nome, Ativo = turma.Ativo });
                }
            }
            return turmasList;
        }

        public bool TemAlunos(int id, List<Aluno> aluno)
        {
            foreach(Aluno alunos in aluno)
            {
                if (alunos.TurmaID == id)
                {
                    return true;
                }
            }
            return false;
        }

    }



}
