-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 13, 2024 at 01:46 PM
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
-- Database: `bankdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `account`
--

CREATE TABLE `account` (
  `accid` int(11) NOT NULL,
  `cusid` int(11) NOT NULL,
  `acctype` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `balance` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`accid`, `cusid`, `acctype`, `description`, `balance`) VALUES
(11122221, 1000, 'Savings ', 'save', 11900),
(11122334, 1001, 'Savings ', '1112233', 1208733),
(0, 1002, '', '', 0),
(0, 1003, '', '', 0),
(0, 1004, 'Savings ', 'savings accounts created', 20),
(0, 1005, 'Fix', 'Deposit', 500),
(0, 1006, 'Savings ', 'save', 100),
(0, 1007, 'Fix', 'Fixed Deposit', 6000),
(123425, 1008, 'Fix', 'fixed deposit', 19750),
(3332222, 1009, 'Savings ', 'save', 2210),
(87882563, 1010, 'Savings ', 'savings', -5);

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `userid` int(11) NOT NULL,
  `fullname` varchar(255) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`userid`, `fullname`, `username`, `password`) VALUES
(1, 'Kofi Amos', 'amos1', 'dbdbdb'),
(2, 'Gidcode', 'gid94', '1234567'),
(3, 'Isaac Ofori', 'ofori', 'icedel1'),
(4, 'Amo Mensah Elvis', 'amoselvis', 'goodmoney1'),
(5, 'Nyarko Freda', 'freda', 'Nyfa');

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `cusID` int(11) NOT NULL,
  `lastname` varchar(255) NOT NULL,
  `firstname` varchar(255) NOT NULL,
  `street` varchar(255) NOT NULL,
  `city` varchar(255) NOT NULL,
  `phone` int(11) NOT NULL,
  `date` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `custumertbl`
--

CREATE TABLE `custumertbl` (
  `custid` int(11) NOT NULL,
  `lastname` varchar(255) NOT NULL,
  `firstname` varchar(255) NOT NULL,
  `street` varchar(255) NOT NULL,
  `city` int(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `phone` int(11) NOT NULL,
  `date` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `loan`
--

CREATE TABLE `loan` (
  `l_id` int(11) NOT NULL,
  `accno` varchar(255) NOT NULL,
  `date` varchar(255) NOT NULL,
  `phone` varchar(255) NOT NULL,
  `houseno` varchar(255) NOT NULL,
  `loanamount` int(11) NOT NULL,
  `duration` varchar(11) NOT NULL,
  `purpose` varchar(255) NOT NULL,
  `status` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `loanform`
--

CREATE TABLE `loanform` (
  `l_id` int(11) NOT NULL,
  `fullname` varchar(255) NOT NULL,
  `accno` int(11) NOT NULL,
  `date` varchar(255) NOT NULL,
  `phone` varchar(255) NOT NULL,
  `houseno` varchar(255) NOT NULL,
  `loanamount` int(11) NOT NULL,
  `duration` int(11) NOT NULL,
  `purpose` varchar(255) NOT NULL,
  `status` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `loaninfo`
--

CREATE TABLE `loaninfo` (
  `loanamount` int(11) NOT NULL,
  `duration` varchar(255) NOT NULL,
  `purpose` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `loantbl`
--

CREATE TABLE `loantbl` (
  `l_id` int(11) NOT NULL,
  `fullname` varchar(255) NOT NULL,
  `cid` int(11) NOT NULL,
  `card` varchar(255) NOT NULL,
  `date` varchar(255) NOT NULL,
  `phone` varchar(255) NOT NULL,
  `houseaddress` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `loantbl`
--

INSERT INTO `loantbl` (`l_id`, `fullname`, `cid`, `card`, `date`, `phone`, `houseaddress`) VALUES
(7, 'Owusu Moses', 111111, '11111111', 'Tuesday, October 1, 2024', '0246380080', 'JM 12');

-- --------------------------------------------------------

--
-- Table structure for table `loan_info`
--

CREATE TABLE `loan_info` (
  `accno` int(11) NOT NULL,
  `loanamount` int(11) NOT NULL,
  `duration` int(11) NOT NULL,
  `purpose` varchar(255) NOT NULL,
  `payamount` int(11) NOT NULL,
  `end_date` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `loan_info`
--

INSERT INTO `loan_info` (`accno`, `loanamount`, `duration`, `purpose`, `payamount`, `end_date`) VALUES
(111111, 1950, 12, 'the farming game', 2000, '');

-- --------------------------------------------------------

--
-- Table structure for table `payment_loan`
--

CREATE TABLE `payment_loan` (
  `accno` int(11) NOT NULL,
  `loan_balance` int(11) NOT NULL,
  `payment_amount` int(11) NOT NULL,
  `payment_date` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `payment_loan`
--

INSERT INTO `payment_loan` (`accno`, `loan_balance`, `payment_amount`, `payment_date`) VALUES
(111111, 2400, 50, '2024-10-02'),
(111111, 2350, 50, '2024-10-02'),
(111111, 2300, 50, '2024-10-02'),
(111111, 2200, 100, '2024-10-02'),
(111111, 2150, 50, '2024-10-02'),
(111111, 2100, 50, '2024-10-02'),
(111111, 2000, 100, '2024-10-02');

-- --------------------------------------------------------

--
-- Table structure for table `tblcustomer`
--

CREATE TABLE `tblcustomer` (
  `custid` int(11) NOT NULL,
  `lastname` varchar(255) NOT NULL,
  `firstname` varchar(255) NOT NULL,
  `street` varchar(255) NOT NULL,
  `city` varchar(255) NOT NULL,
  `region` varchar(255) NOT NULL,
  `phone` int(11) NOT NULL,
  `date` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tblcustomer`
--

INSERT INTO `tblcustomer` (`custid`, `lastname`, `firstname`, `street`, `city`, `region`, `phone`, `date`, `email`) VALUES
(1000, 'John', 'Gid', 'JM 11', 'hema', 'Kintampo', 66666555, 'Monday, September 16, 2024', 'devgid@gmail.com'),
(1001, 'Oti', 'Arhin', 'Techiman', 'Jema', 'Kintampo', 6633333, 'Monday, September 16, 2024', 'devgid@gmai.com'),
(1002, '', '', '', '', '', 0, 'Tuesday, September 17, 2024', ''),
(1003, 'Takyi', 'David', 'Domeabra', 'Jema', 'Kintampo South ', 554617285, 'Wednesday, September 18, 2024', 'devgid@gmail.com'),
(1004, 'Owusu', 'Clement', 'Aboaso', 'Techiman', 'Bono East', 246380080, 'Wednesday, September 18, 2024', 'owusuclement@gmail.com'),
(1005, 'Nana ', 'Appiah', 'Aboaso', 'Jema', 'Bono East', 550273404, 'Thursday, September 19, 2024', 'bensouth@gmail.com'),
(1006, 'Adam', 'Yussif', 'Jema Nkwanta', 'Jema', 'Bono East', 246380080, 'Thursday, September 19, 2024', 'adamy@gmail.com'),
(1007, 'Yeboah', 'Evans', 'Jema', 'Paninamisa', 'Bono East', 20186020, 'Thursday, September 19, 2024', 'yevns@gmail.com'),
(1008, 'Fosu', 'Desmond', 'Hospital Main', 'Jema', 'f@gmail.com', 57620123, 'Thursday, September 19, 2024', 'Bono East'),
(1009, 'Ofori', 'Boateng', 'Jema', 'Jema', 'ofori@gmail.com', 246380080, 'Sunday, September 22, 2024', 'Bono East'),
(1010, 'Gyamea', 'Florence', 'Anyima', 'Anyima', 'gyamea@gmail.com', 550273404, 'Saturday, September 28, 2024', 'Bono East');

-- --------------------------------------------------------

--
-- Table structure for table `transactions`
--

CREATE TABLE `transactions` (
  `ts_id` int(11) NOT NULL,
  `accid` int(11) NOT NULL,
  `date` varchar(255) NOT NULL,
  `narration` int(11) NOT NULL,
  `withdraw` int(11) NOT NULL,
  `deposit` int(11) DEFAULT NULL,
  `bal` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `transactions`
--

INSERT INTO `transactions` (`ts_id`, `accid`, `date`, `narration`, `withdraw`, `deposit`, `bal`) VALUES
(1, 11122221, '0000-00-00', 1000, 200, NULL, ''),
(2, 11122221, '0000-00-00', 1200, 400, NULL, ''),
(3, 11122221, '0000-00-00', 1600, 0, 700, ''),
(4, 11122221, '0000-00-00', 1400, 0, 500, ''),
(5, 11122221, '0000-00-00', 900, 1000, NULL, ''),
(6, 11122334, '0000-00-00', 1221833, 0, 1000, ''),
(7, 3332222, '0000-00-00', 10, 5000, NULL, ''),
(8, 3332222, '0000-00-00', 5010, 0, 200, ''),
(9, 123425, '0000-00-00', 9600, 10000, NULL, ''),
(10, 123425, '0000-00-00', 19600, 600, NULL, ''),
(11, 123425, '0000-00-00', 20200, 0, 500, ''),
(12, 3332222, '9/26/2024', 4810, 0, 1000, ''),
(13, 11122334, '9/26/2024', 1220733, 0, 12000, ''),
(14, 3332222, '2024-09-26', 3810, 500, NULL, ''),
(15, 3332222, '2024-09-26', 4310, 0, 100, ''),
(16, 123425, '2024-09-27', 19700, 50, NULL, ''),
(17, 3332222, '2024-09-27', 4210, 0, 2000, ''),
(18, 11122221, '2024-09-27', 2400, 500, NULL, ''),
(19, 11122221, '2024-09-27', 2900, 0, 1000, ''),
(20, 11122221, '2024-09-27', 1900, 10000, NULL, ''),
(21, 87882563, '2024-09-28', 200, 0, 10, ''),
(22, 87882563, '2024-09-30', 190, 0, 50, 'cash deposited'),
(23, 87882563, '2024-10-02', 240, 0, 50, 'self'),
(24, 87882563, '2024-10-02', 290, 150, NULL, 'by seth'),
(25, 87882563, '2024-10-04', 140, 0, 50, 'sef '),
(26, 87882563, '190', 2024, 0, NULL, '195');

-- --------------------------------------------------------

--
-- Table structure for table `transfer`
--

CREATE TABLE `transfer` (
  `tf_id` int(11) NOT NULL,
  `f_acc` int(11) NOT NULL,
  `t_acc` int(11) NOT NULL,
  `date` varchar(255) NOT NULL,
  `amount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `transfer`
--

INSERT INTO `transfer` (`tf_id`, `f_acc`, `t_acc`, `date`, `amount`) VALUES
(1, 11122334, 11122221, 'Tuesday, September 17, 2024', 500),
(2, 123425, 11122221, 'Thursday, September 19, 2024', 400),
(3, 11122334, 11122221, 'Wednesday, September 25, 2024', 100);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`userid`);

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`cusID`);

--
-- Indexes for table `custumertbl`
--
ALTER TABLE `custumertbl`
  ADD PRIMARY KEY (`custid`),
  ADD UNIQUE KEY `custid` (`custid`,`lastname`,`firstname`,`street`,`city`,`email`,`phone`,`date`) USING HASH,
  ADD UNIQUE KEY `custid_2` (`custid`,`lastname`,`firstname`,`street`,`city`,`email`,`phone`,`date`) USING HASH;

--
-- Indexes for table `loan`
--
ALTER TABLE `loan`
  ADD PRIMARY KEY (`l_id`);

--
-- Indexes for table `loanform`
--
ALTER TABLE `loanform`
  ADD PRIMARY KEY (`l_id`);

--
-- Indexes for table `loantbl`
--
ALTER TABLE `loantbl`
  ADD PRIMARY KEY (`l_id`);

--
-- Indexes for table `tblcustomer`
--
ALTER TABLE `tblcustomer`
  ADD PRIMARY KEY (`custid`);

--
-- Indexes for table `transactions`
--
ALTER TABLE `transactions`
  ADD PRIMARY KEY (`ts_id`);

--
-- Indexes for table `transfer`
--
ALTER TABLE `transfer`
  ADD PRIMARY KEY (`tf_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin`
--
ALTER TABLE `admin`
  MODIFY `userid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `customer`
--
ALTER TABLE `customer`
  MODIFY `cusID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `loan`
--
ALTER TABLE `loan`
  MODIFY `l_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `loanform`
--
ALTER TABLE `loanform`
  MODIFY `l_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `loantbl`
--
ALTER TABLE `loantbl`
  MODIFY `l_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `transactions`
--
ALTER TABLE `transactions`
  MODIFY `ts_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT for table `transfer`
--
ALTER TABLE `transfer`
  MODIFY `tf_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
