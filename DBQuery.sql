CREATE TABLE [dbo].[Customer] (
    [CustomerID]       INT           IDENTITY (1, 1) NOT NULL,
    [CustomerName]     VARCHAR (50)  NOT NULL,
    [CustomerEmail]    VARCHAR (50)  NOT NULL,
    [CustomerPassword] VARCHAR (50)  NOT NULL,
    [CustomerGender]   VARCHAR (6)   NOT NULL,
    [CustomerAddress]  VARCHAR (100) NOT NULL,
    [CustomerRole]     VARCHAR (5)   NOT NULL,
    PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);

CREATE TABLE [dbo].[Artist] (
    [ArtistID]    INT          IDENTITY (1, 1) NOT NULL,
    [ArtistName]  VARCHAR (50) NOT NULL,
    [ArtistImage] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([ArtistID] ASC)
);

CREATE TABLE [dbo].[Album] (
    [AlbumID]          INT           IDENTITY (1, 1) NOT NULL,
    [ArtistID]         INT           NOT NULL,
    [AlbumName]        VARCHAR (50)  NOT NULL,
    [AlbumImage]       VARCHAR (50)  NOT NULL,
    [AlbumPrice]       INT           NOT NULL,
    [AlbumStock]       INT           NOT NULL,
    [AlbumDescription] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([AlbumID] ASC),
    CONSTRAINT [FK_Album_Artist] FOREIGN KEY ([ArtistID]) REFERENCES [dbo].[Artist] ([ArtistID]) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE [dbo].[Cart] (
    [CartID]     INT IDENTITY (1, 1) NOT NULL,
    [CustomerID] INT NOT NULL,
    [AlbumID]    INT NOT NULL,
    [Qty]        INT NOT NULL,
    PRIMARY KEY CLUSTERED ([CartID] ASC),
    CONSTRAINT [FK_Cart_Album] FOREIGN KEY ([AlbumID]) REFERENCES [dbo].[Album] ([AlbumID]),
    CONSTRAINT [FK_Cart_Customer] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID])
);


CREATE TABLE [dbo].[TransactionHeader] (
    [TransactionID]   INT      IDENTITY (1, 1) NOT NULL,
    [TransactionDate] DATETIME NOT NULL,
    [CustomerID]      INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([TransactionID] ASC),
    CONSTRAINT [FK_TransactionHeader_Customer] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID])
);

CREATE TABLE [dbo].[TransactionDetail] (
    [TransactionDetailID] INT IDENTITY (1, 1) NOT NULL,
    [TransactionID]       INT NOT NULL,
    [AlbumID]             INT NOT NULL,
    [Qty]                 INT NOT NULL,
    CONSTRAINT [PK_TransactionDetail] PRIMARY KEY CLUSTERED ([TransactionDetailID] ASC),
    CONSTRAINT [FK_TransactionDetail_TransactionHeader] FOREIGN KEY ([TransactionID]) REFERENCES [dbo].[TransactionHeader] ([TransactionID]),
    CONSTRAINT [FK_TransactionDetail_Album] FOREIGN KEY ([AlbumID]) REFERENCES [dbo].[Album] ([AlbumID])
);



