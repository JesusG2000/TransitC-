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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210123172355_Init')
BEGIN
    CREATE TABLE [UserRole] (
        [Id] int NOT NULL IDENTITY,
        [Role] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_UserRole] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210123172355_Init')
BEGIN
    CREATE TABLE [User] (
        [Id] int NOT NULL IDENTITY,
        [Login] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [PathToImg] nvarchar(max) NOT NULL,
        [Block] bit NOT NULL,
        [RoleId] int NOT NULL,
        CONSTRAINT [PK_User] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_User_UserRole_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [UserRole] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210123172355_Init')
BEGIN
    CREATE TABLE [Collection] (
        [Id] int NOT NULL IDENTITY,
        [Type] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [PathToImg] nvarchar(max) NULL,
        [UserId] int NULL,
        CONSTRAINT [PK_Collection] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Collection_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210123172355_Init')
BEGIN
    CREATE TABLE [Comment] (
        [Id] int NOT NULL IDENTITY,
        [Text] nvarchar(max) NULL,
        [DateTime] datetime2 NOT NULL,
        [UserId] int NULL,
        CONSTRAINT [PK_Comment] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Comment_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210123172355_Init')
BEGIN
    CREATE TABLE [Item] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [PathToImg] nvarchar(max) NULL,
        [Status] nvarchar(max) NULL,
        [BitMask] int NOT NULL,
        [CollectionId] int NULL,
        CONSTRAINT [PK_Item] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Item_Collection_CollectionId] FOREIGN KEY ([CollectionId]) REFERENCES [Collection] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210123172355_Init')
BEGIN
    CREATE TABLE [Field] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Value] nvarchar(max) NULL,
        [Type] nvarchar(max) NULL,
        [ItemId] int NULL,
        [CollectionId] int NULL,
        CONSTRAINT [PK_Field] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Field_Collection_CollectionId] FOREIGN KEY ([CollectionId]) REFERENCES [Collection] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Field_Item_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Item] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210123172355_Init')
BEGIN
    CREATE TABLE [Like] (
        [Id] int NOT NULL IDENTITY,
        [ItemId] int NULL,
        [UserId] int NULL,
        CONSTRAINT [PK_Like] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Like_Item_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Item] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Like_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210123172355_Init')
BEGIN
    CREATE TABLE [Tag] (
        [Id] int NOT NULL IDENTITY,
        [Value] nvarchar(max) NULL,
        [ItemId] int NULL,
        CONSTRAINT [PK_Tag] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Tag_Item_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Item] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210123172355_Init')
BEGIN
    CREATE INDEX [IX_Collection_UserId] ON [Collection] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210123172355_Init')
BEGIN
    CREATE INDEX [IX_Comment_UserId] ON [Comment] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210123172355_Init')
BEGIN
    CREATE INDEX [IX_Field_CollectionId] ON [Field] ([CollectionId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210123172355_Init')
BEGIN
    CREATE INDEX [IX_Field_ItemId] ON [Field] ([ItemId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210123172355_Init')
BEGIN
    CREATE INDEX [IX_Item_CollectionId] ON [Item] ([CollectionId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210123172355_Init')
BEGIN
    CREATE INDEX [IX_Like_ItemId] ON [Like] ([ItemId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210123172355_Init')
BEGIN
    CREATE INDEX [IX_Like_UserId] ON [Like] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210123172355_Init')
BEGIN
    CREATE INDEX [IX_Tag_ItemId] ON [Tag] ([ItemId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210123172355_Init')
BEGIN
    CREATE INDEX [IX_User_RoleId] ON [User] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210123172355_Init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210123172355_Init', N'5.0.2');
END;
GO

COMMIT;
GO

