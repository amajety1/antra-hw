-- Question 1: 
select p.ProductID, p.Name, P.Color, P.ListPrice
from Production.Product p;

-- Question 2: 
select p.ProductID, p.Name, P.Color, P.ListPrice
from Production.Product p
where p.ListPrice <> 0;

-- Question 3: 
select p.ProductID, p.Name, P.Color, P.ListPrice
from Production.Product p
where p.Color is NULL;

-- Question 4: 
select p.ProductID, p.Name, P.Color, P.ListPrice
from Production.Product p
where p.Color is not NULL;

-- Question 5: 
select p.ProductID, p.Name, P.Color, P.ListPrice
from Production.Product p
where p.Color is not NULL and p.ListPrice > 0;

-- Question 6: 
select p.Name + ' ' + p.Color as NameAndColor
from Production.Product p
where p.Color is not NULL;

-- Question 7: 
select p.Name, p.Color
from Production.Product p
where p.Name like '%Crankarm%' or p.Name like '%Chainring%';

-- Question 8: 
select p.ProductID, p.Name
from Production.Product p
where p.ProductID between 400 and 500;

-- Question 9: 
select p.ProductID, p.Name, p.Color
from Production.Product p
where p.Color in ('Black', 'Blue');

-- Question 10: 
select p.ProductID, p.Name
from Production.Product p
where p.Name like 'S%';

-- Question 11: 
select p.Name, p.ListPrice
from Production.Product p
where p.Name like 'S%'
order by p.Name;


-- Question 12: 
select p.Name, p.ListPrice
from Production.Product p
where p.Name like 'S%' or p.Name like 'A%'
order by p.Name;

-- Question 13: 
select p.Name, p.ListPrice
from Production.Product p
where p.Name like 'S%' or p.Name like 'A%'
order by p.Name;

-- Question 13: 
select p.Name, p.ListPrice
from Production.Product p
where p.Name like 'SPO%' and p.Name not like 'SPOK%'
order by p.Name;

-- Question 14: 
select distinct p.Color
from Production.Product p
order by p.Color desc;