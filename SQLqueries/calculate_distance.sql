-- Function: public.calculate_distance(double precision, double precision, double precision, double precision)

-- DROP FUNCTION public.calculate_distance(double precision, double precision, double precision, double precision);

CREATE OR REPLACE FUNCTION public.calculate_distance(
    _lat1 double precision,
    _lon1 double precision,
    _lat2 double precision,
    _lon2 double precision)
  RETURNS double precision AS
$BODY$
  select ACOS(SIN(radians($1))*SIN(radians($3))+COS(radians($1))*COS(radians($3))*COS(radians($4)-radians($2)))*6371;
$BODY$
  LANGUAGE sql IMMUTABLE
  COST 100;
ALTER FUNCTION public.calculate_distance(double precision, double precision, double precision, double precision)
  OWNER TO postgres;
COMMENT ON FUNCTION public.calculate_distance(double precision, double precision, double precision, double precision) IS 'Calculates distance between two coordinates.';
