-- Table: public.Usuarios

-- DROP TABLE IF EXISTS public."Usuarios";

CREATE TABLE IF NOT EXISTS public."Usuarios"
(
    "UserID" integer NOT NULL DEFAULT nextval('usuarios_identity'::regclass),
    "Nome" character varying(255) COLLATE pg_catalog."default",
    "EmailUser" character varying(75) COLLATE pg_catalog."default",
    "Senha" character varying(6) COLLATE pg_catalog."default",
    "Termos" boolean,
    "TipoEmpresa" character varying(50) COLLATE pg_catalog."default",
    "NomeEmpresa" character varying(255) COLLATE pg_catalog."default",
    "CNPJ" character varying(14) COLLATE pg_catalog."default",
    "CEP" character varying(8) COLLATE pg_catalog."default",
    "Endereco" character varying(255) COLLATE pg_catalog."default",
    "Bairro" character varying(50) COLLATE pg_catalog."default",
    "Estado" character varying(2) COLLATE pg_catalog."default",
    "Cidade" character varying(50) COLLATE pg_catalog."default",
    "Complemento" character varying(50) COLLATE pg_catalog."default",
    "Celular" character varying(11) COLLATE pg_catalog."default",
    "NomeAdm" character varying(255) COLLATE pg_catalog."default",
    "CPF" character varying(11) COLLATE pg_catalog."default",
    "EmailEmpresa" character varying(75) COLLATE pg_catalog."default",
    CONSTRAINT usuarios_pkey PRIMARY KEY ("UserID")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Usuarios"
    OWNER to postgres;