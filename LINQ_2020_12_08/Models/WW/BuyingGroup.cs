using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("BuyingGroups", Schema = "Sales")]
    [Index(nameof(BuyingGroupName), Name = "UQ_Sales_BuyingGroups_BuyingGroupName", IsUnique = true)]
    public partial class BuyingGroup
    {
        public BuyingGroup()
        {
            Customers = new HashSet<Customer>();
            SpecialDeals = new HashSet<SpecialDeal>();
        }

        [Key]
        [Column("BuyingGroupID")]
        public int BuyingGroupId { get; set; }
        [Required]
        [StringLength(50)]
        public string BuyingGroupName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.BuyingGroups))]
        public virtual Person LastEditedByNavigation { get; set; }
        [InverseProperty(nameof(Customer.BuyingGroup))]
        public virtual ICollection<Customer> Customers { get; set; }
        [InverseProperty(nameof(SpecialDeal.BuyingGroup))]
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }
    }
}
