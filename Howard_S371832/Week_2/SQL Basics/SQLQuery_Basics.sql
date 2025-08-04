CREATE DATABASE DotNetCourseDatabase
GO

USE DotNetCourseDatabase
GO

CREATE SCHEMA TutortialAppSchema
GO

DROP TABLE TutortialAppSchema.Computer
GO

CREATE TABLE TutortialAppSchema.Computer
(
    --TableId INT  IDENTITY(Starting,Increment By)
    ComputerId INT  IDENTITY(1,1) PRIMARY KEY,
    -- CHAR, VARCHAR, NVARCHAR
    Motherboard NVARCHAR(255),
    -- INT
    CPUCores INT,
    -- BIT plays as Boolean
    HasWifi BIT,
    -- 0.0001
    HasLTE DECIMAL(18, 4),
    ReleaseDate DATETIME,
    Price DECIMAL(18, 4),
    VideoCard NVARCHAR(255)
)
GO

SELECT * FROM TutortialAppSchema.Computer WHERE 1 = 0

INSERT INTO TutortialAppSchema.Computer (
    [Motherboard],
    [CPUCores],
    [HasWifi],
    [HasLTE],
    [ReleaseDate],
    [Price],
    [VideoCard]
) VALUES (
    'Sample-Motherboard',
    4,
    1,
    0,
    '2025-01-01',
    1000,
    'Sample-Videocard'
)

DELETE FROM TutortialAppSchema.Computer WHERE ComputerId = 119

UPDATE TutortialAppSchema.Computer SET CPUCores = 6 WHERE ComputerId = 1
UPDATE TutortialAppSchema.Computer SET CPUCores = 2 WHERE ReleaseDate < '2022-01-01'

SELECT * FROM TutortialAppSchema.Computer 
ORDER BY ReleaseDate DESC, HasWifi DESC