<h1 align="center"> API-CodingGirlsProject :nail_care: </h1>

<h3 align="center">Essa API Rest foi o projeto final do BootCamp RDI - C# realizado pela Blue EdTech.</h3>

#### Para a realizanção desse projeto foram utilizados:
    - C#
    - SQL
    - Azure
    - Net


#### Link da aplicação na Azure:
    https://api20220703160109.azurewebsites.net

#### Link da documentação gerada por testes no Postman:
    https://documenter.getpostman.com/view/21638669/UzJPKa5R


<p align="center">ROTAS DA APLICAÇÃO</p>

**ALUNO**

GET - api/Aluno
Essa rota retornará todos os alunos que estão matrículados em uma turma ativa.

Exemplo de requicição:
 https://api20220703160109.azurewebsites.net/api/Aluno

Resposta:
[
  {
    "id": 2,
    "nome": "Alice Gaspar",
    "dataNascimento": "2015-09-06T00:00:00",
    "sexo": "F",
    "turmaID": 3,
    "faltas": 3
  }
]

Caso não haja alunos ativos a resposta será:
Não há alunos ativos

------------------------------------------------------------------------------------------------

GET - api/Aluno/{id}
Essa rota retornará o aluno cujo id foi passado na rota.

Exemplo de requicição:
 https://api20220703160109.azurewebsites.net/api/Aluno/2

Resposta:
[
  {
    "id": 2,
    "nome": "Alice Gaspar",
    "dataNascimento": "2015-09-06T00:00:00",
    "sexo": "F",
    "turmaID": 3,
    "faltas": 3
  }
]

Caso não haja aluno correspondente ao id escolhido:
Não há aluno relacionado a esse id.

------------------------------------------------------------------------------------------------

POST - api/Aluno
Essa rota criará um novo aluno.

Exemplo de requicição:
 https://api20220703160109.azurewebsites.net/api/Aluno

Body - JSON:
{
    "id": 0,
    "nome": "Anne Hathaway",
    "dataNascimento": "1982-11-12T00:00:00",
    "sexo": "F",
    "turmaID": 3,
    "faltas": 3
}

Resposta:
{
    "id": 4,
    "nome": "Anne Hathaway",
    "dataNascimento": "1982-11-12T00:00:00",
    "sexo": "F",
    "turmaID": 3,
    "faltas": 3
}

Caso há turma escolhida seja inativa ou não exista, a resposta será:
Não foi possível cadastrar o aluno na turma selecionada, pois ela não está ativa ou não existe.

------------------------------------------------------------------------------------------------

PUT - api/Aluno/{id}
Essa rota atualizará os dados do aluno que o id for passado na rota.

Exemplo de requicição:
 https://api20220703160109.azurewebsites.net/api/Aluno/4

Body - JSON:
{
    "id": 4,
    "nome": "Anne Hathaway",
    "dataNascimento": "1982-11-12T00:00:00",
    "sexo": "F",
    "turmaID": 3,
    "faltas": 0
}

Resposta:
Anne Hathway foi atualizado com sucesso!

Caso haja uma mudança de turma  e a turma escolhida seja inativa ou não exista, a resposta será:
Não foi possível cadastrar o aluno na turma selecionada, pois ela não está ativa ou não existe.

------------------------------------------------------------------------------------------------

DELETE - api/Aluno/{id}
Essa rota deleterá o aluno cujo o id for passado na rota.

Exemplo de requicição:
 https://api20220703160109.azurewebsites.net/api/Aluno/4

Resposta:
Aluno deletado com sucesso!

========================================================================================

TURMA

GET - api/Turma
Essa rota retornará todas as turmas que estão ativas.

Exemplo de requicição:
 https://api20220703160109.azurewebsites.net/api/Turma

Resposta:
[
    {
        "id": 3,
        "nome": "JavaScript",
        "ativo": true
    }
]

Caso não haja turmas ativas a resposta será:
Não há turma ativa.

------------------------------------------------------------------------------------------------

GET - api/Turma/{id}
Essa rota retornará a turma relacionada ao id fornecido.

Exemplo de requicição:
 https://api20220703160109.azurewebsites.net/api/Turma/1

Resposta:
{
    "id": 1,
    "nome": "CodingGirl",
    "ativo": false
}

Caso não haja turma correspondente ao id escolhido:
Não há turma relacionada a esse id.

------------------------------------------------------------------------------------------------

POST - api/Turma/
Essa rota criará uma nova turma.

Exemplo de requicição:
 https://api20220703160109.azurewebsites.net/api/Turma/

Body - JSON:
{
    "id": 0,
    "nome": "UnitTest",
    "ativo": true
}

Resposta:
{
    "id": 4,
    "nome": "UnitTest",
    "ativo": true
}

------------------------------------------------------------------------------------------------

PUT - api/Turma/{id}
Essa rota atualizará a turma cujo o id foi fornecido.

Exemplo de requicição:
 https://api20220703160109.azurewebsites.net/api/Turma/1

Body - JSON:
{
   "id": 1,
    "nome": "CodingGirl",
    "ativo": true
}

Resposta:
Turma atualizada com sucesso!

------------------------------------------------------------------------------------------------

DELETE - api/Turma/{id}
Essa rota deleterá a turma cujo o id for passado na rota.

Exemplo de requicição:
 https://api20220703160109.azurewebsites.net/api/Turma/4

Resposta:
Turma deletada com sucesso!

Caso a turma tenha alunos, a resposta será:
Turma não pode ser deletada por conter alunos.



