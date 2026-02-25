SELECT *
FROM versenyzo v
SELECT
WHERE v.id NOT IN (
    FROM eredmeny e
);

CREATE VIEW reszvetelekszama as 
SELECT v.nev, COUNT(*) AS "résztvételekszáma"
FROM versenyzo v
INNER JOIN eredmeny e on v.id = e.versenyzoID
GROUP BY v.nev
ORDER BY 2 DESC;