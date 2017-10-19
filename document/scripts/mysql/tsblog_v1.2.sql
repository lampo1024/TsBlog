/*
SQLyog Enterprise v12.4.1 (64 bit)
MySQL - 5.7.17-log : Database - tsblog
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`tsblog` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `tsblog`;

/*Table structure for table `tb_post` */

DROP TABLE IF EXISTS `tb_post`;

CREATE TABLE `tb_post` (
  `Id` int(12) NOT NULL AUTO_INCREMENT,
  `Title` varchar(255) DEFAULT '' COMMENT '标题',
  `Content` text COMMENT '内容',
  `AuthorId` int(6) DEFAULT '0' COMMENT '作者ID',
  `AuthorName` varchar(50) DEFAULT '' COMMENT '作者姓名',
  `CreatedAt` datetime DEFAULT NULL COMMENT '创建时间',
  `PublishedAt` datetime DEFAULT NULL COMMENT '发布时间',
  `IsDeleted` bit(1) DEFAULT b'0' COMMENT '是否标识已删除[0:否,1:是],默认值:0',
  `AllowShow` bit(1) DEFAULT b'1' COMMENT '是否允许展示[0:否,1:是],默认值:1',
  `ViewCount` int(10) DEFAULT '0' COMMENT '浏览量',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `tb_post` */

insert  into `tb_post`(`Id`,`Title`,`Content`,`AuthorId`,`AuthorName`,`CreatedAt`,`PublishedAt`,`IsDeleted`,`AllowShow`,`ViewCount`) values 
(1,'Title','Clean content',0,'',NULL,NULL,'\0','',0);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
