-- Listar todos os usuários com seus tipos
SELECT u.IdUsuario, u.Nome, u.Email, t.NomeTipo
FROM Usuario u
JOIN TipoUsuario t ON u.IdTipoUsuario = t.IdTipoUsuario;

-- Listar salas com seus equipamentos
SELECT s.NomeSala, e.Nome AS NomeEquipamento, se.DataAlocacao
FROM SalaEquipamento se
JOIN Sala s ON se.IdSala = s.IdSala
JOIN Equipamento e ON se.IdEquipamento = e.IdEquipamento;

-- Verificar se um equipamento está alocado a mais de uma sala
SELECT e.Nome, COUNT(*) AS QtdeSalas
FROM SalaEquipamento se
JOIN Equipamento e ON se.IdEquipamento = e.IdEquipamento
GROUP BY e.Nome
HAVING COUNT(*) > 1;