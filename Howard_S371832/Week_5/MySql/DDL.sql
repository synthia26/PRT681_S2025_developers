CREATE SCHEMA `Learning`;

USE Learning;

CREATE TABLE CUSTOMERS(
CustomerID int,
CustomerFirstName char,
CustomerLastName char
);

-- DROP TABLE CUSTOMERS;
DROP SCHEMA Learning;

ALTER TABLE Learning.CUSTOMERS MODIFY COLUMN CustomerFirstName varchar(16);
ALTER TABLE Learning.CUSTOMERS MODIFY COLUMN CustomerLastName varchar(16);

SELECT * FROM Learning.CUSTOMERS;

-- INSERT INTO Learning.CUSTOMERS
-- VALUES
-- (101, 'John', 'Snow');

-- INSERT INTO Learning.CUSTOMERS
-- VALUES
-- (103, 'Arya', 'Stark'), (104, 'Brandon', 'Stark');