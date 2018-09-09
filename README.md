## Instruções para execução

Requisitos:
1) Instalação do .net core (https://www.microsoft.com/net/core).
2) É necessário um banco SQL;
3) Abrir o arquivo appsettings.json dentro da pasta do projeto, e configurar a DefaultConnection conforme seu banco de dados.
4) Abrir a pasta do projeto, e executar o comando "dotnet run".
5) A aplicação irá iniciar e será exibida uma tela inicial onde contêm cada método disponível para utilização.

## Chamadas
1) Para executar uma chamada em busca de uma sequência de dna por mutantes, 
faça um "post" para a seguinte url (http://localhost:5000/mutant)
com o body em "raw" do tipo "application/json)

POST /mutant HTTP/1.1
Host: localhost:5000
Content-Type: application/json
Cache-Control: no-cache
Postman-Token: 550a9dc1-764c-6280-eee8-58e36c44b874
{
"dna":["ATGCGA","CAGTGC","TTACGT","AGACGG","CACCTA","TCACTG"]
}

2) Para executar uma chamada e obter os stats das buscas por mutantes
faça um "get" para a seguinte url (http://localhost:5000/stats)

GET /stats HTTP/1.1
Host: localhost:5000
Cache-Control: no-cache
Postman-Token: 69652664-2bec-5d76-c33b-2dcc18d6b750


## Testes
Para executar os testes execute o comando:
"dotnet test MutantIdentifier.Tests/MutantIdentifier.Tests.csproj"


