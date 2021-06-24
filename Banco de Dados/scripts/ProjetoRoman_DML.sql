USE ProjetoRoman;

INSERT INTO TiposUsuarios(NomeTipoUsuario)
VALUES					('Administrador'),
						('Professor')

GO

INSERT INTO Usuarios(idTipoUsuario,Email,Senha)
VALUES		(1,'adm@adm.com','adm123'),  
			(2,'caique@gmail.com','prof123'),
			(1,'saulo@gmail.com','prof123')
			
GO

INSERT INTO Professores(IdUsuario, NomeProfessor)
VALUES		(2,'Caique'),
			(1,'Saulo')

GO

INSERT INTO Temas(NomeTema)
VALUES      ('Gestão'),
			('Historia em quadrinhos')

GO

INSERT INTO Projeto(IdTema, NomeProjeto, Descricao)
VALUES				(1, 'Roman', 'Projeto baseado na roma'),
					(2, 'ProjetoMarvel', 'Projeto listar todos os herois da marvel')

GO

