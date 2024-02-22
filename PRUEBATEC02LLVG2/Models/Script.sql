---Creación de la base de datos
Create Database PRUEBATEC02LLVG2

--hacemos uso de la base de datos
Use PRUEBATEC02LLVG2

-- Tabla de tipos de flores
CREATE TABLE Especies (
  id INT identity(1,1) PRIMARY KEY,
  nombre VARCHAR(20) not null
);

-- Tabla de flores
CREATE TABLE Flores (
  id INT Identity (1,1) PRIMARY KEY,
  nombre VARCHAR(20) Not null,
  Descripcion varchar(100) Not null,
  Precio decimal Not null,
  imagen Varbinary(Max),
  tipo_id INT,
  FOREIGN KEY (tipo_id) REFERENCES Especies (id)
);