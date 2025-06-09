

# 📊 Visão Geral

API desenvolvida em ASP.NET Core com Entity Framework Core, utilizando autenticação JWT, Swagger, validações personalizadas e integração com SQL Server (SSMS).

💾 SQL Server (SSMS) com Entity Framework Core

🔐 Endpoints de Autenticação com JWT

✅ Validações com mensagens customizadas

📘 Swagger para testes

📦 CRUD completo com controller


✅ Validações
Usando Data Annotations

Mensagens de erro personalizadas

Middleware para retornar erros de modelo com padrão JSON


# 🔐 Autenticação com JWT
Modelo de Usuario com campos:

-Id, Nome, Email, Senha (com hash), Papel (admin ou user)

-Registro e login via endpoint

-Token JWT com papel embutido no claim

-Filtro de autorização: apenas admin pode deletar produtos, por exemplo


👨‍💼 Entidades do Modelo

1. Usuario

Campo

Tipo

Regras de Validação

IdUsuario

int

Chave primária

Nome

string

Obrigatório, mínimo 3 caracteres

Email

string

Obrigatório, formato de email válido

SenhaHash

string

Gerado via SHA256 (senha original não armazenada)

IdTipoUsuario

int

Obrigatório, FK para TipoUsuario

Relacionamentos:

Usuario pertence a TipoUsuario (N:1)




