
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/08/2016 19:59:07
-- Generated from EDMX file: C:\Users\Margaret Landefeld\Documents\Visual Studio 2015\Projects\TVShows_Networks\TVShowsNetworks\Models\TVshowsNetworks.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TVShowsNetworks];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[fk_network]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TVshows] DROP CONSTRAINT [fk_network];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TVnetworks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TVnetworks];
GO
IF OBJECT_ID(N'[dbo].[TVshows]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TVshows];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TVnetworks'
CREATE TABLE [dbo].[TVnetworks] (
    [NetworkID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NULL,
    [Logo] nvarchar(200)  NULL
);
GO

-- Creating table 'TVshows'
CREATE TABLE [dbo].[TVshows] (
    [ShowID] int IDENTITY(1,1) NOT NULL,
    [NetworkID] int  NOT NULL,
    [Title] nvarchar(100)  NULL,
    [Length] int  NULL,
    [Genre] nvarchar(100)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [NetworkID] in table 'TVnetworks'
ALTER TABLE [dbo].[TVnetworks]
ADD CONSTRAINT [PK_TVnetworks]
    PRIMARY KEY CLUSTERED ([NetworkID] ASC);
GO

-- Creating primary key on [ShowID] in table 'TVshows'
ALTER TABLE [dbo].[TVshows]
ADD CONSTRAINT [PK_TVshows]
    PRIMARY KEY CLUSTERED ([ShowID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [NetworkID] in table 'TVshows'
ALTER TABLE [dbo].[TVshows]
ADD CONSTRAINT [fk_network]
    FOREIGN KEY ([NetworkID])
    REFERENCES [dbo].[TVnetworks]
        ([NetworkID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_network'
CREATE INDEX [IX_fk_network]
ON [dbo].[TVshows]
    ([NetworkID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------