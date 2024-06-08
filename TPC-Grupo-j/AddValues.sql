Use CONSULTORIODB
GO
--Cargarndo tabla ROLES
INSERT INTO ROLES (rol_name) VALUES ('admin');
INSERT INTO ROLES (rol_name) VALUES ('especialista');
INSERT INTO ROLES (rol_name) VALUES ('recepcionista');

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
