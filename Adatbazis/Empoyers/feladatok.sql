SELECT DISTINCT employees.jobTitle
FROM employees
ORDER BY employees.jobTitle ASC;


CREATE VIEW currentJobTitles AS 
SELECT DISTINCT employees.jobTitle
FROM employees
ORDER BY employees.jobTitle ASC;

SELECT employees.jobTitle, COUNT(*) AS db
FROM employees
GROUP BY employees.jobTitle
ORDER BY 2 DESC;

/*replace = update*/
CREATE OR REPLACE VIEW jobtitlecount AS 
SELECT employees.jobTitle, COUNT(*) AS db
FROM employees
GROUP BY employees.jobTitle
HAVING db > 5
ORDER BY 2 DESC;

