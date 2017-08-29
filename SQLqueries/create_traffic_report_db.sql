-- Database: traffic_report_db

-- DROP DATABASE traffic_report_db;

CREATE DATABASE traffic_report_db
  WITH OWNER = postgres
       ENCODING = 'UTF8'
       TABLESPACE = pg_default
       LC_COLLATE = 'en_US.UTF-8'
       LC_CTYPE = 'en_US.UTF-8'
       CONNECTION LIMIT = -1;

COMMENT ON DATABASE traffic_report_db
  IS 'This database stores traffic reports in prodution.';
