# 🛒 Projeto Carrinho de Compras

API REST para gerenciamento de um **Carrinho de Compras**, desenvolvida com **ASP.NET Core**, **Entity Framework Core** e **PostgreSQL**.

O projeto está sendo desenvolvido de forma incremental, utilizando uma arquitetura organizada em camadas, com o objetivo de aplicar conceitos utilizados no desenvolvimento de APIs .NET.
 
---

## 📋 Sumário

* [Sobre o projeto](#-sobre-o-projeto)
* [Tecnologias utilizadas](#-tecnologias-utilizadas)
* [Arquitetura](#-arquitetura)
* [Pré-requisitos](#-pré-requisitos)
* [Clonar o projeto](#-clonar-o-projeto)
* [Configuração do PostgreSQL](#-configuração-do-postgresql)
* [Configuração da Connection String](#-configuração-da-connection-string)
* [Instalação dos pacotes](#-instalação-dos-pacotes)
* [Configuração do DbContext](#-configuração-do-dbcontext)
* [Configuração do Dependency Injection](#-configuração-do-dependency-injection)
* [Entity Framework Core e Migrations](#-entity-framework-core-e-migrations)
* [Seed de dados](#-seed-de-dados)
* [Executando o projeto](#-executando-o-projeto)
* [Testando a API](#-testando-a-api)
* [Endpoints](#-endpoints)
* [Padrão Repository](#-padrão-repository)
* [Padrão Unit of Work](#-padrão-unit-of-work)
* [Service](#-service)
* [Mapper](#-mapper)
* [Fluxo da aplicação](#-fluxo-da-aplicação)
* [Git](#-git)
* [Próximas evoluções](#-próximas-evoluções)

---

# 📌 Sobre o projeto

O **Projeto Carrinho de Compras** tem como objetivo desenvolver uma API para gerenciamento de produtos e carrinhos de compras.

O projeto será evoluído gradualmente, adicionando funcionalidades conforme o desenvolvimento avança.

Entre as funcionalidades previstas estão:

* Cadastro de produtos
* Consulta de produtos
* Alteração de produtos
* Exclusão de produtos
* Cadastro de carrinho
* Inclusão de produtos no carrinho
* Alteração da quantidade de produtos
* Remoção de produtos do carrinho
* Consulta do carrinho
* Cálculo do valor total
* Integração com banco PostgreSQL
* API REST
* Persistência utilizando Entity Framework Core

---

# 🚀 Tecnologias utilizadas

## Backend

* C#
* .NET
* ASP.NET Core Web API
* Entity Framework Core
* PostgreSQL
* Npgsql
* AutoMapper
* Repository Pattern
* Unit of Work Pattern
* Dependency Injection
* REST API

## Ferramentas

* Visual Studio 2022 ou Visual Studio Code
* PostgreSQL
* pgAdmin
* Git
* GitHub
* Postman ou Swagger

---

# 🏗️ Arquitetura

O projeto utiliza uma arquitetura baseada em separação de responsabilidades.

```text
                    ┌──────────────────┐
                    │    Controller    │
                    └────────┬─────────┘
                             │
                             ▼
                    ┌──────────────────┐
                    │     Service      │
                    └────────┬─────────┘
                             │
                             ▼
                    ┌──────────────────┐
                    │   Unit Of Work   │
                    └────────┬─────────┘
                             │
                 ┌───────────┴───────────┐
                 ▼                       ▼
        ┌─────────────────┐     ┌─────────────────┐
        │    Repository   │     │    Repository   │
        │    Product      │     │    Carrinho     │
        └────────┬────────┘     └────────┬────────┘
                 │                       │
                 └───────────┬───────────┘
                             ▼
                    ┌──────────────────┐
                    │    DbContext     │
                    └────────┬─────────┘
                             │
                             ▼
                    ┌──────────────────┐
                    │    PostgreSQL    │
                    └──────────────────┘
```

---

# 📁 Estrutura do projeto

A estrutura pode ser organizada da seguinte maneira:

```text
Carrinho.Compra
│
├── Carrinho.Compra.API
│   │
│   ├── Controllers
│   │   ├── CarrinhoController.cs
│   │   └── ProdutoController.cs
│   │
│   ├── Program.cs
│   ├── appsettings.json
│   └── appsettings.Development.json
│
├── Carrinho.Compra.Domain
│   │
│   ├── Entities
│   │   ├── CarrinhoEntity.cs
│   │   ├── ItemCestaEntity.cs
│   │   └── ProdutoEntity.cs
│   │
│   ├── DTOs
│   │
│   └── Interface
│       │
│       ├── Repository
│       │   ├── IRepository.cs
│       │   ├── ICarrinhoRepository.cs
│       │   └── IItemCestaRepository.cs
│       │
│       └── IUnitOfWork.cs
│
├── Carrinho.Compra.Repository
│   │
│   ├── Context
│   │   └── AppDbContext.cs
│   │
│   ├── Repository.cs
│   ├── CarrinhoRepository.cs
│   ├── ItemCestaRepository.cs
│   └── UnitOfWork.cs
│
└── README.md
```

---

# 💻 Pré-requisitos

Antes de iniciar o projeto, é necessário instalar:

### .NET SDK

Verifique a instalação:

```bash
dotnet --version
```

Exemplo:

```text
8.0.xxx
```

ou a versão utilizada pelo projeto.

---

### PostgreSQL

Verifique se o PostgreSQL está instalado e em execução.

Abra o Package Manager Console -> Selecione a Camada Carrinho.Compra.Repositoy
Utilize o update-database

Os dados serão preechidos automaticamente pelas Migrations do projeto
O projeto utiliza:

```text
Host: localhost
Porta: 5432
Usuário: root
```

---

### Git

Verifique:

```bash
git --version
```

---

# 📥 Clonar o projeto

Clone o repositório:

```bash
git clone URL_DO_REPOSITORIO
```

Entre na pasta:

```bash
cd Carrinho.Compra
```

Caso o projeto possua uma Solution:

```bash
dotnet restore
```

---


