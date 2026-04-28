# 📒 CrudAgenda

Aplicação de linha de comando (CLI) desenvolvida em **C# com .NET** e **Entity Framework Core** para gerenciamento de contatos.

O sistema implementa operações CRUD completas com persistência em banco de dados SQLite, utilizando **operações assíncronas** e boas práticas de organização de código.

---

## 📌 Objetivo

Projeto desenvolvido para consolidar fundamentos de desenvolvimento backend com .NET:

* Manipulação de dados com Entity Framework Core
* Operações assíncronas com `async/await`
* Persistência em banco relacional (SQLite)
* Estruturação de aplicação e separação de responsabilidades
* Validação de entrada de dados
* Integração com pipeline de CI/CD

---

## ⚙️ Tecnologias

* **C# (.NET 10)**
* **Entity Framework Core**
* **SQLite**
* **CLI (Console Application)**
* **GitHub Actions (CI/CD)**

---

## 🧠 Funcionalidades

* 📄 Listar contatos cadastrados
* ➕ Adicionar novos contatos
* ✏️ Atualizar dados de contatos
* ❌ Remover contatos com confirmação
* ✅ Validação de campos obrigatórios
* ⚡ Operações assíncronas com acesso ao banco

---

## 🔄 CI/CD com GitHub Actions

O projeto possui um pipeline de **Integração Contínua (CI)** que valida automaticamente o build e a execução da aplicação.

### ⚙️ Quando o pipeline roda

* Push nas branches: `main`, `master`, `develop`
* Pull Requests para `main` e `master`

### ✔ Etapas automatizadas

* 📥 Checkout do código
* ⚙️ Setup do ambiente .NET (SDK 10)
* 📦 Cache de dependências NuGet
* 🔧 Restauração de pacotes (`dotnet restore`)
* 🏗️ Build da aplicação (`dotnet build`)
* ▶️ Execução da aplicação em modo de teste (`--test-mode`)
* 🗄️ Validação de integração com banco SQLite (`--db-test`)
* 📤 Upload de artefatos de build

### 📁 Workflow

```
.github/workflows/ci.yml
```

### 💡 Destaques técnicos

* Uso de cache para otimização de build
* Validação da execução real da aplicação
* Teste automatizado de integração com banco de dados
* Estrutura pronta para evolução com testes automatizados

---

## 🚀 Como Executar

### 1. Pré-requisitos

* .NET SDK 10 ou superior

### 2. Clonar o repositório

```bash
git clone https://github.com/Devmoises79/CrudAgenda.git
cd CrudAgenda
```

### 3. Restaurar dependências

```bash
dotnet restore
```

### 4. Executar o projeto

```bash
dotnet run
```

---

## 📊 Fluxo da Aplicação

```
Menu Principal
│
├── Listar contatos
├── Adicionar contato
├── Atualizar contato
├── Remover contato
└── Sair
```

---

## 📁 Estrutura do Projeto

```
CrudAgenda/
│
├── Data/              # Contexto do banco (EF Core)
├── Models/            # Entidade Contato
├── Migrations/        # Migrations do banco
├── .github/workflows/ # Pipeline CI/CD
├── Program.cs         # Entrada da aplicação e lógica principal
└── agenda.db          # Banco SQLite
```

---

## 🧪 Modo de Teste

O projeto possui modos específicos para validação automatizada:

```bash
dotnet run -- --test-mode
dotnet run -- --db-test
```

---

## 🎯 Possíveis Evoluções

* Criar API REST com ASP.NET Core
* Implementar arquitetura em camadas (Service/Repository)
* Adicionar logs estruturados
* Implementar testes automatizados (xUnit)
* Criar interface web (Blazor ou MVC)

---

## 👨‍💻 Autor

**Moisés Aniceto**

Backend Developer focado em aprender, criar e desenvolver sistemas escaláveis, seguros e performáticos.

🔗 LinkedIn: https://www.linkedin.com/in/moisés-aniceto-71042a251
