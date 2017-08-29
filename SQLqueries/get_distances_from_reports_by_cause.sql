-- Function: public.get_distances_from_reports_by_cause(double precision, double precision, integer)

-- DROP FUNCTION public.get_distances_from_reports_by_cause(double precision, double precision, integer);

CREATE OR REPLACE FUNCTION public.get_distances_from_reports_by_cause(
    IN new_longitude double precision,
    IN new_lattitude double precision,
    IN new_cause integer)
  RETURNS TABLE(report_id uuid, distance double precision) AS
$BODY$
BEGIN
	RETURN QUERY 
  SELECT id AS report_id, calculate_distance(new_longitude, new_lattitude, longitude, lattitude) AS distance
	 FROM trafreport
	 WHERE cause = new_cause;
END;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100
  ROWS 1000;
ALTER FUNCTION public.get_distances_from_reports_by_cause(double precision, double precision, integer)
  OWNER TO postgres;
COMMENT ON FUNCTION public.get_distances_from_reports_by_cause(double precision, double precision, integer) IS 'Get distances between passed coordinate and reports which have same cause as passed parameter one.';
