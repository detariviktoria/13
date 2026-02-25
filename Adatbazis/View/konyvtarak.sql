/*
    Megyenev | konyvtarDb
    Békés    |     5
*/
SELECT m.megyeNev COUNT(*) AS konyvtarDb
FROM telepulesek INNER JOIN konyvtarak ON konyvtarak.irsz = telepulesek.irsz
GROUP BY megyeNev;

