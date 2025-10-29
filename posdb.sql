-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 22, 2025 at 03:41 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `posdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `billdetails`
--

CREATE TABLE `billdetails` (
  `Id` int(11) NOT NULL,
  `Date` varchar(255) NOT NULL,
  `ProductName` varchar(255) DEFAULT NULL,
  `Quantity` float(11,2) DEFAULT NULL,
  `Price` float DEFAULT NULL,
  `Subtotal` float DEFAULT NULL,
  `HPrice` double(10,2) NOT NULL,
  `Profit` double(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `billdetails`
--

INSERT INTO `billdetails` (`Id`, `Date`, `ProductName`, `Quantity`, `Price`, `Subtotal`, `HPrice`, `Profit`) VALUES
(41, '3/27/2025', '4\" BEND', 2.00, 16, 32, 0.00, 0.00),
(42, '3/27/2025', '4\" BEND', 1.00, 16, 16, 0.00, 0.00),
(43, '3/27/2025', '4\" BEND', 5.00, 16, 80, 0.00, 0.00),
(44, '3/27/2025', '4\" BEND', 5.00, 16, 80, 0.00, 0.00),
(45, '4/1/2025', '4\" BEND', 5.00, 16, 80, 0.00, 0.00),
(46, '4/1/2025', '4\" BEND', 4.00, 16, 64, 0.00, 0.00),
(47, '4/1/2025', '4\" BEND', 1.00, 16, 16, 0.00, 0.00),
(48, '4/1/2025', '4\" BEND', 5.00, 16, 80, 0.00, 0.00),
(49, '4/1/2025', '4\" BEND', 5.00, 16, 80, 0.00, 0.00),
(50, '4/1/2025', '4\" BEND', 10.00, 16, 160, 0.00, 0.00),
(51, '4/1/2025', '4\" BEND', 1.00, 16, 16, 0.00, 0.00),
(52, '4/1/2025', '4\" BEND', 5.00, 16, 80, 0.00, 0.00),
(53, '4/1/2025', '4\" BEND', 8.00, 16, 128, 0.00, 0.00),
(54, '4/2/2025', '4\" BEND', 5.00, 16, 80, 0.00, 0.00),
(55, '4/2/2025', '4\" BEND', 1.00, 16, 16, 0.00, 0.00),
(56, '4/2/2025', '4\" BEND', 5.00, 16, 80, 0.00, 0.00),
(57, '4/2/2025', '4\" BEND', 10.00, 16, 160, 0.00, 0.00),
(58, '4/2/2025', '4\" BEND', 5.00, 16, 80, 0.00, 0.00),
(59, '4/2/2025', '4\" BEND', 5.00, 16, 80, 0.00, 0.00),
(60, '7/8/2025', '1/2\" PPR CHROME COCK', 5.00, 55, 275, 0.00, 0.00),
(61, '7/8/2025', '1/2\" PPR CHROME COCK', 1.00, 55, 55, 0.00, 0.00),
(62, '7/8/2025', '1/2\" PPR CHROME COCK', 1.00, 55, 55, 0.00, 0.00),
(63, '8/8/2025', 'TOWEL HANGER B/S', 5.00, 180, 900, 0.00, 0.00),
(64, '10/4/2025', '1/2\" PPR CHROME COCK', 1.00, 55, 55, 0.00, 0.00),
(65, '10/7/2025', '3/4\" AIR VALVE BRASS', 5.00, 70, 350, 0.00, 0.00),
(66, '10/7/2025', '3/4\" AIR VALVE BRASS', 1.00, 70, 70, 0.00, 0.00),
(67, '10/7/2025', '3/4\" AIR VALVE BRASS', 1.00, 70, 70, 0.00, 0.00),
(68, '10/7/2025', '1/2\" AIR VALVE BRASS', 5.00, 55, 275, 0.00, 0.00),
(69, '10/7/2025', '3/4\" AIR VALVE BRASS', 1.00, 70, 70, 0.00, 0.00),
(70, '10/7/2025', '1/2\" AIR VALVE BRASS', 5.00, 55, 275, 0.00, 0.00),
(71, '10/7/2025', '1/2\" PPR CHROME COCK', 1.00, 55, 55, 0.00, 0.00),
(72, '10/7/2025', '1/2\" AIR VALVE BRASS', 1.00, 55, 55, 0.00, 0.00),
(73, '10/7/2025', '1/2\" PPR CHROME COCK', 1.00, 55, 55, 0.00, 0.00),
(74, '10/7/2025', '1/2\" PPR CHROME COCK', 1.00, 55, 55, 0.00, 0.00),
(75, '10/7/2025', '1/2\" PPR CHROME COCK', 1.00, 55, 55, 0.00, 0.00),
(76, '10/9/2025', '3/4\" AIR VALVE BRASS', 4.00, 70, 280, 0.00, 0.00),
(77, '10/9/2025', '3/4\" AIR VALVE BRASS', 5.00, 70, 350, 0.00, 0.00),
(78, '10/9/2025', '3/4\" AIR VALVE BRASS', 5.00, 70, 350, 0.00, 0.00),
(79, '10/9/2025', '1/2\" AIR VALVE BRASS', 4.00, 55, 220, 0.00, 0.00),
(80, '10/9/2025', '3/4\" AIR VALVE BRASS', 6.00, 70, 420, 0.00, 0.00),
(81, '10/9/2025', '3/4\" AIR VALVE BRASS', 6.00, 70, 420, 0.00, 0.00),
(82, '10/9/2025', '1/2\" PPR CHROME COCK', 6.00, 55, 330, 0.00, 0.00),
(83, '10/9/2025', '1/2\" PPR CHROME COCK', 10.00, 55, 550, 0.00, 0.00),
(84, '10/9/2025', '1/2\" PPR CHROME COCK', 10.00, 55, 550, 0.00, 0.00),
(85, '10/9/2025', '3/4\" AIR VALVE BRASS', 5.00, 70, 350, 0.00, 0.00),
(86, '10/9/2025', '3/4\" AIR VALVE BRASS', 2.00, 70, 140, 0.00, 0.00),
(87, '10/9/2025', '3/4\" AIR VALVE BRASS', 2.00, 70, 140, 0.00, 0.00),
(88, '10/9/2025', '1/2\" PPR CHROME COCK', 5.00, 55, 275, 0.00, 0.00),
(89, '10/9/2025', '3/4\" AIR VALVE BRASS', 5.00, 70, 350, 0.00, 0.00),
(90, '10/9/2025', '1/2\" PPR CHROME COCK', 6.00, 55, 330, 0.00, 0.00),
(91, '10/9/2025', '1/2\" PPR CHROME COCK', 6.00, 55, 330, 0.00, 0.00),
(92, '10/9/2025', '3/4\" AIR VALVE BRASS', 1.00, 70, 70, 0.00, 0.00),
(93, '10/10/2025', '3/4\" AIR VALVE BRASS', 2.00, 70, 140, 0.00, 0.00),
(94, '2025-10-10 10:35:03.883593', '1/2\" PPR CHROME COCK', 6.00, 55, 330, 0.00, 0.00),
(95, '2025-10-10 10:35:30.346723', '1/2\" PPR CHROME COCK', 3.00, 55, 165, 0.00, 0.00),
(96, '2025-10-10 10:36:23.526430', '1/2\" PPR CHROME COCK', 6.00, 55, 330, 0.00, 0.00),
(97, '2025-10-10 11:07:12.240588', '3/4\" AIR VALVE BRASS', 2.00, 70, 140, 0.00, 0.00),
(98, '2025-10-10 11:46:32.337382', '1/2\" PPR CHROME COCK', 4.00, 55, 220, 0.00, 0.00),
(99, '2025-10-10 11:48:45.756596', '3/4\" AIR VALVE BRASS', 1.00, 70, 70, 0.00, 0.00),
(100, '2025-10-10 11:49:00.101933', '1/2\" PPR CHROME COCK', 10.00, 55, 550, 0.00, 0.00),
(101, '2025-10-11 09:58:44.884748', '1/2\" PPR CHROME COCK', 5.00, 55, 275, 0.00, 0.00),
(102, '2025-10-11 10:26:17.400546', '3/4\" AIR VALVE BRASS', 1.00, 70, 70, 0.00, 0.00),
(103, '2025-10-11 10:27:18.460132', '1/2\" PPR CHROME COCK', 5.00, 55, 275, 0.00, 0.00),
(104, '2025-10-11 10:28:12.304695', '1/2\" PPR CHROME COCK', 5.00, 55, 275, 0.00, 0.00),
(105, '2025-10-11 10:28:28.062016', '1/2\" PPR CHROME COCK', 6.00, 55, 330, 0.00, 0.00),
(106, '2025-10-13 14:32:21.366520', '1/2\" PPR CHROME COCK', 4.00, 55, 220, 0.00, 0.00),
(107, '2025-10-13 14:32:32.562822', '1/2\" PPR CHROME COCK', 6.00, 55, 330, 0.00, 0.00),
(108, '2025-10-13 14:34:37.328643', '1/2\" PPR CHROME COCK', 6.00, 55, 330, 0.00, 0.00),
(109, '2025-10-13 14:34:42.124160', '1/2\" PPR CHROME COCK', 6.00, 55, 330, 0.00, 0.00),
(110, '2025-10-13 14:34:48.491373', '1/2\" PPR CHROME COCK', 7.00, 55, 385, 0.00, 0.00),
(111, '2025-10-13 15:12:09.448420', '1/2\" PPR CHROME COCK', 5.00, 55, 275, 0.00, 0.00),
(112, '2025-10-13 15:12:31.345106', '1/2\" PPR CHROME COCK', 2.00, 55, 110, 0.00, 0.00),
(113, '2025-10-13 16:21:47.246408', '3/4\" AIR VALVE BRASS', 5.00, 70, 350, 0.00, 0.00),
(114, '2025-10-13 16:21:59.065639', '1/2\" ATA CHROME COCK', 5.00, 65, 325, 0.00, 0.00),
(115, '2025-10-13 16:22:15.448673', '1/2\" PPR CHROME COCK', 2.00, 55, 110, 0.00, 0.00),
(116, '2025-10-13 16:22:28.490885', '1/2\" K 1 ERA', 5.00, 20, 100, 0.00, 0.00),
(117, '2025-10-13 16:22:42.611015', '3/4\" AIR VALVE BRASS', 3.00, 70, 210, 0.00, 0.00),
(118, '2025-10-14 01:38:21.957944', '3/4\" AIR VALVE BRASS', 6.00, 70, 420, 0.00, 0.00),
(119, '2025-10-14 01:38:32.547134', '1/2\" PPR CHROME COCK', 1.00, 55, 55, 0.00, 0.00),
(120, '2025-10-14 08:38:05.694149', '3/4\" AIR VALVE BRASS', 5.00, 70, 350, 0.00, 0.00),
(121, '2025-10-14 08:38:11.178517', '3/4\" AIR VALVE BRASS', 4.00, 70, 280, 0.00, 0.00),
(122, '2025-10-14 08:59:06.753122', '3/4\" AIR VALVE BRASS', 4.00, 70, 280, 0.00, 0.00),
(123, '2025-10-14 09:10:43.914256', '3/4\" AIR VALVE BRASS', 5.00, 70, 350, 0.00, 0.00),
(124, '2025-10-14 09:28:22.252839', '3/4 PLUG', 6.00, 50, 300, 0.00, 0.00),
(125, '2025-10-14 09:28:40.566110', '3/4\" AIR VALVE BRASS', 7.00, 70, 490, 0.00, 0.00),
(126, '2025-10-14 09:48:40.623248', '3/4\" AIR VALVE BRASS', 7.00, 70, 490, 0.00, 0.00),
(127, '2025-10-14 11:31:36.983421', '3/4 PLUG', 5.00, 50, 250, 0.00, 0.00),
(128, '2025-10-14 16:15:07.180533', '3/4\" AIR VALVE BRASS', 3.00, 70, 210, 0.00, 0.00),
(129, '2025-10-15 12:43:36.908594', '3/4\" AIR VALVE BRASS', 4.00, 70, 280, 0.00, 0.00),
(130, '2025-10-15 12:44:06.875098', '3/4\" AIR VALVE BRASS', 4.00, 70, 280, 0.00, 0.00),
(131, '2025-10-15 13:41:16.438717', '1/2\" AIR VALVE BRASS', 1.00, 55, 55, 0.00, 0.00),
(132, '2025-10-17 17:15:06.597285', 'drug', 6.00, 50, 300, 0.00, 0.00),
(133, '2025-10-17 17:15:11.871781', 'sofa', 10.00, 100, 1000, 0.00, 0.00),
(134, '2025-10-17 17:51:15.120932', 'sofa', 3.00, 100, 300, 85.00, 45.00),
(135, '2025-10-17 17:54:59.544199', 'sofa', 2.00, 100, 200, 85.00, 30.00),
(136, '2025-10-17 17:58:16.824046', 'sofa', 4.00, 100, 400, 85.00, 60.00),
(137, '2025-10-17 18:03:39.602832', 'sofa', 3.00, 100, 300, 85.00, 45.00),
(138, '2025-10-17 18:26:48.125134', 'sofa', 3.00, 100, 300, 85.00, 45.00),
(139, '2025-10-17 18:33:51.638729', 'drug', 7.00, 50, 350, 49.00, 7.00),
(140, '2025-10-18 04:18:36.084609', 'sofa', 2.00, 100, 200, 85.00, 30.00),
(141, '2025-10-19 12:33:02.803151', 'sofa', 3.00, 100, 300, 85.00, 45.00),
(142, '2025-10-19 12:34:03.063519', 'sofa', 5.00, 100, 500, 85.00, 75.00),
(143, '2025-10-19 12:40:22.415346', 'drug', 3.00, 50, 150, 49.00, 3.00),
(144, '2025-10-19 12:40:27.371353', 'sofa', 5.00, 100, 500, 85.00, 75.00),
(145, '2025-10-19 12:40:33.821372', 'drug', 6.00, 50, 300, 49.00, 6.00),
(146, '2025-10-20 08:23:34.838812', 'sofa', 4.00, 100, 400, 85.00, 60.00),
(147, '2025-10-20 09:44:01.180086', 'sofa', 4.00, 100, 400, 85.00, 60.00),
(148, '2025-10-20 09:55:15.426969', 'drug', 4.00, 50, 200, 49.00, 4.00),
(149, '2025-10-20 09:59:17.419729', 'sofa', 6.00, 100, 600, 85.00, 90.00),
(150, '2025-10-20 10:01:06.946391', 'sofa', 6.00, 100, 600, 85.00, 90.00),
(151, '2025-10-20 10:05:08.283496', 'drug', 4.00, 50, 200, 49.00, 4.00),
(152, '2025-10-20 10:07:22.824434', 'sofa', 4.00, 100, 400, 85.00, 60.00),
(153, '2025-10-20 10:18:00.548360', 'sofa', 3.00, 100, 300, 85.00, 45.00),
(154, '2025-10-20 10:26:10.186556', 'sofa', 5.00, 100, 500, 85.00, 75.00),
(155, '2025-10-20 10:26:13.958318', 'drug', 2.00, 50, 100, 49.00, 2.00),
(156, '2025-10-20 10:40:34.407153', 'sofa', 1.00, 100, 100, 85.00, 15.00),
(157, '2025-10-20 10:46:21.666334', 'sofa', 3.00, 100, 300, 85.00, 45.00),
(158, '2025-10-20 11:02:02.792446', 'sofa', 5.00, 100, 500, 85.00, 75.00),
(159, '2025-10-20 11:02:11.249777', 'drug', 4.00, 50, 200, 49.00, 4.00),
(160, '2025-10-20 11:10:01.119588', 'sofa', 4.00, 100, 400, 85.00, 60.00),
(161, '2025-10-20 11:10:04.911164', 'drug', 7.00, 50, 350, 49.00, 7.00),
(162, '2025-10-20 11:13:55.354820', 'sofa', 1.00, 100, 100, 85.00, 15.00),
(163, '2025-10-20 11:14:03.471713', 'drug', 3.00, 50, 150, 49.00, 3.00),
(164, '2025-10-20 11:20:38.378657', 'drug', 3.00, 50, 150, 49.00, 3.00),
(165, '2025-10-20 11:20:43.577284', 'sofa', 1.00, 100, 100, 85.00, 15.00),
(166, '2025-10-20 11:24:54.806273', 'sofa', 2.00, 100, 200, 85.00, 30.00),
(167, '2025-10-20 11:24:59.616693', 'drug', 1.00, 50, 50, 49.00, 1.00),
(168, '2025-10-20 11:27:11.949263', 'sofa', 1.00, 100, 100, 85.00, 15.00),
(169, '2025-10-20 11:27:17.518220', 'drug', 1.00, 50, 50, 49.00, 1.00),
(170, '2025-10-20 11:28:14.603089', 'drug', 3.00, 50, 150, 49.00, 3.00),
(171, '2025-10-20 11:28:17.971828', 'sofa', 1.00, 100, 100, 85.00, 15.00),
(172, '2025-10-20 11:29:26.152590', 'drug', 2.00, 50, 100, 49.00, 2.00),
(173, '2025-10-20 11:29:33.719358', 'sofa', 3.00, 100, 300, 85.00, 45.00),
(174, '2025-10-20 11:31:52.433021', 'sofa', 3.00, 100, 300, 85.00, 45.00),
(175, '2025-10-20 11:32:01.745615', 'drug', 2.00, 50, 100, 49.00, 2.00),
(176, '2025-10-20 16:42:26.563330', 'drug', 4.00, 50, 200, 49.00, 4.00),
(177, '2025-10-20 16:42:34.376016', 'sofa', 4.00, 100, 400, 85.00, 60.00),
(178, '2025-10-21 13:56:04.180549', 'sofa', 1.00, 100, 100, 85.00, 15.00),
(179, '2025-10-21 17:42:54.494809', 'drug', 4.00, 50, 200, 49.00, 4.00);

-- --------------------------------------------------------

--
-- Table structure for table `billt`
--

CREATE TABLE `billt` (
  `bID` int(11) NOT NULL,
  `Bdate` date NOT NULL,
  `CustId` varchar(255) NOT NULL,
  `CustName` varchar(255) NOT NULL,
  `PMethod` varchar(255) NOT NULL,
  `Amt` float NOT NULL,
  `ProductName` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `billt`
--

INSERT INTO `billt` (`bID`, `Bdate`, `CustId`, `CustName`, `PMethod`, `Amt`, `ProductName`) VALUES
(70, '2025-03-20', '1', '', 'Cash', 75, 'added'),
(71, '2025-03-20', '1', '', 'Cash', 15, 'added'),
(72, '2025-03-20', '1', '', 'Cash', 15, 'Correct'),
(73, '2025-03-20', '1', '', 'Credit', 30, 'Correct'),
(74, '2025-03-20', '1', 'Kwadwo Owusu', 'Momo', 15, 'Correct'),
(75, '2025-03-20', '1', '', 'Cash', 15, 'Correct'),
(76, '2025-03-20', '1', '', 'Cash', 15, 'Correct'),
(77, '2025-03-25', '1', '', 'Cash', 91, '1/1/4\" BEND'),
(78, '2025-03-26', '1', '', 'Momo', 7, '1/1/4\" BEND'),
(79, '2025-03-26', '1', '', 'Momo', 34, '1/1/4\" BEND'),
(80, '2025-03-26', '1', '', 'Cash', 87, '1/2\" BEND'),
(81, '2025-03-26', '1', '', 'Cash', 12, '3\" BEND'),
(82, '2025-03-26', '1', '', 'Cash', 9, '1/2\" BEND'),
(83, '2025-03-26', '1', '', 'Cash', 10, '1/2\" BEND'),
(84, '2025-03-26', '1', '', 'Cash', 62, '3\" BEND'),
(85, '2025-03-26', '1', '', 'Credit', 2, '1/2\" BEND'),
(86, '2025-03-26', '1', '', 'Cash', 75, 'Gid'),
(87, '2025-03-26', '1', '', 'Credit', 75, 'Gid'),
(88, '2025-03-26', '1', '', 'Cash', 25, 'Gid'),
(89, '2025-03-26', '1', '', 'Cash', 3.5, '1/1/4\" BEND'),
(90, '2025-03-26', '1', '', 'Cash', 24.875, 'Gid'),
(91, '2025-03-26', '1', '', 'Cash', 2, '1/2\" BEND'),
(92, '2025-03-26', '1', '', 'Cash', 25, 'Gid'),
(93, '2025-03-26', '1', '', 'Credit', 25, 'Gid'),
(94, '2025-03-26', '1', '', 'Cash', 6, '3\" BEND'),
(95, '2025-03-26', '1', '', 'Cash', 7.5, '1/1/4\" BEND'),
(96, '2025-03-26', '1', '', 'Cash', 6, '1/2\" BEND'),
(97, '2025-03-27', '1', '', 'Cash', 80, '4\" BEND'),
(98, '2025-03-27', '1', '', 'Cash', 80, '4\" BEND'),
(99, '2025-04-01', '1', '', 'Cash', 80, '4\" BEND'),
(100, '2025-04-01', '1', '', 'Cash', 64, '4\" BEND'),
(101, '2025-04-01', '1', '', 'Cash', 16, '4\" BEND'),
(102, '2025-04-01', '1', '', 'Momo', 80, '4\" BEND'),
(103, '2025-04-01', '1', '', 'Cash', 80, '4\" BEND'),
(104, '2025-04-01', '1', '', 'Cash', 160, '4\" BEND'),
(105, '2025-04-01', '1', '', 'Cash', 128, '4\" BEND'),
(106, '2025-04-02', '1', '', 'Cash', 80, '4\" BEND'),
(107, '2025-04-02', '1', '', 'Payment Method', 80, '4\" BEND'),
(108, '2025-04-02', '1', '', 'Payment Method', 160, '4\" BEND'),
(109, '2025-04-02', '1', '', 'Payment Method', 80, '4\" BEND'),
(110, '2025-04-02', '1', '', 'Payment Method', 80, '4\" BEND'),
(111, '2025-07-08', '1', '', 'Momo', 275, '1/2\" PPR CHROME COCK'),
(112, '2025-07-08', '1', '', 'Cash', 55, '1/2\" PPR CHROME COCK'),
(113, '2025-08-08', '1', '', 'Cash', 900, 'TOWEL HANGER B/S'),
(114, '2025-10-04', '1', '', 'Cash', 55, '1/2\" PPR CHROME COCK'),
(115, '2025-10-07', '1', '', 'Cash', 350, '3/4\" AIR VALVE BRASS'),
(116, '2025-10-07', '1', '', 'Cash', 400, '1/2\" PPR CHROME COCK'),
(117, '2025-10-07', '1', '', 'Cash', 55, '1/2\" AIR VALVE BRASS'),
(118, '2025-10-09', '1', '', 'Momo', 280, '3/4\" AIR VALVE BRASS'),
(119, '2025-10-09', '1', '', 'Payment Method', 570, '1/2\" AIR VALVE BRASS'),
(120, '2025-10-09', '1', '', 'Payment Method', 750, '1/2\" PPR CHROME COCK'),
(121, '2025-10-09', '1', '', 'Payment Method', 900, '3/4\" AIR VALVE BRASS'),
(122, '2025-10-09', '1', '', 'Payment Method', 415, '1/2\" PPR CHROME COCK'),
(123, '2025-10-10', '1', '', 'Cash', 330, '1/2\" PPR CHROME COCK'),
(124, '2025-10-10', '1', '', 'Payment Method', 140, '3/4\" AIR VALVE BRASS'),
(125, '2025-10-10', '1', '', 'Payment Method', 220, '1/2\" PPR CHROME COCK'),
(126, '2025-10-10', '1', '', 'Payment Method', 620, '1/2\" PPR CHROME COCK'),
(127, '2025-10-11', '1', '', 'Cash', 275, '1/2\" PPR CHROME COCK'),
(128, '2025-10-11', '1', '', 'Payment Method', 275, '1/2\" PPR CHROME COCK'),
(129, '2025-10-11', '1', '', 'Payment Method', 605, '1/2\" PPR CHROME COCK'),
(130, '2025-10-13', '1', '', 'Payment Method', 550, '1/2\" PPR CHROME COCK'),
(131, '2025-10-13', '1', '', 'Payment Method', 1045, '1/2\" PPR CHROME COCK'),
(132, '2025-10-13', '1', '', 'Payment Method', 275, '1/2\" PPR CHROME COCK'),
(133, '2025-10-13', '1', '', 'Payment Method', 110, '1/2\" PPR CHROME COCK'),
(134, '2025-10-13', '1', '', 'Payment Method', 885, '1/2\" K 1 ERA'),
(135, '2025-10-14', '1', '', 'Payment Method', 475, '1/2\" PPR CHROME COCK'),
(136, '2025-10-14', '1', '', 'Payment Method', 630, '3/4\" AIR VALVE BRASS'),
(137, '2025-10-14', '1', '', 'Payment Method', 280, '3/4\" AIR VALVE BRASS'),
(138, '2025-10-14', '1', '', 'Payment Method', 350, '3/4\" AIR VALVE BRASS'),
(139, '2025-10-14', '1', '', 'Payment Method', 790, '3/4\" AIR VALVE BRASS'),
(140, '2025-10-14', '1', '', 'Payment Method', 490, '3/4\" AIR VALVE BRASS'),
(141, '2025-10-14', '1', '', 'Payment Method', 250, '3/4 PLUG'),
(142, '2025-10-14', '1', '', 'Payment Method', 210, '3/4\" AIR VALVE BRASS'),
(143, '2025-10-15', '1', '', 'Payment Method', 560, '3/4\" AIR VALVE BRASS'),
(144, '2025-10-15', '1', '', 'Payment Method', 55, '1/2\" AIR VALVE BRASS'),
(145, '2025-10-17', '1', '', 'Payment Method', 1300, 'sofa'),
(146, '2025-10-17', '1', '', 'Payment Method', 300, 'sofa'),
(147, '2025-10-18', '1', '', 'Payment Method', 200, 'sofa'),
(148, '2025-10-19', '1', '', 'Payment Method', 300, 'sofa'),
(149, '2025-10-19', '1', '', 'Payment Method', 500, 'sofa'),
(150, '2025-10-19', '1', '', 'Payment Method', 950, 'drug'),
(151, '2025-10-20', '1', '', 'Payment Method', 400, 'sofa'),
(152, '2025-10-20', '1', '', 'Payment Method', 400, 'sofa'),
(153, '2025-10-20', '1', '', 'Payment Method', 200, 'drug'),
(154, '2025-10-20', '1', '', 'Payment Method', 600, 'sofa'),
(155, '2025-10-20', '1', '', 'Payment Method', 600, 'sofa'),
(156, '2025-10-20', '1', '', 'Payment Method', 200, 'drug'),
(157, '2025-10-20', '1', '', 'Cash', 400, 'sofa'),
(158, '2025-10-20', '1', '', 'Payment Method', 300, 'sofa'),
(159, '2025-10-20', '1', '', 'Cash', 600, 'drug'),
(160, '2025-10-20', '1', '', 'Payment Method', 100, 'sofa'),
(161, '2025-10-20', '1', '', 'Payment Method', 300, 'sofa'),
(162, '2025-10-20', '1', '', 'Payment Method', 700, 'drug'),
(163, '2025-10-20', '1', '', 'Payment Method', 750, 'drug'),
(164, '2025-10-20', '1', '', 'Payment Method', 250, 'drug'),
(165, '2025-10-20', '1', '', 'Payment Method', 250, 'sofa'),
(166, '2025-10-20', '1', '', 'Payment Method', 250, 'drug'),
(167, '2025-10-20', '1', '', 'Payment Method', 150, 'drug'),
(168, '2025-10-20', '1', '', 'Payment Method', 250, 'sofa'),
(169, '2025-10-20', '1', '', 'Payment Method', 400, 'sofa'),
(170, '2025-10-20', '1', '', 'Payment Method', 400, 'drug'),
(171, '2025-10-20', '1', '', 'Payment Method', 600, 'sofa'),
(172, '2025-10-21', '1', '', 'Payment Method', 100, 'sofa'),
(173, '2025-10-21', '1', '', 'Payment Method', 200, 'drug');

-- --------------------------------------------------------

--
-- Table structure for table `customertbl`
--

CREATE TABLE `customertbl` (
  `CusId` int(11) NOT NULL,
  `CusName` varchar(255) NOT NULL,
  `CusAdd` varchar(255) NOT NULL,
  `CusPhone` int(11) NOT NULL,
  `CusRem` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customertbl`
--

INSERT INTO `customertbl` (`CusId`, `CusName`, `CusAdd`, `CusPhone`, `CusRem`) VALUES
(1, 'Fosu Boahen', 'JM 11', 246380080, 'he owns electrical shop'),
(2, 'Bismark', 'Anyima', 246380080, 'great'),
(3, 'Hey', 'et', 55555, 'good');

-- --------------------------------------------------------

--
-- Table structure for table `expenses`
--

CREATE TABLE `expenses` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `cost` double NOT NULL,
  `date` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `producttbl`
--

CREATE TABLE `producttbl` (
  `PId` int(11) NOT NULL,
  `PName` varchar(255) NOT NULL,
  `Pcat` varchar(255) NOT NULL,
  `Pprice` double(11,2) NOT NULL,
  `H_Price` double(11,2) NOT NULL,
  `PQty` float(11,2) NOT NULL,
  `expiry_date` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `producttbl`
--

INSERT INTO `producttbl` (`PId`, `PName`, `Pcat`, `Pprice`, `H_Price`, `PQty`, `expiry_date`) VALUES
(1240, 'Gid', 'Plumbing Materials', 50.00, 0.00, 0.00, ''),
(1241, 'sofa', 'Plumbing Materials', 100.00, 85.00, 1.00, ''),
(1242, 'drug', 'Plumbing Materials', 50.00, 49.00, 34.00, '');

-- --------------------------------------------------------

--
-- Table structure for table `suppliertbl`
--

CREATE TABLE `suppliertbl` (
  `SupId` int(11) NOT NULL,
  `SupName` varchar(255) NOT NULL,
  `SupAddress` varchar(255) NOT NULL,
  `SupPhone` varchar(255) NOT NULL,
  `SupRem` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `suppliertbl`
--

INSERT INTO `suppliertbl` (`SupId`, `SupName`, `SupAddress`, `SupPhone`, `SupRem`) VALUES
(1, 'Kofi Abogo', 'Supplier of beans', '246380080', 'We gonn make');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `billdetails`
--
ALTER TABLE `billdetails`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `billt`
--
ALTER TABLE `billt`
  ADD PRIMARY KEY (`bID`);

--
-- Indexes for table `customertbl`
--
ALTER TABLE `customertbl`
  ADD PRIMARY KEY (`CusId`);

--
-- Indexes for table `expenses`
--
ALTER TABLE `expenses`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `producttbl`
--
ALTER TABLE `producttbl`
  ADD PRIMARY KEY (`PId`);

--
-- Indexes for table `suppliertbl`
--
ALTER TABLE `suppliertbl`
  ADD PRIMARY KEY (`SupId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `billdetails`
--
ALTER TABLE `billdetails`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=180;

--
-- AUTO_INCREMENT for table `billt`
--
ALTER TABLE `billt`
  MODIFY `bID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=174;

--
-- AUTO_INCREMENT for table `customertbl`
--
ALTER TABLE `customertbl`
  MODIFY `CusId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `expenses`
--
ALTER TABLE `expenses`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `producttbl`
--
ALTER TABLE `producttbl`
  MODIFY `PId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1243;

--
-- AUTO_INCREMENT for table `suppliertbl`
--
ALTER TABLE `suppliertbl`
  MODIFY `SupId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
