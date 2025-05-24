CREATE DATABASE empresa;

CREATE TABLE funcionario(
  id serial PRIMARY KEY,
  nome varchar(50) NOT NULL,
  idade int NOT NULL
);
