using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("Invoices", Schema = "Sales")]
    [Index(nameof(AccountsPersonId), Name = "FK_Sales_Invoices_AccountsPersonID")]
    [Index(nameof(BillToCustomerId), Name = "FK_Sales_Invoices_BillToCustomerID")]
    [Index(nameof(ContactPersonId), Name = "FK_Sales_Invoices_ContactPersonID")]
    [Index(nameof(CustomerId), Name = "FK_Sales_Invoices_CustomerID")]
    [Index(nameof(DeliveryMethodId), Name = "FK_Sales_Invoices_DeliveryMethodID")]
    [Index(nameof(OrderId), Name = "FK_Sales_Invoices_OrderID")]
    [Index(nameof(PackedByPersonId), Name = "FK_Sales_Invoices_PackedByPersonID")]
    [Index(nameof(SalespersonPersonId), Name = "FK_Sales_Invoices_SalespersonPersonID")]
    [Index(nameof(ConfirmedDeliveryTime), Name = "IX_Sales_Invoices_ConfirmedDeliveryTime")]
    public partial class Invoice
    {
        public Invoice()
        {
            CustomerTransactions = new HashSet<CustomerTransaction>();
            InvoiceLines = new HashSet<InvoiceLine>();
            StockItemTransactions = new HashSet<StockItemTransaction>();
        }

        [Key]
        [Column("InvoiceID")]
        public int InvoiceId { get; set; }
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column("BillToCustomerID")]
        public int BillToCustomerId { get; set; }
        [Column("OrderID")]
        public int? OrderId { get; set; }
        [Column("DeliveryMethodID")]
        public int DeliveryMethodId { get; set; }
        [Column("ContactPersonID")]
        public int ContactPersonId { get; set; }
        [Column("AccountsPersonID")]
        public int AccountsPersonId { get; set; }
        [Column("SalespersonPersonID")]
        public int SalespersonPersonId { get; set; }
        [Column("PackedByPersonID")]
        public int PackedByPersonId { get; set; }
        [Column(TypeName = "date")]
        public DateTime InvoiceDate { get; set; }
        [StringLength(20)]
        public string CustomerPurchaseOrderNumber { get; set; }
        public bool IsCreditNote { get; set; }
        public string CreditNoteReason { get; set; }
        public string Comments { get; set; }
        public string DeliveryInstructions { get; set; }
        public string InternalComments { get; set; }
        public int TotalDryItems { get; set; }
        public int TotalChillerItems { get; set; }
        [StringLength(5)]
        public string DeliveryRun { get; set; }
        [StringLength(5)]
        public string RunPosition { get; set; }
        public string ReturnedDeliveryData { get; set; }
        public DateTime? ConfirmedDeliveryTime { get; set; }
        [StringLength(4000)]
        public string ConfirmedReceivedBy { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(AccountsPersonId))]
        [InverseProperty(nameof(Person.InvoiceAccountsPeople))]
        public virtual Person AccountsPerson { get; set; }
        [ForeignKey(nameof(BillToCustomerId))]
        [InverseProperty("InvoiceBillToCustomers")]
        public virtual Customer BillToCustomer { get; set; }
        [ForeignKey(nameof(ContactPersonId))]
        [InverseProperty(nameof(Person.InvoiceContactPeople))]
        public virtual Person ContactPerson { get; set; }
        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("InvoiceCustomers")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(DeliveryMethodId))]
        [InverseProperty("Invoices")]
        public virtual DeliveryMethod DeliveryMethod { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.InvoiceLastEditedByNavigations))]
        public virtual Person LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(OrderId))]
        [InverseProperty("Invoices")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(PackedByPersonId))]
        [InverseProperty(nameof(Person.InvoicePackedByPeople))]
        public virtual Person PackedByPerson { get; set; }
        [ForeignKey(nameof(SalespersonPersonId))]
        [InverseProperty(nameof(Person.InvoiceSalespersonPeople))]
        public virtual Person SalespersonPerson { get; set; }
        [InverseProperty(nameof(CustomerTransaction.Invoice))]
        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }
        [InverseProperty(nameof(InvoiceLine.Invoice))]
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
        [InverseProperty(nameof(StockItemTransaction.Invoice))]
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
    }
}
