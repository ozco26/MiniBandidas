
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/19/2023 13:36:40
-- Generated from EDMX file: C:\Users\pa_or\Desktop\MiniBandidas\MiniBandidas\Models\Model1.edmx
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

IF OBJECT_ID(N'[dbo].[FK_DetallePedido_Pedido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePedido] DROP CONSTRAINT [FK_DetallePedido_Pedido];
GO
IF OBJECT_ID(N'[dbo].[FK_DetallePedido_Producto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePedido] DROP CONSTRAINT [FK_DetallePedido_Producto];
GO
IF OBJECT_ID(N'[dbo].[FK_DetallePedido_Topping1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePedido] DROP CONSTRAINT [FK_DetallePedido_Topping1];
GO
IF OBJECT_ID(N'[dbo].[FK_DetallePedido_Topping2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePedido] DROP CONSTRAINT [FK_DetallePedido_Topping2];
GO
IF OBJECT_ID(N'[dbo].[FK_Usuarios_Estados]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_Usuarios_Estados];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DetallePedido]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetallePedido];
GO
IF OBJECT_ID(N'[dbo].[Estados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Estados];
GO
IF OBJECT_ID(N'[dbo].[Pedido]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pedido];
GO
IF OBJECT_ID(N'[dbo].[Producto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Producto];
GO
IF OBJECT_ID(N'[dbo].[rol_operacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[rol_operacion];
GO
IF OBJECT_ID(N'[dbo].[Topping]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Topping];
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

-- Creating table 'DetallePedido'
CREATE TABLE [dbo].[DetallePedido] (
    [id] int IDENTITY(1,1) NOT NULL,
    [numPedido] int  NOT NULL,
    [idProducto] int  NOT NULL,
    [cantidad] int  NOT NULL,
    [idTopping1] int  NOT NULL,
    [idTopping2] int  NOT NULL
);
GO

-- Creating table 'Pedido'
CREATE TABLE [dbo].[Pedido] (
    [numPedido] int IDENTITY(1,1) NOT NULL,
    [subtotal] decimal(19,2)  NOT NULL,
    [total] decimal(19,2)  NOT NULL
);
GO

-- Creating table 'Producto'
CREATE TABLE [dbo].[Producto] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nomProducto] varchar(50)  NOT NULL,
    [precio] decimal(19,2)  NOT NULL
);
GO

-- Creating table 'Topping'
CREATE TABLE [dbo].[Topping] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nomTopping] varchar(50)  NOT NULL
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

-- Creating primary key on [id] in table 'DetallePedido'
ALTER TABLE [dbo].[DetallePedido]
ADD CONSTRAINT [PK_DetallePedido]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [numPedido] in table 'Pedido'
ALTER TABLE [dbo].[Pedido]
ADD CONSTRAINT [PK_Pedido]
    PRIMARY KEY CLUSTERED ([numPedido] ASC);
GO

-- Creating primary key on [id] in table 'Producto'
ALTER TABLE [dbo].[Producto]
ADD CONSTRAINT [PK_Producto]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Topping'
ALTER TABLE [dbo].[Topping]
ADD CONSTRAINT [PK_Topping]
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

-- Creating foreign key on [numPedido] in table 'DetallePedido'
ALTER TABLE [dbo].[DetallePedido]
ADD CONSTRAINT [FK_DetallePedido_Pedido]
    FOREIGN KEY ([numPedido])
    REFERENCES [dbo].[Pedido]
        ([numPedido])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetallePedido_Pedido'
CREATE INDEX [IX_FK_DetallePedido_Pedido]
ON [dbo].[DetallePedido]
    ([numPedido]);
GO

-- Creating foreign key on [idProducto] in table 'DetallePedido'
ALTER TABLE [dbo].[DetallePedido]
ADD CONSTRAINT [FK_DetallePedido_Producto]
    FOREIGN KEY ([idProducto])
    REFERENCES [dbo].[Producto]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetallePedido_Producto'
CREATE INDEX [IX_FK_DetallePedido_Producto]
ON [dbo].[DetallePedido]
    ([idProducto]);
GO

-- Creating foreign key on [idTopping1] in table 'DetallePedido'
ALTER TABLE [dbo].[DetallePedido]
ADD CONSTRAINT [FK_DetallePedido_Topping1]
    FOREIGN KEY ([idTopping1])
    REFERENCES [dbo].[Topping]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetallePedido_Topping1'
CREATE INDEX [IX_FK_DetallePedido_Topping1]
ON [dbo].[DetallePedido]
    ([idTopping1]);
GO

-- Creating foreign key on [idTopping2] in table 'DetallePedido'
ALTER TABLE [dbo].[DetallePedido]
ADD CONSTRAINT [FK_DetallePedido_Topping2]
    FOREIGN KEY ([idTopping2])
    REFERENCES [dbo].[Topping]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetallePedido_Topping2'
CREATE INDEX [IX_FK_DetallePedido_Topping2]
ON [dbo].[DetallePedido]
    ([idTopping2]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------