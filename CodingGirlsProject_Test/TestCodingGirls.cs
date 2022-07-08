


using API.Context;
using API.Controllers;
using API.Models;
using Microsoft.EntityFrameworkCore;

using Moq;


namespace CodingGirlsProject_Test
{
    public class TestCodingGirls
    {
        Aluno aluno = new Aluno();
        Turma turma = new Turma();

        public List<Aluno> ListTestAlunos()
        {
            return new List<Aluno>(){
                new Aluno {
                Id = 1,
                Nome = "Ana",
                DataNascimento = new DateTime(1991, 1, 21),
                Sexo = "F",
                TurmaID = 1,
                Faltas = 0
            }};
        }

        public List<Turma> ListTestTurmas()
        {
            return new List<Turma>(){
                new Turma {
                Id = 1,
                Nome = "CodingGirl",
                Ativo= false
            }};
        }

        public Turma ListTestTurma(int id)
        {
           List<Turma> list = ListTestTurmas();
           Turma result = new Turma();
           foreach (Turma turma in list)
            {
                if(turma.Id == id)
                {
                    
                    result= turma;
                }
            }
           return result;
        }

        [Fact]
        public  void TestGetAluno()
        {
            List<Aluno> alunos = ListTestAlunos();
            List<Turma> turmas = ListTestTurmas();



            Assert.Equal(0, aluno.AlunoAtivo(alunos,turmas).Count);
        }

        [Fact]
        public void TestGetTurma()
        {
            List<Turma> turmas = ListTestTurmas();

            

            Assert.Equal(0, turma.TurmasAtivas(turmas).Count);

        }

        [Theory]
        [InlineData(1)]
        public void TestTeamAlunosTurma(int id)
        {
            var result = ListTestTurma(id);
            List<Aluno> alunos = ListTestAlunos();



            Assert.Equal(true, turma.TemAlunos(result.Id, alunos));

        }

        [Theory]
        [InlineData(2)]
        public void FailTestTemAlunosTurma(int id)
        {
            var result = ListTestTurma(id);
            List<Aluno> alunos = ListTestAlunos();



            Assert.Equal(false, turma.TemAlunos(result.Id, alunos));
        }









    }
}