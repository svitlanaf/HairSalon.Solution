-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: May 13, 2019 at 05:46 AM
-- Server version: 5.7.25
-- PHP Version: 7.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `svitlana_filatova`
--
CREATE DATABASE IF NOT EXISTS `svitlana_filatova` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `svitlana_filatova`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `details` text NOT NULL,
  `appointment` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` VALUES(8, 7, 'test1', 'test1', '2019-09-09');
INSERT INTO `clients` VALUES(9, 5, 'Ariana', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam ullamcorper interdum ante, quis pharetra nibh blandit ut. Nullam et mauris id nibh luctus blandit.', '2019-05-09');
INSERT INTO `clients` VALUES(10, 6, 'Stevie', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. ', '2019-03-03');
INSERT INTO `clients` VALUES(11, 6, 'Chu', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. ', '2019-02-09');
INSERT INTO `clients` VALUES(15, 10, 'Heidy', 'Lorem ipsum dolor sit amet', '2019-04-04');
INSERT INTO `clients` VALUES(16, 10, 'Mark', 'Lorem ipsum dolor sit amet!', '2019-03-08');
INSERT INTO `clients` VALUES(17, 9, 'David', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. ', '2019-01-01');
INSERT INTO `clients` VALUES(18, 5, 'test client', 'test', '0001-01-01');

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `information` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists`
--

INSERT INTO `stylists` VALUES(5, 'Stevie', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam ullamcorper interdum ante, quis pharetra nibh blandit ut. Nullam et mauris id nibh luctus blandit. Duis at ligula convallis, finibus metus ac, placerat urna. Ut vel pretium nunc, ut commodo nisl. Quisque vel posuere tortor, sit amet sagittis metus. In eget accumsan mauris, id molestie odio. Praesent venenatis dui sed massa elementum, vel condimentum mauris eleifend. Ut laoreet dignissim hendrerit. Fusce eget velit sem. Morbi sit amet commodo metus, imperdiet bibendum ipsum.');
INSERT INTO `stylists` VALUES(6, 'Chelsea', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam ullamcorper interdum ante, quis pharetra nibh blandit ut. Nullam et mauris id nibh luctus blandit. Duis at ligula convallis, finibus metus ac, placerat urna. Ut vel pretium nunc, ut commodo nisl. Quisque vel posuere tortor, sit amet sagittis metus. In eget accumsan mauris, id molestie odio. Praesent venenatis dui sed massa elementum, vel condimentum mauris eleifend. Ut laoreet dignissim hendrerit. Fusce eget velit sem. Morbi sit amet commodo metus, imperdiet bibendum ipsum.');
INSERT INTO `stylists` VALUES(9, 'Ainsley', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam ullamcorper interdum ante, quis pharetra nibh blandit ut. Nullam et mauris id nibh luctus blandit. Duis at ligula convallis, finibus metus ac, placerat urna. Ut vel pretium nunc, ut commodo nisl. Quisque vel posuere tortor, sit amet sagittis metus. In eget accumsan mauris, id molestie odio. Praesent venenatis dui sed massa elementum, vel condimentum mauris eleifend. Ut laoreet dignissim hendrerit. Fusce eget velit sem. Morbi sit amet commodo metus, imperdiet bibendum ipsum.');
INSERT INTO `stylists` VALUES(10, 'Broady', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam ullamcorper interdum ante, quis pharetra nibh blandit ut. Nullam et mauris id nibh luctus blandit. Duis at ligula convallis, finibus metus ac, placerat urna. Ut vel pretium nunc, ut commodo nisl. Quisque vel posuere tortor, sit amet sagittis metus. In eget accumsan mauris, id molestie odio. Praesent venenatis dui sed massa elementum, vel condimentum mauris eleifend. Ut laoreet dignissim hendrerit. Fusce eget velit sem. Morbi sit amet commodo metus, imperdiet bibendum ipsum.');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`),
  ADD KEY `stylist_id` (`stylist_id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
