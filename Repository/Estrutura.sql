﻿DROP TABLE contas_pagar;
CREATE TABLE contas_pagar(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100)NOT NULL,
	valor DECIMAL(8,2)NOT NULL,
	tipo VARCHAR(100),
	descricao VARCHAR(100),
	status VARCHAR(100)
);

SELECT * FROM contas_pagar;

CREATE TABLE contas_receber(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100)NOT NULL,
	valor DECIMAL(8,2)NOT NULL,
	tipo VARCHAR(100),
	descricao VARCHAR(100),
	status VARCHAR(100)
);