# API de Cadastro de Filmes - ASP.NET Core + SQL Server

Esta é uma API REST criada para fins de estudo, que permite realizar operações de CRUD (Create, Read, Update, Delete) em um catálogo de filmes. O projeto foi desenvolvido utilizando **ASP.NET Core**, **Entity Framework Core**, e conecta-se a um banco de dados **SQL Server** em container Docker via **WSL2** no Windows.

---

## Tecnologias utilizadas

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server (rodando via Docker)
- Swagger (interface interativa de teste de API)
- WSL2 + Docker Desktop (para execução do container)

---

## Funcionalidades da API

- Cadastrar um novo filme
- Listar todos os filmes
- Buscar filme por ID
- Atualizar dados de um filme
- Excluir um filme

---

# Pacotes Nuget para adicionar no projeto.
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Swashbuckle.AspNetCore
```

# Docker

### 1. **Baixar a imagem do SQL Server 2022 (caso ainda não tenha)**

```bash
docker pull mcr.microsoft.com/mssql/server:2022-latest
```

### 2. Criação e execução da imagem

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong@Passw0rd" -p 1433:1433 --name sqlserver-filmes -d mcr.microsoft.com/mssql/server:2022-latest
```

## Principais Comandos

### Ferramenta de CLI do EF Core
```bash
dotnet tool install --global dotnet-ef
```

### Criar uma migration

```bash
dotnet ef migrations add InitialCreate
```

### Atualizar banco de dados

```bash
dotnet ef database update
```

### Build da aplicação

```bash
dotnet build
```

### Executar a API

```bash
dotnet run
```
## Abra o navegador e acesse:

```bash
 https://localhost:{porta}/swagger
```

---

## Como testar a API

### Acesse a documentação via Swagger:

```
https://localhost:{porta}/swagger
```

### Endpoints disponíveis

- `GET /api/filmes` – Lista todos os filmes
- `GET /api/filmes/{id}` – Busca um filme por ID
- `POST /api/filmes` – Cadastra um novo filme
- `PUT /api/filmes/{id}` – Atualiza um filme existente

### Exemplo de JSON para criação:

```json
{
  "titulo": "O Poderoso Chefão",
  "diretor": "Francis Ford Coppola",
  "anoLancamento": "24/03/1972"
}
```

> O campo dataCriacao é preenchido automaticamente e inclui data e hora (sem os segundos).>

- O campo `anoLancamento` armazena apenas **data (sem hora)** no formato `dd/MM/yyyy`.
- O campo `dataCriacao` armazena a **data e hora sem segundos**, no formato `dd/MM/yyyy HH:m`

**Aviso:** Esta aplicação **não utiliza DTOs** (Data Transfer Objects). Todos os dados são manipulados diretamente nos modelos de banco de dados.
