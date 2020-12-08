using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("CustomerCategories", Schema = "Sales")]
    [Index(nameof(CustomerCategoryName), Name = "UQ_Sales_CustomerCategories_CustomerCategoryName", IsUnique = true)]
    public partial class CustomerCategory
    {
        public CustomerCategory()
        {
            Customers = new HashSet<Customer>();
            SpecialDeals = new HashSet<SpecialDeal>();
        }

        [Key]
        [Column("CustomerCategoryID")]
        public int CustomerCategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerCategoryName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.CustomerCategories))]
        public virtual Person LastEditedByNavigation { get; set; }
        [InverseProperty(nameof(Customer.CustomerCategory))]
        public virtual ICollection<Customer> Customers { get; set; }
        [InverseProperty(nameof(SpecialDeal.CustomerCategory))]
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }
    }
}
