# Dados do projeto:
 _ c# : net core 2.1
 _ angular: 7.2.1

# Primeiros passos:
_ 1 Gerar o banco: Utilizando o visual studio acessar o projeto ReceitasOpusTeste.Api -> abrir o arquivo appsettings.json -> alterar a       _ string de conexão ("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ReceitasOpusTeste;Integrated Security=true"), restaurar os       _ pacostes nuget, abrir o package manager console e rodar os comandos: Add-Migration InitialCreate, Add-Migration AddProductReviews,       _ Update-Database
_ 2 Instalar as dependencias do projeto ui: instalar o npm e a ultima versao do angular cli -> acessar a pasta do projeto                   _ ReceitasOpusTeste-Ui e rodar o comando -> npm i.
_ 3 Rodar o projeto: Selecionar o projeto ReceitasOpusTeste.Api como o de inicialização no visual studio e rodar, caso a parta do           _ localhost seja diferente de 5001 alterar no projeto ReceitasOpusTeste-Ui -> environments -> environments.ts para aporta correta, na     _ pasta raiz do projeto ReceitasOpusTeste-Ui rodar o comando no console: ng serve -o
  
