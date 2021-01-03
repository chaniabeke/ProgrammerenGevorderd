-- Select Customer With Orders
Select Customer.CustomerId, Customer.Name,Customer.Address, 
OrderT.OrderId, OrderT.DateTime, OrderT.Is_Checked, OrderT.PriceAlreadyPayed
from dbo.Customer
JOIN CustomerOrder ON Customer.CustomerId = CustomerOrder.CustomerId
JOIN OrderT ON CustomerOrder.OrderId = OrderT.OrderId
AND CustomerOrder.CustomerId like 1;