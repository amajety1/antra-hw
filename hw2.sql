-- Question 1: 

SELECT count(*)
from Production.Product p;
-- Output: 504


-- Question 2: 
SELECT count(*)
from Production.Product p
where p.ProductSubcategoryID is not null;
-- Output: 295

-- Question 3: 
SELECT p.ProductSubcategoryID, count(*) as CountedProducts
from Production.Product p
where p.ProductSubcategoryID is not null
GROUP BY p.ProductSubcategoryID;

-- Question 4: 
SELECT count(*) 
from Production.Product p
where p.ProductSubcategoryID is  null

-- Question 5: 
SELECT SUM(p.Quantity)
from Production.ProductInventory p

-- Question 6: 
SELECT ProductID, SUM(Quantity) AS TheSum
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY ProductID
HAVING SUM(Quantity) < 100;

-- Question 7: 
SELECT Shelf, ProductID, SUM(Quantity) AS TheSum
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY Shelf, ProductID
HAVING SUM(Quantity) < 100;

-- Question 8: 

SELECT ProductID, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
WHERE LocationID = 10
GROUP BY ProductID;

-- 9. Average quantity of products by shelf
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
GROUP BY ProductID, Shelf;

-- 10. Average quantity of products by shelf, excluding Shelf = 'N/A'
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
WHERE Shelf <> 'N/A'
GROUP BY ProductID, Shelf;

-- 11. Members and average list price, grouped by Color and Class, excluding NULLs
SELECT Color, Class, COUNT(*) AS TheCount, AVG(ListPrice) AS AvgPrice
FROM Production.Product
WHERE Color IS NOT NULL AND Class IS NOT NULL
GROUP BY Color, Class;

-- 12. List all country and province names (joined)
SELECT cr.Name AS Country, sp.Name AS Province
FROM person.CountryRegion cr
JOIN person.StateProvince sp
  ON cr.CountryRegionCode = sp.CountryRegionCode;

-- 13. List country and province names, filtered to Germany and Canada
SELECT cr.Name AS Country, sp.Name AS Province
FROM person.CountryRegion cr
JOIN person.StateProvince sp
  ON cr.CountryRegionCode = sp.CountryRegionCode
WHERE cr.Name IN ('Germany', 'Canada');

-- 14. Products sold at least once in last 27 years (since 1997)
SELECT DISTINCT p.ProductName
FROM Products p
JOIN [Order Details] od ON p.ProductID = od.ProductID
JOIN Orders o ON od.OrderID = o.OrderID
WHERE o.OrderDate >= DATEADD(YEAR, -27, GETDATE());

-- 15. Top 5 zip codes where products sold most (all time)
SELECT TOP 5 c.PostalCode, COUNT(*) AS SoldCount
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
GROUP BY c.PostalCode
ORDER BY SoldCount DESC;

-- 16. Top 5 zip codes where products sold most in last 27 years
SELECT TOP 5 c.PostalCode, COUNT(*) AS SoldCount
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
WHERE o.OrderDate >= DATEADD(YEAR, -27, GETDATE())
GROUP BY c.PostalCode
ORDER BY SoldCount DESC;

-- 17. All city names and number of customers in that city
SELECT c.City, COUNT(*) AS NumCustomers
FROM Customers c
GROUP BY c.City;

-- 18. City names with more than 2 customers, number of customers
SELECT c.City, COUNT(*) AS NumCustomers
FROM Customers c
GROUP BY c.City
HAVING COUNT(*) > 2;

-- 19. Names of customers who placed orders after 1/1/98 with order date
SELECT DISTINCT c.CompanyName, o.OrderDate
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1998-01-01';

-- 20. Names of all customers with most recent order dates
SELECT c.CompanyName, MAX(o.OrderDate) AS MostRecentOrder
FROM Customers c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.CompanyName;


-- 21. Names of all customers with count of products they bought
SELECT c.CompanyName, COUNT(od.ProductID) AS ProductCount
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.CompanyName;

-- 22. Customer IDs who bought more than 100 products, with count
SELECT c.CustomerID, COUNT(od.ProductID) AS ProductCount
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.CustomerID
HAVING COUNT(od.ProductID) > 100;

-- 23. All possible ways suppliers can ship products
SELECT DISTINCT s.CompanyName AS [Supplier Company Name], sh.CompanyName AS [Shipping Company Name]
FROM Suppliers s
CROSS JOIN Shippers sh;


-- 24. Display the products ordered each day (Order date and Product Name)
SELECT o.OrderDate, p.ProductName
FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID;

-- 25. Pairs of employees with the same job title
SELECT e1.EmployeeID AS Emp1, e2.EmployeeID AS Emp2, e1.Title



-- 26. Managers with more than 2 employees reporting to them
SELECT e.ReportsTo AS ManagerID, COUNT(*) AS NumReports
FROM Employees e
WHERE e.ReportsTo IS NOT NULL
GROUP BY e.ReportsTo
HAVING COUNT(*) > 2;

-- 27. Customers and suppliers by city
SELECT 
    c.City,
    c.CompanyName AS Name,
    c.ContactName,
    'Customer' AS Type
FROM Customers c
UNION ALL
SELECT 
    s.City,
    s.CompanyName AS Name,
    s.ContactName,
    'Supplier' AS Type
FROM Suppliers s;