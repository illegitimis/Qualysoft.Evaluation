IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

IF OBJECT_ID(N'[dbo].[Requests]') IS NULL
BEGIN
CREATE TABLE [dbo].[Requests] (
    [Id] int NOT NULL,
    [Name] nvarchar(max) NULL DEFAULT N'',
    [Visits] int NULL,
    [Date] datetime2 NOT NULL DEFAULT '2018-10-31T21:56:47.7160000Z',
    CONSTRAINT [PK_Requests] PRIMARY KEY ([Id])
);
END;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20181031215648_InitialCreate', N'2.1.4-rtm-31024');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[Requests]') AND [c].[name] = N'Date');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[Requests] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [dbo].[Requests] ALTER COLUMN [Date] datetime2 NOT NULL;
ALTER TABLE [dbo].[Requests] ADD DEFAULT '2018-10-31T22:20:23.2700000Z' FOR [Date];

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Date', N'Name', N'Visits') AND [object_id] = OBJECT_ID(N'[dbo].[Requests]'))
    SET IDENTITY_INSERT [dbo].[Requests] ON;
INSERT INTO [dbo].[Requests] ([Id], [Date], [Name], [Visits])
VALUES (1, '2018-10-31T22:20:23.2710000Z', N'William Shakespeare', 13);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Date', N'Name', N'Visits') AND [object_id] = OBJECT_ID(N'[dbo].[Requests]'))
    SET IDENTITY_INSERT [dbo].[Requests] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Date', N'Name', N'Visits') AND [object_id] = OBJECT_ID(N'[dbo].[Requests]'))
    SET IDENTITY_INSERT [dbo].[Requests] ON;
INSERT INTO [dbo].[Requests] ([Id], [Date], [Name], [Visits])
VALUES (2, '2018-11-01T00:20:23.2720000+02:00', N'io', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Date', N'Name', N'Visits') AND [object_id] = OBJECT_ID(N'[dbo].[Requests]'))
    SET IDENTITY_INSERT [dbo].[Requests] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20181031222023_Seed', N'2.1.4-rtm-31024');

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[Requests]') AND [c].[name] = N'Date');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[Requests] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [dbo].[Requests] ALTER COLUMN [Date] datetime2 NOT NULL;
ALTER TABLE [dbo].[Requests] ADD DEFAULT '2018-11-01T09:33:48.7450000Z' FOR [Date];

GO

UPDATE [dbo].[Requests] SET [Date] = '2018-03-23T18:39:54.0470000+02:00', [Name] = N'Tyler Jaskolski', [Visits] = 982484765
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [dbo].[Requests] SET [Date] = '2018-06-04T06:15:38.4360000+03:00', [Name] = N'Craig Adams'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Date', N'Name', N'Visits') AND [object_id] = OBJECT_ID(N'[dbo].[Requests]'))
    SET IDENTITY_INSERT [dbo].[Requests] ON;
INSERT INTO [dbo].[Requests] ([Id], [Date], [Name], [Visits])
VALUES (0, '2018-02-27T00:19:30.4000000+02:00', N'Raymond Krajcik', 1793900487),
(72, '2016-08-29T10:52:45.0880000+03:00', N'Jaydon Beier', NULL),
(71, '2017-07-27T20:45:52.7130000+03:00', N'Anissa Konopelski', NULL),
(70, '2016-02-29T06:33:45.9550000+02:00', N'Magdalen Welch', NULL),
(69, '2016-03-06T13:10:25.3080000+02:00', N'Julianne Reilly', 1741602539),
(68, '2018-02-19T02:11:02.5530000+02:00', N'Amelia Bode', -540988167),
(67, '2016-03-31T03:36:39.4570000+03:00', N'Vincenza Greenholt', 1173485223),
(66, '2016-06-24T16:50:09.2170000+03:00', N'Muhammad Considine', 1642996289),
(65, '2017-08-19T15:42:33.2180000+03:00', N'Noe Nader', -409225655),
(64, '2018-02-19T12:15:33.8510000+02:00', N'Erin Kilback', 1926974441),
(63, '2018-05-16T00:48:42.6630000+03:00', N'Rex Sauer', NULL),
(62, '2017-05-07T14:20:02.5430000+03:00', N'Madilyn Gislason', NULL),
(61, '2018-01-28T20:42:49.2620000+02:00', N'Roman Rath', -763985458),
(60, '2018-06-29T03:02:12.9400000+03:00', N'Carli Hammes', 1600110950),
(59, '2017-03-18T02:54:58.2130000+02:00', N'Stanford Johnston', 1682122981),
(58, '2018-09-13T08:15:50.2930000+03:00', N'Lynn Torphy', -158765137),
(57, '2016-12-21T21:08:13.5640000+02:00', N'Sierra Thompson', NULL),
(56, '2016-05-28T10:24:15.3480000+03:00', N'Hassie Predovic', -2057014908),
(55, '2017-06-28T04:18:42.0040000+03:00', N'Josianne Hamill', NULL),
(54, '2016-12-30T04:47:19.6160000+02:00', N'Leone Kris', NULL),
(53, '2016-12-25T05:22:02.2930000+02:00', N'Dallin Hoppe', 114750922),
(73, '2018-10-04T13:19:31.2930000+03:00', N'Frida Sauer', -976221554),
(74, '2016-12-26T15:31:07.4720000+02:00', N'Herman Lang', NULL),
(76, '2016-12-04T06:45:39.6300000+02:00', N'Lily Hilll', 1365831145),
(52, '2016-11-22T13:51:53.2100000+02:00', N'Ezra Hirthe', 768053090),
(97, '2017-05-03T06:43:52.0050000+03:00', N'Wilbert Johnston', 1992575015),
(96, '2018-06-26T21:43:26.8440000+03:00', N'Beverly Torphy', -771501248),
(95, '2017-10-05T17:36:56.4920000+03:00', N'Keara Bednar', -1566633350),
(94, '2017-02-04T21:23:39.3640000+02:00', N'Randal O''Reilly', NULL),
(93, '2018-08-08T21:37:00.7340000+03:00', N'Maximus Orn', NULL),
(92, '2018-03-05T19:13:42.4680000+02:00', N'Derrick Schuppe', NULL),
(91, '2016-10-31T00:03:52.5390000+02:00', N'Suzanne Rohan', NULL),
(90, '2017-08-01T08:15:02.4140000+03:00', N'Marietta Donnelly', 116908294),
(89, '2016-07-31T23:38:24.4800000+03:00', N'Felicia Stiedemann', -202617306),
(88, '2018-08-04T08:13:42.8700000+03:00', N'Ettie Kovacek', 604327308),
(87, '2018-10-24T23:43:51.4420000+03:00', N'Trystan Waters', 331288287),
(86, '2017-04-19T23:52:28.9530000+03:00', N'Camren Wilkinson', -1799000837),
(85, '2018-04-20T04:29:58.5440000+03:00', N'Tyshawn Gutkowski', NULL),
(84, '2017-07-08T14:56:00.7640000+03:00', N'Reid Nienow', -197645456),
(83, '2016-10-24T20:50:13.0840000+03:00', N'Madilyn Dibbert', 1670074457),
(82, '2018-01-06T15:23:22.6480000+02:00', N'Floy Reynolds', -161318018),
(81, '2016-03-21T11:23:12.6850000+02:00', N'Efrain Dietrich', NULL),
(80, '2016-08-21T17:18:13.6360000+03:00', N'Lorenza Brakus', NULL),
(79, '2018-07-26T18:21:10.9450000+03:00', N'Karson Doyle', NULL),
(78, '2018-02-18T11:57:07.3850000+02:00', N'Marjolaine Will', 1961307603),
(77, '2016-02-07T08:03:43.4410000+02:00', N'Eulah Bartell', -509485414),
(75, '2016-11-03T15:07:27.5760000+02:00', N'Katlynn Walker', NULL),
(51, '2018-07-02T08:44:37.5100000+03:00', N'Emily Hansen', NULL),
(49, '2017-02-22T15:51:15.1290000+02:00', N'Dejah Friesen', 612448141),
(98, '2018-10-11T05:44:59.4820000+03:00', N'Nasir Dibbert', -1020991058),
(23, '2017-08-31T05:35:04.1800000+03:00', N'Sandrine Johnston', NULL),
(22, '2017-04-14T13:32:54.8320000+03:00', N'Vinnie Homenick', 727393510),
(21, '2018-09-02T14:59:33.7020000+03:00', N'Joseph Considine', NULL),
(20, '2018-05-23T00:54:51.4580000+03:00', N'Maurice Little', -1581725793),
(19, '2016-08-10T07:26:06.0520000+03:00', N'Randal Toy', NULL),
(18, '2016-09-03T05:10:24.9770000+03:00', N'Antonietta Crooks', -121786424),
(17, '2016-04-07T02:47:20.5300000+03:00', N'Leonel Willms', NULL),
(16, '2018-09-07T15:18:48.8670000+03:00', N'Zora Krajcik', NULL),
(15, '2017-04-04T13:05:10.3660000+03:00', N'Shany Windler', 728841488),
(14, '2016-02-23T00:46:06.1960000+02:00', N'Max Bashirian', NULL),
(13, '2017-07-13T12:52:55.2790000+03:00', N'Keaton Johnson', -1461088251),
(12, '2018-07-13T04:01:42.0190000+03:00', N'Jazlyn Goodwin', NULL),
(11, '2018-06-26T11:35:42.7490000+03:00', N'Marian Hayes', NULL),
(10, '2018-02-20T13:02:28.5750000+02:00', N'Khalil Gutkowski', 330794662),
(9, '2018-08-18T03:47:35.1400000+03:00', N'Maximilian Kuhlman', NULL),
(8, '2017-10-26T10:14:55.1470000+03:00', N'Candida Heidenreich', NULL),
(7, '2016-06-29T20:41:12.8210000+03:00', N'Logan Hoeger', -1134962077),
(6, '2017-02-12T17:08:06.5490000+02:00', N'Pierre Kohler', NULL),
(5, '2017-12-21T23:13:00.8640000+02:00', N'Brendon Nolan', -1877654022),
(4, '2017-09-08T19:00:49.0720000+03:00', N'Ubaldo Wilderman', NULL),
(3, '2016-09-02T21:27:06.8170000+03:00', N'Angel Wyman', 704568224),
(24, '2016-12-13T10:39:09.2580000+02:00', N'Leanna Shanahan', NULL),
(50, '2018-01-16T23:09:00.3980000+02:00', N'Jannie Schultz', -1865070130),
(25, '2018-10-13T21:10:57.0040000+03:00', N'Noah Lubowitz', NULL),
(27, '2017-02-13T23:40:48.3750000+02:00', N'Erling Lesch', -1213902140),
(48, '2018-05-24T04:56:55.5540000+03:00', N'Heidi Veum', NULL),
(47, '2016-09-07T07:23:19.9650000+03:00', N'Kennedi Berge', NULL),
(46, '2018-04-06T14:25:43.3540000+03:00', N'Leila Kovacek', -1226128067),
(45, '2017-11-09T21:55:09.5220000+02:00', N'Bridgette Grant', NULL),
(44, '2018-08-27T17:28:58.6860000+03:00', N'Karine Stoltenberg', -1378594139),
(43, '2018-08-31T11:51:43.9710000+03:00', N'Ubaldo Terry', NULL),
(42, '2016-12-24T10:22:48.9730000+02:00', N'Oma Rogahn', 1798217645),
(41, '2017-01-30T11:52:42.3880000+02:00', N'Jaclyn Quigley', -671372334),
(40, '2018-01-13T18:32:57.7810000+02:00', N'Adrianna Fadel', -1122084939),
(39, '2018-04-04T03:02:38.0310000+03:00', N'Neoma Windler', NULL),
(38, '2016-07-19T13:11:18.9250000+03:00', N'Garrison Tromp', NULL),
(37, '2018-07-15T16:59:26.6910000+03:00', N'Zachary Oberbrunner', NULL),
(36, '2016-10-09T07:58:08.4390000+03:00', N'Rosendo McLaughlin', -1374900390),
(35, '2016-10-23T01:49:37.1100000+03:00', N'Reilly Shanahan', NULL),
(34, '2016-03-05T12:40:56.4040000+02:00', N'Jillian Kozey', NULL),
(33, '2016-10-29T09:30:44.3960000+03:00', N'Gilbert Bashirian', NULL),
(32, '2017-01-10T04:52:05.5880000+02:00', N'Sean Hirthe', -2065987253),
(31, '2016-05-13T19:49:36.1740000+03:00', N'Constance Donnelly', NULL),
(30, '2017-02-22T12:20:40.6770000+02:00', N'Niko Jenkins', 1582089799),
(29, '2017-07-03T19:46:31.0550000+03:00', N'Sabryna Bradtke', -319243176),
(28, '2016-08-02T06:07:40.2710000+03:00', N'Sunny Kozey', NULL),
(26, '2017-01-18T14:56:01.5140000+02:00', N'Wellington Swift', 1057909330),
(99, '2017-08-15T06:52:53.1290000+03:00', N'Nayeli Upton', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Date', N'Name', N'Visits') AND [object_id] = OBJECT_ID(N'[dbo].[Requests]'))
    SET IDENTITY_INSERT [dbo].[Requests] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20181101093349_BogusFakerSeed', N'2.1.4-rtm-31024');

GO

