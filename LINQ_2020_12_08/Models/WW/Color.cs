using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("Colors", Schema = "Warehouse")]
    [Index(nameof(ColorName), Name = "UQ_Warehouse_Colors_ColorName", IsUnique = true)]
    public partial class Color
    {
        public Color()
        {
            StockItems = new HashSet<StockItem>();
        }

        [Key]
        [Column("ColorID")]
        public int ColorId { get; set; }
        [Required]
        [StringLength(20)]
        public string ColorName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.Colors))]
        public virtual Person LastEditedByNavigation { get; set; }
        [InverseProperty(nameof(StockItem.Color))]
        public virtual ICollection<StockItem> StockItems { get; set; }
    }
}
