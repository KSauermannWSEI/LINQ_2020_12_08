using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("StockItemTransactions", Schema = "Warehouse")]
    [Index(nameof(CustomerId), Name = "FK_Warehouse_StockItemTransactions_CustomerID")]
    [Index(nameof(InvoiceId), Name = "FK_Warehouse_StockItemTransactions_InvoiceID")]
    [Index(nameof(PurchaseOrderId), Name = "FK_Warehouse_StockItemTransactions_PurchaseOrderID")]
    [Index(nameof(StockItemId), Name = "FK_Warehouse_StockItemTransactions_StockItemID")]
    [Index(nameof(SupplierId), Name = "FK_Warehouse_StockItemTransactions_SupplierID")]
    [Index(nameof(TransactionTypeId), Name = "FK_Warehouse_StockItemTransactions_TransactionTypeID")]
    public partial class StockItemTransaction
    {
        [Key]
        [Column("StockItemTransactionID")]
        public int StockItemTransactionId { get; set; }
        [Column("StockItemID")]
        public int StockItemId { get; set; }
        [Column("TransactionTypeID")]
        public int TransactionTypeId { get; set; }
        [Column("CustomerID")]
        public int? CustomerId { get; set; }
        [Column("InvoiceID")]
        public int? InvoiceId { get; set; }
        [Column("SupplierID")]
        public int? SupplierId { get; set; }
        [Column("PurchaseOrderID")]
        public int? PurchaseOrderId { get; set; }
        public DateTime TransactionOccurredWhen { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Quantity { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("StockItemTransactions")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(InvoiceId))]
        [InverseProperty("StockItemTransactions")]
        public virtual Invoice Invoice { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.StockItemTransactions))]
        public virtual Person LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(PurchaseOrderId))]
        [InverseProperty("StockItemTransactions")]
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        [ForeignKey(nameof(StockItemId))]
        [InverseProperty("StockItemTransactions")]
        public virtual StockItem StockItem { get; set; }
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty("StockItemTransactions")]
        public virtual Supplier Supplier { get; set; }
        [ForeignKey(nameof(TransactionTypeId))]
        [InverseProperty("StockItemTransactions")]
        public virtual TransactionType TransactionType { get; set; }
    }
}
