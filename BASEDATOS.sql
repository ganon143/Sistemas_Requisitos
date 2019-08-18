--CREACION DE LA BASE DE DATOS
USE MASTER;
GO

IF EXISTS(SELECT 1 FROM MASTER.SYS.SYSDATABASES WHERE NAME ='DB_SISTEMA')
BEGIN
  DROP DATABASE DB_SISTEMA;
END;

CREATE DATABASE DB_SISTEMA;
GO

--CREACION DE LAS TABLAS
USE DB_SISTEMA;

IF OBJECT_ID (N'T_Privilegios', N'U') IS NULL
BEGIN
  CREATE TABLE T_Privilegios 
  (
    Id_Privilegio INT NOT NULL IDENTITY(1,1),
	Privilegio VARCHAR(30) NOT NULL,
	Descripcion VARCHAR(50) NOT NULL,
    CONSTRAINT  PK_Id_Privilegio  PRIMARY KEY NONCLUSTERED
    (
	  Id_Privilegio  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Privilegios_Sequential
  ON T_Privilegios (Id_Privilegio)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];
END;  

IF OBJECT_ID (N'T_Roles', N'U') IS NULL
BEGIN
  CREATE TABLE T_Roles 
  (
    Id_Rol INT NOT NULL IDENTITY(1,1),
	Rol VARCHAR(30) NOT NULL,
	Descripcion VARCHAR(50) NOT NULL,
    CONSTRAINT  PK_Id_Rol PRIMARY KEY NONCLUSTERED
    (
	  Id_Rol  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Roles_Sequential
  ON T_Roles (Id_Rol)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];
END;  

IF OBJECT_ID (N'T_Privilegios_Roles', N'U') IS NULL
BEGIN
  CREATE TABLE T_Privilegios_Roles 
  (
    Id_Privilegio_Rol INT NOT NULL IDENTITY(1,1),
	Id_Rol INT NOT NULL,
	Id_Privilegio INT NOT NULL,
    CONSTRAINT  PK_Id_Privilegio_Rol PRIMARY KEY NONCLUSTERED
    (
	  Id_Privilegio_Rol  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Privilegios_Roles_Sequential
  ON T_Privilegios_Roles (Id_Privilegio_Rol)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  CREATE NONCLUSTERED INDEX FK_T_Privilegios_Roles_Id_Rol
  ON T_Privilegios_Roles(Id_Rol)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  CREATE NONCLUSTERED INDEX FK_T_Privilegios_Roles_Id_Privilegio
  ON T_Privilegios_Roles(Id_Privilegio)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  ALTER TABLE T_Privilegios_Roles
    ADD CONSTRAINT FK_T_Privilegios_Roles_Id_Rol
    FOREIGN KEY(Id_Rol)
    REFERENCES T_Roles(Id_Rol)
    ON UPDATE CASCADE
    ON DELETE CASCADE
    NOT FOR REPLICATION;

  ALTER TABLE T_Privilegios_Roles
    ADD CONSTRAINT FK_T_Privilegios_Roles_Id_Privilegio
    FOREIGN KEY(Id_Privilegio)
    REFERENCES T_Privilegios(Id_Privilegio)
    ON UPDATE CASCADE
    ON DELETE CASCADE
    NOT FOR REPLICATION;
END;  

IF OBJECT_ID (N'T_Personas', N'U') IS NULL
BEGIN
  CREATE TABLE T_Personas 
  (
	Cedula VARCHAR(15) NOT NULL UNIQUE,
	Nombre VARCHAR(25) NOT NULL,
	Primer_Apellido VARCHAR(25) NOT NULL,
	Segundo_Apellido VARCHAR(25) NOT NULL,
	Email VARCHAR(35) NOT NULL UNIQUE,
	Telefono1 VARCHAR(14) NOT NULL,
	Usuario VARCHAR(15) NOT NULL UNIQUE,
	Contrasena VARCHAR(12) NOT NULL,
    Super_Usuario BIT NOT NULL DEFAULT(0),
	Activo BIT NOT NULL DEFAULT(0),
    CONSTRAINT  PK_Cedula PRIMARY KEY NONCLUSTERED
    (
	  Cedula  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Personas_Unique
  ON T_Personas (Cedula,Email,Usuario)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];


IF OBJECT_ID (N'T_Roles_Personas', N'U') IS NULL
BEGIN
  CREATE TABLE T_Roles_Personas 
  (
    Id_Rol_Persona INT NOT NULL IDENTITY(1,1),
	Id_Rol INT NOT NULL,
	Cedula VARCHAR(15) NOT NULL,
    CONSTRAINT  PK_Id_Rol_Persona PRIMARY KEY NONCLUSTERED
    (
	  Id_Rol_Persona  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Roles_Personas_Sequential
  ON T_Roles_Personas (Id_Rol_Persona)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  CREATE NONCLUSTERED INDEX FK_T_Roles_Personas_Id_Rol
  ON T_Roles_Personas(Id_Rol)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  CREATE NONCLUSTERED INDEX FK_T_Roles_Personas_Cedula
  ON T_Roles_Personas(Cedula)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  ALTER TABLE T_Roles_Personas
    ADD CONSTRAINT FK_T_Roles_Personas_Id_Rol
    FOREIGN KEY(Id_Rol)
    REFERENCES T_Roles(Id_Rol)
    ON UPDATE CASCADE
    ON DELETE CASCADE
    NOT FOR REPLICATION;

  ALTER TABLE T_Roles_Personas
    ADD CONSTRAINT FK_T_Roles_Personas_Cedula
    FOREIGN KEY(Cedula)
    REFERENCES T_Personas(Cedula)
    ON UPDATE CASCADE
    ON DELETE CASCADE
    NOT FOR REPLICATION;
END;  
--REQUISITO Y REQUISITO_x_PERSONA
IF OBJECT_ID (N'T_Requisito', N'U') IS NULL
BEGIN
  CREATE TABLE T_Requisito 
  (
    Id_Requisito INT NOT NULL IDENTITY(1,1),
	Nombre_Requsito VARCHAR(30) NOT NULL,
	Descripcion VARCHAR(50) NOT NULL,
    CONSTRAINT  PK_Id_Requisito PRIMARY KEY NONCLUSTERED
    (
	  Id_Requisito  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Requisito_Sequential
  ON T_Requisito (Id_Requisito)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];
END;  





IF OBJECT_ID (N'T_Requisito_Personas', N'U') IS NULL
BEGIN
  CREATE TABLE T_Requisito_Personas 
  (
    Id_Requisito_Persona INT NOT NULL IDENTITY(1,1),
	Id_Requisito INT NOT NULL,
	Cedula VARCHAR(15) NOT NULL,
    CONSTRAINT  PK_Id_Requisito_Persona PRIMARY KEY NONCLUSTERED
    (
	  Id_Requisito_Persona  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Requisito_Personas_Sequential
  ON T_Requisito_Personas (Id_Requisito_Persona)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  CREATE NONCLUSTERED INDEX FK_T_Requisito_Personas_Id_Requisito
  ON T_Requisito_Personas(Id_Requisito)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  CREATE NONCLUSTERED INDEX FK_T_Requisito_Personas_Cedula
  ON T_Requisito_Personas(Cedula)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  ALTER TABLE T_Requisito_Personas
    ADD CONSTRAINT FK_T_Requisito_Personas_Id_Requisito
    FOREIGN KEY(Id_Requisito)
    REFERENCES T_Requisito(Id_Requisito)
    ON UPDATE CASCADE
    ON DELETE CASCADE
    NOT FOR REPLICATION;

  ALTER TABLE T_Requisito_Personas
    ADD CONSTRAINT FK_T_Requisito_Personas_Cedula
    FOREIGN KEY(Cedula)
    REFERENCES T_Personas(Cedula)
    ON UPDATE CASCADE
    ON DELETE CASCADE
    NOT FOR REPLICATION;
END;  
END;


--CREACION DE PROCEDURES LISTAR--

IF OBJECT_ID('sp_Listar_Requisito') IS NOT NULL DROP PROCEDURE sp_Listar_Requisito
go


CREATE PROCEDURE sp_Listar_Requisito
AS
BEGIN
  SELECT
    Id_Requisito,
	Nombre_Requsito,
	Descripcion
  FROM 
    T_Requisito
End; 
GO

IF OBJECT_ID('sp_Listar_Personas') IS NOT NULL DROP PROCEDURE sp_Listar_Personas
GO

CREATE PROCEDURE sp_Listar_Personas
AS
BEGIN
  SELECT
    P.Cedula
	,P.Nombre
	,P.Primer_Apellido
	,P.Segundo_Apellido
	,P.Email
	,P.Telefono1
	,P.Usuario
	,P.Contrasena
	,P.Super_Usuario
	,P.Activo	
  FROM 
    T_Personas P
 
End; 
GO

IF OBJECT_ID('sp_Listar_Privilegios') IS NOT NULL DROP PROCEDURE sp_Listar_Privilegios
GO

CREATE PROCEDURE sp_Listar_Privilegios
AS
BEGIN
  SELECT
    Id_Privilegio
    ,Privilegio
	,Descripcion
  FROM 
    T_Privilegios
End; 
GO
IF OBJECT_ID('sp_Listar_Roles') IS NOT NULL DROP PROCEDURE sp_Listar_Roles
GO

CREATE PROCEDURE sp_Listar_Roles
AS
BEGIN
  SELECT
    Id_Rol
    ,Rol
	,Descripcion
  FROM 
    T_Roles
End; 
GO

IF OBJECT_ID('sp_Listar_Roles_Personas') IS NOT NULL DROP PROCEDURE sp_Listar_Roles_Personas
GO

CREATE PROCEDURE sp_Listar_Roles_Personas
AS
BEGIN
  SELECT
    Id_Rol_Persona
    ,Id_Rol
	,Cedula
  FROM 
    T_Roles_Personas
End;
GO

IF OBJECT_ID('sp_Listar_Privilegios_Roles') IS NOT NULL DROP PROCEDURE sp_Listar_Roles_Privilegios
GO

CREATE PROCEDURE sp_Listar_Privilegios_Roles
AS
BEGIN
  SELECT
    Id_Privilegio
    ,Id_Rol
	Descripcion
  FROM 
    T_Privilegios_Roles
End;
GO

--CREACION DE PROCEDURES FILTAR

IF OBJECT_ID('sp_Filtrar_Requisito') IS NOT NULL DROP PROCEDURE sp_Filtrar_Requisito
GO

CREATE PROCEDURE sp_Filtrar_Requisito
(
	@Filtro varchar(25)
)
AS
BEGIN
  SELECT
    Id_Requisito
    ,Nombre_Requsito
	,Descripcion	
  FROM 
    T_Requisito
  WHERE
    (Nombre_Requsito like '%'+@Filtro+'%')
End;
GO

IF OBJECT_ID('sp_Filtrar_Personas') IS NOT NULL DROP PROCEDURE sp_Filtrar_Personas
GO

CREATE PROCEDURE sp_Filtrar_Personas
(
	@Filtro varchar(25)
)
AS
BEGIN
  SELECT
	Cedula
	,Nombre
	,Primer_Apellido
	,Segundo_Apellido
	,Email
	,Telefono1	
	,Usuario
	,Contrasena	
	,Super_Usuario
	,Activo
  FROM 
    T_Personas
  WHERE
    (Nombre like '%'+@Filtro+'%')
End;
GO

IF OBJECT_ID('sp_Filtrar_Privilegios') IS NOT NULL DROP PROCEDURE sp_Filtrar_Privilegios
GO

CREATE PROCEDURE sp_Filtrar_Privilegios
(
	@Filtro varchar(25)
)
AS
BEGIN
  SELECT
    Id_Privilegio
	,Privilegio
	,Descripcion
  FROM 
    T_Privilegios
  WHERE
    (Privilegio like '%'+@Filtro+'%')
End;
GO

IF OBJECT_ID('sp_Filtrar_Privilegios_Roles') IS NOT NULL DROP PROCEDURE sp_Filtrar_Privilegios_Roles
GO

CREATE PROCEDURE sp_Filtrar_Privilegios_Roles
(
	@Filtro INT
)
AS
BEGIN
  SELECT
    T_Privilegios_Roles.Id_Privilegio_Rol
	,T_Privilegios.Descripcion
  FROM 
    T_Privilegios_Roles
  INNER JOIN
    T_Privilegios
  ON
    (T_Privilegios_Roles.Id_Privilegio = T_Privilegios.Id_Privilegio)
  WHERE
    (T_Privilegios_Roles.Id_Rol =  @Filtro)
End;
GO

IF OBJECT_ID('sp_Filtrar_Roles') IS NOT NULL DROP PROCEDURE sp_Filtrar_Roles
GO

CREATE PROCEDURE sp_Filtrar_Roles
(
	@Filtro varchar(25)
)
AS
BEGIN
  SELECT
    Id_Rol
	,Rol
	,Descripcion
  FROM 
    T_Roles
  WHERE
    (Descripcion like '%'+@Filtro+'%')
End;
GO

IF OBJECT_ID('sp_Filtrar_Roles_Personas') IS NOT NULL DROP PROCEDURE sp_Filtrar_Roles_Personas
GO

CREATE PROCEDURE sp_Filtrar_Roles_Personas
(
	@Filtro varchar(15)
)
AS
BEGIN
  SELECT
    T_Roles_Personas.Id_Rol_Persona
	,T_Roles.Rol
  FROM 
    T_Roles_Personas
  INNER JOIN
    T_Roles
  ON
    (T_Roles_Personas.Id_Rol = T_Roles.Id_Rol)
  WHERE
    (T_Roles_Personas.Cedula = @Filtro)
End;
GO

--CREACION DE PROCEDURES INSERTAR
IF OBJECT_ID('sp_Insertar_Persona]') IS NOT NULL DROP PROCEDURE sp_Insertar_Persona
GO

create Procedure sp_Insertar_Persona

(
  @Cedula VARCHAR(15)
  ,@Nombre VARCHAR(25)
  ,@Primer_Apellido VARCHAR(25)
  ,@Segundo_Apellido VARCHAR(25)
  ,@Email VARCHAR(35)
  ,@Telefono1 VARCHAR(14) 
  ,@Usuario VARCHAR(15)
  ,@Contrasena VARCHAR(12)
  ,@Super_Usuario BIT
  ,@Activo BIT

)
As
BEGIN
  BEGIN TRAN InsertarPersona;
    BEGIN TRY   
      INSERT INTO T_Personas
                 (Cedula,Nombre,Primer_Apellido,Segundo_Apellido,Email,Telefono1
				 ,Usuario,Contrasena,Super_Usuario,Activo)
      VALUES
                 (@Cedula,@Nombre,@Primer_Apellido,@Segundo_Apellido,@Email,@Telefono1
                 ,@Usuario,@Contrasena,@Super_Usuario,@Activo);

      COMMIT TRAN InsertarPersona;
  END TRY
  BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  

	ROLLBACK TRAN InsertarPersona;
  
    SELECT   
        @ErrorMessage = ERROR_MESSAGE(),  
        @ErrorSeverity = ERROR_SEVERITY(),  
        @ErrorState = ERROR_STATE();  
  
    RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );

  END CATCH

END
GO

IF OBJECT_ID('sp_Insertar_Rol]') IS NOT NULL DROP PROCEDURE sp_Insertar_Rol
GO

Create Procedure sp_Insertar_Rol

(
  @Rol VARCHAR(20)
  ,@Descripcion VARCHAR(50)
)
As
BEGIN
  BEGIN TRAN InsertarRol;
    BEGIN TRY

      INSERT INTO T_Roles
	    (Rol, Descripcion)
      VALUES
	    (@Rol, @Descripcion);

      COMMIT TRAN InsertarRol;
  END TRY
  BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  

	ROLLBACK TRAN InsertarRol;
  
    SELECT   
        @ErrorMessage = ERROR_MESSAGE(),  
        @ErrorSeverity = ERROR_SEVERITY(),  
        @ErrorState = ERROR_STATE();  
  
    RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );

  END CATCH

END
GO

IF OBJECT_ID('sp_Insertar_Privilegio_Rol]') IS NOT NULL DROP PROCEDURE sp_Insertar_Privilegio_Rol
GO

CREATE Procedure sp_Insertar_Privilegio_Rol

(
  @idRol INT
  ,@IdPrivilegio INT
)
As
BEGIN
  BEGIN TRAN InsertarPrivilegio_Rol;
    BEGIN TRY

	  IF NOT EXISTS(SELECT 1 FROM T_Privilegios_Roles WHERE Id_Rol = @idRol AND Id_Privilegio = @IdPrivilegio)
	  BEGIN
        INSERT INTO T_Privilegios_Roles
	      (Id_Rol, Id_Privilegio)
        VALUES
	      (@idRol, @IdPrivilegio);
	  END

      COMMIT TRAN InsertarPrivilegio_Rol;
  END TRY
  BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  

	ROLLBACK TRAN InsertarPrivilegio_Rol;
  
    SELECT   
        @ErrorMessage = ERROR_MESSAGE(),  
        @ErrorSeverity = ERROR_SEVERITY(),  
        @ErrorState = ERROR_STATE();  
  
    RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );

  END CATCH

END
GO

IF OBJECT_ID('sp_Insertar_Rol_Persona]') IS NOT NULL DROP PROCEDURE sp_Insertar_Rol_Persona
GO

CREATE Procedure sp_Insertar_Rol_Persona

(
  @idRol INT
  ,@cedula VARCHAR(15)
)
As
BEGIN
  BEGIN TRAN InsertarRolPersona;
    BEGIN TRY

	  IF NOT EXISTS(SELECT 1 FROM T_Roles_Personas WHERE Id_Rol = @idRol AND Cedula = @cedula)
	  BEGIN
        INSERT INTO T_Roles_Personas
	      (Id_Rol, Cedula)
        VALUES
	      (@idRol, @cedula);
	  END

      COMMIT TRAN InsertarRolPersona;
  END TRY
  BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  

	ROLLBACK TRAN InsertarRolPersona;
  
    SELECT   
        @ErrorMessage = ERROR_MESSAGE(),  
        @ErrorSeverity = ERROR_SEVERITY(),  
        @ErrorState = ERROR_STATE();  
  
    RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );

  END CATCH

END
GO

--CREACION DE PROCEDURES MODIFICAR
IF OBJECT_ID('sp_Modificar_Persona]') IS NOT NULL DROP PROCEDURE sp_Modificar_Persona
GO

create Procedure sp_Modificar_Persona

(
  @Cedula VARCHAR(15)
  ,@Nombre VARCHAR(25)
  ,@Primer_Apellido VARCHAR(25)
  ,@Segundo_Apellido VARCHAR(25)
  ,@Email VARCHAR(35)
  ,@Telefono1 VARCHAR(14)
  ,@Usuario VARCHAR(15)
  ,@Contrasena VARCHAR(12)
  ,@Super_Usuario BIT
  ,@Activo BIT

)
As
BEGIN
  BEGIN TRAN ModificarPersona;
    BEGIN TRY
      UPDATE 
        T_Personas
      SET
  	    Nombre = @Nombre,
  	    Primer_Apellido = @Primer_Apellido,
	    Segundo_Apellido = @Segundo_Apellido,
	    Email = @Email,
	    Telefono1 = @Telefono1,	
	    Usuario = @Usuario,
	    Contrasena = @Contrasena,
	    Super_Usuario = @Super_Usuario,
	    Activo = @Activo
      WHERE
        (Cedula = @Cedula)

      COMMIT TRAN ModificarPersona;
  END TRY
  BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  

	ROLLBACK TRAN ModificarPersona;
  
    SELECT   
        @ErrorMessage = ERROR_MESSAGE(),  
        @ErrorSeverity = ERROR_SEVERITY(),  
        @ErrorState = ERROR_STATE();  
  
    RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );

  END CATCH

END
GO

IF OBJECT_ID('sp_Modificar_Rol]') IS NOT NULL DROP PROCEDURE sp_Modificar_Rol
GO

Create Procedure sp_Modificar_Rol

(
  @idRol INT
  ,@Rol VARCHAR(20)
  ,@Descripcion VARCHAR(50)
)
As
BEGIN
  BEGIN TRAN ModificarRol;
    BEGIN TRY

      UPDATE 
	    T_Roles
	  SET
	    Rol = @Rol
	    ,Descripcion = @Descripcion
      WHERE
	    (Id_Rol = @idRol);

      COMMIT TRAN ModificarRol;
  END TRY
  BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  

	ROLLBACK TRAN ModificarRol;
  
    SELECT   
        @ErrorMessage = ERROR_MESSAGE(),  
        @ErrorSeverity = ERROR_SEVERITY(),  
        @ErrorState = ERROR_STATE();  
  
    RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );

  END CATCH

END
GO


--CREACION DE PROCEDURES ELIMINAR
IF OBJECT_ID('sp_Eliminar_Persona') IS NOT NULL DROP PROCEDURE sp_Eliminar_Persona
GO

Create Procedure sp_Eliminar_Persona

(
	@Cedula varchar(15)
)
As
BEGIN
  BEGIN TRAN EliminarPersona;
    BEGIN TRY

      DELETE FROM T_Personas WHERE (Cedula = @Cedula);

      COMMIT TRAN EliminarPersona;
    END TRY
  BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  

	ROLLBACK TRAN EliminarPersona;
  
    SELECT   
        @ErrorMessage = ERROR_MESSAGE(),  
        @ErrorSeverity = ERROR_SEVERITY(),  
        @ErrorState = ERROR_STATE();  
  
    RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );

  END CATCH


END
GO

IF OBJECT_ID('sp_Eliminar_Rol]') IS NOT NULL DROP PROCEDURE sp_Eliminar_Rol
GO

Create Procedure sp_Eliminar_Rol

(
  @idRol INT
)
As
BEGIN
  BEGIN TRAN EliminarRol;
    BEGIN TRY

      DELETE 
	    T_Roles
      WHERE
	    (Id_Rol = @idRol);

      COMMIT TRAN EliminarRol;
  END TRY
  BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  

	ROLLBACK TRAN EliminarRol;
  
    SELECT   
        @ErrorMessage = ERROR_MESSAGE(),  
        @ErrorSeverity = ERROR_SEVERITY(),  
        @ErrorState = ERROR_STATE();  
  
    RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );

  END CATCH

END
GO

IF OBJECT_ID('sp_Eliminar_Privilegio_Rol]') IS NOT NULL DROP PROCEDURE sp_Eliminar_Privilegio_Rol
GO

Create Procedure sp_Eliminar_Privilegio_Rol

(
  @idPrivilegioRol INT
)
As
BEGIN
  BEGIN TRAN EliminarPrivilegioRol;
    BEGIN TRY

      DELETE 
	    T_Privilegios_Roles
      WHERE
	    (Id_Privilegio_Rol = @idPrivilegioRol);

      COMMIT TRAN EliminarPrivilegioRol;
  END TRY
  BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  

	ROLLBACK TRAN EliminarPrivilegioRol;
  
    SELECT   
        @ErrorMessage = ERROR_MESSAGE(),  
        @ErrorSeverity = ERROR_SEVERITY(),  
        @ErrorState = ERROR_STATE();  
  
    RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );

  END CATCH

END
GO

IF OBJECT_ID('sp_Eliminar_Rol_Persona]') IS NOT NULL DROP PROCEDURE sp_Eliminar_Rol_Persona
GO

Create Procedure sp_Eliminar_Rol_Persona

(
  @idRolPersona INT
)
As
BEGIN
  BEGIN TRAN EliminarRolPersona;
    BEGIN TRY

      DELETE 
	    T_Roles_Personas
      WHERE
	    (Id_Rol_Persona = @idRolPersona);

      COMMIT TRAN EliminarRolPersona;
  END TRY
  BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  

	ROLLBACK TRAN EliminarRolPersona;
  
    SELECT   
        @ErrorMessage = ERROR_MESSAGE(),  
        @ErrorSeverity = ERROR_SEVERITY(),  
        @ErrorState = ERROR_STATE();  
  
    RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );

  END CATCH

END
GO



IF OBJECT_ID('sp_Listar_Requisito_Personas') IS NOT NULL DROP PROCEDURE sp_Listar_Requisito_Personas
GO

CREATE PROCEDURE sp_Listar_Requisito_Personas
AS
BEGIN
  SELECT
    Id_Requisito_Persona
    ,Id_Requisito
	,Cedula
  FROM 
    T_Requisito_Personas
End;
GO



IF OBJECT_ID('sp_Filtrar_Requisito_Personas') IS NOT NULL DROP PROCEDURE sp_Filtrar_Requisito_Personas
GO

CREATE PROCEDURE sp_Filtrar_Requisito_Personas
(
	@Filtro varchar(15)
)
AS
BEGIN
  SELECT
    T_Requisito_Personas.Id_Requisito_Persona
	,T_Requisito.Nombre_Requsito
  FROM 
    T_Requisito_Personas
  INNER JOIN
    T_Requisito
  ON
    (T_Requisito_Personas.Id_Requisito = T_Requisito.Id_Requisito)
  WHERE
    (T_Requisito_Personas.Cedula = @Filtro)
End;
GO



IF OBJECT_ID('sp_Insertar_Requisito_Persona') IS NOT NULL DROP PROCEDURE sp_Insertar_Rol_Persona
GO

CREATE Procedure sp_Insertar_Requisito_Persona

(
  @idRequi INT
  ,@cedula VARCHAR(15)
)
As
BEGIN
  BEGIN TRAN InsertarRequiPersona;
    BEGIN TRY

	  IF NOT EXISTS(SELECT 1 FROM T_Requisito_Personas WHERE Id_Requisito = @idRequi AND Cedula = @cedula)
	  BEGIN
        INSERT INTO T_Requisito_Personas
	      (Id_Requisito, Cedula)
        VALUES
	      (@idRequi, @cedula);
	  END

      COMMIT TRAN InsertarRequiPersona;
  END TRY
  BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  

	ROLLBACK TRAN InsertarRequiPersona;
  
    SELECT   
        @ErrorMessage = ERROR_MESSAGE(),  
        @ErrorSeverity = ERROR_SEVERITY(),  
        @ErrorState = ERROR_STATE();  
  
    RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );

  END CATCH

END
GO


IF OBJECT_ID('sp_Eliminar_Requi_Persona') IS NOT NULL DROP PROCEDURE sp_Eliminar_Requi_Persona
GO

Create Procedure sp_Eliminar_Requi_Persona

(
  @idRequiPersona INT
)
As
BEGIN
  BEGIN TRAN EliminarRequiPersona;
    BEGIN TRY

      DELETE 
	    T_Requisito_Personas
      WHERE
	    (Id_Requisito = @idRequiPersona);

      COMMIT TRAN EliminarRequiPersona;
  END TRY
  BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  

	ROLLBACK TRAN EliminarRequiPersona;
  
    SELECT   
        @ErrorMessage = ERROR_MESSAGE(),  
        @ErrorSeverity = ERROR_SEVERITY(),  
        @ErrorState = ERROR_STATE();  
  
    RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );

  END CATCH

END
GO




--CREACION DE PROCEDURES MEMBERSHIP
IF OBJECT_ID('sp_Login') IS NOT NULL DROP PROCEDURE sp_Login
GO

CREATE PROCEDURE sp_Login

(
  @UserLogin VARCHAR(35)
  ,@Contrasena VARCHAR(12)
)
As
BEGIN
  SELECT
    1
  FROM
    T_Personas
  WHERE
    ((Email = @UserLogin AND Contrasena = @Contrasena)
	OR (Usuario = @UserLogin AND Contrasena = @Contrasena))
	AND (Activo = 1)
End
GO

IF OBJECT_ID('sp_Has_Privilege') IS NOT NULL DROP PROCEDURE sp_Has_Privilege
GO

CREATE PROCEDURE sp_Has_Privilege

(
  @UserLogin VARCHAR(35)
  ,@Privilegio VARCHAR(30)
)
As
BEGIN
  DECLARE @superUsuario BIT;
  SET @superUsuario = 0;

  SELECT 
    @superUsuario = Super_Usuario 
  FROM 
  T_Personas 
  WHERE
    ((Email = @UserLogin)
	OR (Usuario = @UserLogin))
	AND (Activo = 1);

  IF @superUsuario = 1
  BEGIN
    SELECT @superUsuario Has_Privilege; 
  END
  ELSE
  BEGIN
    SELECT
	1 Has_Privilege
	FROM
	T_Personas P
	INNER JOIN
	T_Roles_Personas RP
	ON
	(RP.Cedula = P.Cedula)
	INNER JOIN
	T_Roles R
	ON
	(R.Id_Rol = RP.Id_Rol)
	INNER JOIN
	T_Privilegios_Roles PR
	ON
	(PR.Id_Rol = R.Id_Rol)
	INNER JOIN
	T_Privilegios PRI
	ON
	(PRI.Id_Privilegio = PR.Id_Privilegio)
  WHERE
    ((P.Email = @UserLogin AND PRI.Privilegio = @Privilegio)
	OR (P.Usuario = @UserLogin AND PRI.Privilegio = @Privilegio))
	AND (P.Activo = 1)

  END
End
GO



CREATE PROCEDURE [dbo].[sp_Insertar_Requisito]
(
   @Nombre_Requsito VARCHAR(50)
  ,@Descripcion VARCHAR(150)
  ,@Usuario VARCHAR (50)
  

)
As
BEGIN
  BEGIN TRAN InsertarPaquete;
    BEGIN TRY

	  DECLARE @Cedula VARCHAR(15);
	  SELECT TOP 1 @Cedula = Cedula FROM T_Personas WHERE Usuario = @Usuario ORDER BY Cedula DESC;

      INSERT INTO T_Requisito
                 (Nombre_Requsito,Descripcion)
      VALUES
                 (@Nombre_Requsito,@Descripcion);

      COMMIT TRAN InsertarPaquete;
  END TRY
  BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  

	ROLLBACK TRAN InsertarPaquete;
  
    SELECT   
        @ErrorMessage = ERROR_MESSAGE(),  
        @ErrorSeverity = ERROR_SEVERITY(),  
        @ErrorState = ERROR_STATE();  
  
    RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );

  END CATCH

END

GO

CREATE PROCEDURE [dbo].[sp_Listar_Paquetes_Factura]
AS
BEGIN
  SELECT
    Id_Paquete
    ,TP.Descripcion AS 'DetallePaquete'
	,Peso
	,TC.Id_Categoria
	,TC.Nombre AS 'TipoCategoria'
	,TE.Id_Estado
	,TE.Descripcion AS 'Estado'
	,TS.Id_Sucursal
	,TS.Nombre AS 'Sucursal'
	,TSE.Id_Servicio
	,TSE.Tipo_Servicio
	,TP.Cedula
	,TPE.Usuario
	,Retiro_Domicilio
	,Entrega_Domicilio
	,Direccion_Entrega
	,TP.Id_Recibo
	,TR.Sub_Total
	,TR.Impuesto
	,TR.Envio
	,TR.Total
	,TR.Pagado
	,TR.Numero_tarjeta
  FROM 
    T_Paquetes TP
	INNER JOIN T_Personas TPE ON TP.Cedula = TPE.Cedula
	INNER JOIN T_Recibos TR ON TP.Id_Recibo=TR.Id_Recibo
	INNER JOIN T_Categorias TC ON TP.Id_Categoria = TC.Id_Categoria
	INNER JOIN T_Sucursales TS ON TP.Id_Sucursal=TS.Id_Sucursal
	INNER JOIN T_Servicios TSE ON TP.Id_Servicio=TSE.Id_Servicio
	INNER JOIN T_Estados TE ON TP.Id_Estado = TE.Id_Estado
End; 
GO


CREATE PROCEDURE [dbo].[sp_Modificar_Requisito]

(

   @Id_Requisito VARCHAR(50)
  ,@Nombre_Requsito VARCHAR(50)
  ,@Descripcion VARCHAR(150)
  ,@Usuario VARCHAR (50)
)
As
BEGIN
  BEGIN TRAN ModificarPaquetes;
    BEGIN TRY

      UPDATE 
        T_Requisito
      SET
  	    Nombre_Requsito = @Nombre_Requsito,
		Descripcion=@Descripcion

      WHERE
        (Id_Requisito = @Id_Requisito)

      COMMIT TRAN ModificarPaquetes;
  END TRY
  BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  

	ROLLBACK TRAN ModificarPaquetes;
  
    SELECT   
        @ErrorMessage = ERROR_MESSAGE(),  
        @ErrorSeverity = ERROR_SEVERITY(),  
        @ErrorState = ERROR_STATE();  
  
    RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );

  END CATCH

END

GO



--INSERTS INICIALES
IF NOT EXISTS(SELECT 1 FROM T_Personas WHERE Usuario = 'admin')
BEGIN
  EXEC sp_Insertar_Persona '1-1111-1111', 'Adrian', 'Soto', 'Loria', 'prueba@prueba.com', '2222-2222', 
                           'admin', '1234', 1, 1
End;
GO

INSERT INTO T_Privilegios
  (Privilegio, Descripcion)
VALUES
  ('Administrar_Personas', 'Permite administrar los usuarios del sistema');

GO

INSERT INTO T_Privilegios
  (Privilegio, Descripcion)
VALUES
  ('Administrar_Requisito', 'Permite administrar los requisitos del sistema');

GO

INSERT INTO T_Privilegios
  (Privilegio, Descripcion)
VALUES
  ('Usuario', 'rol generico pra los usuarios');

GO

INSERT INTO T_Roles
  (Rol, Descripcion)
VALUES
  ('Administrar_Personas', 'Permite administrar los usuarios del sistema');

GO

INSERT INTO T_Roles
  (Rol, Descripcion)
VALUES
  ('Administrar_Requisito', 'Permite administrar los requisitos del sistema');

GO

INSERT INTO T_Roles
  (Rol, Descripcion)
VALUES
  ('Usuario', 'rol generico pra los usuarios');

GO

INSERT INTO T_Privilegios_Roles
  (Id_Privilegio, Id_Rol)
VALUES
  (1, 1);

GO
INSERT INTO T_Privilegios_Roles
  (Id_Privilegio, Id_Rol)
VALUES
  (2, 2);

GO
INSERT INTO T_Privilegios_Roles
  (Id_Privilegio, Id_Rol)
VALUES
  (3, 3);

GO
