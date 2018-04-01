USE [master]
GO

/****** Object:  Database [empresas]    Script Date: 07/03/2018 23:31:48 ******/
CREATE DATABASE [empresas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmpresaDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\EmpresaDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EmpresaDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\EmpresaDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [empresas] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [empresas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [empresas] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [empresas] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [empresas] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [empresas] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [empresas] SET ARITHABORT OFF 
GO

ALTER DATABASE [empresas] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [empresas] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [empresas] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [empresas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [empresas] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [empresas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [empresas] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [empresas] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [empresas] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [empresas] SET  DISABLE_BROKER 
GO

ALTER DATABASE [empresas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [empresas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [empresas] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [empresas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [empresas] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [empresas] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [empresas] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [empresas] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [empresas] SET  MULTI_USER 
GO

ALTER DATABASE [empresas] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [empresas] SET DB_CHAINING OFF 
GO

ALTER DATABASE [empresas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [empresas] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [empresas] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [empresas] SET  READ_WRITE 
GO

