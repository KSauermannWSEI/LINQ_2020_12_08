using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("CustomerTransactions", Schema = "Sales")]
    [Index(nameof(TransactionDate), nameof(CustomerId), Name = "FK_Sales_CustomerTransactions_CustomerID")]
    [Index(nameof(TransactionDate), nameof(InvoiceId), Name = "FK_Sales_CustomerTransactions_InvoiceID")]
    [Index(nameof(TransactionDate), nameof(PaymentMethodId), Name = "FK_Sales_CustomerTransactions_PaymentMethodID")]
    [Index(nameof(TransactionDate), nameof(TransactionTypeId), Name = "FK_Sales_CustomerTransactions_TransactionTypeID")]
    [Index(nameof(TransactionDate), nameof(IsFinalized), Name = "IX_Sales_CustomerTransactions_IsFinalized")]
    public partial class CustomerTransaction
    {
        [Key]
        [Column("CustomerTransactionID")]
        public int CustomerTransactionId { get; set; }
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column("TransactionTypeID")]
        public int TransactionTypeId { get; set; }
        [Column("InvoiceID")]
        public int? InvoiceId { get; set; }
        [Column("PaymentMethodID")]
        public int? PaymentMethodId { get; set; }
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

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("CustomerTransactions")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(InvoiceId))]
        [InverseProperty("CustomerTransactions")]
        public virtual Invoice Invoice { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.CustomerTransactions))]
        public virtual Person LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(PaymentMethodId))]
        [InverseProperty("CustomerTransactions")]
        public virtual PaymentMethod PaymentMethod { get; set; }
        [ForeignKey(nameof(TransactionTypeId))]
        [InverseProperty("CustomerTransactions")]
        public virtual TransactionType TransactionType { get; set; }
    }
}
