USE Mvc5App

SELECT Managers.Name, COUNT(OrderId) AS Orders FROM Managers
LEFT JOIN Orders ON Managers.ManagerId=Orders.ManagerId and Date BETWEEN '2018.01.08' AND '2018.06.26'
GROUP BY Managers.Name


