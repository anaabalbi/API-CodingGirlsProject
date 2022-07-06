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



    }
}
