USE CONSULTORIODB
GO

--Registra un nuevo usuario y devuelve si se pudo insertar en la DB.
create proc sp_RegistrarUsuario(
@email varchar(70),
@password_hash varchar(200),
@img_url varchar(200),
@id_rol int,
@fecha_creacion DATETIME,
@activo BIT,
@Registrado bit output
)
as
begin 
	if(not exists(select * from USUARIOS Where email = @email))
	begin
		insert into USUARIOS(email, password_hash, img_url, id_rol, fecha_creacion, activo) values(@email, @password_hash, @img_url, @id_rol, @fecha_creacion, @activo)
		set @Registrado = 1
	end
	else
	begin
		set @registrado = 0
	end
end;

--Valida que el usuario se encuentre en la DB, de ser asi devuelve el id del usuario
--de lo contrario devuelve 0.
create proc sp_ValidarUsuario(
@email varchar(70),
@password_hash varchar(200)
)
as
begin
	if(exists(select * from USUARIOS where email = @email and password_hash = @password_hash))
		select id from USUARIOS where email = @email and password_hash = @password_hash
	else
		select 0 as id
end

CREATE PROCEDURE sp_ObtenerUsuarioPorEmail
    @Email VARCHAR(70)
AS
BEGIN
    SELECT id, password_hash FROM USUARIOS WHERE email = @Email
END
--Inserta nuevo usuario en la Tabla de Usuarios
CREATE PROCEDURE sp_InsertarNuevo
    @Email VARCHAR(70),
    @Password_Hash VARCHAR(200),
    @Img_Url VARCHAR(200),
	@id_rol int,
    @Fecha_Creacion DATETIME = NULL,
    @activo bit

AS
BEGIN
    IF @Fecha_Creacion IS NULL
    BEGIN
        SET @Fecha_Creacion = GETDATE()
    END

    INSERT INTO USUARIOS (email, password_hash, img_url, id_rol, fecha_creacion, activo)
    OUTPUT INSERTED.id
    VALUES (@Email, @Password_Hash, @Img_Url,@id_rol, @Fecha_Creacion, @activo)
END

CREATE PROCEDURE sp_GetUsuarioPorID
    @usuario_id INT
AS
BEGIN
    SELECT *
    FROM USUARIOS
    WHERE id = @usuario_id;
END;
