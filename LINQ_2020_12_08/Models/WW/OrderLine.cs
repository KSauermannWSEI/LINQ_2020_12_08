using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("OrderLines", Schema = "Sales")]
    [Index(nameof(OrderId), Name = "FK_Sales_OrderLines_OrderID")]
    [Index(nameof(PackageTypeId), Name = "FK_Sales_OrderLines_PackageTypeID")]
    [Index(nameof(StockItemId), Name = "IX_Sales_OrderLines_AllocatedStockItems")]
    [Index(nameof(PickingCompletedWhen), nameof(OrderId), nameof(OrderLineId), Name = "IX_Sales_OrderLines_Perf_20160301_01")]
    [Index(nameof(StockItemId), nameof(PickingCompletedWhen), Name = "IX_Sales_OrderLines_Perf_20160301_02")]
    public partial class OrderLine
    {
        [Key]
        [Column("OrderLineID")]
        public int OrderLineId { get; set; }
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("StockItemID")]
        public int StockItemId { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [Column("PackageTypeID")]
        public int PackageTypeId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? UnitPrice { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal TaxRate { get; set; }
        public int PickedQuantity { get; set; }
        public DateTime? PickingCompletedWhen { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.OrderLines))]
        public virtual Person LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderLines")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(PackageTypeId))]
        [InverseProperty("OrderLines")]
        public virtual PackageType PackageType { get; set; }
        [ForeignKey(nameof(StockItemId))]
        [InverseProperty("OrderLines")]
        public virtual StockItem StockItem { get; set; }
    }
}
