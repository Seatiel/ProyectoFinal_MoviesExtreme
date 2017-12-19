create table Clientes(
ClienteId int identity(1,1) Primary key,
Nombres varchar(100),
Direccion varchar(125),
Telefono varchar(15),
Email varchar(125)
);

create table Peliculas (
PeliculaId int identity(1,1) primary key,
Titulo varchar(80),
Genero varchar(80),
Existencia int,
Duracion int,
Precio money
);

create table Facturas (
FacturaId int identity(1,1) primary key,
ClienteId int,
Fecha date,
CantidadPelicula int,
SubTotal money,
Total money
);

create table FacturasDetalles (
Id int identity(1,1) primary key,
FacturaId int,
PeliculaId int,
Titulo varchar(80),
Cantidad int,
Precio money
);     