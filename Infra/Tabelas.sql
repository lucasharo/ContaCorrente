CREATE TABLE [dbo].[ContaCorrente] (
    [Id]    INT             IDENTITY (1, 1) NOT NULL,
    [Nome]  VARCHAR (255)   NOT NULL,
    [Saldo] DECIMAL (19, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Lancamento] (
    [Id]            INT              IDENTITY (1, 1) NOT NULL,
    [ContaCorrente] INT              NOT NULL,
    [Valor]         DECIMAL (19, 2)  NOT NULL,
    [Tipo]          CHAR (1)         NOT NULL,
    [IdTransacao]   UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Lancamento_ContaCorrente] FOREIGN KEY ([ContaCorrente]) REFERENCES [dbo].[ContaCorrente] ([Id])
);