-- Table: public.trafreport

-- DROP TABLE public.trafreport;

CREATE TABLE public.trafreport
(
  id uuid NOT NULL,
  cause integer NOT NULL,
  direction integer,
  longitude double precision NOT NULL,
  lattitude double precision NOT NULL,
  rating integer DEFAULT 0,
  date_created timestamp without time zone NOT NULL,
  time_remaining time without time zone,
  CONSTRAINT trafreport_pkey PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE public.trafreport
  OWNER TO postgres;
