USE INVTIC

GO

SELECT * FROM NOTAFISCAL
ORDER BY NUMNF

CREATE TABLE NOTAFISCAL
(
	ID				INT IDENTITY,
	NUMNF			VARCHAR(20),
	FORNECEDOR		VARCHAR(200),
	DATA			SMALLDATETIME,
	EMPRESA			VARCHAR(200),
	LINK			VARCHAR(MAX)

	PRIMARY KEY (ID)
)

GO

CREATE TABLE SOFTWARE
(
	ID				INT IDENTITY,
	NOME			VARCHAR(200)

	PRIMARY KEY (ID)
)

ALTER TABLE SOFTWARE
ADD FABRICANTE		VARCHAR(200),
	VERSAO			VARCHAR(10)

ALTER TABLE SOFTWARE
ADD NOMETECNICO		VARCHAR(500)


CREATE TABLE LICENCAS
(
	ID						INT IDENTITY,
	NOTAFISCALID			INT,
	SOFTWAREID				INT,
	QUANTIDADE				DECIMAL(18,2),
	CHAVE					VARCHAR(200)

	PRIMARY KEY (ID),
	FOREIGN KEY (NOTAFISCALID) REFERENCES NOTAFISCAL (ID),
	FOREIGN KEY (SOFTWAREID) REFERENCES SOFTWARE (ID)
	--, CONSTRAINT UNLICENCAS UNIQUE (NOTAFISCALID, SOFTWAREID, CHAVE)
)

ALTER TABLE LICENCAS
ADD STATUS VARCHAR(1)


CREATE TABLE COMPUTADORES
(
	ID						INT IDENTITY,
	ATIVOANTIGO				VARCHAR(100),
	ATIVONOVO				VARCHAR(100),
	USUARIO					VARCHAR(200),
	DEPARTAMENTO			VARCHAR(100),
	STATUS					CHAR(2)

	PRIMARY KEY (ID)
)

ALTER TABLE COMPUTADORES
ADD OBSERVACOES VARCHAR(MAX)


CREATE TABLE COMPUTADORESLICENCAS
(
	COMPUTADORESID			INT,
	LICENCAID				INT

	PRIMARY KEY (COMPUTADORESID, LICENCAID),
	FOREIGN KEY (COMPUTADORESID) REFERENCES COMPUTADORES (ID),
	FOREIGN KEY (LICENCAID) REFERENCES LICENCAS (ID),
	CONSTRAINT UNCOMPUTADORESLICENCA UNIQUE (LICENCAID)
)

ALTER TABLE COMPUTADORESLICENCAS
ADD CONSTRAINT UNCOMPUTADORESID UNIQUE (COMPUTADORESID, LICENCAID)


CREATE VIEW OCS
AS
SELECT * FROM OPENQUERY(MYSQLNEWOCS,'select id, name, ipaddr, osname, userid, winprodid, winprodkey, workgroup, processort, memory, lastdate, lastcome
									From hardware
									order by id') 


CREATE TABLE STATUS
(
	ID				INT IDENTITY,
	CODIGO			VARCHAR(10),
	NOME			VARCHAR(200)

	PRIMARY KEY (ID)
)


/*
INSERT STATUS VALUES ('EU', 'Em Uso')
INSERT STATUS VALUES ('VA', 'Vago')
INSERT STATUS VALUES ('EE', 'Em Estoque')
*/

SELECT * fROM STATUS

ALTER PROCEDURE GETCOMPUTADORES
AS
SELECT C.ID, C.ATIVOANTIGO, C.ATIVONOVO, C.USUARIO, C.DEPARTAMENTO,
CASE WHEN C.STATUS = 'EE' THEN
	'Em Estoque'
ELSE CASE WHEN c.STATUS = 'VA' THEN
	'Vago'
ELSE CASE WHEN c.STATUS = 'EU' THEN
	'Em Uso'
END END END AS STATUS, C.STATUS AS STATUS1,
CASE WHEN OCS.ID IS NOT NULL THEN
	'Sim'
ELSE
	'N�o'
END AS TEMLIGACAOCOMOCS, C.OBSERVACOES,
C.OCSID, 
OCS.ID, OCS.name, OCS.IPADDR, OCS.OSNAME, OCS.USERID, OCS.WINPRODID, OCS.WINPRODKEY, OCS.WORKGROUP, OCS.PROCESSORT, OCS.MEMORY, OCS.LASTDATE, OCS.LASTCOME, 
		OCS.id AS DISCOID, OCS.HARDWARE_ID, OCS.LETTER, OCS.TYPE, OCS.FILESYSTEM, OCS.TOTAL, OCS.FREE, OCS.VOLUMN
FROM COMPUTADORES C
LEFT OUTER JOIN 
(		SELECT * FROM OPENQUERY(MYSQLNEWOCS,'
		SELECT h.ID, h.name, h.IPADDR, h.OSNAME, h.USERID, h.WINPRODID, h.WINPRODKEY, h.WORKGROUP, h.PROCESSORT, h.MEMORY, h.LASTDATE, h.LASTCOME, 
		d.id AS DISCOID, d.HARDWARE_ID, d.LETTER, d.TYPE, d.FILESYSTEM, d.TOTAL, d.FREE, d.VOLUMN
		FROM hardware h
		LEFT JOIN drives d on h.id = d.hardware_id
		WHERE h.DEVICEID not like ''%android%''')
) OCS ON OCS.ID = C.OCSID
ORDER BY C.ATIVONOVO



CREATE PROCEDURE GETCOMPUTADORSTATUS
AS
	SELECT 'EU' AS CODSTATUS, 'Em Uso' AS STATUS
	UNION ALL
	SELECT 'EE' AS CODSTATUS, 'Em Estoque' AS STATUS
	UNION ALL
	SELECT 'VA' AS CODSTATUS, 'Vago' AS STATUS


ALTER PROCEDURE POSTCOMPUTADORES
	-- @ID						int,
	@ATIVOANTIGO			varchar(100),
	@ATIVONOVO				varchar(100),
	@USUARIO				varchar(200),
	@DEPARTAMENTO			varchar(100),
	@STATUS					char(2),
	@OBSERVACOES			VARCHAR(MAX) = NULL
	--,@OCSID					int
AS
	INSERT INTO COMPUTADORES 
	(ATIVOANTIGO, ATIVONOVO, USUARIO, DEPARTAMENTO, STATUS, OBSERVACOES) VALUES 
	(@ATIVOANTIGO, @ATIVONOVO, @USUARIO, @DEPARTAMENTO, @STATUS, @OBSERVACOES)

	SELECT scope_identity()

ALTER PROCEDURE PUTCOMPUTADORES
	@ID						int,
	@ATIVOANTIGO			varchar(100),
	@ATIVONOVO				varchar(100),
	@USUARIO				varchar(200),
	@DEPARTAMENTO			varchar(100),
	@STATUS					char(2),
	@OBSERVACOES			VARCHAR(MAX)
AS
	UPDATE COMPUTADORES SET
	ATIVOANTIGO = @ATIVOANTIGO, 
	ATIVONOVO = @ATIVONOVO, 
	USUARIO = @USUARIO, 
	DEPARTAMENTO = @DEPARTAMENTO, 
	STATUS = @STATUS,
	OBSERVACOES = @OBSERVACOES
	WHERE ID = @ID


CREATE PROCEDURE DELETECOMPUTADORES
	@ID					INT
AS
	DELETE COMPUTADORES
	WHERE ID = @ID

CREATE PROCEDURE GETCOMPUTADORESOCS
AS
	SELECT * FROM OCS

CREATE PROCEDURE PUTASSOCIARAOOCS
	@COMPUTADORID			INT,
	@COMPUTADOROCSID		INT
AS
	UPDATE COMPUTADORES
	SET OCSID = @COMPUTADOROCSID
	WHERE ID = @COMPUTADORID


CREATE PROCEDURE GETNOTASFISCAIS
AS
	SELECT * FROM NOTAFISCAL	

ALTER PROCEDURE POSTNOTAFISCAL
	-- @ID	int,
	@NUMNF	varchar(20),
	@FORNECEDOR	varchar(200),
	@DATA	smalldatetime,
	@EMPRESA	varchar(200),
	@LINK	varchar(max)	
AS
	INSERT INTO NOTAFISCAL (NUMNF, FORNECEDOR, DATA, EMPRESA, LINK) VALUES (@NUMNF, @FORNECEDOR, @DATA, @EMPRESA, @LINK)

	SELECT SCOPE_IDENTITY()

CREATE PROCEDURE PUTNOTAFISCAL
	@NUMNF	varchar(20),
	@FORNECEDOR	varchar(200),
	@DATA	smalldatetime,
	@EMPRESA	varchar(200),
	@LINK	varchar(max),
	@ID	int
AS
	UPDATE NOTAFISCAL SET
	NUMNF = @NUMNF,
	FORNECEDOR = @FORNECEDOR,
	DATA = @DATA,
	EMPRESA = @EMPRESA,
	LINK = @LINK
	WHERE ID = @ID


CREATE PROCEDURE DELETENOTAFISCAL
	@ID			INT
AS
	DELETE NOTAFISCAL
	WHERE ID = @ID



ALTER PROCEDURE POSTSOFTWARE
	@NOME			VARCHAR(200),
	@FABRICANTE		VARCHAR(200),
	@VERSAO			VARCHAR(10),
	@NOMETECNICO	VARCHAR(500) = NULL
AS
	INSERT SOFTWARE (NOME, FABRICANTE, VERSAO, NOMETECNICO) VALUES (@NOME, @FABRICANTE, @VERSAO, @NOMETECNICO)
	SELECT SCOPE_IDENTITY()

ALTER PROCEDURE PUTSOFTWARE
	@NOME			VARCHAR(200),
	@FABRICANTE		VARCHAR(200),
	@VERSAO			VARCHAR(10),	
	@NOMETECNICO		VARCHAR(500),
	@ID				INT
AS
	UPDATE SOFTWARE 
	SET NOME = @NOME,
	FABRICANTE = @FABRICANTE,
	VERSAO = @VERSAO,
	NOMETECNICO = @NOMETECNICO
	WHERE ID = @ID

CREATE PROCEDURE DELETESOFTWARE
	@ID			INT
AS
	DELETE SOFTWARE
	WHERE ID = @ID

CREATE PROCEDURE GETSOFTWARES
AS
	SELECT * FROM SOFTWARE



CREATE PROCEDURE POSTLICENCAS
	--@ID	int,
	@NOTAFISCALID	int,
	@SOFTWAREID	int,
	@QUANTIDADE	decimal,
	@CHAVE	varchar(200),
	@STATUS	varchar(1)
AS
	INSERT INTO LICENCAS (NOTAFISCALID, SOFTWAREID, QUANTIDADE, CHAVE, STATUS) VALUES (@NOTAFISCALID, @SOFTWAREID, @QUANTIDADE, @CHAVE, @STATUS)
	SELECT SCOPE_IDENTITY()

CREATE PROCEDURE PUTLICENCAS
	@NOTAFISCALID	int,
	@SOFTWAREID	int,
	@QUANTIDADE	decimal,
	@CHAVE	varchar(200),
	@STATUS	varchar(1),
	@ID	int
AS
	UPDATE LICENCAS SET
	NOTAFISCALID = @NOTAFISCALID, 
	SOFTWAREID = @SOFTWAREID,
	QUANTIDADE = @QUANTIDADE,
	CHAVE = @CHAVE,
	STATUS = @STATUS
	WHERE ID = @ID

CREATE PROCEDURE DELETELICENCAS
	@ID		INT
AS
	DELETE LICENCAS
	WHERE ID = @ID

CREATE PROCEDURE GETLICENCAS
AS
SELECT *
FROM LICENCAS L
LEFT JOIN  NOTAFISCAL NF ON L.NOTAFISCALID = NF.ID
LEFT JOIN SOFTWARE S ON S.ID = L.SOFTWAREID


CREATE PROCEDURE POSTCOMPUTADORESLICENCAS
	@COMPUTADORESID		INT,
	@LICENCAID			INT
AS
	INSERT COMPUTADORESLICENCAS VALUES (@COMPUTADORESID, @LICENCAID)
	
CREATE PROCEDURE DELETECOMPUTADORESLICENCAS
	@COMPUTADORESID		INT,
	@LICENCAID			INT
AS
	DELETE COMPUTADORESLICENCAS
	WHERE COMPUTADORESID = @COMPUTADORESID AND
	LICENCAID = @LICENCAID


ALTER PROCEDURE GETCOMPUTADORESLICENCAS
AS
SELECT CL.COMPUTADORESID, CL.LICENCAID,
C.ID, ATIVOANTIGO, ATIVONOVO, USUARIO, DEPARTAMENTO, C.STATUS, OCSID, 
L.ID, L.NOTAFISCALID, L.SOFTWAREID, L.QUANTIDADE, L.CHAVE, L.STATUS, 
NF.ID, NF.NUMNF, NF.FORNECEDOR, NF.DATA, NF.EMPRESA, NF.LINK,
S.ID, S.NOME, S.FABRICANTE, S.VERSAO
FROM COMPUTADORES C
INNER JOIN COMPUTADORESLICENCAS CL ON C.ID = CL.COMPUTADORESID
INNER JOIN LICENCAS L ON L.ID = CL.LICENCAID
INNER JOIN NOTAFISCAL NF ON NF.ID = L.NOTAFISCALID
INNER JOIN SOFTWARE S ON S.ID = L.SOFTWAREID
order by c.ID


GETLICENCAS
go
GETCOMPUTADORESLICENCAS

SELECT * FROM COMPUTADORES

ALTER PROCEDURE GETCONFRONTOLICENCASCOMPUTADORES
AS
/*CONTINUAR BATENDO AS LICEN�AS DE WINDOWS E OFFICE COLETADAS DA PLANILHA DO MICHEL COM O OCS*/
--DROP TABLE #TMPLICENCAS

SELECT C.ID, C.ATIVOANTIGO, C.ATIVONOVO, C.USUARIO, C.DEPARTAMENTO, C.STATUS, C.OCSID, WINDOWS.NOME AS WINDOWS, OFFICE.NOME AS OFFICE
INTO #TMPLICENCAS
FROM COMPUTADORES C
LEFT OUTER JOIN
(
	SELECT S.NOMETECNICO AS NOME, CL.COMPUTADORESID
	FROM COMPUTADORESLICENCAS CL 
	INNER JOIN LICENCAS L ON L.ID = CL.LICENCAID
	INNER JOIN SOFTWARE S ON S.ID = L.SOFTWAREID
	WHERE S.NOME LIKE '%WINDOWS%'
) AS WINDOWS ON WINDOWS.COMPUTADORESID = C.ID
LEFT OUTER JOIN
(
	SELECT S.NOMETECNICO AS NOME, CL.COMPUTADORESID
	FROM COMPUTADORESLICENCAS CL 
	INNER JOIN LICENCAS L ON L.ID = CL.LICENCAID
	INNER JOIN SOFTWARE S ON S.ID = L.SOFTWAREID
	WHERE S.NOME LIKE '%OFFICE%'
) AS OFFICE ON OFFICE.COMPUTADORESID = C.ID
--WHERE C.ID = 6


-- DROP TABLE #TMPOCS
SELECT * 
INTO #TMPOCS
FROM OPENQUERY(MYSQLNEWOCS,'SELECT h.ID, h.NAME, h.USERID, h.USERDOMAIN, h.WINPRODID, h.OSNAME AS WINDOWS, OFFICE.OFFICE
FROM hardware h
LEFT OUTER JOIN
(
	SELECT DISTINCT h.ID, s.name as OFFICE
	FROM hardware h
	INNER JOIN softwares s ON h.ID = s.HARDWARE_ID
	WHERE (s.name LIKE ''microsoft%office%home%'' OR 
	s.name LIKE ''microsoft%office%prof%'')
) AS OFFICE ON OFFICE.ID = h.ID')
									 
SELECT CASE WHEN A.WINDOWS = B.WINDOWS THEN --CASE WHEN LTRIM(RTRIM(SUBSTRING(A.WINDOWS, 0, LEN(A.WINDOWS) -3))) = LTRIM(RTRIM(B.WINDOWS)) THEN
	'LICEN�A WINDOWS OK COM O OCS'
ELSE CASE WHEN A.WINDOWS IS NULL THEN
	'N�O EXISTE NF DO WINDOWS'
ELSE
	'LICEN�A COM PROBLEMA'
END END AS STATUSLICENCAWINDOWS,
CASE WHEN A.OFFICE = B.OFFICE THEN --CASE WHEN SUBSTRING(A.OFFICE, 0, LEN(A.OFFICE) -3) = B.OFFICE THEN
	'LICEN�A OFFICE OK COM O OCS'
ELSE CASE WHEN A.OFFICE IS NULL THEN
	'N�O TEM OFFICE INSTALADO'
ELSE
	'LICEN�A COM PROBLEMA'
END END AS STATUSLICENCAOFFICE, *
FROM #TMPLICENCAS A
INNER JOIN #TMPOCS B ON A.ATIVONOVO = B.NAME





ALTER PROCEDURE RELLICENCASNAOUTILIZADAS
	@SOFTWAREID			INT,
	@FORNECEDOR			VARCHAR(200),
	@NUMNF				VARCHAR(9)
AS

SELECT NF.NUMNF, NF.FORNECEDOR, NF.EMPRESA, NF.LINK, S.NOME AS SOFTWARE, SUM(L.QUANTIDADE) QTDELICENCAS, 
COUNT(CL.COMPUTADORESID) QTDEUTILIZADA, L.STATUS STATUSLICENCA, SUM(L.QUANTIDADE) - COUNT(CL.COMPUTADORESID) AS QTDESOBRANDO
FROM LICENCAS L
INNER JOIN SOFTWARE S ON S.ID = L.SOFTWAREID
INNER JOIN NOTAFISCAL NF ON NF.ID = L.NOTAFISCALID
LEFT JOIN COMPUTADORESLICENCAS CL ON L.ID = CL.LICENCAID
WHERE (S.ID = @SOFTWAREID OR @SOFTWAREID = -1) AND
(NF.FORNECEDOR = @FORNECEDOR OR @FORNECEDOR = '') AND
(NF.NUMNF = @NUMNF OR @NUMNF = '')
GROUP BY NF.NUMNF, NF.FORNECEDOR, NF.LINK, S.NOME, NF.EMPRESA, L.STATUS
HAVING SUM(L.QUANTIDADE) - COUNT(CL.COMPUTADORESID) > 0
ORDER BY NF.NUMNF










/*

select * from computadores
select * From OCS
GETCOMPUTADORES

select distinct status from COMPUTADORES

SELECT A.name, C.ATIVONOVO, A.id, C.OCSID
FROM OCS A
LEFT JOIN COMPUTADORES C ON C.ATIVONOVO = A.name









SELECT B.ID, C.NOME, A.NUMNF, B.QUANTIDADE
FROM NOTAFISCAL A
INNER JOIN LICENCAS B ON A.ID = B.NOTAFISCALID
INNER JOIN SOFTWARE C ON C.ID = B.SOFTWAREID
ORDER BY NUMNF



SELECT C.ATIVONOVO, C.ATIVOANTIGO, C.USUARIO, C.DEPARTAMENTO, C.STATUS, NF.NUMNF, NF.FORNECEDOR, NF.EMPRESA, S.NOME SOFTWARE, NF.LINK, L.QUANTIDADE
FROM COMPUTADORES C
INNER JOIN COMPUTADORESLICENCAS CL ON C.ID = CL.COMPUTADORESID
INNER JOIN LICENCAS L ON L.ID = CL.LICENCAID
INNER JOIN SOFTWARE S ON S.ID = L.SOFTWAREID
INNER JOIN NOTAFISCAL NF ON NF.ID = L.NOTAFISCALID




--QUANTIDADE DE LICEN�AS UTILIZADAS
SELECT NF.NUMNF, S.NOME, L.QUANTIDADE AS QTDEDISPONIVEL, CONVERT(DECIMAL(18,2), COUNT(*)) AS QTDEUTILIZADA
FROM COMPUTADORES C
INNER JOIN COMPUTADORESLICENCAS CL ON C.ID = CL.COMPUTADORESID
INNER JOIN LICENCAS L ON L.ID = CL.LICENCAID
INNER JOIN NOTAFISCAL NF ON NF.ID = L.NOTAFISCALID 
INNER JOIN SOFTWARE S ON S.ID = L.SOFTWAREID
GROUP BY NF.NUMNF, S.NOME, L.QUANTIDADE











SELECT *
FROM NOTAFISCAL NF
INNER JOIN LICENCAS L ON NF.ID = L.NOTAFISCALID
INNER JOIN SOFTWARE S ON S.ID = L.SOFTWAREID


select * From LICENCAS
where id in (201, 202)


SELECT * fROM COMPUTADORESLICENCAS
WHERE LICENCAID = 221



UPDATE LICENCAS
SET STATUS = 'A'

















SELECT C.ATIVONOVO, C.ATIVOANTIGO, C.USUARIO, C.DEPARTAMENTO, C.STATUS, NF.NUMNF, NF.FORNECEDOR, NF.EMPRESA, S.NOME , L.CHAVE, NF.LINK, L.QUANTIDADE, CL.LICENCAID, CL.COMPUTADORESID, L.STATUS STATUSLICENCA, OCS.*
FROM COMPUTADORES C
INNER JOIN COMPUTADORESLICENCAS CL ON C.ID = CL.COMPUTADORESID
INNER JOIN LICENCAS L ON L.ID = CL.LICENCAID
INNER JOIN SOFTWARE S ON S.ID = L.SOFTWAREID
INNER JOIN NOTAFISCAL NF ON NF.ID = L.NOTAFISCALID
LEFT OUTER JOIN
(
	SELECT * FROM OPENQUERY(MYSQLNEWOCS,'SELECT id, name, ipaddr, osname, userid, winprodid, winprodkey FROM hardware where OSNAME LIKE ''%Win%'' order by id') 
) AS OCS ON OCS.ID = C.OCSID
ORDER BY C.ATIVONOVO

*/