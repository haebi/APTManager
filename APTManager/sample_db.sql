-- To Create Database and Import sample data Use Sample command below.
-- sqlite3.exe
-- sqlite> .open aptmanager.db
-- sqlite> .read sample_db.sql
CREATE TABLE homeinfo (
  home string PRIMARY KEY
, name string NOT NULL
, ordernum int NOT NULL);

INSERT INTO homeinfo VALUES
('가동 101호','0',1),
('가동 102호','0',2),
('가동 201호','0',3),
('가동 202호','0',4),
('가동 301호','0',5),
('가동 302호','0',6),
('가동 401호','0',7),
('가동 402호','0',8),
('가동 501호','0',9),
('가동 502호','0',10),
('가동 103호','0',11),
('가동 105호','0',12),
('가동 203호','0',13),
('가동 205호','0',14),
('가동 303호','0',15),
('가동 305호','0',16),
('가동 403호','0',17),
('가동 405호','0',18),
('가동 503호','0',19),
('가동 505호','0',20),
('가동 106호','0',21),
('가동 107호','0',22),
('가동 206호','0',23),
('가동 207호','0',24),
('가동 306호','0',25),
('가동 307호','0',26),
('가동 406호','0',27),
('가동 407호','0',28),
('가동 506호','0',29),
('가동 507호','0',30),
('가동 108호','0',31),
('가동 109호','0',32),
('가동 208호','0',33),
('가동 209호','0',34),
('가동 308호','0',35),
('가동 309호','0',36),
('가동 408호','0',37),
('가동 409호','0',38),
('가동 508호','0',39),
('가동 509호','0',40),
('가동 110호','0',41),
('가동 111호','0',42),
('가동 210호','0',43),
('가동 211호','0',44),
('가동 310호','0',45),
('가동 311호','0',46),
('가동 410호','0',47),
('가동 411호','0',48),
('가동 510호','0',49),
('가동 511호','0',50),
('가동 112호','0',51),
('가동 212호','0',52),
('가동 312호','0',53),
('가동 412호','0',54),
('나동 101호','0',55),
('나동 102호','0',56),
('나동 201호','0',57),
('나동 202호','0',58),
('나동 301호','0',59),
('나동 302호','0',60),
('나동 401호','0',61),
('나동 402호','0',62),
('나동 103호','0',63),
('나동 105호','0',64),
('나동 203호','0',65),
('나동 205호','0',66),
('나동 303호','0',67),
('나동 305호','0',68),
('나동 403호','0',69),
('나동 405호','0',70);

CREATE TABLE admexp (
  yyyymm string NOT NULL
, home string
, name string NOT NULL
, premonth int NOT NULL
, nowmonth int NOT NULL
, useamount int NOT NULL
, usecost int NOT NULL
, admexpcost int NOT NULL
, totalcost int NOT NULL
, remark string
, ordernum int NOT NULL
, PRIMARY KEY (yyyymm, home));

CREATE TABLE comcode (
comgroup int NOT NULL
, comcode int NOT NULL
, comvalue string NOT NULL
, comremark string
, PRIMARY KEY (comgroup, comcode)
);

INSERT INTO comcode VALUES
(0001,001,'25000','관리비');