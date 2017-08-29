CREATE OR REPLACE FUNCTION get_range_from_cause_table(int)
RETURNS double precision
AS
	'SELECT cause_range FROM cause_table WHERE id = $1'
LANGUAGE SQL IMMUTABLe

UPDATE cause_table
SET cause_range = 100;

SELECT get_range_from_cause_table(2);

--cause_table holds various static data(for now, time rmaining(how long report lasts in db) and range(within which range is report effective))
SELECT * FROM get_distances_from_reports_by_cause(0, 0, 1) WHERE distance < get_range_from_cause_table(1)


CREATE OR REPLACE FUNCTION get_reports_with_same_cause_and_within_range(new_longitude double precision, new_lattitude double precision, cause int)
RETURNS TABLE (
	report_uuid	uuid,
	report_distance double precision
)
AS $$
BEGIN
	RETURN QUERY
	SELECT report_id as report_uuid, report_distance FROM get_distances_from_reports_by_cause(new_longitude, new_lattitude, cause) WHERE distance < get_range_from_cause_table(cause);
END;
$$ LANGUAGE 'plpgsql'  

DROP FUNCTION get_reports_with_same_cause_and_within_range(double precision,double precision,integer)

SELECT * FROM get_reports_with_same_cause_and_within_range(45, 45, 1);
