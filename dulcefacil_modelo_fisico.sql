
CREATE DATABASE DulceFacil;
go

USE  DulceFacil;



CREATE TABLE Rol (
    IdRol INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(50) NOT NULL
);

CREATE TABLE Usuario (
    IdUsuario INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(100),
    Email VARCHAR(100),
    PasswordHash VARCHAR(200),
    IdRol INT,
    FOREIGN KEY (IdRol) REFERENCES Rol(IdRol)
);

CREATE TABLE Cliente (
    IdCliente INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(100),
    Tipo VARCHAR(20), -- Mayorista o Minorista
    FrecuenciaCompra VARCHAR(50)
);

CREATE TABLE Ubicacion (
    IdUbicacion INT PRIMARY KEY IDENTITY,
    IdCliente INT UNIQUE,
    Latitud DECIMAL(9,6),
    Longitud DECIMAL(9,6),
    Direccion VARCHAR(200),
    FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente)
);

CREATE TABLE Producto (
    IdProducto INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(100),
    Precio DECIMAL(10,2),
    Stock INT
);

CREATE TABLE Pedido (
    IdPedido INT PRIMARY KEY IDENTITY,
    Fecha DATETIME,
    IdCliente INT,
    Estado VARCHAR(50),
    FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente)
);

CREATE TABLE DetallePedido (
    IdDetalle INT PRIMARY KEY IDENTITY,
    IdPedido INT,
    IdProducto INT,
    Cantidad INT,
    PrecioUnitario DECIMAL(10,2),
    FOREIGN KEY (IdPedido) REFERENCES Pedido(IdPedido),
    FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto)
);

CREATE TABLE Ruta (
    IdRuta INT PRIMARY KEY IDENTITY,
    Fecha DATETIME,
    IdUsuario INT,
    Descripcion VARCHAR(200),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);

CREATE TABLE Entrega (
    IdEntrega INT PRIMARY KEY IDENTITY,
    IdRuta INT,
    IdPedido INT,
    HoraEntrega DATETIME,
    EstadoEntrega VARCHAR(50),
    FOREIGN KEY (IdRuta) REFERENCES Ruta(IdRuta),
    FOREIGN KEY (IdPedido) REFERENCES Pedido(IdPedido)
);
