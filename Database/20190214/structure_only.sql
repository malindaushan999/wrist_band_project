/*
SQLyog Community v13.1.1 (64 bit)
MySQL - 8.0.12 : Database - wristband_master
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`wristband_master` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;

USE `wristband_master`;

/*Table structure for table `login_session` */

DROP TABLE IF EXISTS `login_session`;

CREATE TABLE `login_session` (
  `id` bigint(32) NOT NULL,
  `session_id` varchar(256) NOT NULL,
  `user_id` bigint(6) NOT NULL,
  `start_datetime` datetime NOT NULL,
  `end_datetime` datetime DEFAULT NULL,
  `status` smallint(6) DEFAULT NULL,
  `is_delete` smallint(6) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_login_session_user_id_user_id` (`user_id`),
  KEY `fk_login_session_is_delete_xxbt_yesno_id` (`is_delete`),
  KEY `fk_login_session_status_xxbt_login_session_status_id` (`status`),
  CONSTRAINT `fk_login_session_is_delete_xxbt_yesno_id` FOREIGN KEY (`is_delete`) REFERENCES `xxbt_yesno` (`id`),
  CONSTRAINT `fk_login_session_status_xxbt_login_session_status_id` FOREIGN KEY (`status`) REFERENCES `xxbt_login_session_status` (`id`),
  CONSTRAINT `fk_login_session_user_id_user_id` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Table structure for table `sensor_data` */

DROP TABLE IF EXISTS `sensor_data`;

CREATE TABLE `sensor_data` (
  `id` bigint(32) NOT NULL AUTO_INCREMENT,
  `sensor` bigint(6) DEFAULT NULL,
  `data` varchar(512) DEFAULT NULL,
  `timestamp` datetime DEFAULT NULL,
  `is_delete` smallint(6) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_sensor_data_is_delete_xxbt_yesno_id` (`is_delete`),
  KEY `fk_sensor_data_sensor_sensor_info_id` (`sensor`),
  CONSTRAINT `fk_sensor_data_is_delete_xxbt_yesno_id` FOREIGN KEY (`is_delete`) REFERENCES `xxbt_yesno` (`id`),
  CONSTRAINT `fk_sensor_data_sensor_sensor_info_id` FOREIGN KEY (`sensor`) REFERENCES `sensor_info` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Table structure for table `sensor_info` */

DROP TABLE IF EXISTS `sensor_info`;

CREATE TABLE `sensor_info` (
  `id` bigint(6) NOT NULL AUTO_INCREMENT,
  `name` varchar(128) DEFAULT NULL,
  `serial_no` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `description` varchar(512) DEFAULT NULL,
  `sensor_type` smallint(6) DEFAULT NULL,
  `added_by` bigint(6) DEFAULT NULL,
  `added_datetime` datetime DEFAULT NULL,
  `modified_by` bigint(6) DEFAULT NULL,
  `modified_datetime` datetime DEFAULT NULL,
  `is_delete` smallint(6) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_sensor_info_is_delete_xxt_yes_no_id` (`is_delete`),
  KEY `fk_sensor_info_sensor_type_xxbt_sensor_type_id` (`sensor_type`),
  CONSTRAINT `fk_sensor_info_is_delete_xxt_yes_no_id` FOREIGN KEY (`is_delete`) REFERENCES `xxbt_yesno` (`id`),
  CONSTRAINT `fk_sensor_info_sensor_type_xxbt_sensor_type_id` FOREIGN KEY (`sensor_type`) REFERENCES `xxbt_sensor_type` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Table structure for table `user` */

DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
  `id` bigint(6) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(64) NOT NULL,
  `last_name` varchar(64) DEFAULT NULL,
  `username` varchar(64) NOT NULL,
  `password` varchar(512) NOT NULL,
  `email` varchar(128) DEFAULT NULL,
  `phone` int(10) DEFAULT NULL,
  `mobile` int(10) DEFAULT NULL,
  `address` varchar(512) DEFAULT NULL,
  `user_type` smallint(6) DEFAULT NULL,
  `image_path` varchar(256) DEFAULT NULL,
  `is_delete` smallint(6) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_user_user_type_xxt_user_type_id` (`user_type`),
  KEY `fk_user_is_delete_xxbt_is_delete_id` (`is_delete`),
  CONSTRAINT `fk_user_is_delete_xxbt_is_delete_id` FOREIGN KEY (`is_delete`) REFERENCES `xxbt_yesno` (`id`),
  CONSTRAINT `fk_user_user_type_xxt_user_type_id` FOREIGN KEY (`user_type`) REFERENCES `xxbt_user_type` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Table structure for table `wristband_info` */

DROP TABLE IF EXISTS `wristband_info`;

CREATE TABLE `wristband_info` (
  `id` bigint(6) NOT NULL AUTO_INCREMENT,
  `name` varchar(128) DEFAULT NULL,
  `description` varchar(512) DEFAULT NULL,
  `status` smallint(6) DEFAULT NULL,
  `issued_to` bigint(6) DEFAULT NULL,
  `issued_by` bigint(6) DEFAULT NULL,
  `issued_datetime` datetime DEFAULT NULL,
  `is_delete` smallint(6) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_wristband_info_is_delete_xxbt_yesno_id` (`is_delete`),
  KEY `fk_wristband_info_issued_to_user_id` (`issued_to`),
  KEY `fk_wristband_info_issued_by_user_id` (`issued_by`),
  KEY `fk_wristband_info_status_xxbt_wb_status_id` (`status`),
  CONSTRAINT `fk_wristband_info_is_delete_xxbt_yesno_id` FOREIGN KEY (`is_delete`) REFERENCES `xxbt_yesno` (`id`),
  CONSTRAINT `fk_wristband_info_issued_by_user_id` FOREIGN KEY (`issued_by`) REFERENCES `user` (`id`),
  CONSTRAINT `fk_wristband_info_issued_to_user_id` FOREIGN KEY (`issued_to`) REFERENCES `user` (`id`),
  CONSTRAINT `fk_wristband_info_status_xxbt_wb_status_id` FOREIGN KEY (`status`) REFERENCES `xxbt_wb_status` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Table structure for table `xxbt_default` */

DROP TABLE IF EXISTS `xxbt_default`;

CREATE TABLE `xxbt_default` (
  `id` smallint(6) NOT NULL AUTO_INCREMENT,
  `description` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Table structure for table `xxbt_login_session_status` */

DROP TABLE IF EXISTS `xxbt_login_session_status`;

CREATE TABLE `xxbt_login_session_status` (
  `id` smallint(6) NOT NULL AUTO_INCREMENT,
  `description` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Table structure for table `xxbt_sensor_type` */

DROP TABLE IF EXISTS `xxbt_sensor_type`;

CREATE TABLE `xxbt_sensor_type` (
  `id` smallint(6) NOT NULL AUTO_INCREMENT,
  `description` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Table structure for table `xxbt_user_type` */

DROP TABLE IF EXISTS `xxbt_user_type`;

CREATE TABLE `xxbt_user_type` (
  `id` smallint(6) NOT NULL AUTO_INCREMENT,
  `description` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Table structure for table `xxbt_wb_status` */

DROP TABLE IF EXISTS `xxbt_wb_status`;

CREATE TABLE `xxbt_wb_status` (
  `id` smallint(6) NOT NULL AUTO_INCREMENT,
  `description` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Table structure for table `xxbt_yesno` */

DROP TABLE IF EXISTS `xxbt_yesno`;

CREATE TABLE `xxbt_yesno` (
  `id` smallint(6) NOT NULL AUTO_INCREMENT,
  `description` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
