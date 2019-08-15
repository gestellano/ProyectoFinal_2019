
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/16/2019 00:23:20
-- Generated from EDMX file: C:\Users\Gaston\Downloads\PedidoSoftware\PedidoSoftware\WebApplication3\modeloBD.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PedidosDataBase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PedidoVendedor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PedidoSet] DROP CONSTRAINT [FK_PedidoVendedor];
GO
IF OBJECT_ID(N'[dbo].[FK_PedidoCliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PedidoSet] DROP CONSTRAINT [FK_PedidoCliente];
GO
IF OBJECT_ID(N'[dbo].[FK_PedidoLineaPedido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LineaPedidoSet] DROP CONSTRAINT [FK_PedidoLineaPedido];
GO
IF OBJECT_ID(N'[dbo].[FK_LineaPedidoArticulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArticuloSet] DROP CONSTRAINT [FK_LineaPedidoArticulo];
GO
IF OBJECT_ID(N'[dbo].[FK_Vendedor_inherits_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioSet_Vendedor] DROP CONSTRAINT [FK_Vendedor_inherits_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Admin_inherits_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioSet_Admin] DROP CONSTRAINT [FK_Admin_inherits_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Desarrollador_inherits_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioSet_Desarrollador] DROP CONSTRAINT [FK_Desarrollador_inherits_Usuario];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UsuarioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioSet];
GO
IF OBJECT_ID(N'[dbo].[PedidoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PedidoSet];
GO
IF OBJECT_ID(N'[dbo].[ClienteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClienteSet];
GO
IF OBJECT_ID(N'[dbo].[LineaPedidoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LineaPedidoSet];
GO
IF OBJECT_ID(N'[dbo].[ArticuloSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArticuloSet];
GO
IF OBJECT_ID(N'[dbo].[UsuarioSet_Vendedor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioSet_Vendedor];
GO
IF OBJECT_ID(N'[dbo].[UsuarioSet_Admin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioSet_Admin];
GO
IF OBJECT_ID(N'[dbo].[UsuarioSet_Desarrollador]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioSet_Desarrollador];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UsuarioSet'
CREATE TABLE [dbo].[UsuarioSet] (
    [nickName] nvarchar(max)  NOT NULL,
    [passcode] nvarchar(max)  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [numEmpleado] int IDENTITY(1,1) NOT NULL,
    [celular] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PedidoSet'
CREATE TABLE [dbo].[PedidoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [fecha] datetime  NOT NULL,
    [estadoImpres] int  NOT NULL,
    [unidades] int  NOT NULL,
    [envio] int  NOT NULL,
    [Vendedor_numEmpleado] int  NOT NULL,
    [Cliente_Id] int  NOT NULL
);
GO

-- Creating table 'ClienteSet'
CREATE TABLE [dbo].[ClienteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [rut] nvarchar(max)  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [direccion] nvarchar(max)  NOT NULL,
    [telefono] nvarchar(max)  NOT NULL,
    [ciudad] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'LineaPedidoSet'
CREATE TABLE [dbo].[LineaPedidoSet] (
    [cantidad] nvarchar(max)  NOT NULL,
    [PedidoId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'ArticuloSet'
CREATE TABLE [dbo].[ArticuloSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [imagen] nvarchar(max)  NOT NULL,
    [LineaPedidoArticulo_Articulo_Id] int  NOT NULL
);
GO

-- Creating table 'UsuarioSet_Vendedor'
CREATE TABLE [dbo].[UsuarioSet_Vendedor] (
    [numEmpleado] int  NOT NULL
);
GO

-- Creating table 'UsuarioSet_Admin'
CREATE TABLE [dbo].[UsuarioSet_Admin] (
    [numEmpleado] int  NOT NULL
);
GO

-- Creating table 'UsuarioSet_Desarrollador'
CREATE TABLE [dbo].[UsuarioSet_Desarrollador] (
    [numEmpleado] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [numEmpleado] in table 'UsuarioSet'
ALTER TABLE [dbo].[UsuarioSet]
ADD CONSTRAINT [PK_UsuarioSet]
    PRIMARY KEY CLUSTERED ([numEmpleado] ASC);
GO

-- Creating primary key on [Id] in table 'PedidoSet'
ALTER TABLE [dbo].[PedidoSet]
ADD CONSTRAINT [PK_PedidoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClienteSet'
ALTER TABLE [dbo].[ClienteSet]
ADD CONSTRAINT [PK_ClienteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LineaPedidoSet'
ALTER TABLE [dbo].[LineaPedidoSet]
ADD CONSTRAINT [PK_LineaPedidoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ArticuloSet'
ALTER TABLE [dbo].[ArticuloSet]
ADD CONSTRAINT [PK_ArticuloSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [numEmpleado] in table 'UsuarioSet_Vendedor'
ALTER TABLE [dbo].[UsuarioSet_Vendedor]
ADD CONSTRAINT [PK_UsuarioSet_Vendedor]
    PRIMARY KEY CLUSTERED ([numEmpleado] ASC);
GO

-- Creating primary key on [numEmpleado] in table 'UsuarioSet_Admin'
ALTER TABLE [dbo].[UsuarioSet_Admin]
ADD CONSTRAINT [PK_UsuarioSet_Admin]
    PRIMARY KEY CLUSTERED ([numEmpleado] ASC);
GO

-- Creating primary key on [numEmpleado] in table 'UsuarioSet_Desarrollador'
ALTER TABLE [dbo].[UsuarioSet_Desarrollador]
ADD CONSTRAINT [PK_UsuarioSet_Desarrollador]
    PRIMARY KEY CLUSTERED ([numEmpleado] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Vendedor_numEmpleado] in table 'PedidoSet'
ALTER TABLE [dbo].[PedidoSet]
ADD CONSTRAINT [FK_PedidoVendedor]
    FOREIGN KEY ([Vendedor_numEmpleado])
    REFERENCES [dbo].[UsuarioSet_Vendedor]
        ([numEmpleado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedidoVendedor'
CREATE INDEX [IX_FK_PedidoVendedor]
ON [dbo].[PedidoSet]
    ([Vendedor_numEmpleado]);
GO

-- Creating foreign key on [Cliente_Id] in table 'PedidoSet'
ALTER TABLE [dbo].[PedidoSet]
ADD CONSTRAINT [FK_PedidoCliente]
    FOREIGN KEY ([Cliente_Id])
    REFERENCES [dbo].[ClienteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedidoCliente'
CREATE INDEX [IX_FK_PedidoCliente]
ON [dbo].[PedidoSet]
    ([Cliente_Id]);
GO

-- Creating foreign key on [PedidoId] in table 'LineaPedidoSet'
ALTER TABLE [dbo].[LineaPedidoSet]
ADD CONSTRAINT [FK_PedidoLineaPedido]
    FOREIGN KEY ([PedidoId])
    REFERENCES [dbo].[PedidoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedidoLineaPedido'
CREATE INDEX [IX_FK_PedidoLineaPedido]
ON [dbo].[LineaPedidoSet]
    ([PedidoId]);
GO

-- Creating foreign key on [LineaPedidoArticulo_Articulo_Id] in table 'ArticuloSet'
ALTER TABLE [dbo].[ArticuloSet]
ADD CONSTRAINT [FK_LineaPedidoArticulo]
    FOREIGN KEY ([LineaPedidoArticulo_Articulo_Id])
    REFERENCES [dbo].[LineaPedidoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LineaPedidoArticulo'
CREATE INDEX [IX_FK_LineaPedidoArticulo]
ON [dbo].[ArticuloSet]
    ([LineaPedidoArticulo_Articulo_Id]);
GO

-- Creating foreign key on [numEmpleado] in table 'UsuarioSet_Vendedor'
ALTER TABLE [dbo].[UsuarioSet_Vendedor]
ADD CONSTRAINT [FK_Vendedor_inherits_Usuario]
    FOREIGN KEY ([numEmpleado])
    REFERENCES [dbo].[UsuarioSet]
        ([numEmpleado])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [numEmpleado] in table 'UsuarioSet_Admin'
ALTER TABLE [dbo].[UsuarioSet_Admin]
ADD CONSTRAINT [FK_Admin_inherits_Usuario]
    FOREIGN KEY ([numEmpleado])
    REFERENCES [dbo].[UsuarioSet]
        ([numEmpleado])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [numEmpleado] in table 'UsuarioSet_Desarrollador'
ALTER TABLE [dbo].[UsuarioSet_Desarrollador]
ADD CONSTRAINT [FK_Desarrollador_inherits_Usuario]
    FOREIGN KEY ([numEmpleado])
    REFERENCES [dbo].[UsuarioSet]
        ([numEmpleado])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------