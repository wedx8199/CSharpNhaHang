-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 09, 2019 at 03:40 PM
-- Server version: 10.1.36-MariaDB
-- PHP Version: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `nhahang`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetDoanhThuByDate` (IN `date1` VARCHAR(255), IN `date2` VARCHAR(255))  SELECT t.name , b.id ,b.total , b.discount ,b.DateChecked FROM bill AS b, tablefood AS t WHERE b.status = 1 AND t.id = b.id_table AND b.DateChecked BETWEEN date1 AND date2$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `GetListBillByDateForReport` ()  SELECT t.name , b.id ,b.total , b.discount ,b.DateChecked FROM bill AS b, tablefood AS t WHERE b.status = 1 AND t.id = b.id_table$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `PrintBillInfo` (IN `idbill` INT)  SELECT f.name , bi.quantity ,f.price FROM food AS f, bill_info AS bi WHERE f.id = bi.id_food AND bi.id_bill = idbill$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `PrintBillInfoTotal` (IN `idbill` INT)  SELECT t.name , b.id ,b.total , b.discount ,b.DateChecked FROM bill AS b, tablefood AS t WHERE b.id = idbill AND t.id = b.id_table$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `bill`
--

CREATE TABLE `bill` (
  `id` int(11) NOT NULL,
  `DateChecked` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `id_table` int(11) NOT NULL,
  `bill_maker` int(11) NOT NULL,
  `total` float NOT NULL DEFAULT '0',
  `discount` int(11) NOT NULL DEFAULT '0',
  `status` varchar(255) COLLATE utf8_unicode_ci NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `bill`
--

INSERT INTO `bill` (`id`, `DateChecked`, `id_table`, `bill_maker`, `total`, `discount`, `status`) VALUES
(1, '2019-11-14 03:18:01', 3, 1, 100000, 20, '1'),
(2, '2019-10-31 15:54:12', 1, 1, 72000, 40, '1'),
(4, '2019-11-01 14:09:40', 4, 1, 210000, 0, '1'),
(7, '2019-11-15 13:13:37', 7, 1, 90000, 0, '1'),
(8, '2019-11-15 14:57:08', 6, 3, 325000, 0, '1'),
(10, '2019-11-16 11:09:12', 4, 3, 185000, 0, '1'),
(13, '2019-11-16 17:21:51', 5, 3, 200000, 0, '1'),
(14, '2019-11-17 12:21:03', 5, 3, 25000, 50, '1'),
(15, '2019-11-17 20:07:42', 11, 3, 203000, 30, '1'),
(16, '2019-11-18 15:34:34', 9, 3, 50000, 0, '1'),
(18, '2019-12-01 19:59:06', 6, 3, 75000, 0, '1'),
(19, '2019-12-01 20:24:35', 9, 3, 40000, 0, '1'),
(20, '2019-12-01 20:25:01', 9, 3, 140000, 0, '1'),
(21, '2019-12-01 20:25:14', 8, 3, 100000, 0, '1'),
(22, '2019-12-01 21:03:42', 11, 3, 84000, 30, '1'),
(23, '2019-12-01 21:11:54', 5, 3, 50000, 0, '1'),
(24, '2019-12-01 21:43:21', 4, 3, 100000, 0, '1'),
(25, '2019-12-01 21:51:28', 1, 3, 15000, 0, '1'),
(26, '2019-12-01 21:54:22', 2, 3, 12500, 50, '1'),
(27, '2019-12-04 12:28:04', 11, 3, 0, 0, '0');

-- --------------------------------------------------------

--
-- Table structure for table `bill_info`
--

CREATE TABLE `bill_info` (
  `id` int(11) NOT NULL,
  `id_bill` int(11) NOT NULL,
  `id_food` int(11) NOT NULL,
  `id_food_cat` int(11) NOT NULL,
  `quantity` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `bill_info`
--

INSERT INTO `bill_info` (`id`, `id_bill`, `id_food`, `id_food_cat`, `quantity`) VALUES
(1, 1, 1, 1, 2),
(2, 1, 6, 3, 1),
(3, 2, 7, 8, 2),
(4, 2, 5, 3, 2),
(6, 4, 2, 1, 2),
(7, 4, 5, 3, 2),
(8, 4, 8, 8, 3),
(9, 1, 5, 3, 1),
(12, 7, 7, 8, 1),
(13, 8, 5, 3, 5),
(15, 10, 9, 8, 2),
(17, 14, 1, 1, 2),
(18, 15, 5, 3, 4),
(19, 15, 6, 3, 3),
(20, 15, 9, 8, 3),
(21, 10, 10, 8, 1),
(22, 10, 3, 2, 1),
(23, 10, 2, 1, 2),
(24, 16, 1, 1, 2),
(25, 7, 11, 4, 1),
(26, 8, 1, 1, 3),
(28, 18, 1, 1, 3),
(29, 19, 2, 1, 1),
(30, 20, 2, 1, 1),
(31, 20, 5, 3, 2),
(32, 21, 7, 8, 2),
(33, 21, 4, 2, 2),
(34, 22, 2, 1, 3),
(35, 23, 1, 1, 2),
(36, 24, 5, 3, 2),
(37, 25, 10, 8, 1),
(38, 26, 1, 1, 1),
(39, 27, 1, 1, 1);

--
-- Triggers `bill_info`
--
DELIMITER $$
CREATE TRIGGER `QuantityControl` AFTER INSERT ON `bill_info` FOR EACH ROW BEGIN
DECLARE idFood INT(11);
DECLARE orderedQuantity INT(11);

SET idFood = new.id_food;
SET orderedQuantity = new.quantity;

UPDATE food SET quantity = quantity - orderedQuantity WHERE id = idFood;

END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `UTG_DeleteBillInfo` AFTER DELETE ON `bill_info` FOR EACH ROW BEGIN

DECLARE billInfoID INT(11);
DECLARE billID INT(11);
DECLARE idTable INT(11);
DECLARE dem INT(11);
SET dem = 0;

SET billInfoID = old.id;
SET billID = old.id_bill;

SELECT id_table INTO idTable FROM bill WHERE id = billID;

SELECT COUNT(*) INTO dem FROM bill_info AS bi, bill AS b WHERE b.id= bi.id_bill AND b.id= billID AND b.status = 0;
IF dem=0 THEN
UPDATE `tablefood` SET `status` = 'Tr???ng' WHERE `tablefood`.`id` = idTable;
DELETE FROM bill WHERE id = billID AND status = 0;
END IF;

END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `id` int(11) NOT NULL,
  `name` varchar(255) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Ch??a ?????t t??n'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`id`, `name`) VALUES
(1, 'Ha??i sa??n'),
(2, 'Mo??n Bo??'),
(3, 'Mo??n Heo'),
(4, 'Mo??n Ga??'),
(5, 'Mo??n C??m'),
(6, 'L????u'),
(7, '??????c bi????t'),
(8, 'N??????c gi???i kh??t');

-- --------------------------------------------------------

--
-- Table structure for table `food`
--

CREATE TABLE `food` (
  `id` int(11) NOT NULL,
  `name` varchar(255) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Ch??a ?????t t??n',
  `id_cat` int(11) NOT NULL,
  `quantity` int(11) NOT NULL DEFAULT '50',
  `price` float NOT NULL DEFAULT '0',
  `status` varchar(25) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'C??n h??ng'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `food`
--

INSERT INTO `food` (`id`, `name`, `id_cat`, `quantity`, `price`, `status`) VALUES
(1, 'Ca?? Nugget', 1, 41, 25000, 'C??n h??ng'),
(2, 'Ngh??u h????p sa??', 1, 45, 40000, 'C??n h??ng'),
(3, 'B?? s???t ti??u xanh', 2, 50, 80000, 'C??n h??ng'),
(4, 'B?? n?????ng l?? l???t', 2, 38, 40000, 'C??n h??ng'),
(5, 'Ba ch??? chi??n b??', 3, 46, 50000, 'C??n h??ng'),
(6, 'Heo n?????ng gi??? c???y', 3, 50, 25000, 'C??n h??ng'),
(7, 'Coca Cola', 8, 48, 10000, 'C??n h??ng'),
(8, 'Pepsi', 8, 50, 10000, 'C??n h??ng'),
(9, 'N?????c su???i', 8, 50, 5000, 'C??n h??ng'),
(10, 'Cafe s???a ????', 8, 39, 15000, 'C??n h??ng'),
(11, 'Oyakodon', 4, 0, 80000, 'C??n h??ng'),
(12, 'C??m chi??n d????ng ch??u', 5, 30, 35000, 'C??n h??ng'),
(13, 'C??m chi??n h???i s???n', 5, 30, 35000, 'C??n h??ng'),
(14, 'L???u b?? nh???', 6, 30, 150000, 'C??n h??ng'),
(15, 'L???u b?? l???n', 6, 30, 190000, 'C??n h??ng'),
(16, 'L???u th??i nh???', 6, 40, 100000, 'C??n h??ng'),
(17, 'L???u th??i l???n', 6, 40, 120000, 'C??n h??ng'),
(18, 'M?? ?? s???t b??', 7, 10, 35000, 'C??n h??ng'),
(19, 'Pizza h???i s???n', 7, 10, 90000, 'C??n h??ng');

-- --------------------------------------------------------

--
-- Table structure for table `tablefood`
--

CREATE TABLE `tablefood` (
  `id` int(11) NOT NULL,
  `name` varchar(255) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Ch??a ?????t t??n b??n',
  `status` varchar(255) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Tr???ng'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tablefood`
--

INSERT INTO `tablefood` (`id`, `name`, `status`) VALUES
(1, 'B??n 1', 'Tr???ng'),
(2, 'B??n 2', 'Tr???ng'),
(3, 'B??n 3', 'Tr???ng'),
(4, 'B??n 4', 'Tr???ng'),
(5, 'B??n 5', 'Tr???ng'),
(6, 'B??n 6', 'Tr???ng'),
(7, 'B??n 7', 'Tr???ng'),
(8, 'B??n 8', 'Tr???ng'),
(9, 'B??n 9', 'Tr???ng'),
(10, 'B??n 10', 'Tr???ng'),
(11, 'B??n 11', 'Co?? ng??????i');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `fullname` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `birthday` date NOT NULL,
  `gender` varchar(5) COLLATE utf8_unicode_ci NOT NULL,
  `phone` varchar(11) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'ch??a c??',
  `email` varchar(255) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'ch??a c??',
  `address` varchar(255) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'ch??a c??',
  `username` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(255) COLLATE utf8_unicode_ci NOT NULL DEFAULT '20720532132149213101239102231223249249135100218',
  `type` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `fullname`, `birthday`, `gender`, `phone`, `email`, `address`, `username`, `password`, `type`) VALUES
(1, 'D????ng Ho??ng L??n', '1999-10-28', 'nam', '01224186811', 'manutdvodoi@gmail.com', 'ch??a c??', 'wedx8199', '20720532132149213101239102231223249249135100218', 0),
(3, 'D????ng Ho??ng Huy', '1999-09-10', 'nam', '0995475406', 'yahoo@yahoo.com', 'ch??a c??', 'psp8199', '20720532132149213101239102231223249249135100218', 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bill`
--
ALTER TABLE `bill`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_id_table` (`id_table`),
  ADD KEY `FK_bill_maker` (`bill_maker`);

--
-- Indexes for table `bill_info`
--
ALTER TABLE `bill_info`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_id_bill` (`id_bill`),
  ADD KEY `fk_id_food` (`id_food`);

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `food`
--
ALTER TABLE `food`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_cat` (`id_cat`),
  ADD KEY `id_cat_2` (`id_cat`);

--
-- Indexes for table `tablefood`
--
ALTER TABLE `tablefood`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bill`
--
ALTER TABLE `bill`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT for table `bill_info`
--
ALTER TABLE `bill_info`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `food`
--
ALTER TABLE `food`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `tablefood`
--
ALTER TABLE `tablefood`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `bill`
--
ALTER TABLE `bill`
  ADD CONSTRAINT `fk_id_table` FOREIGN KEY (`id_table`) REFERENCES `tablefood` (`id`);

--
-- Constraints for table `bill_info`
--
ALTER TABLE `bill_info`
  ADD CONSTRAINT `fk_id_bill` FOREIGN KEY (`id_bill`) REFERENCES `bill` (`id`),
  ADD CONSTRAINT `fk_id_food` FOREIGN KEY (`id_food`) REFERENCES `food` (`id`);

--
-- Constraints for table `food`
--
ALTER TABLE `food`
  ADD CONSTRAINT `fk_id_cat` FOREIGN KEY (`id_cat`) REFERENCES `categories` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
