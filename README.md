# Migration via dot-ef tools

## Entrar na pasta do projeto ICI.ProvaCandidato.Dados
Acessar via terminal a pasta do projeto de dados para executar os comandos

### Criar uma nova migration
dotnet ef migrations add -c AppDbContexto -o ./Migrations -s ..\ICI.ProvaCandidato.Web\ICI.ProvaCandidato.Web.csproj <Nome_Migration> 

### Atualizar o banco com a migration
dotnet ef database update -c AppDbContexto -s ..\ICI.ProvaCandidato.Web\ICI.ProvaCandidato.Web.csproj 

## Remover a migration
dotnet ef migrations remove -c AppDbContexto -s ..\ICI.ProvaCandidato.Web\ICI.ProvaCandidato.Web.csproj Add_Tag
