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

CREATE TABLE [Character] (
    [Id] int NOT NULL IDENTITY,
    [CurrentHealth] int NOT NULL,
    [MaxHealth] int NOT NULL,
    [IsDead] bit NOT NULL,
    [CharacterType] nvarchar(13) NOT NULL, -- Discriminator column
    [NpcID] int NULL,
    [NpcName] nvarchar(max) NULL,
    [MaxDamage] int NULL,
    [AwardXP] int NULL,
    [AwardLoot] int NULL,
    [PlayerID] int NULL,
    [PlayerName] nvarchar(max) NULL,
    [Loot] int NULL,
    [Xp] int NULL,
    [Level] int NULL,
    CONSTRAINT [PK_Character] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Skill] (
    [SkillID] int NOT NULL IDENTITY,
    [SkillName] nvarchar(max) NOT NULL,
    [PlayerId] int NULL,
    CONSTRAINT [PK_Skill] PRIMARY KEY ([SkillID]),
    CONSTRAINT [FK_Skill_Player] FOREIGN KEY ([PlayerId]) REFERENCES [Character] ([Id])
);
GO

CREATE INDEX [IX_Skill_PlayerId] ON [Skill] ([PlayerId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240831184227_InitialCreate', N'8.0.8');
GO

COMMIT;
GO
