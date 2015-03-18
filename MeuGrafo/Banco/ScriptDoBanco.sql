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



/*			#----------------------------------------------#			*/
/*			|     _____   _____   _____   ___     _____    |			*/
/*			|    /       |       |       |   \   /         |			*/
/*			|    \____   |____   |____   |    |  \____     |			*/
/*			|         \  |       |       |    |       \    |			*/
/*			|    _____/  |_____  |_____  |___/   _____/    |			*/
/*			|											   |			*/
/*			#----------------------------------------------#			*/



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



INSERT INTO tb_Grafo VALUES('RN', 600, 300);

INSERT INTO tb_Vertice VALUES(2, 'Agreste Potiguar', 510, 210, 0);
INSERT INTO tb_Vertice VALUES(2, 'Angicos', 390, 120, 0);
INSERT INTO tb_Vertice VALUES(2, 'Baixa Verde', 450, 120, 0);
INSERT INTO tb_Vertice VALUES(2, 'Mossoro', 240, 60, 0);
INSERT INTO tb_Vertice VALUES(2, 'Chapada do Apodi', 180, 120, 0);
INSERT INTO tb_Vertice VALUES(2, 'Litoral Sul', 570, 240, 0);
INSERT INTO tb_Vertice VALUES(2, 'Borborema Potiguar', 450, 210, 0);
INSERT INTO tb_Vertice VALUES(2, 'Pau dos Ferros', 120, 210, 0);
INSERT INTO tb_Vertice VALUES(2, 'Serra de Santana', 330, 180, 0);
INSERT INTO tb_Vertice VALUES(2, 'Serra de Sao Miguel', 60, 240, 0);
INSERT INTO tb_Vertice VALUES(2, 'Umarizal', 150, 210, 0);
INSERT INTO tb_Vertice VALUES(2, 'Litoral Nordeste', 510, 90, 0);
INSERT INTO tb_Vertice VALUES(2, 'Macaiba', 540, 180, 0);
INSERT INTO tb_Vertice VALUES(2, 'Macau', 390, 60, 0);
INSERT INTO tb_Vertice VALUES(2, 'Medio Oeste', 240, 180, 0);
INSERT INTO tb_Vertice VALUES(2, 'Natal', 570, 150, 0);
INSERT INTO tb_Vertice VALUES(2, 'Serido Ocidental', 270, 270, 0);
INSERT INTO tb_Vertice VALUES(2, 'Serido Oriental', 330, 270, 0);
INSERT INTO tb_Vertice VALUES(2, 'Vale do Acu', 300, 120, 0);

INSERT INTO tb_Aresta VALUES(6, 11, 1);
INSERT INTO tb_Aresta VALUES(6, 18, 1);
INSERT INTO tb_Aresta VALUES(6, 8, 1);
INSERT INTO tb_Aresta VALUES(6, 7, 1);
INSERT INTO tb_Aresta VALUES(6, 12, 1);
INSERT INTO tb_Aresta VALUES(6, 17, 1);
INSERT INTO tb_Aresta VALUES(11, 18, 1);
INSERT INTO tb_Aresta VALUES(18, 21, 1);
INSERT INTO tb_Aresta VALUES(18, 17, 1);
INSERT INTO tb_Aresta VALUES(17, 8, 1);
INSERT INTO tb_Aresta VALUES(17, 19, 1);
INSERT INTO tb_Aresta VALUES(8, 19, 1);
INSERT INTO tb_Aresta VALUES(8, 7, 1);
INSERT INTO tb_Aresta VALUES(19, 24, 1);
INSERT INTO tb_Aresta VALUES(19, 7, 1);
INSERT INTO tb_Aresta VALUES(7, 24, 1);
INSERT INTO tb_Aresta VALUES(7, 12, 1);
INSERT INTO tb_Aresta VALUES(7, 14, 1);
INSERT INTO tb_Aresta VALUES(12, 23, 1);
INSERT INTO tb_Aresta VALUES(12, 14, 1);
INSERT INTO tb_Aresta VALUES(14, 24, 1);
INSERT INTO tb_Aresta VALUES(14, 22, 1);
INSERT INTO tb_Aresta VALUES(14, 23, 1);
INSERT INTO tb_Aresta VALUES(24, 20, 1);
INSERT INTO tb_Aresta VALUES(24, 9, 1);
INSERT INTO tb_Aresta VALUES(9, 20, 1);
INSERT INTO tb_Aresta VALUES(9, 10, 1);
INSERT INTO tb_Aresta VALUES(20, 10, 1);
INSERT INTO tb_Aresta VALUES(20, 16, 1);
INSERT INTO tb_Aresta VALUES(10, 16, 1);
INSERT INTO tb_Aresta VALUES(10, 13, 1);
INSERT INTO tb_Aresta VALUES(16, 13, 1);
INSERT INTO tb_Aresta VALUES(13, 15, 1);