**🇺🇸 Version: English**
<div align="center">

# 📦 Product Management API
**Nível: Junior Backend Developer Portfolio**

[![.NET 10](https://img.shields.io/badge/.NET-10.0-512bd4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)
[![SQLite](https://img.shields.io/badge/SQLite-07405E?style=for-the-badge&logo=sqlite&logoColor=white)](https://www.sqlite.org/)
[![JWT](https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=JSON%20web%20tokens)](https://jwt.io/)
[![Swagger](https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white)](https://swagger.io/)

<p align="center">
  <a href="#-about">About</a> •
  <a href="#-tech-stack">Tech Stack</a> •
  <a href="#-features">Features</a> •
  <a href="#-how-to-run">How to Run</a> •
  <a href="#-português">Português</a>
</p>

---

</div>

## 📑 About

This is a robust REST API for product inventory management. Developed with **.NET 8**, it focuses on clean code principles, using a structured **Service Layer** to separate business logic from the infrastructure.

> **Key Learning:** Implementation of JWT Bearer authentication and SQLite persistence using Entity Framework Core.

---

## 🛠 Tech Stack

* **Framework:** .NET 10 (Web API)
* **ORM:** Entity Framework Core
* **Database:** SQLite
* **Security:** JSON Web Token (JWT)
* **Documentation:** Swagger / OpenAPI

---

## 🚀 Features

- [x] **Full CRUD**: Create, Read, Update, and Delete products.
- [x] **JWT Auth**: Secure routes with token-based authentication.
- [x] **Validation Layer**: Custom business rules (e.g., inventory limits).
- [x] **Auto-Migrations**: SQLite database setup via EF Core.

---

## ⚙️ How to Run

### Prerequisites
* [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

### Installation
```bash
# 1. Clone the repository
git clone [https://github.com/seu-usuario/cadastro-produtos-api.git](https://github.com/seu-usuario/cadastro-produtos-api.git)

# 2. Go to project folder
cd cadastro-produtos-api

# 3. Update Database
dotnet ef database update

# 4. Run the project
dotnet run
```
**🇧🇷 Versão: Português**

<div align="center">

# 📦 API de Gerenciamento de Produtos
**Portfólio: Desenvolvedor Backend Júnior**

[![.NET 10](https://img.shields.io/badge/.NET-10.0-512bd4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)
[![SQLite](https://img.shields.io/badge/SQLite-07405E?style=for-the-badge&logo=sqlite&logoColor=white)](https://www.sqlite.org/)
[![JWT](https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=JSON%20web%20tokens)](https://jwt.io/)
[![Swagger](https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white)](https://swagger.io/)

<p align="center">
  <a href="#-sobre-o-projeto">Sobre</a> •
  <a href="#-tecnologias">Tecnologias</a> •
  <a href="#-funcionalidades">Funcionalidades</a> •
  <a href="#-como-executar">Como Executar</a>
</p>

---

</div>

## 📑 Sobre o Projeto

Esta é uma API REST robusta para o gerenciamento de inventário de produtos. Desenvolvida com **.NET 10**, o foco principal foi aplicar princípios de código limpo (*Clean Code*) e uma estrutura de camadas que separa a lógica de negócio da infraestrutura.

> **Destaque técnico:** Implementação de autenticação JWT Bearer e persistência de dados com SQLite utilizando Entity Framework Core.

---

## 🛠 Tecnologias

* **Framework:** .NET 10 (Web API)
* **ORM:** Entity Framework Core
* **Banco de Dados:** SQLite
* **Segurança:** JSON Web Token (JWT)
* **Documentação:** Swagger / OpenAPI

---

## 🚀 Funcionalidades

- [x] **CRUD Completo**: Criar, Ler, Atualizar e Deletar produtos.
- [x] **Autenticação JWT**: Rotas protegidas que exigem token de acesso.
- [x] **Camada de Validação**: Regras de negócio customizadas (ex: limites de estoque).
- [x] **Injeção de Dependência**: Uso de `Scoped Services` para desacoplamento.
- [x] **Auto-Migrations**: Configuração automática do banco SQLite via EF Core.

---

## ⚙️ Como Executar

### Pré-requisitos
* [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

### Instalação e Execução
```bash
# 1. Clone o repositório
git clone [https://github.com/seu-usuario/nome-do-repositorio.git](https://github.com/seu-usuario/nome-do-repositorio.git)

# 2. Acesse a pasta do projeto
cd nome-do-repositorio

# 3. Atualize o Banco de Dados (Migrations)
dotnet ef database update

# 4. Execute a aplicação
dotnet run
