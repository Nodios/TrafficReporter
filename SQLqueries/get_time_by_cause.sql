-- Function: public.get_time(integer)

-- DROP FUNCTION public.get_time(integer);

CREATE OR REPLACE FUNCTION public.get_time(integer)
  RETURNS time without time zone AS
'SELECT time_remaining FROM cause_table WHERE id = $1'
  LANGUAGE sql IMMUTABLE
  COST 100;
ALTER FUNCTION public.get_time(integer)
  OWNER TO postgres;
