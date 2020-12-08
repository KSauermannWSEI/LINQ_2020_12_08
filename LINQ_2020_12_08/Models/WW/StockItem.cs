using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("StockItems", Schema = "Warehouse")]
    [Index(nameof(ColorId), Name = "FK_Warehouse_StockItems_ColorID")]
    [Index(nameof(OuterPackageId), Name = "FK_Warehouse_StockItems_OuterPackageID")]
    [Index(nameof(SupplierId), Name = "FK_Warehouse_StockItems_SupplierID")]
    [Index(nameof(UnitPackageId), Name = "FK_Warehouse_StockItems_UnitPackageID")]
    [Index(nameof(StockItemName), Name = "UQ_Warehouse_StockItems_StockItemName", IsUnique = true)]
    public partial class StockItem
    {
        public StockItem()
        {
            InvoiceLines = new HashSet<InvoiceLine>();
            OrderLines = new HashSet<OrderLine>();
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
            SpecialDeals = new HashSet<SpecialDeal>();
            StockItemStockGroups = new HashSet<StockItemStockGroup>();
            StockItemTransactions = new HashSet<StockItemTransaction>();
        }

        [Key]
        [Column("StockItemID")]
        public int StockItemId { get; set; }
        [Required]
        [StringLength(100)]
        public string StockItemName { get; set; }
        [Column("SupplierID")]
        public int SupplierId { get; set; }
        [Column("ColorID")]
        public int? ColorId { get; set; }
        [Column("UnitPackageID")]
        public int UnitPackageId { get; set; }
        [Column("OuterPackageID")]
        public int OuterPackageId { get; set; }
        [StringLength(50)]
        public string Brand { get; set; }
        [StringLength(20)]
        public string Size { get; set; }
        public int LeadTimeDays { get; set; }
        public int QuantityPerOuter { get; set; }
        public bool IsChillerStock { get; set; }
        [StringLength(50)]
        public string Barcode { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal TaxRate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? RecommendedRetailPrice { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal TypicalWeightPerUnit { get; set; }
        public string MarketingComments { get; set; }
        public string InternalComments { get; set; }
        public byte[] Photo { get; set; }
        public string CustomFields { get; set; }
        public string Tags { get; set; }
        [Required]
        public string SearchDetails { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(ColorId))]
        [InverseProperty("StockItems")]
        public virtual Color Color { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.StockItems))]
        public virtual Person LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(OuterPackageId))]
        [InverseProperty(nameof(PackageType.StockItemOuterPackages))]
        public virtual PackageType OuterPackage { get; set; }
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty("StockItems")]
        public virtual Supplier Supplier { get; set; }
        [ForeignKey(nameof(UnitPackageId))]
        [InverseProperty(nameof(PackageType.StockItemUnitPackages))]
        public virtual PackageType UnitPackage { get; set; }
        [InverseProperty("StockItem")]
        public virtual StockItemHolding StockItemHolding { get; set; }
        [InverseProperty(nameof(InvoiceLine.StockItem))]
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
        [InverseProperty(nameof(OrderLine.StockItem))]
        public virtual ICollection<OrderLine> OrderLines { get; set; }
        [InverseProperty(nameof(PurchaseOrderLine.StockItem))]
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        [InverseProperty(nameof(SpecialDeal.StockItem))]
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }
        [InverseProperty(nameof(StockItemStockGroup.StockItem))]
        public virtual ICollection<StockItemStockGroup> StockItemStockGroups { get; set; }
        [InverseProperty(nameof(StockItemTransaction.StockItem))]
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
    }
}
