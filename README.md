# Projeto

📦 Usando AutoMapper para mapear entre entidades e DTOs
Incluiremos:

DTO para criação e edição (ProdutoCreateDTO)

DTO para listagem e leitura (ProdutoDTO)

Proteção por role: apenas admin pode criar/editar/excluir



💾 SQL Server (SSMS) com Entity Framework Core

🔐 Autenticação JWT

✅ Validações com mensagens customizadas

📘 Swagger para testes

📦 CRUD completo com controller


✅ Validações
Usando Data Annotations

Mensagens de erro personalizadas

Middleware para retornar erros de modelo com padrão JSON


# 🔐 Autenticação com JWT
# Modelo de Usuario com campos:

-Id, Nome, Email, Senha (com hash), Papel (admin ou user)

-Registro e login via endpoint

-Token JWT com papel embutido no claim

-Filtro de autorização: apenas admin pode deletar produtos, por exemplo
