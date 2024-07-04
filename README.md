Ez egy "képzeletbeli" telefonkönyv API készlete.
Folyamatosan fejlesztem, de a gerince már látható.

A mögöttes adattábla létrehozó scriptje [dbo] sablont feltételezve:

CREATE TABLE [dbo].[PhoneUsr](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TrzsSzam] [nvarchar](50) NULL,
	[FhNev] [nvarchar](50) NULL,
	[Nev] [nvarchar](100) NULL,
	[MhNev] [nvarchar](100) NULL,
	[FTrzsSzam] [nvarchar](50) NULL,
	[MPhoneNum] [nvarchar](50) NULL,
	[VPhoneNum] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[IsDeleted] [bit] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PhoneUsr] ADD  CONSTRAINT [DF_PhoneUsr_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
