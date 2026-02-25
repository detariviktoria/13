-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Jan 12. 16:49
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `filmdb`
--
CREATE DATABASE IF NOT EXISTS `filmdb` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `filmdb`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `films`
--

DROP TABLE IF EXISTS `films`;
CREATE TABLE `films` (
  `Cim` varchar(255) NOT NULL,
  `Hossz` int(11) NOT NULL,
  `Ertekeles` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `films`
--

INSERT INTO `films` (`Cim`, `Hossz`, `Ertekeles`) VALUES
('A hercegnő és a béka', 88, 7.8),
('Aladdin', 92, 8.2),
('Aranyhaj', 98, 7.45),
('Bambi', 85, 9),
('Cinderella', 90, 8.05),
('Dumbo', 91, 8.5),
('Hamupipőke', 89, 9.2),
('Mulan', 98, 8.4),
('Notre Dame-i toronyőr', 95, 9.3),
('Tarzan', 92, 8.5);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `films`
--
ALTER TABLE `films`
  ADD PRIMARY KEY (`Cim`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
