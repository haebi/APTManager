-- To Create Database and Import sample data Use Sample command below.
-- sqlite3.exe
-- sqlite> .open aptmanager.db
-- sqlite> .read sample_db.sql
CREATE TABLE homeinfo (home string PRIMARY KEY, name string NOT NULL);
INSERT INTO homeinfo VALUES ('가동 101호','0');
INSERT INTO homeinfo VALUES ('가동 102호','0');
INSERT INTO homeinfo VALUES ('가동 201호','0');
INSERT INTO homeinfo VALUES ('가동 202호','0');
INSERT INTO homeinfo VALUES ('가동 301호','0');
INSERT INTO homeinfo VALUES ('가동 302호','0');
INSERT INTO homeinfo VALUES ('가동 401호','0');
INSERT INTO homeinfo VALUES ('가동 402호','0');
INSERT INTO homeinfo VALUES ('가동 501호','0');
INSERT INTO homeinfo VALUES ('가동 502호','0');
INSERT INTO homeinfo VALUES ('가동 103호','0');
INSERT INTO homeinfo VALUES ('가동 105호','0');
INSERT INTO homeinfo VALUES ('가동 203호','0');
INSERT INTO homeinfo VALUES ('가동 205호','0');
INSERT INTO homeinfo VALUES ('가동 303호','0');
INSERT INTO homeinfo VALUES ('가동 305호','0');
INSERT INTO homeinfo VALUES ('가동 403호','0');
INSERT INTO homeinfo VALUES ('가동 405호','0');
INSERT INTO homeinfo VALUES ('가동 503호','0');
INSERT INTO homeinfo VALUES ('가동 505호','0');
INSERT INTO homeinfo VALUES ('가동 106호','0');
INSERT INTO homeinfo VALUES ('가동 107호','0');
INSERT INTO homeinfo VALUES ('가동 206호','0');
INSERT INTO homeinfo VALUES ('가동 207호','0');
INSERT INTO homeinfo VALUES ('가동 306호','0');
INSERT INTO homeinfo VALUES ('가동 307호','0');
INSERT INTO homeinfo VALUES ('가동 406호','0');
INSERT INTO homeinfo VALUES ('가동 407호','0');
INSERT INTO homeinfo VALUES ('가동 506호','0');
INSERT INTO homeinfo VALUES ('가동 507호','0');
INSERT INTO homeinfo VALUES ('가동 108호','0');
INSERT INTO homeinfo VALUES ('가동 109호','0');
INSERT INTO homeinfo VALUES ('가동 208호','0');
INSERT INTO homeinfo VALUES ('가동 209호','0');
INSERT INTO homeinfo VALUES ('가동 308호','0');
INSERT INTO homeinfo VALUES ('가동 309호','0');
INSERT INTO homeinfo VALUES ('가동 408호','0');
INSERT INTO homeinfo VALUES ('가동 409호','0');
INSERT INTO homeinfo VALUES ('가동 508호','0');
INSERT INTO homeinfo VALUES ('가동 509호','0');
INSERT INTO homeinfo VALUES ('가동 110호','0');
INSERT INTO homeinfo VALUES ('가동 111호','0');
INSERT INTO homeinfo VALUES ('가동 210호','0');
INSERT INTO homeinfo VALUES ('가동 211호','0');
INSERT INTO homeinfo VALUES ('가동 310호','0');
INSERT INTO homeinfo VALUES ('가동 311호','0');
INSERT INTO homeinfo VALUES ('가동 410호','0');
INSERT INTO homeinfo VALUES ('가동 411호','0');
INSERT INTO homeinfo VALUES ('가동 510호','0');
INSERT INTO homeinfo VALUES ('가동 511호','0');
INSERT INTO homeinfo VALUES ('가동 112호','0');
INSERT INTO homeinfo VALUES ('가동 212호','0');
INSERT INTO homeinfo VALUES ('가동 312호','0');
INSERT INTO homeinfo VALUES ('가동 412호','0');
INSERT INTO homeinfo VALUES ('나동 101호','0');
INSERT INTO homeinfo VALUES ('나동 102호','0');
INSERT INTO homeinfo VALUES ('나동 201호','0');
INSERT INTO homeinfo VALUES ('나동 202호','0');
INSERT INTO homeinfo VALUES ('나동 301호','0');
INSERT INTO homeinfo VALUES ('나동 302호','0');
INSERT INTO homeinfo VALUES ('나동 401호','0');
INSERT INTO homeinfo VALUES ('나동 402호','0');
INSERT INTO homeinfo VALUES ('나동 103호','0');
INSERT INTO homeinfo VALUES ('나동 105호','0');
INSERT INTO homeinfo VALUES ('나동 203호','0');
INSERT INTO homeinfo VALUES ('나동 205호','0');
INSERT INTO homeinfo VALUES ('나동 303호','0');
INSERT INTO homeinfo VALUES ('나동 305호','0');
INSERT INTO homeinfo VALUES ('나동 403호','0');
INSERT INTO homeinfo VALUES ('나동 405호','0');

CREATE TABLE admexp (
  yyyymm string NOT NULL
, home string
, name string NOT NULL
, premonth NOT NULL
, nowmonth NOT NULL
, useamount NOT NULL
, usecost NOT NULL
, admexpcost NOT NULL
, totalcost NOT NULL
, remark
, PRIMARY KEY (yyyymm, home));