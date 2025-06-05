-- Crear la base de datos
CREATE DATABASE Ecommerce;
GO

USE Ecommerce;
GO

CREATE TABLE TipoUsuario (
    id_tipo_usuario INT IDENTITY(1,1) PRIMARY KEY,
    descripcion VARCHAR(50) NOT NULL
);

CREATE TABLE Usuario (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    mail VARCHAR(100) NOT NULL UNIQUE,
    pass VARCHAR(50) NOT NULL,
    id_tipo_usuario INT NOT NULL,
    dni VARCHAR(20) NULL,
    nombre VARCHAR(50) NULL,
    apellido VARCHAR(50) NULL,
    direccion VARCHAR(100) NULL,
    ciudad VARCHAR(50) NULL,
    codigo_postal INT NULL,
    telefono VARCHAR(20) NULL,
    FOREIGN KEY (id_tipo_usuario) REFERENCES TipoUsuario(id_tipo_usuario)
);
-- Categoría
CREATE TABLE Categoria (
    id_categoria INT PRIMARY KEY IDENTITY(1,1),
    descripcion VARCHAR(100) NOT NULL
);

-- Producto
CREATE TABLE Producto (
    id_producto INT PRIMARY KEY IDENTITY(1,1),
    codigo VARCHAR(50) UNIQUE NOT NULL,
	nombre VARCHAR(50) NOT NULL,
    descripcion VARCHAR (1000) NOT NULL,
    precio DECIMAL(10,2) NOT NULL,
    stock INT NOT NULL,
    unidad_venta VARCHAR(20) NOT NULL, -- 'unidad', 'docena', etc.
    id_categoria INT NOT NULL,
	FOREIGN KEY (id_categoria) REFERENCES Categoria(id_categoria)
);

--Imagen
CREATE TABLE Imagen (
    id_imagen INT PRIMARY KEY IDENTITY(1,1),
    id_producto INT NOT NULL,
    imagen_url VARCHAR(1000) NOT NULL,
    FOREIGN KEY (id_producto) REFERENCES Producto(id_producto)
);

-- Carrito
CREATE TABLE Carrito (
    id_carrito INT PRIMARY KEY IDENTITY(1,1),
    id_usuario INT NULL,
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

-- Ítems del carrito
CREATE TABLE Carrito_Item (
    id_carrito INT NOT NULL,
    id_producto INT NOT NULL,
    cantidad INT NOT NULL,
    PRIMARY KEY (id_carrito, id_producto),
    FOREIGN KEY (id_carrito) REFERENCES Carrito(id_carrito),
    FOREIGN KEY (id_producto) REFERENCES Producto(id_producto)
);


-- Pedido
CREATE TABLE Pedido (
    id_pedido INT PRIMARY KEY IDENTITY(1,1),
    id_usuario INT NOT NULL,
    fecha_pedido DATETIME DEFAULT GETDATE() NOT NULL,
    metodo_entrega VARCHAR(20) NOT NULL, -- 'envio' o 'retiro' o tendria que ser int?
    fecha_entrega DATE NOT NULL,
    precio_total DECIMAL(10,2) NOT NULL,
	estado_pedido INT NOT NULL, --lo agregue dsps, ver dominio
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

-- Ítems del pedido
CREATE TABLE Pedido_Item (
    id_item_pedido INT PRIMARY KEY IDENTITY(1,1),
    id_pedido INT NOT NULL,
    id_producto INT NOT NULL,
    cantidad INT NOT NULL,
    precio DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (id_pedido) REFERENCES Pedido(id_pedido),
    FOREIGN KEY (id_producto) REFERENCES Producto(id_producto)
);

-- Pago
CREATE TABLE Pago (
    id_pago INT PRIMARY KEY IDENTITY(1,1),
    id_pedido INT NOT NULL,
    fecha_pago DATE NOT NULL,
    metodo_pago VARCHAR(50) NOT NULL,
    monto DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (id_pedido) REFERENCES Pedido(id_pedido)
);

-- Envío
CREATE TABLE Envio (
    id_envio INT PRIMARY KEY IDENTITY(1,1),
    id_pedido INT NOT NULL,
    fecha_entrega DATE NOT NULL,
    direccion VARCHAR(255) NOT NULL,
    barrio VARCHAR(100) NOT NULL,
    ciudad VARCHAR(100) NOT NULL,
    codigo_postal INT NOT NULL,
    FOREIGN KEY (id_pedido) REFERENCES Pedido(id_pedido)
);

-- Presupuesto (reemplaza Lista de Deseos)
CREATE TABLE Presupuesto (
    id_presupuesto INT PRIMARY KEY IDENTITY(1,1),
    id_usuario INT NOT NULL,
    fecha_solicitud DATETIME DEFAULT GETDATE() NOT NULL,
    total DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

-- Ítems del presupuesto
CREATE TABLE Presupuesto_Item (
    id_presupuesto INT NOT NULL,
    id_producto INT NOT NULL,
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(10,2) NOT NULL,
    PRIMARY KEY (id_presupuesto, id_producto),
    FOREIGN KEY (id_presupuesto) REFERENCES Presupuesto(id_presupuesto),
    FOREIGN KEY (id_producto) REFERENCES Producto(id_producto)
);