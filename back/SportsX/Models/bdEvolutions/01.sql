CREATE DATABASE gerenciamento_cliente
  WITH OWNER = postgres
       ENCODING = 'UTF8'
       TABLESPACE = pg_default
       CONNECTION LIMIT = -1
       TEMPLATE = template1;     
       
CREATE SCHEMA base_corporativa;


ALTER SCHEMA base_corporativa OWNER TO postgres;

CREATE SEQUENCE base_corporativa.sq_clientes
MINVALUE 1
NO MAXVALUE
START WITH 1
INCREMENT BY 1
CACHE 1;


CREATE TABLE base_corporativa.clientes (
	id INTEGER NOT null DEFAULT nextval('base_corporativa.sq_clientes'::regclass),
	nome_razao_social varchar not null,
	cep varchar,
	email varchar not null,
	classificacao int not null,
	telefone varchar,
	CONSTRAINT pk_clientes PRIMARY KEY (id)
);