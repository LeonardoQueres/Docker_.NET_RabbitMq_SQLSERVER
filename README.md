## Project Documentation
### Docker - RabbitMq - .NET 8 - C# - SQL SERVER

### Project Description
- Application created to demonstrate the knowledge acquired in the course `Deepen in .NET with Microservices Architecture and RabbitMQ`.
- The docker-compose file was configured to download the SQL Server image, configure and create the containers and images. 
- The main application runs on port 4001 - `https://localhost:4001/swagger/index.html`
- The secondary application runs on port 5001 - `https://localhost:5001/swagger/index.html`

## System Requirements
- .NET SDK: .NET Core 8 or higher
- Editor/IDE: Visual Studio or Visual Studio Code
- Docker Desktop
- RabbitMq

## Project Structure
```
Restaurant Solution/
├──ItemService_Api
├── ItemService_Borders
├── ItemService_Repositories
├── ItemService_Tests
├── ItemService_UseCases
├──Restaurant_Api
├── Restaurant_Frontiers
├── Restaurant_Repositories
├── Restaurant_Tests
└──Restaurant_UseCases
```

##Configuration
1. After downloading the project.

2. Run the `docker-compose up --build` command in the terminal.

------------------------------------------------------------------------------------------------------------------------------------------------------------------


## Documentação do Projeto
### Docker - RabbitMq - .NET 8 - C# - SQL SERVER

### Descrição do Projeto
 - Aplicação criada para demonstrar os conhecimentos adiquiridos no curso `Aprofunde em .NET com Arquitetura de Microsserviços e RabbitMQ`.
 - O arquivo docker-compose foi configurado para baixar a imagem do sql server, configurar e criar os containers e imagens.	
 - A aplicação principal roda na porta 4001 - `https://localhost:4001/swagger/index.html`
 - A aplicação secundaria roda na porta 5001 - `https://localhost:5001/swagger/index.html`

## Requisitos do Sistema
 - .NET SDK: .NET Core 8 ou superior
 - Editor/IDE: Visual Studio ou Visual Studio Code
 - Docker Desktop
 - RabbitMq 

## Estrutura do Projeto
```
RestauranteSolution/
├── ItemService_Api
├── ItemService_Borders
├── ItemService_Repositories
├── ItemService_Tests
├── ItemService_UseCases
├── Restaurante_Api
├── Restaurante_Borders
├── Restaurante_Repositories
├── Restaurante_Tests
└── Restaurante_UseCases
```

## Configuração
1. Após baixar o projeto.

2. Execute o comando `docker-compose up --build` no terminal.


   



