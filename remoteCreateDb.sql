DROP TABLE IF EXISTS  trafreport;

CREATE TABLE trafreport (
	id		uuid PRIMARY KEY,
	cause		int NOT NULL,
	direction 	int,
	longitude	double precision NOT NULL,
	lattitude	double precision NOT NULL,
	rating		int DEFAULT 0,
	date_time 	timestamp NOT NULL


);

SELECT * FROM trafreport;