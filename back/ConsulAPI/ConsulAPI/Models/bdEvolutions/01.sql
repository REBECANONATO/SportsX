CREATE DATABASE gerenciamento_consultorio
  WITH OWNER = postgres
       ENCODING = 'UTF8'
       TABLESPACE = pg_default
       CONNECTION LIMIT = -1
       TEMPLATE = template1;     
       
CREATE SCHEMA base_corporativa;


ALTER SCHEMA base_corporativa OWNER TO postgres;

CREATE SEQUENCE base_corporativa.sq_medicos
MINVALUE 1
NO MAXVALUE
START WITH 1
INCREMENT BY 1
CACHE 1;

CREATE SEQUENCE base_corporativa.sq_consultorios
MINVALUE 1
NO MAXVALUE
START WITH 1
INCREMENT BY 1
CACHE 1;

CREATE SEQUENCE base_corporativa.sq_rel_medicos_consultorios
MINVALUE 1
NO MAXVALUE
START WITH 1
INCREMENT BY 1
CACHE 1;


CREATE TABLE base_corporativa.consultorio (
	id INTEGER NOT null DEFAULT nextval('base_corporativa.sq_consultorios'::regclass),
	nome varchar not null,
	endereco varchar not null,
	telefone varchar not null,
	CONSTRAINT pk_consultorios PRIMARY KEY (id)
);

CREATE TABLE base_corporativa.medico (
 id INTEGER NOT null DEFAULT nextval('base_corporativa.sq_medicos'::regclass),
 CRM varchar NOT NULL,
 nome varchar not null,
 telefone varchar not null,
 valor double precision NOT NULL,
 CONSTRAINT pk_medicos PRIMARY KEY (id)
);

create table base_corporativa.rel_medico_consultorio (
id INTEGER NOT null DEFAULT nextval('base_corporativa.sq_rel_medicos_consultorios'::regclass),
id_medico integer not null,
id_consultorio integer not null,
 CONSTRAINT fk_medico FOREIGN KEY (id_medico) REFERENCES base_corporativa.medico(id),
 CONSTRAINT fk_consultorio FOREIGN KEY (id_consultorio) REFERENCES base_corporativa.consultorio(id),
 CONSTRAINT pk_rel_medico_consultorio PRIMARY KEY (id)
 );
 