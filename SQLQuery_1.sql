CREATE DATABASE wearhouseDB;

CREATE TABLE MsUser (
    UserID VARCHAR(225) PRIMARY key NOT NULL,
    userName VARCHAR(225) NOT NULL,
    userEmail VARCHAR(225) NOT NULL,
    userPassword VARCHAR(225) NOT NULL
)

CREATE TABLE MsCategory (
    CategoryID VARCHAR(225) PRIMARY KEY,
    UserID VARCHAR(225) NOT NULL FOREIGN KEY, 
    Category VARCHAR(225) NOT NULL,
    categorydate DATETIME
)

ALTER TABLE MsCategory
ADD CONSTRAINT FK_Category_User FOREIGN KEY (UserID) REFERENCES MsUser(UserID);

INSERT INTO MsUser (UserID, Username, userEmail, userPassword) VALUES ('483f43ae-b4f6-4274-8057-329dda560903', 'admin', 'admin@gmail.com', 'Admin@123');

SELECT * From MsUser;

INSERT INTO MsCategory 
VALUES
  ('1acf2035-a7e9-4bdd-ae93-44ec21cff32d', '483f43ae-b4f6-4274-8057-329dda560903', 'pistol', GETDATE()),
  ('1bc2c010-614d-428f-8471-7a48ae01f71d', '483f43ae-b4f6-4274-8057-329dda560903', 'clothe', GETDATE()),
  ('57499776-50d9-4f0c-a8c0-78131d300e6a', '483f43ae-b4f6-4274-8057-329dda560903', 'shoe', GETDATE()),
  ('66f46e23-077e-4ebd-9192-1baa33bba9d2', '483f43ae-b4f6-4274-8057-329dda560903', 'hat', GETDATE()),
  ('c4cf3569-52b8-43d3-8f3f-9e6125ecd35b', '483f43ae-b4f6-4274-8057-329dda560903', 'gergaji mesin', GETDATE());

SELECT * from MsCategory