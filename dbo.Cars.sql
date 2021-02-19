CREATE TABLE [dbo].[Cars]
(
    [Id]          INT           NOT NULL,
    [BrandId]     INT           NOT NULL,
    [ColorId]     INT           NOT NULL,
    [ModelYear]   INT           NOT NULL,
    [DailyPrice]  INT           NOT NULL,
    [Description] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED ([Id] ASC)
);
