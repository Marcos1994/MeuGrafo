--CREATE DATABASE GrafoWebService;
USE GrafoWebService;

CREATE TABLE tb_Grafo
(
	id_grafo INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(30) UNIQUE NOT NULL,
	width INT NOT NULL,
	height INT NOT NULL
);

CREATE TABLE tb_Vertice
(
	id_vertice INT PRIMARY KEY IDENTITY(1,1),
	id_grafo INT FOREIGN KEY REFERENCES tb_Grafo(id_grafo) NOT NULL,
	nome VARCHAR(30) NOT NULL,
	posX INT NOT NULL,
	posY INT NOT NULL,
	cor INT
);

CREATE TABLE tb_Aresta
(
	id_aresta INT PRIMARY KEY IDENTITY(1,1),
	id_origem INT FOREIGN KEY REFERENCES tb_Vertice(id_vertice) NOT NULL,
	id_destino INT FOREIGN KEY REFERENCES tb_Vertice(id_vertice) NOT NULL,
	peso INT NOT NULL
)