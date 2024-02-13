--CREATE DATABASE [KolboldPaintingDb]

--Creating Tables 

CREATE TABLE [KoboldUser] 
(
    [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
    [AspNetUserID] nvarchar(500),
    [FirstName] nvarchar(64),
    [LastName] nvarchar(64)
)

CREATE TABLE [Tutorials] 
(
    [KoboldUserID] int,
    [VideoUrl] nvarchar(500)
)


CREATE TABLE [OwnedPaint]
(
    [KoboldUserID] int,
    [PaintID] int
)

CREATE TABLE [WantedPaint]
(
    [KoboldUserID] int,
    [PaintID] int
)

CREATE TABLE [RefillPaint]
(
    [KoboldUserID] int,
    [PaintID] int
)

CREATE TABLE [Paints]
(
    [ID] int PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [PaintName] nvarchar(64),
    [CompanyID] int,
    [PaintTypeID] int
)

CREATE TABLE [Company]
(
    [ID] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [CompanyName] NVARCHAR(100)
)

CREATE TABLE [PaintType] 
(
    [ID] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [TypeOfPaint] NVARCHAR(100)
)



CREATE TABLE [PaintRecipes] 
(
    [ID] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [KoboldUserID] int,
    [RecipeName] NVARCHAR(50),
    [Description] NVARCHAR(MAX)
)


CREATE TABLE [PaintsForRecipe] 
(
    [RecipeID] int,
    [PaintID] int
)

ALTER TABLE [Tutorials] ADD CONSTRAINT [Tutorials_FK_KoboldUserID]  FOREIGN KEY ([KoboldUserID]) REFERENCES [KoboldUser] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [OwnedPaint] ADD CONSTRAINT [OwnedPaint_FK_KoboldUserID]  FOREIGN KEY ([KoboldUserID]) REFERENCES [KoboldUser] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [WantedPaint] ADD CONSTRAINT [WantedPaint_FK_KoboldUserID]  FOREIGN KEY ([KoboldUserID]) REFERENCES [KoboldUser] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [RefillPaint] ADD CONSTRAINT [RefillPaint_FK_KoboldUserID]  FOREIGN KEY ([KoboldUserID]) REFERENCES [KoboldUser] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [OwnedPaint] ADD CONSTRAINT [OwnedPaint_FK_PaintID]  FOREIGN KEY ([PaintID]) REFERENCES [Paints] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [WantedPaint] ADD CONSTRAINT [WantedPaint_FK_PaintID]  FOREIGN KEY ([PaintID]) REFERENCES [Paints] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [RefillPaint] ADD CONSTRAINT [RefillPaint_FK_PaintID]  FOREIGN KEY ([PaintID]) REFERENCES [Paints] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [Paints] ADD CONSTRAINT [Paints_FK_CompanyID]  FOREIGN KEY ([CompanyID]) REFERENCES [Company] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [Paints] ADD CONSTRAINT [Paints_FK_PaintTypeID]  FOREIGN KEY ([PaintTypeID]) REFERENCES [PaintType] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [PaintRecipes] ADD CONSTRAINT [PaintRecipes_FK_KoboldUserID]  FOREIGN KEY ([KoboldUserID]) REFERENCES [KoboldUser] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [PaintsForRecipe] ADD CONSTRAINT [PaintsForRecipe_FK_RecipeID]  FOREIGN KEY ([RecipeID]) REFERENCES [PaintRecipes] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [PaintsForRecipe] ADD CONSTRAINT [PaintsForRecipe_FK_PaintID]  FOREIGN KEY ([PaintID]) REFERENCES [Paints] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
