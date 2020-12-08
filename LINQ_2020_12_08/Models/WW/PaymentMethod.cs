using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("PaymentMethods", Schema = "Application")]
    [Index(nameof(PaymentMethodName), Name = "UQ_Application_PaymentMethods_PaymentMethodName", IsUnique = true)]
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            CustomerTransactions = new HashSet<CustomerTransaction>();
            SupplierTransactions = new HashSet<SupplierTransaction>();
        }

        [Key]
        [Column("PaymentMethodID")]
        public int PaymentMethodId { get; set; }
        [Required]
        [StringLength(50)]
        public string PaymentMethodName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.PaymentMethods))]
        public virtual Person LastEditedByNavigation { get; set; }
        [InverseProperty(nameof(CustomerTransaction.PaymentMethod))]
        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }
        [InverseProperty(nameof(SupplierTransaction.PaymentMethod))]
        public virtual ICollection<SupplierTransaction> SupplierTransactions { get; set; }
    }
}
