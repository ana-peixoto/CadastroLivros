# Cadastro de Livros

## Descrição
Este projeto é um sistema de cadastro de livros, autores e assuntos, desenvolvido como parte de um desafio técnico. O objetivo é implementar um CRUD (Criar, Ler, Atualizar e Deletar) para gerenciar informações sobre livros, autores e suas respectivas categorias (assuntos).

## Tecnologias Utilizadas
- **Linguagem**: C#
- **Framework**: ASP.NET Core
- **Banco de Dados**: MySQL
- **Frontend**: HTML, CSS (Bootstrap)
- **Relatórios**: ReportViewer
- **Gerenciamento de Pacotes**: NuGet

## Funcionalidades
- Cadastro de livros, autores e assuntos.
- Edição e exclusão de registros.
- Geração de relatórios em PDF com dados dos livros agrupados por autor.
- Interface simples e responsiva utilizando Bootstrap.

## Estrutura do Projeto
/CadastroLivros ├── /Controllers # Controladores do ASP.NET ├── /Models # Modelos de Dados ├── /Views # Views do MVC ├── /wwwroot # Arquivos estáticos (CSS, JS) ├── /Reports # Relatórios RDLC └── /Migrations # Migrations do Entity Framework


## Como Executar o Projeto
### Pré-requisitos
- [.NET SDK](https://dotnet.microsoft.com/download) instalado.
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) instalado ou configuração de um banco de dados em nuvem.
- [MySQL Connector/NET](https://dev.mysql.com/downloads/connector/net/) para o Entity Framework.

### Passos
1. Clone o repositório:
   ```bash
   git clone https://github.com/ana-peixoto/CadastroLivros.git
   cd CadastroLivros
2. Configure a string de conexão no arquivo appsettings.json:
   ```json
   "ConnectionStrings": {
    "DefaultConnection": "Server=seu_servidor;Database=CadastroLivros;User Id=seu_usuario;Password=sua_senha;"
   }
   ```
   
    - Caso prefira usar o docker para levantar o MySql, mantenha a connection string do projeto e rode o comando:
   ```bash
   docker run --name mysql -e MYSQL_DATABASE=livrosdb -e MYSQL_ROOT_PASSWORD=root -p 3306:3306 -d mysql:latest
   ```

   - Em seguida, inicie o migrations rodando o comando dentro do diretório do projeto:
   ```bash
   dotnet ef migrations add InitialCreate
   ```
     

4. Crie o banco de dados e aplique as migrations:
   ```bash
   dotnet ef database update
5. Execute a aplicação e acesse pelo seu navegador

### Contribuições
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests.

### Licença
Este projeto está licenciado sob a MIT License - veja o arquivo LICENSE para mais detalhes.

### Contato
Para mais informações, entre em contato:

* Ana Peixoto

  
Sinta-se à vontade para personalizar conforme necessário!



