
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/13/2023 21:33:00
-- Generated from EDMX file: C:\Users\josse\source\repos\MiniBandidas\MiniBandidas\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DBMini_Bandidas];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Pedido_Productos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pedido] DROP CONSTRAINT [FK_Pedido_Productos];
GO
IF OBJECT_ID(N'[dbo].[FK_Usuarios_Estados]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_Usuarios_Estados];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Estados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Estados];
GO
IF OBJECT_ID(N'[dbo].[Pedido]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pedido];
GO
IF OBJECT_ID(N'[dbo].[Productos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Productos];
GO
IF OBJECT_ID(N'[dbo].[rol_operacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[rol_operacion];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Estados'
CREATE TABLE [dbo].[Estados] (
    [id] int  NOT NULL,
    [descripcion] varchar(50)  NOT NULL
);
GO

-- Creating table 'Pedido'
CREATE TABLE [dbo].[Pedido] (
    [numPedido] int  NOT NULL,
    [producto] int  NOT NULL,
    [subtotal] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'Productos'
CREATE TABLE [dbo].[Productos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [presentacion] varchar(50)  NOT NULL,
    [topping1] varchar(50)  NOT NULL,
    [topping2] varchar(50)  NOT NULL,
    [cantidad] int  NOT NULL,
    [precio] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'rol_operacion'
CREATE TABLE [dbo].[rol_operacion] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idRol] int  NOT NULL,
    [idOperacion] int  NOT NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [id] int IDENTITY(1,1) NOT NULL,
    [email] varchar(50)  NOT NULL,
    [nombre] varchar(20)  NOT NULL,
    [apellido] varchar(20)  NULL,
    [telefono] varchar(50)  NULL,
    [estado] int  NOT NULL,
    [cedula] varchar(10)  NOT NULL,
    [contrasenna] varchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Estados'
ALTER TABLE [dbo].[Estados]
ADD CONSTRAINT [PK_Estados]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [numPedido] in table 'Pedido'
ALTER TABLE [dbo].[Pedido]
ADD CONSTRAINT [PK_Pedido]
    PRIMARY KEY CLUSTERED ([numPedido] ASC);
GO

-- Creating primary key on [id] in table 'Productos'
ALTER TABLE [dbo].[Productos]
ADD CONSTRAINT [PK_Productos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'rol_operacion'
ALTER TABLE [dbo].[rol_operacion]
ADD CONSTRAINT [PK_rol_operacion]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [estado] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK_Usuarios_Estados]
    FOREIGN KEY ([estado])
    REFERENCES [dbo].[Estados]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Usuarios_Estados'
CREATE INDEX [IX_FK_Usuarios_Estados]
ON [dbo].[Usuarios]
    ([estado]);
GO

-- Creating foreign key on [numPedido] in table 'Pedido'
ALTER TABLE [dbo].[Pedido]
ADD CONSTRAINT [FK_Pedido_Productos]
    FOREIGN KEY ([numPedido])
    REFERENCES [dbo].[Productos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------