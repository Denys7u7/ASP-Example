create database estudiante;

use estudiante;

create table estudiante(
    id int primary key identity,
    carnet char(6) unique CHECK(carnet LIKE '[a-zA-Z][a-zA-Z][1-9][1-9][1-9][1-9][1-9][1-9]'),
    nombre VARCHAR(50) CHECK(nombre not like '[%0-9%]'),
    apellido VARCHAR(50) CHECK(nombre not like '[%0-9%]'),
    sexo CHAR(1) CHECK(sexo = 'M' OR sexo = 'H'),
    edad int CHECK(edad > 6 AND edad < 18)
)