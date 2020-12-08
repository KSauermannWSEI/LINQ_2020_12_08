using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("PurchaseOrders", Schema = "Purchasing")]
    [Index(nameof(ContactPersonId), Name = "FK_Purchasing_PurchaseOrders_ContactPersonID")]
    [Index(nameof(DeliveryMethodId), Name = "FK_Purchasing_PurchaseOrders_DeliveryMethodID")]
    [Index(nameof(SupplierId), Name = "FK_Purchasing_PurchaseOrders_SupplierID")]
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
            StockItemTransactions = new HashSet<StockItemTransaction>();
            SupplierTransactions = new HashSet<SupplierTransaction>();
        }

        [Key]
        [Column("PurchaseOrderID")]
        public int PurchaseOrderId { get; set; }
        [Column("SupplierID")]
        public int SupplierId { get; set; }
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }
        [Column("DeliveryMethodID")]
        public int DeliveryMethodId { get; set; }
        [Column("ContactPersonID")]
        public int ContactPersonId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ExpectedDeliveryDate { get; set; }
        [StringLength(20)]
        public string SupplierReference { get; set; }
        public bool IsOrderFinalized { get; set; }
        public string Comments { get; set; }
        public string InternalComments { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(ContactPersonId))]
        [InverseProperty(nameof(Person.PurchaseOrderContactPeople))]
        public virtual Person ContactPerson { get; set; }
        [ForeignKey(nameof(DeliveryMethodId))]
        [InverseProperty("PurchaseOrders")]
        public virtual DeliveryMethod DeliveryMethod { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.PurchaseOrderLastEditedByNavigations))]
        public virtual Person LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty("PurchaseOrders")]
        public virtual Supplier Supplier { get; set; }
        [InverseProperty(nameof(PurchaseOrderLine.PurchaseOrder))]
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        [InverseProperty(nameof(StockItemTransaction.PurchaseOrder))]
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
        [InverseProperty(nameof(SupplierTransaction.PurchaseOrder))]
        public virtual ICollection<SupplierTransaction> SupplierTransactions { get; set; }
    }
}
