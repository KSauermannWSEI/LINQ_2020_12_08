using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("PackageTypes", Schema = "Warehouse")]
    [Index(nameof(PackageTypeName), Name = "UQ_Warehouse_PackageTypes_PackageTypeName", IsUnique = true)]
    public partial class PackageType
    {
        public PackageType()
        {
            InvoiceLines = new HashSet<InvoiceLine>();
            OrderLines = new HashSet<OrderLine>();
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
            StockItemOuterPackages = new HashSet<StockItem>();
            StockItemUnitPackages = new HashSet<StockItem>();
        }

        [Key]
        [Column("PackageTypeID")]
        public int PackageTypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string PackageTypeName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.PackageTypes))]
        public virtual Person LastEditedByNavigation { get; set; }
        [InverseProperty(nameof(InvoiceLine.PackageType))]
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
        [InverseProperty(nameof(OrderLine.PackageType))]
        public virtual ICollection<OrderLine> OrderLines { get; set; }
        [InverseProperty(nameof(PurchaseOrderLine.PackageType))]
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        [InverseProperty(nameof(StockItem.OuterPackage))]
        public virtual ICollection<StockItem> StockItemOuterPackages { get; set; }
        [InverseProperty(nameof(StockItem.UnitPackage))]
        public virtual ICollection<StockItem> StockItemUnitPackages { get; set; }
    }
}
