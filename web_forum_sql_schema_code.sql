-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema web_forum
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema web_forum
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `web_forum` DEFAULT CHARACTER SET utf8 ;
USE `web_forum` ;

-- -----------------------------------------------------
-- Table `web_forum`.`user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `web_forum`.`user` (
  `id` VARCHAR(36) NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  `password` VARCHAR(100) NOT NULL,
  `nickname` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) VISIBLE,
  UNIQUE INDEX `nickname_UNIQUE` (`nickname` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `web_forum`.`topic`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `web_forum`.`topic` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `title` VARCHAR(45) NOT NULL,
  `content` TEXT(300) NOT NULL,
  `user_id` VARCHAR(36) NOT NULL,
  UNIQUE INDEX `title_UNIQUE` (`title` ASC) VISIBLE,
  PRIMARY KEY (`id`),
  INDEX `fk_topic_user_idx` (`user_id` ASC) VISIBLE,
  CONSTRAINT `fk_topic_user`
    FOREIGN KEY (`user_id`)
    REFERENCES `web_forum`.`user` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `web_forum`.`comment`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `web_forum`.`comment` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `content` TEXT(300) NOT NULL,
  `topic_id` INT NOT NULL,
  `user_id` VARCHAR(36) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_comment_topic1_idx` (`topic_id` ASC) VISIBLE,
  INDEX `fk_comment_user1_idx` (`user_id` ASC) VISIBLE,
  CONSTRAINT `fk_comment_topic1`
    FOREIGN KEY (`topic_id`)
    REFERENCES `web_forum`.`topic` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_comment_user1`
    FOREIGN KEY (`user_id`)
    REFERENCES `web_forum`.`user` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
