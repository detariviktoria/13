SELECT o.orderNumber, od.quantityOrdered, od.priceEach, COUNT(*) AS "affected_products"
FROM products p
INNER JOIN orderdetails od ON od.productCode = p.productCode
INNER JOIN orders o ON od.orderNumber = o.orderNumber
WHERE p.productCode = 
GROUP BY products.productCode