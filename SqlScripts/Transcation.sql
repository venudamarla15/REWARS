CREATE TABLE [dbo].[Transaction](
	[TransactionId] [int] NOT NULL Identity(1,1) primary key,
	[CustomerId] [int] NULL,
	[Amount] [int] NULL,
	[TransactionDate] [datetime] NULL
	)
GO

ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Transaction] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO

ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Customer_Transaction]
GO
