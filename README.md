# Dados do projeto:
 - c# : net core 2.1
 - angular: 7.2.1

# Primeiros passos:
- 1 Gerar o banco: Utilizando o visual studio acessar o projeto ReceitasOpusTeste.Api -> abrir o arquivo appsettings.json -> alterar a         string de conexão ("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ReceitasOpusTeste;Integrated Security=true"), restaurar os         pacostes nuget, abrir o package manager console -> selecionar o projeto ReceitasOpusTeste.core e rodar o comando: Update-Database
- 2 Instalar as dependencias do projeto ui: instalar o npm e a ultima versao do angular cli -> acessar a pasta do projeto                     ReceitasOpusTeste-Ui e rodar o comando -> npm i
- 3 Rodar o projeto: Selecionar o projeto ReceitasOpusTeste.Api como o de inicialização no visual studio e rodar, caso a parta do             localhost seja diferente de 5001 alterar no projeto ReceitasOpusTeste-Ui -> environments -> environments.ts para a porta correta, na       pasta raiz do projeto ReceitasOpusTeste-Ui rodar o comando no console: ng serve -o
  
