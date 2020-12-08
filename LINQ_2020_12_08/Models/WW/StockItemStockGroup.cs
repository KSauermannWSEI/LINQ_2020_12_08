using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("StockItemStockGroups", Schema = "Warehouse")]
    [Index(nameof(StockGroupId), nameof(StockItemId), Name = "UQ_StockItemStockGroups_StockGroupID_Lookup", IsUnique = true)]
    [Index(nameof(StockItemId), nameof(StockGroupId), Name = "UQ_StockItemStockGroups_StockItemID_Lookup", IsUnique = true)]
    public partial class StockItemStockGroup
    {
        [Key]
        [Column("StockItemStockGroupID")]
        public int StockItemStockGroupId { get; set; }
        [Column("StockItemID")]
        public int StockItemId { get; set; }
        [Column("StockGroupID")]
        public int StockGroupId { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.StockItemStockGroups))]
        public virtual Person LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(StockGroupId))]
        [InverseProperty("StockItemStockGroups")]
        public virtual StockGroup StockGroup { get; set; }
        [ForeignKey(nameof(StockItemId))]
        [InverseProperty("StockItemStockGroups")]
        public virtual StockItem StockItem { get; set; }
    }
}
