-- Table: public.cause_table

-- DROP TABLE public.cause_table;

CREATE TABLE public.cause_table
(
  id integer NOT NULL,
  time_remaining time without time zone,
  cause_range double precision,
  cause_str character varying(20),
  icon_uri text,
  CONSTRAINT cause_time_pkey PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE public.cause_table
  OWNER TO postgres;
