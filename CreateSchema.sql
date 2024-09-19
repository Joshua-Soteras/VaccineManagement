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

CREATE TABLE [Vaccines] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [DosesRequired] int NOT NULL,
    [DosesInBetween] int NOT NULL,
    [DosesRecieved] int NOT NULL,
    [TotalDosesLeft] int NOT NULL,
    CONSTRAINT [PK_Vaccines] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Patients] (
    [PatientId] int NOT NULL IDENTITY,
    [PatientName] nvarchar(max) NULL,
    [VaccineCompanyId] int NULL,
    [FirstDose] datetime2 NULL,
    [SecondDose] datetime2 NULL,
    CONSTRAINT [PK_Patients] PRIMARY KEY ([PatientId]),
    CONSTRAINT [FK_Patients_Vaccines_VaccineCompanyId] FOREIGN KEY ([VaccineCompanyId]) REFERENCES [Vaccines] ([Id])
);
GO

CREATE INDEX [IX_Patients_VaccineCompanyId] ON [Patients] ([VaccineCompanyId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240806082330_InitialSchema', N'8.0.7');
GO

COMMIT;
GO

