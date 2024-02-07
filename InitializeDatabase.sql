CREATE SCHEMA Sales AUTHORIZATION dbo
GO

CREATE TABLE Sales.Stores
(
	[Id] [int] NOT NULL,
	[StoreName] VARCHAR(200) NULL,
	CONSTRAINT [PK_stores_store_Id] PRIMARY KEY ([Id] ASC)
)
GO

INSERT INTO Sales.Stores VALUES ('1', 'Cevahir');
INSERT INTO Sales.Stores VALUES ('2', 'Istiklal');
INSERT INTO Sales.Stores VALUES ('3', 'Kadikoy');

CREATE TABLE Sales.Products
(
	[Id] [int] NOT NULL,
	[ProductName] VARCHAR(200) NULL,
	[Cost] [int] NOT NULL,
	[SalesPrice] [int] NOT NULL,
	CONSTRAINT [PK_Products_product_Id] PRIMARY KEY ([Id] ASC)
)
GO

INSERT INTO Sales.Products VALUES ('1', 'Shoes', '30', '120');
INSERT INTO Sales.Products VALUES ('2', 'Tshirt', '10', '25');
INSERT INTO Sales.Products VALUES ('3', 'Jacket', '5', '15');

CREATE TABLE Sales.InventorySales
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[SalesQuantity] [int] NOT NULL,
	[Stock] [int] NOT NULL,
	CONSTRAINT [PK_InventorySales_InventorySales_Id] PRIMARY KEY ([Id] ASC),
	CONSTRAINT FK_InventorySales_Products FOREIGN KEY ([ProductId]) REFERENCES Sales.Products ([id]) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT FK_InventorySales_Stores FOREIGN KEY ([StoreId]) REFERENCES Sales.Stores ([id]) ON DELETE CASCADE ON UPDATE CASCADE
)
GO

select * from Sales.InventorySales 

SELECT ProductId,StoreId,SalesQuantity,Stock,ProductName,Cost,SalesPrice,StoreName FROM Sales.InventorySales 
JOIN Sales.Products ON Sales.InventorySales.ProductId = Sales.Products.Id
JOIN Sales.Stores ON Sales.InventorySales.StoreId = Sales.Stores.Id

