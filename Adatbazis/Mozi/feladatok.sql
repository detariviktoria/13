CREATE VIEW  otven_alatti_bevetel as

SELECT *
FROM eloadas eloadas
WHERE e.bevetel < 50000;


SELECT mozi.varos, SUM(bevetel) AS Város_bevétel
FROM mozi INNER JOIN eloadas ON mozi.id = moziid
GROUP BY mozi.varos ;