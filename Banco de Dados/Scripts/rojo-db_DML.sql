USE Rojo_App;
GO

--------------------------------- DML ---------------------------------

INSERT INTO tipoUsuario (PerfisDeUsuario)
VALUES		('Administrador'),('Usuario Comum'),('Administrador Empresa');
GO

INSERT INTO Empresa (CNPJ, Email, Senha, NomeFantasia, RazaoSocial, FundaçãoAniversario, Endereço, Telefone, TotalFuncionarios)
VALUES ('61585865000151', 'Drogasil@hotmail.com', '123456789','Drogasil', 'Raia Drogasil S.A', '1935/03/28', 'Av. Corifeu de Azevedo Marques, 3097 - Vila Butantã, São Paulo', '99999999999', 50000);
GO

INSERT INTO Usuario (IDTipoUsuario, IDEmpresa, Email,Senha,NomeUsu )
VALUES (2, 2, 'matheusmarthis@drogasil.com', '123456789', 'Matheus Martins');
GO

INSERT INTO Evento (IDEmpresa, IDUsuario, NomeEvento, Palestrante, DataEventoIncio, DataEventoFim)
VALUES (2, 2, 'Como se tornar um bom vendedor', 'Matheus Novais', '2022-03-21 13:30:00.000', '2022-03-21 17:00:00:000')
GO

INSERT INTO Comentario (IDEvento, CadastrarComentario)
VALUES (1, 'Foi Muito Bom Man, a drogasil sempre me ajuda')
GO

SELECT  * FROM tipoUsuario
SELECT  * FROM Empresa
SELECT  * FROM Usuario
SELECT  * FROM Evento
SELECT  * FROM Comentario
