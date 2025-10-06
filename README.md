# 💼 WebApi-Employee - API REST em .NET 8

![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet)
![C#](https://img.shields.io/badge/C%23-Developer-blue)
![PostgreSQL](https://img.shields.io/badge/Database-PostgreSQL-blue)
![License: MIT](https://img.shields.io/badge/License-MIT-green)
![Status](https://img.shields.io/badge/Status-Em%20desenvolvimento-yellow)

## 📘 Sobre o projeto
O **WebApi-Employee** é uma **API RESTful** desenvolvida em **C# (.NET 8)** para o gerenciamento de funcionários em um sistema de **Recursos Humanos (RH)**.  
O sistema fornece um **CRUD completo**, autenticação segura com **JWT**, versionamento de endpoints e integração com **PostgreSQL**, oferecendo uma base sólida para aplicações empresariais.

---

## 🚀 Funcionalidades
- ✅ **CRUD completo** de funcionários  
- 🔐 **Autenticação e autorização JWT**  
- 🗂️ **Versionamento de API** (v1, v2, …)  
- 🧩 **Integração com PostgreSQL** via **Entity Framework Core**  
- 📄 **Documentação automática com Swagger**  
- ⚙️ Estrutura modular e pronta para escalar  

---

## 🧱 Tecnologias utilizadas
- **.NET 8**  
- **C#**  
- **Entity Framework Core**  
- **PostgreSQL**  
- **JWT Authentication**  
- **Swagger / OpenAPI**

---

## 🔧 Como executar o projeto

### 1️⃣ Clonar o repositório
git clone https://github.com/AdrianKeven/WebApi-Employee.git

### 2️⃣ Acessar a pasta do projeto
cd WebApi-Employee

### 3️⃣ Configurar o banco de dados
No arquivo appsettings.json, configure a string de conexão com seu banco PostgreSQL:

"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=WebApiEmployee;Username=postgres;Password=suasenha"
}

### 4️⃣ Executar as migrações
dotnet ef database update

### 5️⃣ Rodar o projeto
dotnet run

Acesse o Swagger da API:
https://localhost:5001/swagger

---

## 🧠 Conceitos aplicados
- Arquitetura RESTful  
- Autenticação e Autorização JWT (senha: admin, usuário admin)
- Versionamento de APIs  
- Mapeamento objeto-relacional com EF Core  
- Documentação interativa via Swagger  
- Boas práticas de camadas e separação de responsabilidades  

---

## 📚 Futuras melhorias
- 👥 Módulo de departamentos e cargos  
- 📊 Relatórios de desempenho e estatísticas  
- 📨 Envio de notificações automáticas  

---

## 👨‍💻 Autor
Adrian Keven Amaro Santo  
Desenvolvedor de Sistemas de Informação  

📧 adriankevenas@gmail.com  
🌐 https://github.com/AdrianKeven

---

### 🏷️ Licença
Este projeto está licenciado sob a MIT License — sinta-se à vontade para usar, modificar e contribuir.
