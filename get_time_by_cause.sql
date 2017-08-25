CREATE OR REPLACE FUNCTION get_time(int)
RETURNS time
AS
	'SELECT time_remaining FROM cause_time WHERE id = $1'
LANGUAGE SQL IMMUTABLE

UPDATE trafreport
SET time_remaining = get_time(cause);

SELECT * FROM trafreport;


SELECT * FROM cause_time;