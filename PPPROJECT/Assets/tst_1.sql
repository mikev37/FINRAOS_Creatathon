BEGIN TRANSACTION;
CREATE TABLE "user_2" (
	`id`	INTEGER,
	`order_id`	TEXT
);
INSERT INTO `user_2` VALUES (222,'dweufeui');
INSERT INTO `user_2` VALUES (234,'weifhwihu');
INSERT INTO `user_2` VALUES (222,'dhifhirnfi');
CREATE TABLE `user` (
	`name`	TEXT,
	`id`	INTEGER,
	`age`	INTEGER
);
INSERT INTO `user` VALUES ('bbb',234,56);
INSERT INTO `user` VALUES ('ccc',222,44);
INSERT INTO `user` VALUES ('aaa',123,34);
COMMIT;
