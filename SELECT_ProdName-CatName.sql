SELECT prod.ProductName [Продукт], cat.CategoryName [Категории]
FROM Products prod
LEFT JOIN Products prodcat ON prod.ProductID = prodcat.CategoryID
INNER JOIN Categories cat ON cat.CategoryID = prodcat.CategoryID
ORDER BY prod.ProductName