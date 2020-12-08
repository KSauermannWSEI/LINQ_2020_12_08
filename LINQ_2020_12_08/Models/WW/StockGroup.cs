using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("StockGroups", Schema = "Warehouse")]
    [Index(nameof(StockGroupName), Name = "UQ_Warehouse_StockGroups_StockGroupName", IsUnique = true)]
    public partial class StockGroup
    {
        public StockGroup()
        {
            SpecialDeals = new HashSet<SpecialDeal>();
            StockItemStockGroups = new HashSet<StockItemStockGroup>();
        }

        [Key]
        [Column("StockGroupID")]
        public int StockGroupId { get; set; }
        [Required]
        [StringLength(50)]
        public string StockGroupName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.StockGroups))]
        public virtual Person LastEditedByNavigation { get; set; }
        [InverseProperty(nameof(SpecialDeal.StockGroup))]
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }
        [InverseProperty(nameof(StockItemStockGroup.StockGroup))]
        public virtual ICollection<StockItemStockGroup> StockItemStockGroups { get; set; }
    }
}
