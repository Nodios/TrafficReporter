CREATE TABLE report(
	id		uuid PRIMARY KEY,
	cause		int NOT NULL,
	direction 	int,
	longitude	double NOT NULL,
	lattitude	double NOT NULL,
	rating		int DEFAULT 0,
);