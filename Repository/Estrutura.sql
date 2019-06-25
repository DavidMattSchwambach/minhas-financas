DROP TABLE contas_pagar;
CREATE TABLE contas_pagar(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100)NOT NULL,
	valor DECIMAL(8,2)NOT NULL,
	tipo VARCHAR(100),
	descricao VARCHAR(100),
	status VARCHAR(100)
);

CREATE TABLE contas_receber(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100)NOT NULL,
	valor DECIMAL(8,2)NOT NULL,
	tipo VARCHAR(100),
	descricao VARCHAR(100),
	status VARCHAR(100)
);

CREATE TABLE clientes_pessoas_fisicas(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100)NOT NULL,
	cpf VARCHAR(100),
	data_nascimento DATETIME2,
	rg VARCHAR(100)NOT NULL,
	sexo BIT
);

CREATE TABLE clientes_pessoas_juridicas(
	id INT PRIMARY KEY IDENTITY(1,1),
	cnpj VARCHAR(100)NOT NULL,
	razao_social VARCHAR(100)NOT NULL,
	inscricao_estadual VARCHAR(100) NOT NULL
);

CREATE TABLE enderecos(
	id INT PRIMARY KEY IDENTITY(1,1),
	unidade_federativa VARCHAR(100)NOT NULL,
	cidade VARCHAR(100)NOT NULL,
	logradouro VARCHAR(100)NOT NULL,
	cep DECIMAL(8,2)NOT NULL,
	numero INT,
	comnplemento VARCHAR(100)NOT NULL

);