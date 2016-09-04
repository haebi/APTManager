-- To Create Database and Import sample data Use Sample command below.
-- sqlite3.exe
-- sqlite> .open aptmanager.db
-- sqlite> .read sample_db.sql
CREATE TABLE homeinfo (home string PRIMARY KEY, name string NOT NULL);
INSERT INTO homeinfo VALUES ('���� 101ȣ','0');
INSERT INTO homeinfo VALUES ('���� 102ȣ','0');
INSERT INTO homeinfo VALUES ('���� 201ȣ','0');
INSERT INTO homeinfo VALUES ('���� 202ȣ','0');
INSERT INTO homeinfo VALUES ('���� 301ȣ','0');
INSERT INTO homeinfo VALUES ('���� 302ȣ','0');
INSERT INTO homeinfo VALUES ('���� 401ȣ','0');
INSERT INTO homeinfo VALUES ('���� 402ȣ','0');
INSERT INTO homeinfo VALUES ('���� 501ȣ','0');
INSERT INTO homeinfo VALUES ('���� 502ȣ','0');
INSERT INTO homeinfo VALUES ('���� 103ȣ','0');
INSERT INTO homeinfo VALUES ('���� 105ȣ','0');
INSERT INTO homeinfo VALUES ('���� 203ȣ','0');
INSERT INTO homeinfo VALUES ('���� 205ȣ','0');
INSERT INTO homeinfo VALUES ('���� 303ȣ','0');
INSERT INTO homeinfo VALUES ('���� 305ȣ','0');
INSERT INTO homeinfo VALUES ('���� 403ȣ','0');
INSERT INTO homeinfo VALUES ('���� 405ȣ','0');
INSERT INTO homeinfo VALUES ('���� 503ȣ','0');
INSERT INTO homeinfo VALUES ('���� 505ȣ','0');
INSERT INTO homeinfo VALUES ('���� 106ȣ','0');
INSERT INTO homeinfo VALUES ('���� 107ȣ','0');
INSERT INTO homeinfo VALUES ('���� 206ȣ','0');
INSERT INTO homeinfo VALUES ('���� 207ȣ','0');
INSERT INTO homeinfo VALUES ('���� 306ȣ','0');
INSERT INTO homeinfo VALUES ('���� 307ȣ','0');
INSERT INTO homeinfo VALUES ('���� 406ȣ','0');
INSERT INTO homeinfo VALUES ('���� 407ȣ','0');
INSERT INTO homeinfo VALUES ('���� 506ȣ','0');
INSERT INTO homeinfo VALUES ('���� 507ȣ','0');
INSERT INTO homeinfo VALUES ('���� 108ȣ','0');
INSERT INTO homeinfo VALUES ('���� 109ȣ','0');
INSERT INTO homeinfo VALUES ('���� 208ȣ','0');
INSERT INTO homeinfo VALUES ('���� 209ȣ','0');
INSERT INTO homeinfo VALUES ('���� 308ȣ','0');
INSERT INTO homeinfo VALUES ('���� 309ȣ','0');
INSERT INTO homeinfo VALUES ('���� 408ȣ','0');
INSERT INTO homeinfo VALUES ('���� 409ȣ','0');
INSERT INTO homeinfo VALUES ('���� 508ȣ','0');
INSERT INTO homeinfo VALUES ('���� 509ȣ','0');
INSERT INTO homeinfo VALUES ('���� 110ȣ','0');
INSERT INTO homeinfo VALUES ('���� 111ȣ','0');
INSERT INTO homeinfo VALUES ('���� 210ȣ','0');
INSERT INTO homeinfo VALUES ('���� 211ȣ','0');
INSERT INTO homeinfo VALUES ('���� 310ȣ','0');
INSERT INTO homeinfo VALUES ('���� 311ȣ','0');
INSERT INTO homeinfo VALUES ('���� 410ȣ','0');
INSERT INTO homeinfo VALUES ('���� 411ȣ','0');
INSERT INTO homeinfo VALUES ('���� 510ȣ','0');
INSERT INTO homeinfo VALUES ('���� 511ȣ','0');
INSERT INTO homeinfo VALUES ('���� 112ȣ','0');
INSERT INTO homeinfo VALUES ('���� 212ȣ','0');
INSERT INTO homeinfo VALUES ('���� 312ȣ','0');
INSERT INTO homeinfo VALUES ('���� 412ȣ','0');
INSERT INTO homeinfo VALUES ('���� 101ȣ','0');
INSERT INTO homeinfo VALUES ('���� 102ȣ','0');
INSERT INTO homeinfo VALUES ('���� 201ȣ','0');
INSERT INTO homeinfo VALUES ('���� 202ȣ','0');
INSERT INTO homeinfo VALUES ('���� 301ȣ','0');
INSERT INTO homeinfo VALUES ('���� 302ȣ','0');
INSERT INTO homeinfo VALUES ('���� 401ȣ','0');
INSERT INTO homeinfo VALUES ('���� 402ȣ','0');
INSERT INTO homeinfo VALUES ('���� 103ȣ','0');
INSERT INTO homeinfo VALUES ('���� 105ȣ','0');
INSERT INTO homeinfo VALUES ('���� 203ȣ','0');
INSERT INTO homeinfo VALUES ('���� 205ȣ','0');
INSERT INTO homeinfo VALUES ('���� 303ȣ','0');
INSERT INTO homeinfo VALUES ('���� 305ȣ','0');
INSERT INTO homeinfo VALUES ('���� 403ȣ','0');
INSERT INTO homeinfo VALUES ('���� 405ȣ','0');

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