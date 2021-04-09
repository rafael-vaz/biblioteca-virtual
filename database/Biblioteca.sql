-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Tempo de geração: 09/04/2021 às 02:02
-- Versão do servidor: 10.4.14-MariaDB
-- Versão do PHP: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `Biblioteca`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `Emprestimos`
--

CREATE TABLE `Emprestimos` (
  `Id` int(11) NOT NULL,
  `DataEmprestimo` datetime(6) NOT NULL,
  `DataDevolucao` datetime(6) NOT NULL,
  `NomeUsuario` longtext DEFAULT NULL,
  `Telefone` longtext DEFAULT NULL,
  `Devolvido` tinyint(1) NOT NULL,
  `LivroId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Despejando dados para a tabela `Emprestimos`
--

INSERT INTO `Emprestimos` (`Id`, `DataEmprestimo`, `DataDevolucao`, `NomeUsuario`, `Telefone`, `Devolvido`, `LivroId`) VALUES
(1, '2021-04-07 00:00:00.000000', '2021-04-12 00:00:00.000000', 'Rafael', '988195244', 0, 3),
(2, '2021-04-07 00:00:00.000000', '2021-04-15 00:00:00.000000', 'João', '988196844', 1, 2),
(3, '2021-04-07 00:00:00.000000', '2021-04-13 00:00:00.000000', 'Pedro', '988195766', 0, 6),
(4, '2021-04-05 00:00:00.000000', '2021-04-07 00:00:00.000000', 'Carlos', '988195255', 0, 1);

-- --------------------------------------------------------

--
-- Estrutura para tabela `Livros`
--

CREATE TABLE `Livros` (
  `Id` int(11) NOT NULL,
  `Titulo` longtext DEFAULT NULL,
  `Autor` longtext DEFAULT NULL,
  `Ano` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Despejando dados para a tabela `Livros`
--

INSERT INTO `Livros` (`Id`, `Titulo`, `Autor`, `Ano`) VALUES
(1, 'Dom Quixote', 'Miguel de Cervantes', 1605),
(2, 'Guerra e Paz', 'Liev Tolstói', 1869),
(3, 'A Montanha Mágica', 'Thomas Mann', 1924),
(4, 'Cem Anos de Solidão', 'Gabriel García Márquez', 1967),
(5, 'A Divina Comédia', 'Dante Alighieri', 1321),
(6, 'Em Busca do Tempo Perdido', 'Marcel Proust', 1913);

-- --------------------------------------------------------

--
-- Estrutura para tabela `Usuario`
--

CREATE TABLE `Usuario` (
  `Id` int(11) NOT NULL,
  `Login` longtext DEFAULT NULL,
  `Senha` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Despejando dados para a tabela `Usuario`
--

INSERT INTO `Usuario` (`Id`, `Login`, `Senha`) VALUES
(2, 'roberto', '1305'),
(3, 'pedro', '2050'),
(4, 'maria', '1401'),
(5, 'joão', '2030'),
(6, 'rafael', '1701'),
(7, 'admin', '1234');

-- --------------------------------------------------------

--
-- Estrutura para tabela `__EFMigrationsHistory`
--

CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Despejando dados para a tabela `__EFMigrationsHistory`
--

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
('20210407111126_CreateDatabase', '3.0.0'),
('20210408115010_ChangeVarchar', '3.0.0');

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `Emprestimos`
--
ALTER TABLE `Emprestimos`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Emprestimos_LivroId` (`LivroId`);

--
-- Índices de tabela `Livros`
--
ALTER TABLE `Livros`
  ADD PRIMARY KEY (`Id`);

--
-- Índices de tabela `Usuario`
--
ALTER TABLE `Usuario`
  ADD PRIMARY KEY (`Id`);

--
-- Índices de tabela `__EFMigrationsHistory`
--
ALTER TABLE `__EFMigrationsHistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `Emprestimos`
--
ALTER TABLE `Emprestimos`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de tabela `Livros`
--
ALTER TABLE `Livros`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de tabela `Usuario`
--
ALTER TABLE `Usuario`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `Emprestimos`
--
ALTER TABLE `Emprestimos`
  ADD CONSTRAINT `FK_Emprestimos_Livros_LivroId` FOREIGN KEY (`LivroId`) REFERENCES `Livros` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
