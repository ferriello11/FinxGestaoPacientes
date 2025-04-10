# FinxGestaoPacientes

**FinxGestaoPacientes** é uma aplicação web desenvolvida com .NET 8, voltada para a gestão de pacientes em clínicas ou consultórios médicos. O sistema permite cadastrar, listar e gerenciar informações de pacientes de forma prática e eficiente.

## 🚀 Funcionalidades

- Cadastro de pacientes.
- Listagem de pacientes.
- Atualização e remoção de registros.
- Estrutura em camadas (Controller, Service, Repository, DTOs, Data).
- Integração com Entity Framework Core.

## 🛠️ Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server (ou outro banco compatível)

## 📁 Estrutura do Projeto

```
FinxGestaoPacientes/
├── Controllers/         # Endpoints da API
├── Data/                # Contexto e configuração do banco de dados
├── DTOs/                # Objetos de transferência de dados (Data Transfer Objects)
├── Entities/            # Modelos de domínio da aplicação
├── Extensions/          # Extensões e utilitários (ex: MappingExtensions para DTO <-> entidade)
├── Repositories/        # Implementações de repositórios e interfaces de acesso a dados
├── Services/            # Implementações dos serviços e suas interfaces
├── Program.cs           # Ponto de entrada e inicialização da aplicação
└── appsettings.json     # Configurações da aplicação (conexão, JWT, etc.)
```

## ⚙️ Configuração e Execução

### Pré-requisitos

- .NET 8 SDK instalado
- SQL Server rodando localmente ou na nuvem

### Passos

1. Clone o repositório:

   ```bash
   git clone https://github.com/ferriello11/FinxGestaoPacientes.git
   cd FinxGestaoPacientes
   ```

2. Configure sua `ConnectionString` no arquivo `appsettings.json`:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=FinxPacientesDb;Trusted_Connection=True;"
     }
   }
   ```

3. Execute os scripts de banco:

   ```
      CREATE TABLE Pacientes (
         PacienteId INT IDENTITY(1,1) PRIMARY KEY,
         Nome NVARCHAR(100) NOT NULL,
         DataNascimento DATETIME2 NOT NULL,
         CPF NVARCHAR(11) NOT NULL UNIQUE,
         Endereco NVARCHAR(200)
      );

      CREATE TABLE HistoricoMedicos (
         HistoricoMedicoId INT IDENTITY(1,1) PRIMARY KEY,
         PacienteId INT NOT NULL,
         DataConsulta DATETIME2 NOT NULL,
         Diagnostico NVARCHAR(500) NOT NULL,
         Tratamento NVARCHAR(500),
         CONSTRAINT FK_HistoricoMedicos_Pacientes FOREIGN KEY (PacienteId)
            REFERENCES Pacientes(PacienteId)
            ON DELETE CASCADE
      );

   ```

4. Rode o projeto:

   ```bash
   dotnet run
   ```
