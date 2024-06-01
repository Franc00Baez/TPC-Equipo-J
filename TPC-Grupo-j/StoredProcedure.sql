USE CONSULTORIODB
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



--EXEC sp_GetPermisosPorRol @rol_name = 'admin';