using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("Orders", Schema = "Sales")]
    [Index(nameof(ContactPersonId), Name = "FK_Sales_Orders_ContactPersonID")]
    [Index(nameof(CustomerId), Name = "FK_Sales_Orders_CustomerID")]
    [Index(nameof(PickedByPersonId), Name = "FK_Sales_Orders_PickedByPersonID")]
    [Index(nameof(SalespersonPersonId), Name = "FK_Sales_Orders_SalespersonPersonID")]
    public partial class Order
    {
        public Order()
        {
            InverseBackorderOrder = new HashSet<Order>();
            Invoices = new HashSet<Invoice>();
            OrderLines = new HashSet<OrderLine>();
        }

        [Key]
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column("SalespersonPersonID")]
        public int SalespersonPersonId { get; set; }
        [Column("PickedByPersonID")]
        public int? PickedByPersonId { get; set; }
        [Column("ContactPersonID")]
        public int ContactPersonId { get; set; }
        [Column("BackorderOrderID")]
        public int? BackorderOrderId { get; set; }
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime ExpectedDeliveryDate { get; set; }
        [StringLength(20)]
        public string CustomerPurchaseOrderNumber { get; set; }
        public bool IsUndersupplyBackordered { get; set; }
        public string Comments { get; set; }
        public string DeliveryInstructions { get; set; }
        public string InternalComments { get; set; }
        public DateTime? PickingCompletedWhen { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(BackorderOrderId))]
        [InverseProperty(nameof(Order.InverseBackorderOrder))]
        public virtual Order BackorderOrder { get; set; }
        [ForeignKey(nameof(ContactPersonId))]
        [InverseProperty(nameof(Person.OrderContactPeople))]
        public virtual Person ContactPerson { get; set; }
        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Orders")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.OrderLastEditedByNavigations))]
        public virtual Person LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(PickedByPersonId))]
        [InverseProperty(nameof(Person.OrderPickedByPeople))]
        public virtual Person PickedByPerson { get; set; }
        [ForeignKey(nameof(SalespersonPersonId))]
        [InverseProperty(nameof(Person.OrderSalespersonPeople))]
        public virtual Person SalespersonPerson { get; set; }
        [InverseProperty(nameof(Order.BackorderOrder))]
        public virtual ICollection<Order> InverseBackorderOrder { get; set; }
        [InverseProperty(nameof(Invoice.Order))]
        public virtual ICollection<Invoice> Invoices { get; set; }
        [InverseProperty(nameof(OrderLine.Order))]
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
