--CREATE DATABASE SpeseDB


CREATE TABLE Categoria (
IDcat INT IDENTITY(1,1) primary key,
Nome VARCHAR(50)
);

CREATE TABLE Spesa (
IDspesa INT IDENTITY(1,1) primary key,
DataSpesa DATETIME,
Descrizione VARCHAR(500),
Utente VARCHAR(50),
Importo DECIMAL,
Approvata BIT,
IDcat int not null,
constraint FK_CAT foreign key (IDcat) references Categoria(IDcat)
);

INSERT INTO Categoria VALUES('Affitto');
insert into Categoria VALUES ('Bolletta gas');

select * from Categoria;

insert into Spesa Values('03-03-2021', 'Affitto mese di Marzo', 'Giada', 500, 1,1);
insert into Spesa Values('07-02-2021', 'Gas luglio', 'Mario', 76, 1,2);


select * from Spesa
insert into Spesa Values('01-03-2022', 'Affitto mese di Gennaio', 'Giada', 500, 0,1);