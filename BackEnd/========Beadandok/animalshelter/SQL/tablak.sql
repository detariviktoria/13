CREATE TABLE Species (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    averageLifespan INT
);

CREATE TABLE Locations (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    address VARCHAR(255),
    phone VARCHAR(20),
    email VARCHAR(100)
);

CREATE TABLE Animals (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    speciesID INT,
    age INT,
    adopted BOOLEAN DEFAULT FALSE,
    registeredAt DATETIME,
    locationID INT,
    FOREIGN KEY (speciesID) REFERENCES Species(id),
    FOREIGN KEY (locationID) REFERENCES Locations(id)
);

CREATE TABLE Adopters (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE,
    phone VARCHAR(20),
    registeredAt DATETIME
);

CREATE TABLE Adoptions (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    animalID INT NOT NULL,
    adopterID INT NOT NULL,
    adoptionDate DATE,
    FOREIGN KEY (animalID) REFERENCES Animals(id),
    FOREIGN KEY (adopterID) REFERENCES Adopters(id)
);

CREATE TABLE Vets (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    specialty VARCHAR(50),
    phone VARCHAR(20),
    email VARCHAR(100)
);

CREATE TABLE Appointments (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    animalID INT NOT NULL,
    vetID INT NOT NULL,
    appointmentDate DATETIME,
    reason VARCHAR(255),
    notes TEXT,
    FOREIGN KEY (animalID) REFERENCES Animals(id),
    FOREIGN KEY (vetID) REFERENCES Vets(id)
);
