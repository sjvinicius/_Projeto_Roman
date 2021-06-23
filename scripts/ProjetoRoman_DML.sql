USE ProjetoRoman;

INSERT INTO TiposUsuarios(NomeTipoUsuario)
VALUES					('Comum'),
						('Professor')

GO

INSERT INTO Usuarios(IdTipoUsuario)
VALUES		('1'),
			('2'),
			('1'),
			('1'),

GO

INSERT INTO Professores(NomeProfessor)
VALUES		('Caique'),
			('Saulo')

GO

INSERT INTO Temas(NomeTemas)
VALUES      ('Gestão', 'Projeto de controle de estoque'),
			('Historia em quadrinhos', 'Projeto de Listagem de Personagens')

GO

