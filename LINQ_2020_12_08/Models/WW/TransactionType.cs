using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("TransactionTypes", Schema = "Application")]
    [Index(nameof(TransactionTypeName), Name = "UQ_Application_TransactionTypes_TransactionTypeName", IsUnique = true)]
    public partial class TransactionType
    {
        public TransactionType()
        {
            CustomerTransactions = new HashSet<CustomerTransaction>();
            StockItemTransactions = new HashSet<StockItemTransaction>();
            SupplierTransactions = new HashSet<SupplierTransaction>();
        }

        [Key]
        [Column("TransactionTypeID")]
        public int TransactionTypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string TransactionTypeName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.TransactionTypes))]
        public virtual Person LastEditedByNavigation { get; set; }
        [InverseProperty(nameof(CustomerTransaction.TransactionType))]
        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }
        [InverseProperty(nameof(StockItemTransaction.TransactionType))]
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
        [InverseProperty(nameof(SupplierTransaction.TransactionType))]
        public virtual ICollection<SupplierTransaction> SupplierTransactions { get; set; }
    }
}
