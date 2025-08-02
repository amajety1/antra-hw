-- 1 
SELECT DISTINCT e.City
FROM Employees e
INNER JOIN Customers c ON e.City = c.City;


-- 2

-- a) Subquery
SELECT DISTINCT City
FROM Customers
WHERE City NOT IN (
    SELECT DISTINCT City
    FROM Employees
);

-- b) Not using subquery
SELECT DISTINCT c.City
FROM Customers c
LEFT JOIN Employees e ON c.City = e.City
WHERE e.City IS NULL;


--3 
SELECT p.ProductID, sum(od.Quantity) as TotalOrderQuantity
from Products p
left join [Order Details] od
on p.ProductID = od.ProductID
group by p.ProductID




--4
select distinct c.City, k.totalQuantity
from Customers c
left join ( select sum(od.Quantity) as totalQuantity, o.ShipCity from [Order Details] od
 left join Orders o
 on od.OrderID = o.OrderID
 GROUP by o.ShipCity) k
on c.City = k.ShipCity


--5
select * from(
select c.City, count(distinct c.ContactName) as uniqueCustomers
from Customers c
group by c.City
) k

where k.uniqueCustomers>1



--6
select   o.ShipCity
from Orders o
left join [Order Details] od
on o.OrderID = od.OrderID
group by o.ShipCity
having count(distinct od.ProductID)>=2



--7
select o.CustomerID
from Orders o
left join Customers c
on  o.CustomerID = c.CustomerID
where o.ShipCity <> c.City
group by o.CustomerID





--8
with rankedCities as(
select f.ProductID, f.averagePrice, s.CustomerCity, count(s.CustomerCity) 
as quantityFromCity , ROW_NUMBER() over 
(PARTITION by f.ProductID order by count(s.CustomerCity) desc) as rn

from (

select top 5
od.ProductID, count(*) as quantityOrdered, sum(od.UnitPrice*od.Quantity)/sum(od.Quantity) as averagePrice
from [Order Details] od
group by od.ProductID
order by quantityOrdered desc ) f left join 


(
select k.CustomerCity, k.OrderID, od.ProductID from (
select c.City as CustomerCity, o.OrderID from Orders o
left join
Customers c
on o.CustomerID = c.CustomerID
) k
left join [Order Details] od
on k.OrderID = od.OrderID) s 

on f.ProductID = s.ProductID
group by f.ProductID, f.averagePrice, s.CustomerCity)

SELECT 
    ProductID, 
    averagePrice, 
    CustomerCity, 
    quantityFromCity
FROM RankedCities
WHERE rn = 1
ORDER BY ProductID;



--9
SELECT DISTINCT City
FROM Employees
WHERE City NOT IN (
    SELECT DISTINCT ShipCity
    FROM Orders
);
-- no subquery
SELECT DISTINCT e.City
FROM Employees e
LEFT JOIN Orders o ON e.City = o.ShipCity
WHERE o.ShipCity IS NULL;

 --10
 with i as (select  o.EmployeeID, o.ShipCity, count(distinct od.OrderID) as uniqueOrders, 
ROW_NUMBER() over 
(PARTITION by o.EmployeeID order by count(distinct od.OrderID) desc) as rn
from [Order Details] od
left join Orders o
on od.OrderID = o.OrderID
group by o.EmployeeID, o.ShipCity
)

select EmployeeID, ShipCity
from i
where rn=1


--11
SELECT DISTINCT * 
INTO new_table
FROM your_table;


