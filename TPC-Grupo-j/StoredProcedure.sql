﻿USE CONSULTORIODB
GO
--Obtener Permisos Por rol
CREATE PROCEDURE sp_GetPermisosPorRol
    @rol_name VARCHAR(50)
AS
BEGIN
    SELECT P.permiso_name
    FROM PERMISOS P
    JOIN PERMISOS_X_ROLES PR ON P.id = PR.id_permiso
    JOIN ROLES R ON PR.id_rol = R.id
    WHERE R.rol_name = @rol_name;
END;

create proc sp_RegistrarUsuario(
@email varchar(70),
@password_hash varchar(200),
@img_url varchar(200),
@id_rol int,
@fecha_creacion DATETIME,
@Registrado bit output,
@Mensaje varchar(50) output
)
as
begin 
	if(not exists(select * from USUARIOS Where email = @email))
	begin
		insert into USUARIOS(email, password_hash, img_url, id_rol, fecha_creacion) values(@email, @password_hash, @img_url, @id_rol, @fecha_creacion)
		set @Registrado = 1
		set @Mensaje = 'usuario registrado'
	end
	else
	begin
		set @registrado = 0
		set @Mensaje = 'correo ya existente'
	end
end;


create proc sp_ValidarUsuario(
@email varchar(70),
@password_hash varchar(200)
)
as
begin
	if(exists(select * from USUARIOS where email = @email and password_hash = @password_hash))
		select id from USUARIOS where email = @email and password_hash = @password_hash
	else
		select '0'
end;