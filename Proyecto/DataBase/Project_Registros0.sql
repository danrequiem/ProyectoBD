CREATE DATABASE  IF NOT EXISTS `Project` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `Project`;
-- MySQL dump 10.13  Distrib 5.6.11, for osx10.6 (i386)
--
-- Host: 127.0.0.1    Database: Project
-- ------------------------------------------------------
-- Server version	5.5.29

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Registros`
--

DROP TABLE IF EXISTS `Registros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Registros` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ApellidoP` varchar(45) DEFAULT NULL,
  `ApellidoM` varchar(45) DEFAULT NULL,
  `Nombre` varchar(45) DEFAULT NULL,
  `Domicilio` varchar(45) DEFAULT NULL,
  `CP` int(11) DEFAULT NULL,
  `Municipio` varchar(45) DEFAULT NULL,
  `Estado` varchar(50) DEFAULT NULL,
  `Pais` varchar(45) DEFAULT NULL,
  `Mapa` varchar(50) DEFAULT NULL,
  `Telefono` int(20) DEFAULT NULL,
  `Celular` int(20) DEFAULT NULL,
  `Radio` int(20) DEFAULT NULL,
  `Observaciones` varchar(70) DEFAULT NULL,
  `saved_at` datetime DEFAULT NULL,
  `modified_in` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Registros`
--

LOCK TABLES `Registros` WRITE;
/*!40000 ALTER TABLE `Registros` DISABLE KEYS */;
INSERT INTO `Registros` VALUES (22,'Verdin','Garcia ','Daniel','Porvenir 220',45500,'Tlaquepaque','Jalisco','México','dgarciaverdin@gmail.com',36356795,2147483647,2147483647,'Pues se la rifa en la programacion','2013-12-04 16:15:17',NULL),(23,'Garcia','Gurrola ','David','Rio Ameca 22',34564,'Guadalajara','Jalisco','México','dugv08@gmail.com',36356793,445532884,11234665,'Que mas puedo decir.','2013-12-04 16:18:13',NULL),(24,'Verdin','Garcia','Maria','Matamoros',34553,'Suhings','Albarinos','Bahráin','dancore1@gmail.com',23455345,245678754,234566675,'Señora','2013-12-04 16:21:48',NULL),(25,'Filomenez','Suarez','Panchito','Av. Siempreviva 123',12223,'Sprinfield','Arligi','Bosnia y Hercegovina','Panchito@gmail.com',2223344,1111111,3232425,'Pues este bato ni existe ','2013-12-04 16:26:17',NULL),(26,'Virgen','Diaz','Porfirio','Morelos 344',2345,'Tonayork','Jalisco','Estados Unidos','Porfirio@gmail.com',33445664,22233442,23345666,'la neta este we nomas lo agrege a la base de datos por mamon','2013-12-04 16:30:54',NULL);
/*!40000 ALTER TABLE `Registros` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-12-04 16:31:51
