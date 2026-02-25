-- Species (Fajok)
INSERT INTO Species(id, name, averageLifespan) VALUES
(1, 'Kutya', 12),
(2, 'Macska', 15),
(3, 'Nyúl', 8),
(4, 'Papagáj', 25),
(5, 'Hüllő', 20);

-- Locations (Helyek)
INSERT INTO Locations(id, name, address, phone, email) VALUES
(1, 'Budapest Menhely', 'Budapest, Fő utca 12', '0612345678', 'info@menhelybp.hu'),
(2, 'Debrecen Állatotthon', 'Debrecen, Petőfi u. 8', '0620123456', 'info@debrecanimal.hu'),
(3, 'Szeged Kisállat Centrum', 'Szeged, Tisza Lajos krt. 5', '0630123456', 'szeged@kisallat.hu');

-- Animals (Állatok)
INSERT INTO Animals(id, name, speciesID, age, adopted, registeredAt, locationID) VALUES
(1, 'Bodri', 1, 3, FALSE, '2025-01-10 10:00:00', 1),
(2, 'Cirmi', 2, 2, TRUE, '2024-12-01 09:30:00', 1),
(3, 'Nyuszi', 3, 1, FALSE, '2025-02-15 14:00:00', 2),
(4, 'Papagájka', 4, 5, FALSE, '2025-03-12 11:20:00', 3),
(5, 'Zöldike', 5, 7, TRUE, '2025-04-05 16:45:00', 2);

-- Adopters (Örökbefogadók)
INSERT INTO Adopters(id, name, email, phone, registeredAt) VALUES
(1, 'Kovács Anna', 'anna.kovacs@mail.com', '0630123456', '2025-01-05 12:00:00'),
(2, 'Nagy Péter', 'peter.nagy@mail.com', '0620123456', '2025-02-10 14:30:00'),
(3, 'Tóth Lilla', 'lilla.toth@mail.com', '0612345678', '2025-03-01 09:15:00');

-- Adoptions (Örökbefogadások)
INSERT INTO Adoptions(id, animalID, adopterID, adoptionDate) VALUES
(1, 2, 1, '2025-01-15'),
(2, 5, 2, '2025-04-10');

-- Vets (Állatorvosok)
INSERT INTO Vets(id, name, specialty, phone, email) VALUES
(1, 'Dr. Kiss János', 'Kisállatok', '0612345670', 'kiss.janos@vet.hu'),
(2, 'Dr. Szabó Éva', 'Hüllők', '0612345671', 'szabo.eva@vet.hu');

-- Appointments (Időpontok)
INSERT INTO Appointments(id, animalID, vetID, appointmentDate, reason, notes) VALUES
(1, 1, 1, '2025-05-01 10:00:00', 'Általános vizsgálat', 'Nincs megjegyzés'),
(2, 3, 2, '2025-05-02 11:30:00', 'Védőoltás', 'Nyuszi oltása'),
(3, 4, 1, '2025-05-03 14:00:00', 'Egészségellenőrzés', 'Papagáj tollazata jó');

