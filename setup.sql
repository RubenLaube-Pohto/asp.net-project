#NOT NEEDED
#Found a better solution bt using EF EnsureCreated()
CREATE DATABASE CHat;
USE Chat;
CREATE TABLE Messages (
  Id INT NOT NULL AUTO_INCREMENT,
  Author VARCHAR(20),
  Text TEXT,
  Timestamp TIMESTAMP,
  PRIMARY KEY (id)
);
INSERT INTO Messages (Author, Text, Timestamp)
  VALUES ('Admin', 'Database setup successfully.', NOW());
