-- Select Customer With Orders (WERKT NIET MEER)
Select Customer.CustomerId, Customer.Name,Customer.Address, 
OrderT.OrderId, OrderT.DateTime, OrderT.Is_Checked, OrderT.PriceAlreadyPayed
from dbo.Customer
JOIN CustomerOrder ON Customer.CustomerId = CustomerOrder.CustomerId
JOIN OrderT ON CustomerOrder.OrderId = OrderT.OrderId
AND CustomerOrder.CustomerId like 1;

-- Select All Orders With/Without Products
Select OrderT.OrderId, OrderT.DateTime, OrderT.Is_Checked, OrderT.PriceAlreadyPayed, OrderT.CustomerId,
Product.Name, Product.Price, OrderProduct.Amount from OrderT
LEFT OUTER JOIN OrderProduct
ON OrderT.OrderId = OrderProduct.OrderId
LEFT OUTER JOIN Product 
ON OrderProduct.ProductId = Product.ProductId;

-- Select OrderById With/Without Products
Select OrderT.OrderId, OrderT.DateTime, OrderT.Is_Checked, OrderT.PriceAlreadyPayed, OrderT.CustomerId,
Product.Name, Product.Price, OrderProduct.Amount from OrderT
LEFT OUTER JOIN OrderProduct
ON OrderT.OrderId = OrderProduct.OrderId
LEFT OUTER JOIN Product 
ON OrderProduct.ProductId = Product.ProductId
where OrderT.OrderId = 2;