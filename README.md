# 📒 CrudAgenda

Aplicação de linha de comando (CLI) desenvolvida em C# com .NET e Entity Framework Core para gerenciamento de contatos.  
O sistema implementa operações CRUD completas com persistência em banco de dados SQLite e uso de operações assíncronas.

---

## 📌 Objetivo

Projeto desenvolvido para praticar conceitos fundamentais de backend com .NET, incluindo:

- Manipulação de dados com Entity Framework Core
- Operações assíncronas (async/await)
- Persistência em banco relacional (SQLite)
- Estruturação de aplicação em camadas
- Validação de entrada de dados

---

## ⚙️ Tecnologias

- C# (.NET 10)
- Entity Framework Core
- SQLite
- CLI (Console Application)

---

## 🧠 Funcionalidades

- 📄 Listar contatos cadastrados  
- ➕ Adicionar novos contatos  
- ✏️ Atualizar dados de contatos  
- ❌ Remover contatos com confirmação  
- ✅ Validação de campos obrigatórios  
- ⚡ Operações assíncronas com acesso ao banco  

---

## 🚀 Como Executar

### 1. Pré-requisitos

- .NET SDK 10 ou superior

---

### 2. Clonar o repositório

```bash
git clone https://github.com/Devmoises79/CrudAgenda.git
cd CrudAgenda
```
3. Restaurar dependências
```bash
dotnet restore
```
4. Executar o projeto
```bash
dotnet run
```

# 📊 Fluxo da Aplicação

```bash
Menu Principal
│
├── Listar contatos
├── Adicionar contato
├── Atualizar contato
├── Remover contato
└── Sair
```

# 📁 Estrutura do Projeto

```bash
CrudAgenda/
│
├── Data/              # Contexto do banco (EF Core)
├── Models/            # Entidade Contato
├── Migrations/        # Migrations do banco
├── Program.cs         # Entrada da aplicação e lógica principal
└── agenda.db          # Banco SQLite
```

# 🧪 Modo de Teste

O projeto possui modos específicos para testes automatizados:

```bash
dotnet run -- --test-mode
dotnet run -- --db-test
```

# 🎯 Possíveis Evoluções
- Criar API REST com ASP.NET Core
- Implementar validações mais robustas 
- Adicionar logs estruturados
- Separar camadas (Service/Repository)
- Criar interface web (Blazor ou MVC)

# 👨‍💻 Autor

* Moises
