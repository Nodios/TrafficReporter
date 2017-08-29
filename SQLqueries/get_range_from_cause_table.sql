-- Function: public.get_range_from_cause_table(integer)

-- DROP FUNCTION public.get_range_from_cause_table(integer);

CREATE OR REPLACE FUNCTION public.get_range_from_cause_table(integer)
  RETURNS double precision AS
'SELECT cause_range FROM cause_table WHERE id = $1'
  LANGUAGE sql IMMUTABLE
  COST 100;
ALTER FUNCTION public.get_range_from_cause_table(integer)
  OWNER TO postgres;
