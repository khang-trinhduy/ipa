IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181230131558_InitialIdentityServerPersistedGrantDbMigration')
BEGIN
    CREATE TABLE [DeviceCodes] (
        [DeviceCode] nvarchar(200) NOT NULL,
        [UserCode] nvarchar(200) NOT NULL,
        [SubjectId] nvarchar(200) NULL,
        [ClientId] nvarchar(200) NOT NULL,
        [CreationTime] datetime2 NOT NULL,
        [Expiration] datetime2 NOT NULL,
        [Data] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_DeviceCodes] PRIMARY KEY ([UserCode])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181230131558_InitialIdentityServerPersistedGrantDbMigration')
BEGIN
    CREATE TABLE [PersistedGrants] (
        [Key] nvarchar(200) NOT NULL,
        [Type] nvarchar(50) NOT NULL,
        [SubjectId] nvarchar(200) NULL,
        [ClientId] nvarchar(200) NOT NULL,
        [CreationTime] datetime2 NOT NULL,
        [Expiration] datetime2 NULL,
        [Data] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_PersistedGrants] PRIMARY KEY ([Key])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181230131558_InitialIdentityServerPersistedGrantDbMigration')
BEGIN
    CREATE UNIQUE INDEX [IX_DeviceCodes_DeviceCode] ON [DeviceCodes] ([DeviceCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181230131558_InitialIdentityServerPersistedGrantDbMigration')
BEGIN
    CREATE INDEX [IX_PersistedGrants_SubjectId_ClientId_Type] ON [PersistedGrants] ([SubjectId], [ClientId], [Type]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20181230131558_InitialIdentityServerPersistedGrantDbMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20181230131558_InitialIdentityServerPersistedGrantDbMigration', N'2.1.4-rtm-31024');
END;

GO

