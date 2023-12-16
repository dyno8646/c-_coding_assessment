
------------------------------------INSURANCE MANAGEMENT SYSTEM-------------------------------------------


---------1. SCHEMA DESIGN


-- Create the Users table to manage system users with different roles 

CREATE TABLE Users(
user_id INT PRIMARY KEY IDENTITY(1,1),
username VARCHAR(50) NOT NULL,
password VARCHAR(50) NOT NULL,
role VARCHAR(10) NOT NULL CHECK (role IN ('admin', 'agent', 'client')));

-- Create the Policies table to store information about insurance policies

CREATE TABLE Policies(
policy_id INT PRIMARY KEY IDENTITY(1,1),
policy_number VARCHAR(20) NOT NULL,
policy_type VARCHAR(50) NOT NULL,
coverage_amount DECIMAL(10, 2) NOT NULL,
premium_amount DECIMAL(8, 2) NOT NULL,
start_date DATE NOT NULL,
end_date DATE NOT NULL);

-- Create the Clients table to manage client information

CREATE TABLE Clients(
client_id INT PRIMARY KEY IDENTITY(1,1),
client_name VARCHAR(100) NOT NULL,
contact_info VARCHAR(255),
policy_id INT,
FOREIGN KEY (policy_id) REFERENCES Policies(policy_id));

-- Create the Claims table to record insurance claims

CREATE TABLE Claims (
claim_id INT PRIMARY KEY IDENTITY(1,1),
claim_number VARCHAR(20) NOT NULL,
date_filed DATE NOT NULL,
claim_amount DECIMAL(10, 2) NOT NULL,
status VARCHAR(10) NOT NULL CHECK (status IN ('pending', 'approved', 'denied')),
policy_id INT,
client_id INT,
FOREIGN KEY (policy_id) REFERENCES Policies(policy_id),
FOREIGN KEY (client_id) REFERENCES Clients(client_id));

-- Create the Payments table to record premium payments

CREATE TABLE Payments (
payment_id INT PRIMARY KEY IDENTITY(1,1),
payment_date DATE NOT NULL,
payment_amount DECIMAL(8, 2) NOT NULL,
client_id INT,
FOREIGN KEY (client_id) REFERENCES Clients(client_id));


SELECT * FROM Users;
SELECT * FROM Policies;
SELECT * FROM Clients;
SELECT * FROM Claims;
SELECT * FROM Payments;




INSERT INTO Users (username, password, role) VALUES
('Naruto_Uzumaki', 'hiddenleaf123', 'client'),
('Luffy_Monkey', 'strawhat456', 'client'),
('Sasuke_Uchiha', 'sharingan789', 'client'),
('Goku_Son', 'kamehameha987', 'client'),
('Light_Yagami', 'deathnote654', 'admin');

UPDATE Users SET role = 'agent' WHERE username = 'Sasuke_Uchiha';

INSERT INTO Policies (policy_number, policy_type, coverage_amount, premium_amount, start_date, end_date)
VALUES
  ('POL001', 'Life Insurance', 50000.00, 100.00, '2020-01-01', '2023-12-31'),
  ('POL002', 'Car Insurance', 30000.00, 50.00, '2022-02-01', '2023-12-31'),
  ('POL003', 'Home Insurance', 80000.00, 120.00, '2023-03-01', '2023-12-31'),
  ('POL004', 'Health Insurance', 25000.00, 80.00, '2019-04-01', '2022-12-31'),
  ('POL005', 'Travel Insurance', 10000.00, 30.00, '2023-05-01', '2023-12-31'),
  ('POL006', 'Accident Insurance', 20000.00, 40.00, '2021-06-01', '2023-12-31'),
  ('POL007', 'Property Insurance', 70000.00, 90.00, '2015-07-01', '2023-12-31'),
  ('POL008', 'Pet Insurance', 15000.00, 25.00, '2020-08-01', '2023-12-31'),
  ('POL009', 'Business Insurance', 120000.00, 150.00, '2022-09-01', '2023-12-31'),
  ('POL010', 'Electronics Insurance', 18000.00, 35.00, '2023-10-01', '2023-12-31');

 INSERT INTO Clients (client_name, contact_info, policy_id) 
 VALUES
  ('Tanjiro Kamado', 'tanjiro.kamado@example.com', 1),
  ('Nezuko Kamado', 'nezuko.kamado@gmail.com', 3),
  ('Zenitsu Agatsuma', 'zenitsu.agatsuma@outlook.com', 5),
  ('Inosuke Hashibira', 'inosuke.hashibira@gmail.com', 7),
  ('Kanao Tsuyuri', 'kanao.tsuyuri@example.com', 9);


INSERT INTO Claims (claim_number, date_filed, claim_amount, status, policy_id, client_id)
VALUES
  ('CLM001', '2023-01-15', 1500.00, 'pending', 1, 1),
  ('CLM002', '2023-02-22', 2000.00, 'approved', 3, 2),
  ('CLM003', '2023-03-10', 1200.50, 'pending', 5, 3),
  ('CLM004', '2023-04-05', 1800.75, 'denied', 7, 4),
  ('CLM005', '2023-05-12', 900.25, 'approved', 9, 5),
  ('CLM006', '2023-06-20', 2500.00, 'pending', 2, 2),
  ('CLM007', '2023-07-08', 3000.50, 'approved', 4, 1),
  ('CLM008', '2023-08-17', 1500.75, 'denied', 6, 3);


INSERT INTO Payments (payment_date, payment_amount, client_id)
VALUES
  ('2023-01-25', 500.00, 1),
  ('2023-02-15', 750.50, 2),
  ('2023-03-08', 1200.75, 3),
  ('2023-04-20', 1000.00, 4),
  ('2023-05-10', 1500.25, 5);