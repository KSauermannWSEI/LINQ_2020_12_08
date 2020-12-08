using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("SupplierCategories", Schema = "Purchasing")]
    [Index(nameof(SupplierCategoryName), Name = "UQ_Purchasing_SupplierCategories_SupplierCategoryName", IsUnique = true)]
    public partial class SupplierCategory
    {
        public SupplierCategory()
        {
            Suppliers = new HashSet<Supplier>();
        }

        [Key]
        [Column("SupplierCategoryID")]
        public int SupplierCategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string SupplierCategoryName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.SupplierCategories))]
        public virtual Person LastEditedByNavigation { get; set; }
        [InverseProperty(nameof(Supplier.SupplierCategory))]
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
