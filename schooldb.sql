-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 26, 2024 at 12:08 AM
-- Server version: 10.1.29-MariaDB
-- PHP Version: 7.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `schooldb`
--

-- --------------------------------------------------------

--
-- Table structure for table `finance`
--

CREATE TABLE `finance` (
  `FinanceID` int(11) NOT NULL,
  `StudentID` int(11) NOT NULL,
  `TuitionFee` decimal(10,2) NOT NULL,
  `OtherFees` decimal(10,2) NOT NULL,
  `Balance` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `marks`
--

CREATE TABLE `marks` (
  `MarkID` int(11) NOT NULL,
  `StudentID` int(11) NOT NULL,
  `TeacherID` int(11) NOT NULL,
  `Subject` varchar(50) NOT NULL,
  `Mark` int(11) NOT NULL,
  `ChangeReason` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE `students` (
  `StudentID` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Age` int(11) NOT NULL,
  `Grade` varchar(10) NOT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `ParentContact` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `students`
--

INSERT INTO `students` (`StudentID`, `Name`, `Age`, `Grade`, `Address`, `ParentContact`) VALUES
(1, 'John Doe', 10, 'Grade 5', '123 Main St', '123-456-7890'),
(34, 'Jane Smith', 11, 'Grade 6', '456 Elm St', '456-789-0123'),
(35, 'Michael Johnson', 9, 'Grade 4', '789 Oak St', '789-012-3456'),
(36, 'Emily Williams', 12, 'Grade 7', '321 Pine St', '321-654-9870'),
(37, 'David Brown', 8, 'Grade 3', '654 Maple St', '654-987-0123'),
(38, 'Sarah Davis', 13, 'Grade 8', '987 Cedar St', '987-012-3456'),
(39, 'James Wilson', 11, 'Grade 6', '741 Birch St', '741-852-9630'),
(40, 'Emma Jones', 10, 'Grade 5', '852 Walnut St', '852-963-1470'),
(41, 'Daniel Taylor', 9, 'Grade 4', '369 Elm St', '369-258-1470'),
(42, 'Olivia Martinez', 12, 'Grade 7', '159 Oak St', '159-357-8520');

-- --------------------------------------------------------

--
-- Table structure for table `teachers`
--

CREATE TABLE `teachers` (
  `TeacherID` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Subject` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `teachers`
--

INSERT INTO `teachers` (`TeacherID`, `Name`, `Subject`) VALUES
(24, 'Mr. Smith', 'Math'),
(25, 'Ms. Johnson', 'Science'),
(26, 'Mrs. Brown', 'English'),
(27, 'Mr. Davis', 'History'),
(28, 'Ms. Wilson', 'Art'),
(29, 'Mr. Jones', 'Music'),
(30, 'Mrs. Taylor', 'Physical Education'),
(31, 'Mr. Martinez', 'Geography'),
(32, 'Mrs. White', 'Computer Science'),
(33, 'Mr. Harris', 'French');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `UserID` int(11) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `Role` enum('Principal','Receptionist') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserID`, `Username`, `Password`, `Role`) VALUES
(1, 'fbfgb', 'fgg', 'Receptionist'),
(2, 'tapiwa', 'rt', 'Principal'),
(3, 'tapiwa', 'rt', 'Receptionist'),
(4, 'tapiwa', 'rt', 'Principal'),
(5, 'tapiwa', 'tk', 'Principal'),
(6, 'ds', 'sd', 'Receptionist'),
(7, 'as', 'sa', 'Receptionist'),
(8, 'qw', 'wq', 'Principal'),
(9, 'Tapiwa', 'cgi', 'Principal'),
(10, 'zizo', 'mvambi', 'Receptionist'),
(11, 'a', 's', 'Receptionist'),
(12, 'a', 's', 'Principal'),
(13, 'a', 's', 'Receptionist'),
(14, 'we', 'qw', 'Principal');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `finance`
--
ALTER TABLE `finance`
  ADD PRIMARY KEY (`FinanceID`),
  ADD KEY `StudentID` (`StudentID`);

--
-- Indexes for table `marks`
--
ALTER TABLE `marks`
  ADD PRIMARY KEY (`MarkID`),
  ADD KEY `TeacherID` (`TeacherID`),
  ADD KEY `marks_ibfk_1` (`StudentID`);

--
-- Indexes for table `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`StudentID`);

--
-- Indexes for table `teachers`
--
ALTER TABLE `teachers`
  ADD PRIMARY KEY (`TeacherID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `finance`
--
ALTER TABLE `finance`
  MODIFY `FinanceID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `marks`
--
ALTER TABLE `marks`
  MODIFY `MarkID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `students`
--
ALTER TABLE `students`
  MODIFY `StudentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=43;

--
-- AUTO_INCREMENT for table `teachers`
--
ALTER TABLE `teachers`
  MODIFY `TeacherID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `finance`
--
ALTER TABLE `finance`
  ADD CONSTRAINT `finance_ibfk_1` FOREIGN KEY (`StudentID`) REFERENCES `students` (`StudentID`);

--
-- Constraints for table `marks`
--
ALTER TABLE `marks`
  ADD CONSTRAINT `marks_ibfk_1` FOREIGN KEY (`StudentID`) REFERENCES `students` (`StudentID`) ON DELETE CASCADE,
  ADD CONSTRAINT `marks_ibfk_2` FOREIGN KEY (`TeacherID`) REFERENCES `teachers` (`TeacherID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
