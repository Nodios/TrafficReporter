CREATE OR REPLACE FUNCTION get_time(int)
RETURNS time
AS
	'SELECT time_remaining FROM cause_table WHERE id = $1'
LANGUAGE SQL IMMUTABLE

UPDATE trafreport
SET time_remaining = get_time(cause)
WHERE time_remaining <= 0;

SELECT * FROM trafreport;


SELECT * FROM cause_time;