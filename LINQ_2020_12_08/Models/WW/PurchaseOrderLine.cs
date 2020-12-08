using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("PurchaseOrderLines", Schema = "Purchasing")]
    [Index(nameof(PackageTypeId), Name = "FK_Purchasing_PurchaseOrderLines_PackageTypeID")]
    [Index(nameof(PurchaseOrderId), Name = "FK_Purchasing_PurchaseOrderLines_PurchaseOrderID")]
    [Index(nameof(StockItemId), Name = "FK_Purchasing_PurchaseOrderLines_StockItemID")]
    [Index(nameof(IsOrderLineFinalized), nameof(StockItemId), Name = "IX_Purchasing_PurchaseOrderLines_Perf_20160301_4")]
    public partial class PurchaseOrderLine
    {
        [Key]
        [Column("PurchaseOrderLineID")]
        public int PurchaseOrderLineId { get; set; }
        [Column("PurchaseOrderID")]
        public int PurchaseOrderId { get; set; }
        [Column("StockItemID")]
        public int StockItemId { get; set; }
        public int OrderedOuters { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        public int ReceivedOuters { get; set; }
        [Column("PackageTypeID")]
        public int PackageTypeId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ExpectedUnitPricePerOuter { get; set; }
        [Column(TypeName = "date")]
        public DateTime? LastReceiptDate { get; set; }
        public bool IsOrderLineFinalized { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.PurchaseOrderLines))]
        public virtual Person LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(PackageTypeId))]
        [InverseProperty("PurchaseOrderLines")]
        public virtual PackageType PackageType { get; set; }
        [ForeignKey(nameof(PurchaseOrderId))]
        [InverseProperty("PurchaseOrderLines")]
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        [ForeignKey(nameof(StockItemId))]
        [InverseProperty("PurchaseOrderLines")]
        public virtual StockItem StockItem { get; set; }
    }
}
