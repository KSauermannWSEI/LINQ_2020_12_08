using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("SupplierTransactions", Schema = "Purchasing")]
    [Index(nameof(TransactionDate), nameof(PaymentMethodId), Name = "FK_Purchasing_SupplierTransactions_PaymentMethodID")]
    [Index(nameof(TransactionDate), nameof(PurchaseOrderId), Name = "FK_Purchasing_SupplierTransactions_PurchaseOrderID")]
    [Index(nameof(TransactionDate), nameof(SupplierId), Name = "FK_Purchasing_SupplierTransactions_SupplierID")]
    [Index(nameof(TransactionDate), nameof(TransactionTypeId), Name = "FK_Purchasing_SupplierTransactions_TransactionTypeID")]
    [Index(nameof(TransactionDate), nameof(IsFinalized), Name = "IX_Purchasing_SupplierTransactions_IsFinalized")]
    public partial class SupplierTransaction
    {
        [Key]
        [Column("SupplierTransactionID")]
        public int SupplierTransactionId { get; set; }
        [Column("SupplierID")]
        public int SupplierId { get; set; }
        [Column("TransactionTypeID")]
        public int TransactionTypeId { get; set; }
        [Column("PurchaseOrderID")]
        public int? PurchaseOrderId { get; set; }
        [Column("PaymentMethodID")]
        public int? PaymentMethodId { get; set; }
        [StringLength(20)]
        public string SupplierInvoiceNumber { get; set; }
        [Column(TypeName = "date")]
        public DateTime TransactionDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AmountExcludingTax { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TaxAmount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TransactionAmount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OutstandingBalance { get; set; }
        [Column(TypeName = "date")]
        public DateTime? FinalizationDate { get; set; }
        public bool? IsFinalized { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.SupplierTransactions))]
        public virtual Person LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(PaymentMethodId))]
        [InverseProperty("SupplierTransactions")]
        public virtual PaymentMethod PaymentMethod { get; set; }
        [ForeignKey(nameof(PurchaseOrderId))]
        [InverseProperty("SupplierTransactions")]
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty("SupplierTransactions")]
        public virtual Supplier Supplier { get; set; }
        [ForeignKey(nameof(TransactionTypeId))]
        [InverseProperty("SupplierTransactions")]
        public virtual TransactionType TransactionType { get; set; }
    }
}
