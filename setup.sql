CREATE DATABASE CHat;
USE Chat;
CREATE TABLE messages (
  id INT NOT NULL AUTO_INCREMENT,
  msg_author VARCHAR(20),
  msg_text TEXT,
  msg_timestamp TIMESTAMP,
  PRIMARY KEY (id)
);
INSERT INTO messages (msg_author, msg_text, msg_timestamp)
  VALUES ('Admin', 'Database setup successfully.', NOW());
