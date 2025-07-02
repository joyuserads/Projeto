

# 📊 Visão Geral

API desenvolvida em ASP.NET 9 Core com Entity Framework Core, utilizando autenticação JWT, Swagger, validações personalizadas e integração com SQL Server (SSMS).

💾 SQL Server (SSMS) com Entity Framework Core

🔐 Endpoints de Autenticação com JWT

✅ Validações com mensagens customizadas

📘 Scalar para testes

📦 CRUD completo com controller

-------------------------------------------------------------------------------------------------------------------------------------------------------------
🎨 Ferramentas Utilizadas no Front-end

React.js — construção da interface

Vite — empacotador leve e rápido para projetos React

Tailwind CSS — estilização responsiva e utilitária

Axios — requisições HTTP com suporte a interceptadores

React Router DOM — rotas públicas e protegidas

JWT Storage — autenticação com armazenamento seguro de tokens

Context API / Hooks — controle de estado global



# ✅ Validações e Boas Práticas

Anotações de validação como [Required], [StringLength], [Range]

Hash de senha com SHA256 (sem armazenar a senha original)


# 🔐 Autenticação e Acesso

JWT com roles (admin, user)

[Authorize(Roles = "admin")] em endpoints protegid

 # Diagrama de Relacionamentos

Usuario (N) ------ (1) TipoUsuario

SalaEquipamento (N) ------ (1) Sala
SalaEquipamento (N) ------ (1) Equipamento


## ✨ Documentação da API - Controle de Salas e Equipamentos


## 👨‍💼 Entidades do Modelo

### 1. **Usuario**

| Campo         | Tipo   | Regras de Validação                  |
| ------------- | ------ | ------------------------------------ |
| IdUsuario     | int    | Chave primária                       |
| Nome          | string | Obrigatório, mínimo 3 caracteres     |
| Email         | string | Obrigatório, formato de email válido |
| SenhaHash     | string | Gerado via SHA256                    |
| IdTipoUsuario | int    | Obrigatório, FK para `TipoUsuario`   |

**Relacionamento:** Usuario → TipoUsuario (N:1)

### 2. **TipoUsuario**

| Campo         | Tipo   | Regras de Validação                   |
| ------------- | ------ | ------------------------------------- |
| IdTipoUsuario | int    | Chave primária                        |
| NomeTipo      | string | Obrigatório. Exemplo: `admin`, `user` |

### 3. **Equipamento**

| Campo            | Tipo   | Regras de Validação                   |
| ---------------- | ------ | ------------------------------------- |
| IdEquipamento    | int    | Chave primária                        |
| Nome             | string | Obrigatório, até 100 caracteres       |
| Descricao        | string | Opcional, até 255 caracteres          |
| NumeroPatrimonio | string | Obrigatório, único, até 50 caracteres |

### 4. **Sala**

| Campo       | Tipo   | Regras de Validação             |
| ----------- | ------ | ------------------------------- |
| IdSala      | int    | Chave primária                  |
| NomeSala    | string | Obrigatório, até 100 caracteres |
| Localizacao | string | Obrigatório, até 255 caracteres |

### 5. **SalaEquipamento**

| Campo             | Tipo     | Regras de Validação                                    |
| ----------------- | -------- | ------------------------------------------------------ |
| IdSalaEquipamento | int      | Chave primária                                         |
| IdSala            | int      | Obrigatório, FK para `Sala`                            |
| IdEquipamento     | int      | Obrigatório, FK para `Equipamento`                     |
| DataAlocacao      | DateTime | Obrigatório, deve ser uma data igual ou maior que hoje |

**Relacionamentos:**

* SalaEquipamento → Sala (N:1)
* SalaEquipamento → Equipamento (N:1)







