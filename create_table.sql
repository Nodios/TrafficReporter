DROP TABLE IF EXISTS report;

CREATE TABLE report(
	id		uuid PRIMARY KEY,
	cause		int NOT NULL,
	direction 	int,
	longitude	double precision NOT NULL,
	lattitude	double precision NOT NULL,
	rating		int DEFAULT 0,
	date_time 	date NOT NULL
);

SELECT * FROM report;