-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 13, 2018 at 10:53 AM
-- Server version: 5.7.14
-- PHP Version: 5.6.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `tcc_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `accounts`
--

CREATE TABLE `accounts` (
  `accnum` int(11) NOT NULL,
  `accfname` varchar(50) NOT NULL,
  `accmname` varchar(50) NOT NULL,
  `acclname` varchar(50) NOT NULL,
  `acctype` varchar(20) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `accounts`
--

INSERT INTO `accounts` (`accnum`, `accfname`, `accmname`, `acclname`, `acctype`) VALUES
(1, 'Leo Jhen', 'Panis', 'Ibasco', 'Mixxer'),
(2, 'Ken Jan Eruel', 'Tanupan', 'Misa', 'Agent/Canvasser'),
(3, 'John Oliver', 'Englis', 'Jamang', 'Pintor');

-- --------------------------------------------------------

--
-- Table structure for table `acquired_products`
--

CREATE TABLE `acquired_products` (
  `srrnum` varchar(50) NOT NULL,
  `prodcode` varchar(100) NOT NULL,
  `prodname` varchar(50) NOT NULL,
  `qty` int(11) NOT NULL,
  `srp` varchar(50) NOT NULL,
  `daterecieved` varchar(50) NOT NULL,
  `purchasecapital` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `acquired_products`
--

INSERT INTO `acquired_products` (`srrnum`, `prodcode`, `prodname`, `qty`, `srp`, `daterecieved`, `purchasecapital`) VALUES
('2018-0001', '1', 'GREAT TASTE WHITE TWIN PACK', 5, '10.00', '12/12/2018 12:00:00 AM', '50'),
('2018-0001', '4', 'NISSIN CUP NOODLES (BEEF)', 5, '12.00', '12/12/2018 12:00:00 AM', '60'),
('2018-0002', '8', 'BAYGON SPRAY (500ML)', 2, '130.00', '12/13/2018 12:00:00 AM', '260');

-- --------------------------------------------------------

--
-- Table structure for table `agents_transac`
--

CREATE TABLE `agents_transac` (
  `accnum` varchar(50) NOT NULL,
  `transacnum` varchar(50) NOT NULL,
  `datetransac` date NOT NULL,
  `gallons` double NOT NULL,
  `earnings` double NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `agents_transac`
--

INSERT INTO `agents_transac` (`accnum`, `transacnum`, `datetransac`, `gallons`, `earnings`) VALUES
('2', '201809061', '2018-09-06', 2, 2.5),
('2', '201809062', '2018-09-06', 7, 8.75),
('2', '201809063', '2018-09-06', 23, 28.75),
('2', '201809064', '2018-09-06', 20, 25),
('2', '201809065', '2018-09-06', 8, 10),
('2', '201809071', '2018-09-07', 4, 5);

-- --------------------------------------------------------

--
-- Table structure for table `banks`
--

CREATE TABLE `banks` (
  `bank_id` int(11) NOT NULL,
  `bank_name` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `bayad_payables`
--

CREATE TABLE `bayad_payables` (
  `bu_id` int(11) NOT NULL,
  `bank` varchar(50) NOT NULL,
  `drnum` varchar(50) NOT NULL,
  `supplier_code` varchar(50) NOT NULL,
  `chequenum` varchar(50) NOT NULL,
  `date` date NOT NULL,
  `partial` double NOT NULL,
  `chequestatus` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `bossamt`
--

CREATE TABLE `bossamt` (
  `bosid` int(11) NOT NULL,
  `date` date NOT NULL,
  `amt` double NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `cheque_infos`
--

CREATE TABLE `cheque_infos` (
  `reference_num` varchar(50) NOT NULL,
  `bank_name` varchar(50) NOT NULL,
  `cheque_num` varchar(50) NOT NULL,
  `cheque_date` date NOT NULL,
  `status` varchar(50) NOT NULL,
  `remarks` varchar(100) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `custcode` int(11) NOT NULL,
  `fname` varchar(50) NOT NULL,
  `mname` varchar(50) NOT NULL,
  `lname` varchar(50) NOT NULL,
  `address` varchar(50) NOT NULL,
  `department` varchar(50) NOT NULL,
  `creditlimit` double NOT NULL,
  `balance` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `custcode` int(11) NOT NULL,
  `fname` varchar(50) DEFAULT NULL,
  `mname` varchar(50) NOT NULL,
  `lname` varchar(50) NOT NULL,
  `street_purok` varchar(100) NOT NULL,
  `barangay` varchar(100) NOT NULL,
  `city` varchar(100) NOT NULL,
  `province` varchar(100) NOT NULL,
  `contact_number` varchar(11) NOT NULL,
  `creditlimit` varchar(100) NOT NULL,
  `balance` varchar(100) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`custcode`, `fname`, `mname`, `lname`, `street_purok`, `barangay`, `city`, `province`, `contact_number`, `creditlimit`, `balance`) VALUES
(1, 'Jether', 'Bohol', 'Gamones', '10', 'Poblacion', 'Maco', 'Comval', '09975993007', '2000', '1988');

-- --------------------------------------------------------

--
-- Table structure for table `customer_payments`
--

CREATE TABLE `customer_payments` (
  `reference_num` varchar(50) NOT NULL,
  `custcode` varchar(50) NOT NULL,
  `transacnum` int(50) NOT NULL,
  `date_paid` date NOT NULL,
  `payment` double NOT NULL,
  `payment_type` varchar(20) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `customer_payments`
--

INSERT INTO `customer_payments` (`reference_num`, `custcode`, `transacnum`, `date_paid`, `payment`, `payment_type`) VALUES
('1', '1', 201809031, '2018-09-03', 123, 'Cheque'),
('123', '1', 201808312, '2018-09-03', 226, 'Cash'),
('231', '1', 201809031, '2018-09-06', 12, 'Cheque'),
('111', '1', 201809033, '2018-09-06', 123, 'Cash'),
('22', '1', 201809032, '2018-09-06', 123, 'Cash'),
('11515', '3', 201809064, '2018-09-06', 500, 'Cash');

-- --------------------------------------------------------

--
-- Table structure for table `customer_utangs`
--

CREATE TABLE `customer_utangs` (
  `transacnum` varchar(50) NOT NULL,
  `custcode` varchar(50) NOT NULL,
  `partial` double NOT NULL,
  `balance` double NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `department`
--

CREATE TABLE `department` (
  `dept_id` int(11) NOT NULL,
  `dept_name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `department`
--

INSERT INTO `department` (`dept_id`, `dept_name`) VALUES
(1, 'q'),
(2, 'dd');

-- --------------------------------------------------------

--
-- Table structure for table `deposit`
--

CREATE TABLE `deposit` (
  `dep_id` int(11) NOT NULL,
  `date` date NOT NULL,
  `bank` varchar(50) NOT NULL,
  `cheque_num` varchar(50) NOT NULL,
  `amount` double NOT NULL,
  `reference_num` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `depositam`
--

CREATE TABLE `depositam` (
  `depam_id` int(11) NOT NULL,
  `date` date NOT NULL,
  `bank` varchar(50) NOT NULL,
  `paymeth` varchar(50) NOT NULL,
  `amt` double NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `depositpm`
--

CREATE TABLE `depositpm` (
  `deppm_id` int(11) NOT NULL,
  `date` date NOT NULL,
  `bank` varchar(50) NOT NULL,
  `paymeth` varchar(50) NOT NULL,
  `amt` double NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `dsalesreport`
--

CREATE TABLE `dsalesreport` (
  `dsalesrep_id` int(11) NOT NULL,
  `date` date NOT NULL,
  `store` varchar(50) NOT NULL,
  `sales` double NOT NULL,
  `remit3pm` double DEFAULT NULL,
  `remit5pm` double DEFAULT NULL,
  `tot_remit` double DEFAULT NULL,
  `po` double DEFAULT NULL,
  `expensesamt` double DEFAULT NULL,
  `comm_pintor` double DEFAULT NULL,
  `cnb` double DEFAULT NULL,
  `paymnts_chck` double DEFAULT NULL,
  `paymnts_cash` double DEFAULT NULL,
  `over` double DEFAULT NULL,
  `short` double DEFAULT NULL,
  `coh` double NOT NULL,
  `comcoh` double NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--

CREATE TABLE `employees` (
  `employ_id` varchar(50) NOT NULL,
  `employ_fname` varchar(50) NOT NULL,
  `employ_lname` varchar(50) NOT NULL,
  `employ_mname` varchar(50) NOT NULL,
  `employ_position` varchar(50) NOT NULL,
  `employ_branch` varchar(50) NOT NULL,
  `employ_mrate` double NOT NULL,
  `employ_drate` double NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `employees_attendance`
--

CREATE TABLE `employees_attendance` (
  `employ_id` varchar(50) NOT NULL,
  `attendance_date` date NOT NULL,
  `time_in` datetime NOT NULL,
  `time_out` datetime NOT NULL,
  `total_hours` double NOT NULL,
  `late` double NOT NULL,
  `undertime` double NOT NULL,
  `timelog_type` varchar(10) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `employees_cashadvance`
--

CREATE TABLE `employees_cashadvance` (
  `employ_id` varchar(50) NOT NULL,
  `ca_code` int(11) NOT NULL,
  `amount` double NOT NULL,
  `partial` double NOT NULL,
  `balance` double NOT NULL,
  `status` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `employees_infos`
--

CREATE TABLE `employees_infos` (
  `employ_id` varchar(50) NOT NULL,
  `sss_cont` double NOT NULL,
  `sss_loan` double NOT NULL,
  `hdmf_cont` double NOT NULL,
  `hdmf_loan` double NOT NULL,
  `phic_cont` double NOT NULL,
  `taxwh` double NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `employees_payments`
--

CREATE TABLE `employees_payments` (
  `employ_id` varchar(50) NOT NULL,
  `date_paid` date NOT NULL,
  `payment` double NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `expenses`
--

CREATE TABLE `expenses` (
  `exp_id` int(11) NOT NULL,
  `exp_type` varchar(50) NOT NULL,
  `exp_name` varchar(50) NOT NULL,
  `detail_type` text NOT NULL,
  `exp_desc` varchar(100) NOT NULL,
  `IsSub` tinyint(1) NOT NULL,
  `sub_exp` varchar(100) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `expenses_logs`
--

CREATE TABLE `expenses_logs` (
  `explog_id` int(11) NOT NULL,
  `exp_name` varchar(100) NOT NULL,
  `explog_desc` varchar(100) NOT NULL,
  `explog_date` date NOT NULL,
  `pymeth_desc` varchar(50) NOT NULL,
  `explog_amt` double NOT NULL,
  `explog_memo` varchar(100) DEFAULT NULL,
  `HasReceipt` tinyint(1) NOT NULL,
  `receiptno` varchar(100) NOT NULL,
  `tax` varchar(100) NOT NULL,
  `tin` varchar(100) NOT NULL,
  `address` varchar(100) NOT NULL,
  `store` varchar(100) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `floating_exp`
--

CREATE TABLE `floating_exp` (
  `explog_id` int(11) NOT NULL,
  `exp_name` varchar(100) NOT NULL,
  `explog_desc` varchar(100) NOT NULL,
  `explog_date` date NOT NULL,
  `pymeth_desc` varchar(50) NOT NULL,
  `explog_amt` double NOT NULL,
  `explog_memo` varchar(100) DEFAULT NULL,
  `HasReceipt` tinyint(1) NOT NULL,
  `receiptno` varchar(100) NOT NULL,
  `tax` varchar(100) NOT NULL,
  `tin` varchar(100) NOT NULL,
  `address` varchar(100) NOT NULL,
  `store` varchar(100) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `majexp`
--

CREATE TABLE `majexp` (
  `majexp_id` int(11) NOT NULL,
  `date` date NOT NULL,
  `exp_name` varchar(50) NOT NULL,
  `exp_desc` varchar(50) NOT NULL,
  `amt` double NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `menudo_records`
--

CREATE TABLE `menudo_records` (
  `transacnum` varchar(50) NOT NULL,
  `prodcode` varchar(50) NOT NULL,
  `units` double NOT NULL,
  `price` double NOT NULL,
  `qty` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `menudo_sobra`
--

CREATE TABLE `menudo_sobra` (
  `prodcode` varchar(50) NOT NULL,
  `units` double NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `mixxer_transac`
--

CREATE TABLE `mixxer_transac` (
  `accnum` varchar(50) NOT NULL,
  `mixtype` varchar(20) NOT NULL,
  `transacnum` varchar(50) NOT NULL,
  `datetransac` date NOT NULL,
  `gallons` double NOT NULL,
  `earnings` double NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `mixxer_transac`
--

INSERT INTO `mixxer_transac` (`accnum`, `mixtype`, `transacnum`, `datetransac`, `gallons`, `earnings`) VALUES
('1', 'Mixing', '201809061', '2018-09-06', 2, 5),
('1', 'Mixing', '201809062', '2018-09-06', 2, 5),
('1', 'Mixing', '201809063', '2018-09-06', 2, 5),
('1', 'Mixing', '201809064', '2018-09-06', 20, 50),
('1', 'Mixing', '201809065', '2018-09-06', 8, 20),
('1', 'Mixing', '201809071', '2018-09-07', 4, 10);

-- --------------------------------------------------------

--
-- Table structure for table `oldaccounts`
--

CREATE TABLE `oldaccounts` (
  `old_id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `address` varchar(70) NOT NULL,
  `contactnum` int(11) NOT NULL,
  `date_purchased` date NOT NULL,
  `ci_num` int(20) NOT NULL,
  `amount` int(11) DEFAULT NULL,
  `term` int(11) NOT NULL,
  `methodofpayment` varchar(20) NOT NULL,
  `totalpayment` int(11) DEFAULT NULL,
  `balance` int(20) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `oldaccounts`
--

INSERT INTO `oldaccounts` (`old_id`, `name`, `address`, `contactnum`, `date_purchased`, `ci_num`, `amount`, `term`, `methodofpayment`, `totalpayment`, `balance`) VALUES
(1, 'q', 'q', 123, '2018-09-06', 111, 1500, 60, 'CASH RECEIPT', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `old_transact`
--

CREATE TABLE `old_transact` (
  `old_trans_id` int(11) NOT NULL,
  `old_acc_id` int(11) NOT NULL,
  `date_of_payment` int(11) NOT NULL,
  `pay_amount` int(11) NOT NULL,
  `balance` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `payables`
--

CREATE TABLE `payables` (
  `payables_id` int(11) NOT NULL,
  `inv_no` int(11) NOT NULL,
  `payable_name` varchar(100) NOT NULL,
  `payable_desc` varchar(100) NOT NULL,
  `date` date NOT NULL,
  `due_date` date NOT NULL,
  `last_pyment` date NOT NULL,
  `total_amt` double NOT NULL,
  `tot_paid` double NOT NULL,
  `outs_bal` double NOT NULL,
  `paid` tinyint(1) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `payroll_done`
--

CREATE TABLE `payroll_done` (
  `sgkey` int(11) NOT NULL,
  `emp_id` int(11) NOT NULL,
  `fromx` date NOT NULL,
  `tox` date NOT NULL,
  `emp_fullname` varchar(100) NOT NULL,
  `position` varchar(100) NOT NULL,
  `branch` varchar(100) NOT NULL,
  `mrate` double NOT NULL,
  `drate` double NOT NULL,
  `noofdays` int(11) NOT NULL,
  `overtime` double NOT NULL,
  `ssscon` double NOT NULL,
  `sssloan` double NOT NULL,
  `hdmfcon` double NOT NULL,
  `hdmfloan` double NOT NULL,
  `phiccon` double NOT NULL,
  `taxwh` double NOT NULL,
  `poca` double NOT NULL,
  `late` double NOT NULL,
  `undertime` double NOT NULL,
  `partial` double NOT NULL,
  `balance` double NOT NULL,
  `netpay` double NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `pintor_transac`
--

CREATE TABLE `pintor_transac` (
  `accnum` varchar(50) NOT NULL,
  `transacnum` varchar(50) NOT NULL,
  `readymixtotal` double NOT NULL,
  `mixingtotal` double NOT NULL,
  `totalearnings` double NOT NULL,
  `datetransac` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pintor_transac`
--

INSERT INTO `pintor_transac` (`accnum`, `transacnum`, `readymixtotal`, `mixingtotal`, `totalearnings`, `datetransac`) VALUES
('3', '201809061', 0, 25, 22, '2018-09-06'),
('3', '201809062', 0, 25, 22, '2018-09-06'),
('3', '201809063', 0, 25, 22, '2018-09-06'),
('3', '201809064', 0, 250, 220, '2018-09-06'),
('3', '201809065', 0, 100, 88, '2018-09-06'),
('3', '201809071', 0, 50, 44, '2018-09-07');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `prodcode` int(11) NOT NULL,
  `barcode` varchar(50) NOT NULL,
  `prodname` varchar(100) NOT NULL,
  `prodtype` varchar(50) NOT NULL,
  `stock` int(255) NOT NULL,
  `srp` varchar(20) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`prodcode`, `barcode`, `prodname`, `prodtype`, `stock`, `srp`) VALUES
(1, '4800016021800', 'GREAT TASTE WHITE TWIN PACK', 'DRY', 1, '10.00'),
(2, '097855060266', 'LOGITECH FULL COLORED MOUSE(BLACK)', 'DRY', 0, '94.16'),
(3, '6935364050719', 'TP LINK WIRELESS ADAPTER', 'DRY', 0, '549.00'),
(4, '4800016552021', 'NISSIN CUP NOODLES (BEEF)', 'DRY', 2, '12.00'),
(5, '4800016644801', 'PIATTOS (CHEESE)', 'DRY', 0, '13.00'),
(6, '4800016552120', 'NISSIN CUP NOODLES (CHICKEN)', 'DRY', 0, '14.50'),
(7, '4800049720121', 'NATURE SPRING WATER (1L)', 'DRY', 0, '56.00'),
(8, '4801234106027', 'BAYGON SPRAY (500ML)', 'DRY', 1, '130.00');

-- --------------------------------------------------------

--
-- Table structure for table `pymnt_method`
--

CREATE TABLE `pymnt_method` (
  `paymeth_id` int(11) NOT NULL,
  `paymeth_desc` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pymnt_method`
--

INSERT INTO `pymnt_method` (`paymeth_id`, `paymeth_desc`) VALUES
(1, 'COD');

-- --------------------------------------------------------

--
-- Table structure for table `receivables`
--

CREATE TABLE `receivables` (
  `receivable_id` int(11) NOT NULL,
  `inv_no` int(11) NOT NULL,
  `rec_name` varchar(100) NOT NULL,
  `rec_desc` varchar(100) NOT NULL,
  `term` int(11) NOT NULL,
  `last_pyment` date NOT NULL,
  `tot_amt` double NOT NULL,
  `tot_paid` double NOT NULL,
  `outs_bal` double NOT NULL,
  `paid` tinyint(1) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `released_products`
--

CREATE TABLE `released_products` (
  `releasereceiptnum` varchar(50) NOT NULL,
  `prodcode` varchar(100) NOT NULL,
  `qty` int(255) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `remperstore`
--

CREATE TABLE `remperstore` (
  `rps_id` int(11) NOT NULL,
  `date` date NOT NULL,
  `store` varchar(50) NOT NULL,
  `amt` double NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `resibo`
--

CREATE TABLE `resibo` (
  `transacnum` varchar(50) NOT NULL,
  `transacdate` date NOT NULL,
  `custcode` varchar(100) NOT NULL,
  `total` double NOT NULL,
  `discount` double NOT NULL,
  `finaltotal` double NOT NULL,
  `cashier` varchar(100) NOT NULL,
  `payment_type` varchar(10) NOT NULL,
  `prionum` int(10) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `resibo_products`
--

CREATE TABLE `resibo_products` (
  `transacnum` varchar(50) NOT NULL,
  `prodcode` varchar(50) NOT NULL,
  `qty` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `return_log`
--

CREATE TABLE `return_log` (
  `id` int(11) NOT NULL,
  `transacnum` varchar(50) NOT NULL,
  `totalreturned` double NOT NULL,
  `datereturned` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `stocks_acquired`
--

CREATE TABLE `stocks_acquired` (
  `srrnum` varchar(50) NOT NULL,
  `invoice_type` varchar(50) NOT NULL,
  `invoice_number` varchar(50) NOT NULL,
  `datereceived` varchar(50) NOT NULL,
  `transacdate` varchar(50) NOT NULL,
  `suppname` varchar(50) NOT NULL,
  `suppadd` varchar(50) NOT NULL,
  `amount` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `stocks_acquired`
--

INSERT INTO `stocks_acquired` (`srrnum`, `invoice_type`, `invoice_number`, `datereceived`, `transacdate`, `suppname`, `suppadd`, `amount`) VALUES
('2018-0001', 'Cash Invoice', '1', '12/12/2018 1:55:13 PM', '12/12/2018', 'qq', 'qwewe', '122.5'),
('2018-0002', 'Cash Invoice', '11100', '12/13/2018 4:09:32 PM', '12/13/2018', 'qq', 'qwewe', '286');

-- --------------------------------------------------------

--
-- Table structure for table `stocks_release`
--

CREATE TABLE `stocks_release` (
  `releasereceiptnum` varchar(50) NOT NULL,
  `daterelease` date NOT NULL,
  `destination` varchar(50) NOT NULL,
  `remarks` varchar(255) NOT NULL,
  `releasedby` varchar(50) NOT NULL,
  `driver` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `store_branches`
--

CREATE TABLE `store_branches` (
  `store_id` int(11) NOT NULL,
  `store_name` varchar(50) NOT NULL,
  `store_address` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

CREATE TABLE `supplier` (
  `supplier_code` varchar(50) NOT NULL,
  `supplier_name` varchar(100) NOT NULL,
  `supplier_province` varchar(50) NOT NULL,
  `supplier_city` varchar(50) NOT NULL,
  `supplier_barangay` varchar(50) NOT NULL,
  `supplier_street` varchar(100) NOT NULL,
  `payment_dues` varchar(20) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `supplier`
--

INSERT INTO `supplier` (`supplier_code`, `supplier_name`, `supplier_province`, `supplier_city`, `supplier_barangay`, `supplier_street`, `payment_dues`) VALUES
('1', 'BOSYEN', 'Davao', 'Tagum', 'Magugpo', 'Mabini', '5'),
('12', 'qq', '12312414', 'sadsa', 'asd', 'dddd', 'asdsad');

-- --------------------------------------------------------

--
-- Table structure for table `suppliers`
--

CREATE TABLE `suppliers` (
  `suppID` int(11) NOT NULL,
  `suppName` varchar(50) NOT NULL,
  `suppContact` varchar(15) NOT NULL,
  `suppAddress` varchar(50) NOT NULL,
  `suppCountry` varchar(50) NOT NULL,
  `suppCity` varchar(50) NOT NULL,
  `suppRegion` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `suppliers`
--

INSERT INTO `suppliers` (`suppID`, `suppName`, `suppContact`, `suppAddress`, `suppCountry`, `suppCity`, `suppRegion`) VALUES
(222, 'qq', '3124566722', 'qwewe', 'qewr', 'qweqwe', '');

-- --------------------------------------------------------

--
-- Table structure for table `type`
--

CREATE TABLE `type` (
  `typeID` int(11) NOT NULL,
  `type` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `type`
--

INSERT INTO `type` (`typeID`, `type`) VALUES
(3, 'WET'),
(4, 'DRY');

-- --------------------------------------------------------

--
-- Table structure for table `units`
--

CREATE TABLE `units` (
  `unitID` int(50) NOT NULL,
  `unit` double NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `units`
--

INSERT INTO `units` (`unitID`, `unit`) VALUES
(1, 1),
(2, 4);

-- --------------------------------------------------------

--
-- Table structure for table `unitword`
--

CREATE TABLE `unitword` (
  `unit_ID` int(11) NOT NULL,
  `unitname` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `unitword`
--

INSERT INTO `unitword` (`unit_ID`, `unitname`) VALUES
(1, 'ARB'),
(2, 'arb'),
(3, 'arb'),
(4, 'sad'),
(5, 'qww'),
(6, 'a'),
(7, 'HHHH');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `employeeID` varchar(50) NOT NULL,
  `fname` varchar(50) NOT NULL,
  `mname` varchar(50) NOT NULL,
  `lname` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `acctype` varchar(20) NOT NULL,
  `status` int(1) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`employeeID`, `fname`, `mname`, `lname`, `username`, `password`, `acctype`, `status`) VALUES
('2018-001', 'Jether', 'Bohol', 'Gamones', 'dev', 'xhRICKT+mAI=', 'ADMIN', 1),
('2018-002', 'Ken Jan Eruel', 'Tanupan', 'Misa', 'dev1', 'wQdaV/XPoAJebWyzYrnhlg==', 'CASHIER', 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `accounts`
--
ALTER TABLE `accounts`
  ADD PRIMARY KEY (`accnum`);

--
-- Indexes for table `banks`
--
ALTER TABLE `banks`
  ADD PRIMARY KEY (`bank_id`);

--
-- Indexes for table `bayad_payables`
--
ALTER TABLE `bayad_payables`
  ADD PRIMARY KEY (`bu_id`);

--
-- Indexes for table `bossamt`
--
ALTER TABLE `bossamt`
  ADD PRIMARY KEY (`bosid`);

--
-- Indexes for table `cheque_infos`
--
ALTER TABLE `cheque_infos`
  ADD PRIMARY KEY (`reference_num`);

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`custcode`);

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`custcode`);

--
-- Indexes for table `customer_payments`
--
ALTER TABLE `customer_payments`
  ADD PRIMARY KEY (`reference_num`);

--
-- Indexes for table `customer_utangs`
--
ALTER TABLE `customer_utangs`
  ADD PRIMARY KEY (`transacnum`);

--
-- Indexes for table `department`
--
ALTER TABLE `department`
  ADD PRIMARY KEY (`dept_id`);

--
-- Indexes for table `deposit`
--
ALTER TABLE `deposit`
  ADD PRIMARY KEY (`dep_id`);

--
-- Indexes for table `depositam`
--
ALTER TABLE `depositam`
  ADD PRIMARY KEY (`depam_id`);

--
-- Indexes for table `depositpm`
--
ALTER TABLE `depositpm`
  ADD PRIMARY KEY (`deppm_id`);

--
-- Indexes for table `dsalesreport`
--
ALTER TABLE `dsalesreport`
  ADD PRIMARY KEY (`dsalesrep_id`);

--
-- Indexes for table `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`employ_id`);

--
-- Indexes for table `employees_cashadvance`
--
ALTER TABLE `employees_cashadvance`
  ADD PRIMARY KEY (`ca_code`);

--
-- Indexes for table `employees_infos`
--
ALTER TABLE `employees_infos`
  ADD PRIMARY KEY (`employ_id`);

--
-- Indexes for table `expenses`
--
ALTER TABLE `expenses`
  ADD PRIMARY KEY (`exp_id`);

--
-- Indexes for table `expenses_logs`
--
ALTER TABLE `expenses_logs`
  ADD PRIMARY KEY (`explog_id`);

--
-- Indexes for table `floating_exp`
--
ALTER TABLE `floating_exp`
  ADD PRIMARY KEY (`explog_id`);

--
-- Indexes for table `majexp`
--
ALTER TABLE `majexp`
  ADD PRIMARY KEY (`majexp_id`);

--
-- Indexes for table `menudo_sobra`
--
ALTER TABLE `menudo_sobra`
  ADD PRIMARY KEY (`prodcode`);

--
-- Indexes for table `oldaccounts`
--
ALTER TABLE `oldaccounts`
  ADD PRIMARY KEY (`old_id`);

--
-- Indexes for table `old_transact`
--
ALTER TABLE `old_transact`
  ADD PRIMARY KEY (`old_trans_id`);

--
-- Indexes for table `payables`
--
ALTER TABLE `payables`
  ADD PRIMARY KEY (`payables_id`);

--
-- Indexes for table `payroll_done`
--
ALTER TABLE `payroll_done`
  ADD PRIMARY KEY (`sgkey`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`prodcode`);

--
-- Indexes for table `pymnt_method`
--
ALTER TABLE `pymnt_method`
  ADD PRIMARY KEY (`paymeth_id`);

--
-- Indexes for table `receivables`
--
ALTER TABLE `receivables`
  ADD PRIMARY KEY (`receivable_id`);

--
-- Indexes for table `remperstore`
--
ALTER TABLE `remperstore`
  ADD PRIMARY KEY (`rps_id`);

--
-- Indexes for table `resibo`
--
ALTER TABLE `resibo`
  ADD PRIMARY KEY (`transacnum`);

--
-- Indexes for table `return_log`
--
ALTER TABLE `return_log`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stocks_acquired`
--
ALTER TABLE `stocks_acquired`
  ADD PRIMARY KEY (`srrnum`);

--
-- Indexes for table `stocks_release`
--
ALTER TABLE `stocks_release`
  ADD PRIMARY KEY (`releasereceiptnum`);

--
-- Indexes for table `store_branches`
--
ALTER TABLE `store_branches`
  ADD PRIMARY KEY (`store_id`);

--
-- Indexes for table `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`supplier_code`);

--
-- Indexes for table `suppliers`
--
ALTER TABLE `suppliers`
  ADD PRIMARY KEY (`suppID`);

--
-- Indexes for table `type`
--
ALTER TABLE `type`
  ADD PRIMARY KEY (`typeID`);

--
-- Indexes for table `units`
--
ALTER TABLE `units`
  ADD PRIMARY KEY (`unitID`);

--
-- Indexes for table `unitword`
--
ALTER TABLE `unitword`
  ADD PRIMARY KEY (`unit_ID`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`employeeID`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `accounts`
--
ALTER TABLE `accounts`
  MODIFY `accnum` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `banks`
--
ALTER TABLE `banks`
  MODIFY `bank_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `bayad_payables`
--
ALTER TABLE `bayad_payables`
  MODIFY `bu_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `bossamt`
--
ALTER TABLE `bossamt`
  MODIFY `bosid` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `customer`
--
ALTER TABLE `customer`
  MODIFY `custcode` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `customers`
--
ALTER TABLE `customers`
  MODIFY `custcode` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `department`
--
ALTER TABLE `department`
  MODIFY `dept_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `deposit`
--
ALTER TABLE `deposit`
  MODIFY `dep_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `depositam`
--
ALTER TABLE `depositam`
  MODIFY `depam_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `depositpm`
--
ALTER TABLE `depositpm`
  MODIFY `deppm_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `dsalesreport`
--
ALTER TABLE `dsalesreport`
  MODIFY `dsalesrep_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `employees_cashadvance`
--
ALTER TABLE `employees_cashadvance`
  MODIFY `ca_code` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `expenses`
--
ALTER TABLE `expenses`
  MODIFY `exp_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `expenses_logs`
--
ALTER TABLE `expenses_logs`
  MODIFY `explog_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `floating_exp`
--
ALTER TABLE `floating_exp`
  MODIFY `explog_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `majexp`
--
ALTER TABLE `majexp`
  MODIFY `majexp_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `oldaccounts`
--
ALTER TABLE `oldaccounts`
  MODIFY `old_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `old_transact`
--
ALTER TABLE `old_transact`
  MODIFY `old_trans_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `payables`
--
ALTER TABLE `payables`
  MODIFY `payables_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `payroll_done`
--
ALTER TABLE `payroll_done`
  MODIFY `sgkey` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `prodcode` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT for table `pymnt_method`
--
ALTER TABLE `pymnt_method`
  MODIFY `paymeth_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `receivables`
--
ALTER TABLE `receivables`
  MODIFY `receivable_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `remperstore`
--
ALTER TABLE `remperstore`
  MODIFY `rps_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `return_log`
--
ALTER TABLE `return_log`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `store_branches`
--
ALTER TABLE `store_branches`
  MODIFY `store_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `suppliers`
--
ALTER TABLE `suppliers`
  MODIFY `suppID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=223;
--
-- AUTO_INCREMENT for table `type`
--
ALTER TABLE `type`
  MODIFY `typeID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `units`
--
ALTER TABLE `units`
  MODIFY `unitID` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `unitword`
--
ALTER TABLE `unitword`
  MODIFY `unit_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
