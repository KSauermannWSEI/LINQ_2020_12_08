using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("SpecialDeals", Schema = "Sales")]
    [Index(nameof(BuyingGroupId), Name = "FK_Sales_SpecialDeals_BuyingGroupID")]
    [Index(nameof(CustomerCategoryId), Name = "FK_Sales_SpecialDeals_CustomerCategoryID")]
    [Index(nameof(CustomerId), Name = "FK_Sales_SpecialDeals_CustomerID")]
    [Index(nameof(StockGroupId), Name = "FK_Sales_SpecialDeals_StockGroupID")]
    [Index(nameof(StockItemId), Name = "FK_Sales_SpecialDeals_StockItemID")]
    public partial class SpecialDeal
    {
        [Key]
        [Column("SpecialDealID")]
        public int SpecialDealId { get; set; }
        [Column("StockItemID")]
        public int? StockItemId { get; set; }
        [Column("CustomerID")]
        public int? CustomerId { get; set; }
        [Column("BuyingGroupID")]
        public int? BuyingGroupId { get; set; }
        [Column("CustomerCategoryID")]
        public int? CustomerCategoryId { get; set; }
        [Column("StockGroupID")]
        public int? StockGroupId { get; set; }
        [Required]
        [StringLength(30)]
        public string DealDescription { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? DiscountAmount { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal? DiscountPercentage { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? UnitPrice { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(BuyingGroupId))]
        [InverseProperty("SpecialDeals")]
        public virtual BuyingGroup BuyingGroup { get; set; }
        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("SpecialDeals")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(CustomerCategoryId))]
        [InverseProperty("SpecialDeals")]
        public virtual CustomerCategory CustomerCategory { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.SpecialDeals))]
        public virtual Person LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(StockGroupId))]
        [InverseProperty("SpecialDeals")]
        public virtual StockGroup StockGroup { get; set; }
        [ForeignKey(nameof(StockItemId))]
        [InverseProperty("SpecialDeals")]
        public virtual StockItem StockItem { get; set; }
    }
}
