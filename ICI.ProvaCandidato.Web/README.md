#Add migration

##Entrar na pasta do projeto ICI.ProvaCandidato.Dados 

dotnet ef migrations add -c AppDbContexto -o ./Migrations -s ..\ICI.ProvaCandidato.Web\ICI.ProvaCandidato.Web.csproj <Nome_Migration>
dotnet ef database update -c AppDbContexto -s ..\ICI.ProvaCandidato.Web\ICI.ProvaCandidato.Web.csproj 
dotnet ef migrations remove -c AppDbContexto  -s ..\ICI.ProvaCandidato.Web\ICI.ProvaCandidato.Web.csproj Add_Tag