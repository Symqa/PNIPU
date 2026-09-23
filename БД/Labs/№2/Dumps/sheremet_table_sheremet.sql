-- MySQL dump 10.13  Distrib 8.0.46, for Win64 (x86_64)
--
-- Host: localhost    Database: sheremet
-- ------------------------------------------------------
-- Server version	8.0.46

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
-- Table structure for table `table_sheremet`
--

DROP TABLE IF EXISTS `table_sheremet`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `table_sheremet` (
  `id` int NOT NULL AUTO_INCREMENT,
  `fullName` varchar(45) NOT NULL,
  `phoneNumber` varchar(12) NOT NULL,
  `salary` decimal(10,2) NOT NULL,
  `address` varchar(100) NOT NULL,
  `yearOfEmployment` year NOT NULL,
  `yearsOfService` smallint DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `table_sheremet`
--

LOCK TABLES `table_sheremet` WRITE;
/*!40000 ALTER TABLE `table_sheremet` DISABLE KEYS */;
INSERT INTO `table_sheremet` VALUES (1,'Шеремет Семён Олегович','+79867557161',100000.00,'Г. Пермь, ул.Профессора Дедюкина 18к9',2015,11),(2,'Иванов Иван Иванович','+79161234567',85000.50,'г. Москва, ул. Ленина, д. 10, кв. 5',2018,8),(3,'Петрова Анна Сергеевна','+79219876543',92000.00,'г. Санкт-Петербург, Невский пр., д. 20, кв. 12',2015,11),(4,'Сидоров Алексей Владимирович','+79991112233',64000.00,'г. Новосибирск, ул. Гоголя, д. 5',2020,6),(5,'Кузнецова Елена Дмитриевна','+79135554433',110000.00,'г. Екатеринбург, ул. Мира, д. 15, кв. 3',2010,16),(6,'Смирнов Дмитрий Олегович','+79650001122',78000.25,'г. Казань, ул. Баумана, д. 7',2019,7),(7,'Волкова Ольга Игоревна','+79507778899',55000.00,'г. Челябинск, ул. Кирова, д. 30, кв. 8',2022,4),(8,'Морозов Павел Андреевич','+79274445566',83000.00,'г. Самара, ул. Победы, д. 12',2017,9),(9,'Новикова Мария Александровна','+79138889900',67000.80,'г. Омск, ул. Ленина, д. 4, кв. 10',2021,5),(10,'Федоров Артем Игоревич','+79885551122',72000.00,'г. Ростов-на-Дону, ул. Садовая, д. 50',2016,10),(11,'Михайлова Татьяна Петровна','+79273332211',95000.00,'г. Уфа, пр. Октября, д. 80',2012,14),(12,'Белов Никита Сергеевич','+79021119988',60000.00,'г. Красноярск, ул. Мира, д. 22, кв. 1',2023,3),(13,'Тарасова Ирина Викторовна','+79165557788',81000.00,'г. Воронеж, ул. Плехановская, д. 18',2014,12),(14,'Комаров Максим Алексеевич','+79504448899',74000.50,'г. Пермь, Комсомольский пр., д. 40',2018,8),(15,'Орлова Светлана Николаевна','+79667773322',88000.00,'г. Волгоград, ул. Мира, д. 11, кв. 7',2011,15),(16,'Киселев Андрей Владимирович','+79282221100',69000.00,'г. Краснодар, ул. Красная, д. 15',2024,2),(17,'Макарова Юлия Дмитриевна','+79152223344',105000.00,'г. Саратов, ул. Московская, д. 8',2013,13),(18,'Гусев Виктор Павлович','+79323334455',58000.00,'г. Тюмень, ул. Республики, д. 25, кв. 2',2025,1),(19,'Данилова Ксения Андреевна','+79681112233',76000.00,'г. Тольятти, ул. Ленина, д. 3',2019,7),(20,'Лебедев Роман Олегович','+79127778899',120000.00,'г. Ижевск, ул. Пушкинская, д. 10',2026,0);
/*!40000 ALTER TABLE `table_sheremet` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-09-23  2:49:04
