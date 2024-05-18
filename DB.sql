use socketdb3
go

CREATE TABLE receivedData1 (
    idData INT PRIMARY KEY IDENTITY,
    client INT,
	os VARCHAR(MAX),
	motherboard VARCHAR(MAX),
	processeur VARCHAR(MAX),
	ram VARCHAR(MAX),
	hardDisk VARCHAR(MAX),
    captureData VARBINARY(MAX),
    receivedAt DATETIME
);

select * from receivedData1;