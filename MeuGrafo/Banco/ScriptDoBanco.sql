--CREATE DATABASE GrafoWebService;
USE GrafoWebService;
/*
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
*/


/*			#----------------------------------------------#			*/
/*			|     _____   _____   _____   ___     _____    |			*/
/*			|    /       |       |       |   \   /         |			*/
/*			|    \____   |____   |____   |    |  \____     |			*/
/*			|         \  |       |       |    |       \    |			*/
/*			|    _____/  |_____  |_____  |___/   _____/    |			*/
/*			|											   |			*/
/*			#----------------------------------------------#			*/


/*
INSERT INTO tb_Grafo VALUES('Brasil', 300, 300);

INSERT INTO tb_Vertice VALUES(1, 'Norte', 120, 90, 0);
INSERT INTO tb_Vertice VALUES(1, 'Nordeste', 240, 120, 0);
INSERT INTO tb_Vertice VALUES(1, 'CentroOeste', 150, 150, 0);
INSERT INTO tb_Vertice VALUES(1, 'Sudeste', 210, 210, 0);
INSERT INTO tb_Vertice VALUES(1, 'Sul', 180, 270, 0);

INSERT INTO tb_Aresta VALUES(2, 1, 1);
INSERT INTO tb_Aresta VALUES(2, 4, 1);
INSERT INTO tb_Aresta VALUES(1, 3, 1);
INSERT INTO tb_Aresta VALUES(3, 2, 1);
INSERT INTO tb_Aresta VALUES(3, 4, 1);
INSERT INTO tb_Aresta VALUES(4, 5, 1);
INSERT INTO tb_Aresta VALUES(5, 3, 1);
*/
/*
INSERT INTO tb_Grafo VALUES('RN', 600, 300);
*/