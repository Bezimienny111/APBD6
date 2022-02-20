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

CREATE TABLE [Doctor] (
    [IdDoctor] int NOT NULL,
    [FirstName] nvarchar(100) NOT NULL,
    [LastName] nvarchar(100) NOT NULL,
    [Email] nvarchar(100) NOT NULL,
    CONSTRAINT [Doctor_PK] PRIMARY KEY ([IdDoctor])
);
GO

CREATE TABLE [Medicament] (
    [IdMedicament] int NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [Description] nvarchar(100) NOT NULL,
    [Type] nvarchar(100) NOT NULL,
    CONSTRAINT [Medicament_PK] PRIMARY KEY ([IdMedicament])
);
GO

CREATE TABLE [Patient] (
    [IdPatient] int NOT NULL,
    [FirstName] nvarchar(100) NOT NULL,
    [LastName] nvarchar(100) NOT NULL,
    [Birthdate] datetime2 NOT NULL,
    CONSTRAINT [Patient_PK] PRIMARY KEY ([IdPatient])
);
GO

CREATE TABLE [Prescription] (
    [IdPrescription] int NOT NULL,
    [Date] datetime2 NOT NULL,
    [DueDate] datetime2 NOT NULL,
    [IdPatient] int NOT NULL,
    [IdDoctor] int NOT NULL,
    CONSTRAINT [Prescritpion_PK] PRIMARY KEY ([IdPrescription]),
    CONSTRAINT [Prescription_Doctor] FOREIGN KEY ([IdDoctor]) REFERENCES [Doctor] ([IdDoctor]) ON DELETE NO ACTION,
    CONSTRAINT [Prescription_Patient] FOREIGN KEY ([IdPatient]) REFERENCES [Patient] ([IdPatient]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Prescription_Medicament] (
    [IdMedicament] int NOT NULL,
    [IdPrescription] int NOT NULL,
    [Dose] int NOT NULL,
    [Details] nvarchar(max) NOT NULL,
    CONSTRAINT [Prescription_Medicament_PK] PRIMARY KEY ([IdMedicament], [IdPrescription]),
    CONSTRAINT [Prescription_Medicament_Medicament] FOREIGN KEY ([IdMedicament]) REFERENCES [Medicament] ([IdMedicament]) ON DELETE NO ACTION,
    CONSTRAINT [Prescription_Medicament_Prescription] FOREIGN KEY ([IdPrescription]) REFERENCES [Prescription] ([IdPrescription]) ON DELETE NO ACTION
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdDoctor', N'Email', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Doctor]'))
    SET IDENTITY_INSERT [Doctor] ON;
INSERT INTO [Doctor] ([IdDoctor], [Email], [FirstName], [LastName])
VALUES (1, N'0dot25l@gmail.com', N'Jan', N'Sobieski'),
(2, N'0dot50l@gmail.com', N'Pan', N'Tadeusz');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdDoctor', N'Email', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Doctor]'))
    SET IDENTITY_INSERT [Doctor] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdMedicament', N'Description', N'Name', N'Type') AND [object_id] = OBJECT_ID(N'[Medicament]'))
    SET IDENTITY_INSERT [Medicament] ON;
INSERT INTO [Medicament] ([IdMedicament], [Description], [Name], [Type])
VALUES (10, N'z ABPD', N'ITN', N'Dropsy'),
(20, N' to ITN', N'APBD', N'Turbo dropsy'),
(40, N'po co', N'DTO', N'Alkohol');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdMedicament', N'Description', N'Name', N'Type') AND [object_id] = OBJECT_ID(N'[Medicament]'))
    SET IDENTITY_INSERT [Medicament] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdPatient', N'Birthdate', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Patient]'))
    SET IDENTITY_INSERT [Patient] ON;
INSERT INTO [Patient] ([IdPatient], [Birthdate], [FirstName], [LastName])
VALUES (0, '1993-01-05T00:00:00.0000000+01:00', N'aaa', N'bbb'),
(1, '1993-01-05T00:00:00.0000000+01:00', N'ccc', N'ddd'),
(2, '1993-01-05T00:00:00.0000000+01:00', N'eee', N'fff'),
(3, '1993-01-05T00:00:00.0000000+01:00', N'ggg', N'hhh');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdPatient', N'Birthdate', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Patient]'))
    SET IDENTITY_INSERT [Patient] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdPrescription', N'Date', N'DueDate', N'IdDoctor', N'IdPatient') AND [object_id] = OBJECT_ID(N'[Prescription]'))
    SET IDENTITY_INSERT [Prescription] ON;
INSERT INTO [Prescription] ([IdPrescription], [Date], [DueDate], [IdDoctor], [IdPatient])
VALUES (111, '2021-06-06T00:00:00.0000000+02:00', '2050-06-01T00:00:00.0000000+02:00', 1, 0),
(112, '2021-06-06T00:00:00.0000000+02:00', '2050-06-01T00:00:00.0000000+02:00', 1, 1),
(113, '2021-06-06T00:00:00.0000000+02:00', '2050-06-01T00:00:00.0000000+02:00', 1, 2),
(114, '2021-06-06T00:00:00.0000000+02:00', '2050-07-01T00:00:00.0000000+02:00', 2, 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdPrescription', N'Date', N'DueDate', N'IdDoctor', N'IdPatient') AND [object_id] = OBJECT_ID(N'[Prescription]'))
    SET IDENTITY_INSERT [Prescription] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdMedicament', N'IdPrescription', N'Details', N'Dose') AND [object_id] = OBJECT_ID(N'[Prescription_Medicament]'))
    SET IDENTITY_INSERT [Prescription_Medicament] ON;
INSERT INTO [Prescription_Medicament] ([IdMedicament], [IdPrescription], [Details], [Dose])
VALUES (20, 111, N'Przed egzaminem', 2),
(10, 112, N'Przed cwiczeniami', 1),
(40, 113, N'Po wykładach', 5),
(40, 114, N'Przed APBD', 200);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdMedicament', N'IdPrescription', N'Details', N'Dose') AND [object_id] = OBJECT_ID(N'[Prescription_Medicament]'))
    SET IDENTITY_INSERT [Prescription_Medicament] OFF;
GO

CREATE INDEX [IX_Prescription_IdDoctor] ON [Prescription] ([IdDoctor]);
GO

CREATE INDEX [IX_Prescription_IdPatient] ON [Prescription] ([IdPatient]);
GO

CREATE INDEX [IX_Prescription_Medicament_IdPrescription] ON [Prescription_Medicament] ([IdPrescription]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210606110855_CreateBase', N'5.0.6');
GO

COMMIT;
GO

