create database estudiante;
GO

use estudiante;
GO

create table estudiante(
    id int primary key identity,
    carnet varchar(8) CHECK(carnet LIKE '[a-z][a-z][0-9][0-9][0-9][0-9][0-9][0-9]') unique,
    nombre VARCHAR(50) CHECK(nombre not like '[%0-9%]'),
    apellido VARCHAR(50) CHECK(apellido not like '[%0-9%]'),
    sexo CHAR(1) CHECK(sexo = 'M' OR sexo = 'H'),
    edad int CHECK(edad > 6 AND edad < 18)
);
GO

create procedure insertarEstudiante(
@carnet char(8),
@nombre VARCHAR(50),
@apellido VARCHAR(50),
@sexo CHAR(1),
@edad INT) as
begin
	insert into estudiante(carnet, nombre, apellido, sexo, edad) values (@carnet, @nombre, @apellido, @sexo, @edad);
end;
GO

exec insertarEstudiante 'CI180440', 'Denys', 'Cruz', 'H', 17;
exec insertarEstudiante 'AG160230', 'Alejandro', 'Alejo', 'H', 17;
exec insertarEstudiante 'HH186320', 'Marco', 'Hernandez', 'H', 17;
exec insertarEstudiante 'CM193012', 'Yanci', 'Garcia', 'M', 16;
exec insertarEstudiante 'AL789654', 'Alejandra', 'Perez', 'M', 17;
GO

create proc modificarEstudiante(
@id int,
@carnet char(8),
@nombre VARCHAR(50),
@apellido VARCHAR(50),
@sexo CHAR(1),
@edad INT) as
begin
	update estudiante set carnet=@carnet, nombre=@nombre, apellido=@apellido,sexo=@sexo,edad=@edad where id = @id;
end;
GO

exec modificarEstudiante 1, 'CI180440', 'Denys', 'Cruz', 'H', 16;
GO


create procedure eliminarEstudiante(@id int) as
begin
	delete from estudiante where id = @id;
end;
GO

exec eliminarEstudiante 1
GO

sp_helptext eliminarEstudiante;
GO

create proc mostrarEstudiantes
with encryption as
begin
	select * from estudiante;
end;
GO

exec mostrarEstudiantes;
GO

sp_helptext mostrarEstudiantes;
GO


create proc mostrarEstudiante(@id int)
with encryption as
begin
	select * from estudiante where id = @id;
end;
GO

exec mostrarEstudiante 3