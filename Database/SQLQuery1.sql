--create login [Prueba] with password = 'Prueba2024!', CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
--exec sp_addsrvrolemember [Prueba], 'sysadmin'

CREATE DATABASE Prueba

CREATE TABLE [User](
	Id INT IDENTITY(1,1) NOT NULL,
	Name VARCHAR(50) NOT NULL,
	Username VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	Phone VARCHAR(30),
	Website VARCHAR(50),
	CONSTRAINT PK_IdUser PRIMARY KEY (Id)
)
