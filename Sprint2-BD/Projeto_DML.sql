-- Tipos de usuário
INSERT INTO TipoUsuario (NomeTipo) VALUES ('Administrador'), ('Técnico'), ('Usuário Comum');

-- Usuários
INSERT INTO Usuario (Nome, Email, SenhaHash, IdTipoUsuario)
VALUES 
('João Silva', 'joao@email.com', 'hashsenha1', 1),
('Maria Souza', 'maria@email.com', 'hashsenha2', 2);

-- Equipamentos
INSERT INTO Equipamento (Nome, Descricao, NumeroPatrimonio)
VALUES 
('Projetor', 'Projetor Epson 3000 lumens', 'PAT-001'),
('Notebook', 'Dell Latitude 5490', 'PAT-002');

-- Salas
INSERT INTO Sala (NomeSala, Localizacao)
VALUES 
('Sala de Reunião 1', 'Bloco A - 1º andar'),
('Auditório', 'Bloco C - Térreo');

-- Relacionando equipamentos com salas
INSERT INTO SalaEquipamento (IdSala, IdEquipamento)
VALUES 
(1, 1),
(1, 2),
(2, 1);