# InsperClassSchedule

Telas de Cadastro e Exibição de Horários de Aulas.
_________________________________________________________________________

IDE Microsoft Visual Studio Community 2022
Linguagem: c#

Projetos na Solução:
InsperClass.Web - WebApplication - .net core 3.1
InsperClass.Domain - Class Library - .net core 3.1
InsperClass.Data - Class Library - .net core 3.1

Pacotes externos utilizados:
Dapper (micro ORM)

Bibliotecas Javascript utilizadas:
jquery
jquery.dateandtime

_________________________________________________________________________

Observações do Projeto:
Database: \InsperClassSchedule\InsperClass.Data\DataBase\InsperDatabase.mdf

É necessário alterar o endereço do arquivo do database da ConnetionString, no arquivo 
\InsperClassSchedule\InsperClass.Web\appsettings.json
_________________________________________________________________________

Considerações sobre o teste:
- Não encontrei a função o para item "Atendimento" dentro do contexto da aplicação web que registre os horários das aulas.
É necessário levantar os dados sobre o processo de atendimento.

Considerações do projeto:
- É necessário alterar o endereço do arquivo de Database da ConnetionString, no arquivo 
\InsperClassSchedule\InsperClass.Web\appsettings.json,
para que a conexão com a base de dados funcione.

- Criei a arquitetura da solução com os itens solicitados funcionando , para que possa ser melhor estruturada e completada.
- É necessário criar Validação para os Horários cadastrados, para impedir cadastro duplicados.
- É preciso adicionar uma camada de Aplicação com serviços, para desacoplar a camada de Data do projeto Web.

