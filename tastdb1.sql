-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: taskdb1
-- ------------------------------------------------------
-- Server version	5.5.62

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tasks`
--

DROP TABLE IF EXISTS `tasks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tasks` (
  `TaskID` int(11) NOT NULL AUTO_INCREMENT,
  `Task` varchar(64) NOT NULL,
  `AssignedToUserID` int(11) NOT NULL,
  `TaskTypeID` int(11) NOT NULL DEFAULT '1',
  `TaskStatusID` int(11) NOT NULL DEFAULT '1',
  `ProjectID` int(11) NOT NULL,
  `UpdatedBy` int(11) NOT NULL DEFAULT '1',
  `TimeUpdated` datetime NOT NULL,
  `CreatedBy` int(11) NOT NULL DEFAULT '1',
  `TimeCreated` datetime NOT NULL,
  PRIMARY KEY (`TaskID`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tasks`
--

LOCK TABLES `tasks` WRITE;
/*!40000 ALTER TABLE `tasks` DISABLE KEYS */;
INSERT INTO `tasks` VALUES (1,'任务1',1,1,1,1,1,'2023-06-15 00:00:00',1,'2023-06-15 00:00:00'),(2,'任务2',2,2,2,2,2,'2023-06-15 00:00:00',2,'2023-06-15 00:00:00'),(20,'4',4,4,4,4,4,'2023-06-23 12:57:39',4,'2023-06-23 12:57:39'),(21,'3',3,3,3,3,3,'2023-06-23 12:58:03',4,'2023-06-23 12:57:39');
/*!40000 ALTER TABLE `tasks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `UserID` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(45) NOT NULL,
  `NickName` varchar(45) NOT NULL,
  `RoleID` int(11) NOT NULL DEFAULT '1',
  `Email` varchar(45) NOT NULL,
  `Phone` char(11) NOT NULL,
  `EncryptedPassword` varchar(64) NOT NULL,
  `Status` int(11) NOT NULL DEFAULT '1',
  `UpdatedBy` int(11) NOT NULL DEFAULT '1',
  `TimeUpdated` datetime NOT NULL,
  `CreatedBy` int(11) NOT NULL DEFAULT '1',
  `TimeCreated` datetime NOT NULL,
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8 COMMENT='用户名';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'ZhengJunxiang','Junxiang',1,'123@qq.com','123456','123456',1,1,'2023-04-17 00:00:00',1,'2023-04-17 00:00:00'),(2,'QianMeng','Meng',1,'123@qq.com','123456','123456',1,1,'2023-04-17 00:00:00',1,'2023-04-17 00:00:00'),(3,'YiBan','Ban',1,'123@qq.com','123456','123456',1,1,'2023-04-17 00:00:00',1,'2023-04-17 00:00:00'),(4,'t','t',1,'123@qq.com','123456','123456',1,1,'2023-04-17 00:00:00',1,'2023-04-17 00:00:00'),(5,'wer','wer',1,'wer','wer','11',1,1,'2023-05-08 17:31:32',1,'2023-05-08 17:31:32'),(6,'adnadno','dajpdpq',1,'231','123','123',1,1,'2023-05-08 17:32:52',1,'2023-05-08 17:32:52'),(7,'qwer','qw',1,'123@qq.com','123','123',1,1,'2023-05-16 18:24:50',1,'2023-05-16 18:24:50'),(15,'123','123',1,'402981391@qq.com','18786246842','123456',1,1,'2023-06-20 15:35:18',1,'2023-06-20 15:35:18'),(16,'1201020155','11',1,'92994333900@qq.com','15209570211','123123',1,1,'2023-06-23 12:52:18',1,'2023-06-23 12:52:18'),(17,'1201020155','11',1,'2994333900@qq.com','15209570211','123123',1,1,'2023-06-23 12:53:52',1,'2023-06-23 12:53:52'),(18,'123456','123',1,'123@qq.com','18209570211','123123',1,1,'2023-06-23 12:59:30',1,'2023-06-23 12:59:30'),(19,'asdf','zxc',1,'402981391@qq.com','18786246842','123456',1,1,'2023-06-30 01:10:14',1,'2023-06-30 01:10:14');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-11-29 11:09:37
