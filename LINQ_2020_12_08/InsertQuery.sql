insert into [Sales].[OrderLines]
([OrderID],[StockItemID],[Description],[PackageTypeID], [Quantity], [UnitPrice], [TaxRate], [PickedQuantity], [PickingCompletedWhen], [LastEditedBy], [LastEditedWhen]
)
select 
[OrderID],[StockItemID],[Description],[PackageTypeID], [Quantity], [UnitPrice], [TaxRate], [PickedQuantity], [PickingCompletedWhen], [LastEditedBy], [LastEditedWhen]
from [Sales].[OrderLines]


select COUNT(*) from [Sales].[OrderLines]