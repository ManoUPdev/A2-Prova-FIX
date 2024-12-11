# A2-Prova-FIX
repositorio para a a2 corrigida



Para que funcione use o repositorio como consulta de API e banco de dados


Como fazer uma API do zero
obs:esse e um exemplo especifico, que pode mudar de acordo
exercicio. mas os passos a seguir sao essencias para criar api e banco de dados

Passo 1 

criar o local onde sera feito a API

dotnet new sln --output Todo ou qualquer outro nome

Passo 2 
Criar uma API(pasta)

dotnet new web --name API:

Passo 3
Adicionar uma solucao para API:
dotnet sln add API

Passo 4
rode o projeto para gerar a porta necessaria.(localhost:XXXX)
dotnet run --project API

Passo 5 
Crie um arquivo http para colocar as urls:
Clique com botao direito do mouse no Explorer,dps new file
crie um http(test.http), dps copie a porta gerada enquanto a api estiver
aberta e nao desligue antes dos testes(pode ser tanto pelo terminal externo quanto do vscode)

Passo 6 
com rest client instalado mande um send request que aparecera
o que precisa.

Passo 7
Crie a pasta "Modelos", dps crie as classes necessarias
obs:faca via solution explorer nesse caso
Passo 8 com a classes criadas mexa no API.csproj
faca isso:

<ItemGroup>
         <Folder Include="Models\" />
      </ItemGroup> 

Passo 9 
com a classe tarefa.cs criada e escrita, Vc devera criar instalar
as bibliotecas e dependencias para conseguir criar um banco de dados.
va para a pasta API ao inves projeto(Todo,por exemplo)  para funcionar corretamente

dotnet add package Microsoft.EntityFrameworkCore.Sqlite

logo em seguida

dotnet add package Microsoft.EntityFrameworkCore.Design

Passo 10
Crie AppDataContext.cs
a classe que vai determinar como vai ser o banco de dados
configure a classe


Passo 11 Adicone a primeira micracao

caso de erro mande inslatar as dependecias faltantes, senao realize a primeira migracao:

dotnet tool install --global dotnet-ef

se nao der erro:
dotnet ef migrations add InitialCreate


Passo 12
Após adicionar sua primeira migração,
aplique-a para criar o banco de dados. 
O Entity Framework Core usará a string de conexão definida no seu contexto (AppDbContext)
 para saber onde e como criar o banco de dados. Execute o seguinte comando:

dica: se vc quiser mudar o nome, vc tera que criar de novo o banco de dados

dotnet ef database update

Passo 13
Apos banco de dados criado, o program.cs deve ser modificado ate
permitir que uma nova url seja executada, POST:http//localhost:XXXX/api/tarefas/cadastrar
(funcao de cadastrar tarefa)

Passo 14 
Adicione listar todas as tarefas com um get modificado no program.cs e consequentemente
.http

Passo 15 
Adicione buscar , com um outro get modificada em program.cs conse
quentemente .http 

assim por diante
