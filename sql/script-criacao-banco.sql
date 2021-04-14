/* script gerado usando o PM > Script-Migration -Context ApplicationDbContext **necessário pacote Microsoft.EntityFrameworkCore.SqlServer*/

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Anunciantes] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(100) NOT NULL,
    [Descricao] varchar(1000) NOT NULL,
    [Email] varchar(100) NOT NULL,
    [Telefone] varchar(11) NOT NULL,
    [Creci] varchar(20) NOT NULL,
    [Imagem] varchar(100) NOT NULL,
    CONSTRAINT [PK_Anunciantes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Imoveis] (
    [Id] uniqueidentifier NOT NULL,
    [AnuncianteId] uniqueidentifier NOT NULL,
    [Titulo] varchar(100) NOT NULL,
    [Descricao] varchar(1000) NOT NULL,
    [AreaTotal] decimal(18,2) NOT NULL,
    [AreaUtil] decimal(18,2) NOT NULL,
    [Quartos] int NOT NULL,
    [Banheiros] int NOT NULL,
    [Garagens] int NOT NULL,
    [Suites] int NOT NULL,
    [Valor] decimal(18,2) NOT NULL,
    [ValorCondominio] decimal(18,2) NULL,
    [TipoContrato] int NOT NULL,
    [TipoImovel] int NOT NULL,
    [Imagem] varchar(100) NOT NULL,
    CONSTRAINT [PK_Imoveis] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Imoveis_Anunciantes_AnuncianteId] FOREIGN KEY ([AnuncianteId]) REFERENCES [Anunciantes] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Enderecos] (
    [Id] uniqueidentifier NOT NULL,
    [ImovelId] uniqueidentifier NOT NULL,
    [Logradouro] varchar(200) NOT NULL,
    [Numero] varchar(50) NOT NULL,
    [Complemento] varchar(250) NULL,
    [Cep] varchar(8) NOT NULL,
    [Bairro] varchar(100) NOT NULL,
    [Cidade] varchar(100) NOT NULL,
    [Estado] varchar(50) NOT NULL,
    CONSTRAINT [PK_Enderecos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Enderecos_Imoveis_ImovelId] FOREIGN KEY ([ImovelId]) REFERENCES [Imoveis] ([Id]) ON DELETE NO ACTION
);
GO

CREATE UNIQUE INDEX [IX_Enderecos_ImovelId] ON [Enderecos] ([ImovelId]);
GO

CREATE INDEX [IX_Imoveis_AnuncianteId] ON [Imoveis] ([AnuncianteId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210308232329_InitialCreate', N'5.0.3');
GO

COMMIT;
GO

