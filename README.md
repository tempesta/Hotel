# Hotel

## Descrição do projeto:
-Arquitetura back-end:
>Foi escolhido por utilizar arquitetura circular(clean archteture). O projeto foi dividido em core < infrastructure < presentation e testes. Para conexão com banco foi utilizado FluentNHibernate, configurado para criar uma nova base de dados de acordo com as entidades mapeadas cada vez que a aplicação for iniciada. Optei por essa configuração por facilitar a configuração da base de dados. O back-end foi desenvolvido em **.NetCore 2.2** .
- Front-end
> A aplicação front-end foi utilizando o framework angularJS com a ultima versão do bootstrap(4.3). O front-end consome uma api rest criada no back-end para realizar as tarefas necessárias. Foi utilizado a versão do **node 12.10.0 32 bits**.
> Foi utilizado o banco de dados PostgreSQL 11.

## Passos para configurar a base de dados
- Criar uma nova base de dados com o nome 'hotelapi' , usuário 'postgres' e senha 'postgres', porta padrao 5432. Esta configuração deve ser desta forma devido a string de coneção : "DefaultConnection": "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=hotelapi;"

## Passos para rodar o front-end executar os seguintes passos:
- Va na pasta UI, e execute o comando **npm install**, para instalar as dependências do front-end;
- Digite o comando **'http-server -o http://localhost:8080/index.html'**. Este comando irá abrir a página do front-end no seu navegador padrão.


## Passos para rodar o back-end:
- Na pasta raiz do projeto digite o comando **'dotnet run -p Hotel.Api'**. Este comando criara o servidor para o back-end.

