SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for ts_user
-- ----------------------------
DROP TABLE IF EXISTS `tb_user`;
CREATE TABLE `tb_user`  (
  `Id` int(10) NOT NULL AUTO_INCREMENT,
  `LoginName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '' COMMENT '登录名',
  `Password` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '' COMMENT '密码',
  `DisplayName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '' COMMENT '显示名称',
  `RealName` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '' COMMENT '真实姓名',
  `EmailAddress` varchar(120) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '' COMMENT '电子邮箱',
  `Avatar` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '' COMMENT '用户头像',
  `Status` int(2) NOT NULL DEFAULT 1 COMMENT '用户的状态,0:禁用,1:正常',
  `Telephone` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '' COMMENT '手机号码',
  `Qq` varchar(15) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `WebsiteUrl` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `CreatedOn` datetime(0) NULL DEFAULT NULL COMMENT '用户创建时间',
  `CreatedIp` varchar(24) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '' COMMENT '创建用户时的IP地址',
  `LoginCount` int(8) NULL DEFAULT 0 COMMENT '登录次数累加器',
  `LatestLoginDate` datetime(0) NULL DEFAULT NULL COMMENT '最近一次登录时间',
  `LatestLoginIp` varchar(24) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '' COMMENT '最近一次登录时的IP地址',
  `ModifiedOn` datetime(0) NULL DEFAULT NULL COMMENT '最近修改时间',
  `Type` int(2) NULL DEFAULT 0 COMMENT '用户类型[-1:超级管理员,0:一般用户]',
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_LoginName`(`LoginName`) USING BTREE,
  UNIQUE INDEX `IX_EmailAddress`(`EmailAddress`) USING BTREE,
  INDEX `IX_CreatedOn`(`CreatedOn`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 0 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
