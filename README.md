# Projeto

# API 
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


# ✅ Funcionalidades para Produto

| Ação    | Endpoint                    | Acesso                  |
| ------- | --------------------------- | ----------------------- |
| Listar  | `GET /api/produtos`         | Público ✅ com paginação |
| Buscar  | `GET /api/produtos/{id}`    | Público ✅               |
| Criar   | `POST /api/produtos`        | Somente `admin` 🔒      |
| Editar  | `PUT /api/produtos/{id}`    | Somente `admin` 🔒      |
| Excluir | `DELETE /api/produtos/{id}` | Somente `admin` 🔒      |

