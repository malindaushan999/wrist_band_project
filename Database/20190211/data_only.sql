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

/*Data for the table `login_session` */

/*Data for the table `sensor_data` */

/*Data for the table `sensor_info` */

/*Data for the table `user` */

/*Data for the table `wristband_info` */

/*Data for the table `xxbt_default` */

/*Data for the table `xxbt_sensor_type` */

insert  into `xxbt_sensor_type`(`id`,`description`) values 
(1,'Heart Beat Sensor'),
(2,'Blood Pressure Sensor'),
(3,'Temparature Sensor');

/*Data for the table `xxbt_user_type` */

insert  into `xxbt_user_type`(`id`,`description`) values 
(1,'sys_admin'),
(2,'local'),
(3,'web_admin');

/*Data for the table `xxbt_wb_status` */

insert  into `xxbt_wb_status`(`id`,`description`) values 
(1,'Active'),
(2,'Deactive'),
(3,'Pending');

/*Data for the table `xxbt_yesno` */

insert  into `xxbt_yesno`(`id`,`description`) values 
(0,'OFF'),
(1,'ON');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
