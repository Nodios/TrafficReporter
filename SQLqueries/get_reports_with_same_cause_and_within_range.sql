-- Function: public.get_reports_with_same_cause_and_within_range(double precision, double precision, integer)

-- DROP FUNCTION public.get_reports_with_same_cause_and_within_range(double precision, double precision, integer);

CREATE OR REPLACE FUNCTION public.get_reports_with_same_cause_and_within_range(
    IN new_longitude double precision,
    IN new_lattitude double precision,
    IN cause integer)
  RETURNS TABLE(report_uuid uuid, report_distance double precision) AS
$BODY$
BEGIN
	RETURN QUERY
	SELECT report_id as report_uuid, report_distance FROM get_distances_from_reports_by_cause(new_longitude, new_lattitude, cause) WHERE distance < get_range_from_cause_table(cause);
END;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100
  ROWS 1000;
ALTER FUNCTION public.get_reports_with_same_cause_and_within_range(double precision, double precision, integer)
  OWNER TO postgres;
COMMENT ON FUNCTION public.get_reports_with_same_cause_and_within_range(double precision, double precision, integer) IS 'This function retrives all reports which have the same cause AND are within range of the passed coordinate(that range is specified in special table cause_table).';
