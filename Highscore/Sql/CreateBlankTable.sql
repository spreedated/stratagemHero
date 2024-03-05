CREATE TABLE "highscores" (
	"id"	INTEGER NOT NULL,
	"playername"	TEXT NOT NULL,
	"score"	INTEGER,
	"date"	TEXT NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
);
INSERT INTO highscores (playername, score, date) VALUES ('SpReeD', 1337, '02-03-2024 00:00:00');
INSERT INTO highscores (playername, score, date) VALUES ('SpReeD', 1000, '02-03-2024 00:00:00');
INSERT INTO highscores (playername, score, date) VALUES ('SpReeD', 800, '02-03-2024 00:00:00');
INSERT INTO highscores (playername, score, date) VALUES ('SpReeD', 500, '02-03-2024 00:00:00');