using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("DeliveryMethods", Schema = "Application")]
    [Index(nameof(DeliveryMethodName), Name = "UQ_Application_DeliveryMethods_DeliveryMethodName", IsUnique = true)]
    public partial class DeliveryMethod
    {
        public DeliveryMethod()
        {
            Customers = new HashSet<Customer>();
            Invoices = new HashSet<Invoice>();
            PurchaseOrders = new HashSet<PurchaseOrder>();
            Suppliers = new HashSet<Supplier>();
        }

        [Key]
        [Column("DeliveryMethodID")]
        public int DeliveryMethodId { get; set; }
        [Required]
        [StringLength(50)]
        public string DeliveryMethodName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.DeliveryMethods))]
        public virtual Person LastEditedByNavigation { get; set; }
        [InverseProperty(nameof(Customer.DeliveryMethod))]
        public virtual ICollection<Customer> Customers { get; set; }
        [InverseProperty(nameof(Invoice.DeliveryMethod))]
        public virtual ICollection<Invoice> Invoices { get; set; }
        [InverseProperty(nameof(PurchaseOrder.DeliveryMethod))]
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        [InverseProperty(nameof(Supplier.DeliveryMethod))]
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
