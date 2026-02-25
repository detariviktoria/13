ALTER TABLE gondoz AUTO_increment 

DELIMITER //
CREATE TRIGGER gondozoFelvetele
AFTER INSERT on gondozo FOR EACH ROW
BEGIN 
    INSERT into gondoz
    Select null, allatok.id, NEW.ID
    