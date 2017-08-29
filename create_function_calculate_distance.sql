
--insert two parameters as two geo coordinates
--it will return table which has id and distance
--of every report in trafreport 
CREATE OR REPLACE FUNCTION get_distances_in_range(new_longitude double precision, new_lattitude double precision, new_cause integer)
RETURNS TABLE (
	report_id uuid,
	distance double precision
)
AS $$
BEGIN
	RETURN QUERY 
  SELECT id AS report_id, calculate_distance(new_longitude, new_lattitude, longitude, lattitude) AS distance
	 FROM trafreport
	 WHERE cause = new_cause;
END;
$$ LANGUAGE 'plpgsql'


DROP FUNCTION get_distances_in_range(double precision, double precision)


--and here is the usage of get_distances_in_range
SELECT * FROM get_distances_in_range(40, 40, 1) WHERE distance > 0




