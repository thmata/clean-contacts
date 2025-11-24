# Clean Contacts API

API RESTful para gerenciamento de contatos desenvolvida com .NET 10, seguindo os princípios de Clean Architecture, CQRS e Domain-Driven Design (DDD).

## 🚀 Quick Start

A forma mais rápida de executar o projeto é usando Docker:

```bash
git clone https://github.com/thmata/clean-contacts.git
cd clean-contacts
docker compose up -d
```

Acesse o Swagger em: **http://localhost:5000/swagger**

**Credenciais padrão:**
- Usuário: `admin`
- Senha: `admin123`

---

## Arquitetura

O projeto segue os princípios de **Clean Architecture**, com separação clara de responsabilidades:

```
src/
+-- Api/                    # Camada de apresentação (Controllers, DTOs, Filtros)
+-- Application/            # Camada de aplicação (Use Cases, CQRS, Validações)
+-- Domain/                 # Camada de domínio (Entidades, Regras de negócio)
+-- Infrastructure/         # Camada de infraestrutura (Persistência, Serviços externos)

tests/
+-- Application.UnitTests/  # Testes unitários
```

### Princípios Aplicados

- **Clean Architecture** – Separação de responsabilidades em camadas  
- **CQRS** – Separação de comandos (escrita) e queries (leitura) usando MediatR  
- **DDD** – Modelagem orientada a domínio  
- **Repository Pattern** – Abstração da persistência  
- **Dependency Injection** – Injeção de dependências  
- **Validation Pattern** – Validações com FluentValidation  
- **JWT Authentication** – Autenticação baseada em tokens  
- **Global Exception Handling** – Tratamento de exceções centralizado  

## Funcionalidades

### Autenticação
- **POST** `/api/auth/login` - Autenticação de usuário e geração de token JWT

### Gerenciamento de Contatos
- **GET** `/api/contacts` – Lista contatos do usuário autenticado com paginação  
- **GET** `/api/contacts/{id}` – Obtém um contato específico  
- **POST** `/api/contacts` – Cria novo contato  
- **PUT** `/api/contacts/{id}` – Atualiza contato existente  
- **DELETE** `/api/contacts/{id}` – Remove contato  

### Recursos Adicionais
- Paginação  
- Auditoria de alterações (ContactAudit)  
  - *Módulo em desenvolvimento: futuramente será integrado com mensageria usando RabbitMQ para rastrear mudanças em tempo real.*
- Isolamento de dados por usuário (somente contatos do usuário logado)
- Validações com FluentValidation
- Documentação com Swagger/OpenAPI  

## Tecnologias Utilizadas

- **.NET 10**
- **ASP.NET Core**
- **Entity Framework Core 9**
- **PostgreSQL**
- **MediatR**
- **FluentValidation**
- **JWT Bearer**
- **BCrypt.Net**
- **Swagger/OpenAPI**
- **xUnit**

## Pré-requisitos

- .NET 10 SDK  
- PostgreSQL 15+  
- Docker (opcional)

## 🐳 Docker (Recomendado)

### Executar com Docker Compose

```bash
docker compose up -d
```

A API estará disponível em:
- **HTTP**: http://localhost:5000
- **Swagger**: http://localhost:5000/swagger

**Recursos automáticos:**
✅ Banco de dados PostgreSQL configurado
✅ Migrações aplicadas automaticamente
✅ Usuário admin criado
✅ Pronto para uso!

### Parar os containers

```bash
docker compose down
```

### Remover volumes (limpar dados)

```bash
docker compose down -v
```

---

## 💻 Execução Local (Sem Docker)

### Pré-requisitos

- .NET 10 SDK
- PostgreSQL 15+

### 1. Clone o repositório

```bash
git clone https://github.com/thmata/clean-contacts.git
cd clean-contacts
```

### 2. Configure o Banco de Dados

Crie um banco PostgreSQL e atualize a connection string em `src/Api/appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=clean_contacts_db;Username=seu_usuario;Password=sua_senha;Port=5432"
  }
}
```

### 3. Aplicar Migrações

```bash
cd src/Api
dotnet ef database update --project ../Infrastructure --startup-project .
```

### 4. Executar a Aplicação

```bash
cd src/Api
dotnet run
```

A API estará disponível em:

- **HTTP**: http://localhost:5163
- **HTTPS**: https://localhost:7144
- **Swagger**: https://localhost:7144/swagger

---

## 📖 Exemplos de Uso da API

### Credenciais Padrão

- **Usuário**: `admin`
- **Senha**: `admin123`

### 1. Logingin

```bash
POST /api/auth/login
Content-Type: application/json

{
  "username": "admin",
  "password": "admin123"
}
```

**Resposta:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

### 2. Listar Contatostos

```bash
GET /api/contacts?page=1&pageSize=10
Authorization: Bearer {seu_token}
```

### 3. Criar Contatoato

```bash
POST /api/contacts
Authorization: Bearer {seu_token}
Content-Type: application/json

{
  "name": "João Silva",
  "email": "joao@example.com",
  "phone": "11999999999"
}
```

### 4. Atualizar Contato

```bash
PUT /api/contacts/{id}
Authorization: Bearer {seu_token}
Content-Type: application/json

{
  "name": "João Silva Santos",
  "email": "joao.silva@example.com",
  "phone": "11988888888"
}
```

### 5. Deletar Contato

```bash
DELETE /api/contacts/{id}
Authorization: Bearer {seu_token}
```

---

## 🧪 Testes

### Executar todos os testes

```bash
dotnet test
```

### Executar com cobertura de código

```bash
dotnet test --collect:"XPlat Code Coverage"
```

### Executar testes específicos

```bash
dotnet test --filter "FullyQualifiedName~CreateContactCommandHandlerTests"
```

---

## 📊 Estrutura de Dados

### User
```csharp
Id: Guid
Username: string
PasswordHash: string
CreatedAt: DateTime
UpdatedAt: DateTime?
Contacts: List<Contact>
```

### Contact
```csharp
Id: Guid
UserId: Guid
Name: string
Email: string
Phone: string
CreatedAt: DateTime
UpdatedAt: DateTime?
```

### ContactAudit
```csharp
Id: Guid
ContactId: Guid
UserId: Guid
Name: string
Email: string
UpdatedAt: DateTime?
CreatedAt: DateTime
```

---

## 📝 Notas

- **Migrações automáticas**: Ao usar Docker, as migrações são aplicadas automaticamente na inicialização.
- **Usuário padrão**: Um usuário admin é criado automaticamente para facilitar os testes.
- **Isolamento de dados**: Cada usuário vê apenas seus próprios contatos.
- **Auditoria**: O sistema registra todas as alterações em contatos (em desenvolvimento).

## Front-end
Este projeto de API alimenta o Front [Clean Contacts Web](https://github.com/thmata/clean-contacts-web). Siga as instruções do repositório do Front para configurá-la e executá-la localmente.

