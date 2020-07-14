USE timsfinaltacos;

-- CREATE TABLE tacos(
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   price DECIMAL(6,2) NOT NULL,
--   PRIMARY KEY (id)
-- );
-- CREATE TABLE ingredients(
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   kcal INT NOT NULL,
--   PRIMARY KEY (id)
-- );

CREATE TABLE tacoingredients(
  id int NOT NULL AUTO_INCREMENT,
  tacoId int NOT NULL,
  ingId int NOT NULL,
  PRIMARY KEY(id),
  FOREIGN KEY (tacoId)
    REFERENCES tacos (id)
    ON DELETE CASCADE,
  FOREIGN KEY (ingId)
    REFERENCES ingredients (id)
    ON DELETE CASCADE
)