	--DML

USE projetoInicial3T
GO

--  Nome que o projeto dever� ter : senai_projInicial3T_02_DML.sql


INSERT INTO tiposUsuario (nome)
VALUES					 ('Administrador')
						,('Comum')
GO

INSERT INTO usuario (nome, email, senha, idTiposUsuario)
VALUES				('Administrador', 'adm@adm.com', 'ADM123', 1)
				   ,('Lucas', 'lucas@hotmail.com', 'LUCAS123', 2)
				   ,('Jo�o', 'joao@hotmail.com', 'JOAO123', 2)
GO

INSERT INTO salas (andar, nome, metragem, idUsuario)
VALUES			  (1, 'Sala1', 25, 2)
				 ,(2, 'Sala2', 40, 3)
GO

INSERT INTO equipamentos (marca, tipo, numeroSerie, descricao, numeroPatrimonio, disponivel)
VALUES					 ('Phillips','Eletroeletr�nica','123456', 'Jogo de chaves', '220456', 1 )
						,('Panasonic','Eletroeletr�nica','785466', 'C�mero Digital', '554023', 0 )
						,('HP', 'Inform�tica', '123879','Laptop', '443522', 0 )
						,('Sony', 'Inform�tica', '456457','Fone de ouvido', '456888', 0 )
GO

INSERT INTO salasEquipamentos (idSala, idEquipamento)
VALUES						  (1, 3),
							  (1,4),
							  (2,2)
GO