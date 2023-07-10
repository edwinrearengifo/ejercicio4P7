-- Crear una base de datos llamada "UsuariosPrueba"
CREATE DATABASE UsuariosPrueba;

-- Utilizar la base de datos recién creada
USE UsuariosPrueba;

-- Crear una tabla llamada "usuario" con sus atributos
CREATE TABLE usuario (
    int_id INT identity(1,1) PRIMARY KEY,
    str_status VARCHAR(20),
    dat_fecha DATE,
    str_nombre VARCHAR(50),
    str_direccion VARCHAR(100),
    str_departamento VARCHAR(50),
    int_telefono INT
);
go

DROP TABLE usuario;

CREATE TABLE listaIP (
    str_ip VARCHAR (50) PRIMARY KEY
);

--------------------------MOSTRAR USUARIOS
create proc MostrarUsuarios
as
select * from usuario
go

--------------------------MOSTRAR DIRECCIONES ÍP
create proc MostrarDireccionesIP
as
select * from listaIP
go
--------------------------INSERTAR 
create proc InsertarUsuario
@status VARCHAR(20),
@fecha DATE,
@nombre VARCHAR(50),
@direccion VARCHAR(100),
@departamento VARCHAR(50),
@telefono INT
as
insert into usuario values (@status,@fecha,@nombre,@direccion,@departamento,@telefono)
go
------------------------ELIMINAR
create proc EliminarUsuario
@id_eliminar int
as
delete from usuario where int_id=@id_eliminar
go
------------------EDITAR Usuario
create proc EditarUsuario

@id int,
@status VARCHAR(40),
@fecha DATE,
@nombre VARCHAR(40),
@direccion VARCHAR(40),
@departamento VARCHAR(40),
@telefono INT

as
update usuario set 

str_status=@status,
dat_fecha=@fecha,
str_nombre=@nombre,
str_direccion=@direccion,
str_departamento=@departamento,
int_telefono=@telefono

where int_id=@id
go

CREATE TABLE listaIP (
    str_ip VARCHAR (50) PRIMARY KEY
);

select * from listaIP
