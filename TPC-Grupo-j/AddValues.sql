Use CONSULTORIODB
GO
--Cargarndo tabla ROLES
INSERT INTO ROLES (rol_name) VALUES ('admin');
INSERT INTO ROLES (rol_name) VALUES ('especialista');
INSERT INTO ROLES (rol_name) VALUES ('recepcionista');

--Cargando tabla PERMISOS
INSERT INTO PERMISOS (permiso_name) VALUES ('crear usuario');
INSERT INTO PERMISOS (permiso_name) VALUES ('editar usuario');
INSERT INTO PERMISOS (permiso_name) VALUES ('borrar usuario');
INSERT INTO PERMISOS (permiso_name) VALUES ('crear paciente');
INSERT INTO PERMISOS (permiso_name) VALUES ('editar paciente');
INSERT INTO PERMISOS (permiso_name) VALUES ('borrar paciente');
INSERT INTO PERMISOS (permiso_name) VALUES ('crear turno');
INSERT INTO PERMISOS (permiso_name) VALUES ('editar turno');
INSERT INTO PERMISOS (permiso_name) VALUES ('borrar turno');
INSERT INTO PERMISOS (permiso_name) VALUES ('editar roles del usuario');
INSERT INTO PERMISOS (permiso_name) VALUES ('editar estado de turno');
INSERT INTO PERMISOS (permiso_name) VALUES ('ver usuarios');
INSERT INTO PERMISOS (permiso_name) VALUES ('ver turnos');
INSERT INTO PERMISOS (permiso_name) VALUES ('ver pacientes');
INSERT INTO PERMISOS (permiso_name) VALUES ('pedir reprogramacion de turno');
INSERT INTO PERMISOS (permiso_name) VALUES ('editar perfil');

-- Obtener IDs de roles
-- admin = 1, especialista = 2, recepcionista = 3

-- Obtener IDs de permisos
-- crear usuario = 1, editar usuario = 2, borrar usuario = 3, 
-- crear paciente = 4, editar paciente = 5, borrar paciente = 6,
-- crear turno = 7, editar turno = 8, borrar turno = 9,
-- editar roles del usuario = 10, editar estado de turno = 11,
-- ver usuarios = 12, ver turnos = 13, ver pacientes = 14,
-- pedir reprogramacion de turno = 15, editar perfil = 16

-- Relacionar permisos con roles
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (1, 1); -- admin - crear usuario
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (1, 2); -- admin - editar usuario
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (1, 3); -- admin - borrar usuario
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (1, 4); -- admin - crear paciente
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (3, 4); -- recepcionista - crear paciente
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (1, 5); -- admin - editar paciente
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (3, 5); -- recepcionista - editar paciente
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (1, 6); -- admin - borrar paciente
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (1, 7); -- admin - crear turno
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (3, 7); -- recepcionista - crear turno
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (1, 8); -- admin - editar turno
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (3, 8); -- recepcionista - editar turno
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (1, 9); -- admin - borrar turno
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (1, 10); -- admin - editar roles del usuario
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (1, 11); -- admin - editar estado de turno
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (3, 11); -- recepcionista - editar estado de turno
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (1, 12); -- admin - ver usuarios
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (3, 12); -- recepcionista - ver usuarios
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (2, 12); -- especialista - ver usuarios
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (1, 13); -- admin - ver turnos
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (3, 13); -- recepcionista - ver turnos
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (2, 13); -- especialista - ver turnos
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (1, 14); -- admin - ver pacientes
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (3, 14); -- recepcionista - ver pacientes
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (2, 14); -- especialista - ver pacientes
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (2, 15); -- especialista - pedir reprogramacion de turno
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (1, 16); -- admin - editar perfil
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (3, 16); -- recepcionista - editar perfil
INSERT INTO PERMISOS_X_ROLES (id_rol, id_permiso) VALUES (2, 16); -- especialista - editar perfil

--Cargamos DIAS
INSERT INTO DIAS (nombre) VALUES ('Lunes');
INSERT INTO DIAS (nombre) VALUES ('Martes');
INSERT INTO DIAS (nombre) VALUES ('Miércoles');
INSERT INTO DIAS (nombre) VALUES ('Jueves');
INSERT INTO DIAS (nombre) VALUES ('Viernes');
INSERT INTO DIAS (nombre) VALUES ('Sábado');
INSERT INTO DIAS (nombre) VALUES ('Domingo');

--Cargamos algunas Especialidades
INSERT INTO ESPECIALIDADES (especialidad_name) VALUES ('Cardiología');
INSERT INTO ESPECIALIDADES (especialidad_name) VALUES ('Dermatología');
INSERT INTO ESPECIALIDADES (especialidad_name) VALUES ('Ginecología');

--Cargamos ESTADOS de los turnos
INSERT INTO ESTADOS (tipo) VALUES ('Nuevo');
INSERT INTO ESTADOS (tipo) VALUES ('Reprogramado');
INSERT INTO ESTADOS (tipo) VALUES ('Cancelado');
INSERT INTO ESTADOS (tipo) VALUES ('No Asistió');
INSERT INTO ESTADOS (tipo) VALUES ('Cerrado');

--Cargamos algunos USUARIOS
INSERT INTO USUARIOS (email, password_hash, img_url, id_rol, fecha_creacion)
VALUES ('especialista@example.com', 'doc', 'http://example.com/especialista.jpg', 2, GETDATE());

INSERT INTO USUARIOS (email, password_hash, img_url, id_rol, fecha_creacion)
VALUES ('recepcionista@example.com', 'rec', 'http://example.com/recepcionista.jpg', 3, GETDATE());

--Cargamos un usuario ADMIN
INSERT INTO USUARIOS (email, password_hash, img_url, id_rol) 
VALUES ('admin@example.com', 'adm', 'http://example.com/admin.jpg', 1);

--Cargamos un RECEPCIONISTA
INSERT INTO RECEPCIONISTAS (usuario_id, nombre, apellido, nacimiento)
VALUES (3, 'Ana', 'Martínez', '1992-07-20');

--Cargamos un ESPECIALISTA
INSERT INTO ESPECIALISTAS (usuario_id, nombre, apellido, nacimiento)
VALUES (2, 'Pedro', 'Gómez', '1980-05-15');

--Cargamos una ESPECIALIDAD al ESPECIALISTA
INSERT INTO ESPECIALIDADES_X_ESPECIALISTAS (especialista_id, especialidad_id)
VALUES (1, 1);

--Cargamos Turnos de trabajo para el especialista
INSERT INTO TURNOS_DE_TRABAJO (especialista_id, dia_id, hora_inicio, hora_final)
VALUES (1, 1, '09:00', '18:00'),
	   (1, 2, '09:00', '18:00'),
	   (1, 3, '09:00', '18:00'),
	   (1, 4, '09:00', '18:00'),
	   (1, 5, '09:00', '18:00')

--Cargamos un PACIENTE
INSERT INTO PACIENTES (nombre, apellido, email, telefono, nacimiento, dni)
VALUES ('Juan', 'Pérez', 'juan@example.com', '+54 11655443', '1990-01-01', '41253874');

--Cargamos un TURNO
INSERT INTO TURNOS (paciente_id, especialista_id, fecha, hora, estado_id, observacion)
VALUES (1, 1, '2024-06-03', '10:00', 1, 'Primera consulta');
