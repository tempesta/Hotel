# Hotel

## Descrição do projeto:
- Back-end:
>Arquitetura circular(clean archteture). Projeto dividido em core < infrastructure < presentation e testes. ORM FluentNHibernate. Desenvolvido em **.NetCore 2.2** .
- Front-end
> AngularJS com a ultima versão do bootstrap(4.3). **node version 12.10.0 32 bits**.
> Banco de dados PostgreSQL 11.

## Passos para configurar a base de dados
- Criar uma nova base de dados com o nome 'hotelapi' , usuário 'postgres' e senha 'postgres', porta padrao 5432. Esta configuração deve ser desta forma devido a string de coneção : "DefaultConnection": "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=hotelapi;"

## Passos para rodar o front-end executar os seguintes passos:
- Va na pasta UI, e execute o comando **npm install**, para instalar as dependências do front-end;
- Digite o comando **'http-server -o http://localhost:8080/index.html'**. Este comando irá abrir a página do front-end no seu navegador padrão.


## Passos para rodar o back-end:
- Na pasta raiz do projeto digite o comando **'dotnet run -p Hotel.Api'**. Este comando criara o servidor para o back-end.

