using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("Suppliers", Schema = "Purchasing")]
    [Index(nameof(AlternateContactPersonId), Name = "FK_Purchasing_Suppliers_AlternateContactPersonID")]
    [Index(nameof(DeliveryCityId), Name = "FK_Purchasing_Suppliers_DeliveryCityID")]
    [Index(nameof(DeliveryMethodId), Name = "FK_Purchasing_Suppliers_DeliveryMethodID")]
    [Index(nameof(PostalCityId), Name = "FK_Purchasing_Suppliers_PostalCityID")]
    [Index(nameof(PrimaryContactPersonId), Name = "FK_Purchasing_Suppliers_PrimaryContactPersonID")]
    [Index(nameof(SupplierCategoryId), Name = "FK_Purchasing_Suppliers_SupplierCategoryID")]
    [Index(nameof(SupplierName), Name = "UQ_Purchasing_Suppliers_SupplierName", IsUnique = true)]
    public partial class Supplier
    {
        public Supplier()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
            StockItemTransactions = new HashSet<StockItemTransaction>();
            StockItems = new HashSet<StockItem>();
            SupplierTransactions = new HashSet<SupplierTransaction>();
        }

        [Key]
        [Column("SupplierID")]
        public int SupplierId { get; set; }
        [Required]
        [StringLength(100)]
        public string SupplierName { get; set; }
        [Column("SupplierCategoryID")]
        public int SupplierCategoryId { get; set; }
        [Column("PrimaryContactPersonID")]
        public int PrimaryContactPersonId { get; set; }
        [Column("AlternateContactPersonID")]
        public int AlternateContactPersonId { get; set; }
        [Column("DeliveryMethodID")]
        public int? DeliveryMethodId { get; set; }
        [Column("DeliveryCityID")]
        public int DeliveryCityId { get; set; }
        [Column("PostalCityID")]
        public int PostalCityId { get; set; }
        [StringLength(20)]
        public string SupplierReference { get; set; }
        [StringLength(50)]
        public string BankAccountName { get; set; }
        [StringLength(50)]
        public string BankAccountBranch { get; set; }
        [StringLength(20)]
        public string BankAccountCode { get; set; }
        [StringLength(20)]
        public string BankAccountNumber { get; set; }
        [StringLength(20)]
        public string BankInternationalCode { get; set; }
        public int PaymentDays { get; set; }
        public string InternalComments { get; set; }
        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(20)]
        public string FaxNumber { get; set; }
        [Required]
        [Column("WebsiteURL")]
        [StringLength(256)]
        public string WebsiteUrl { get; set; }
        [Required]
        [StringLength(60)]
        public string DeliveryAddressLine1 { get; set; }
        [StringLength(60)]
        public string DeliveryAddressLine2 { get; set; }
        [Required]
        [StringLength(10)]
        public string DeliveryPostalCode { get; set; }
        [Required]
        [StringLength(60)]
        public string PostalAddressLine1 { get; set; }
        [StringLength(60)]
        public string PostalAddressLine2 { get; set; }
        [Required]
        [StringLength(10)]
        public string PostalPostalCode { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(AlternateContactPersonId))]
        [InverseProperty(nameof(Person.SupplierAlternateContactPeople))]
        public virtual Person AlternateContactPerson { get; set; }
        [ForeignKey(nameof(DeliveryCityId))]
        [InverseProperty(nameof(City.SupplierDeliveryCities))]
        public virtual City DeliveryCity { get; set; }
        [ForeignKey(nameof(DeliveryMethodId))]
        [InverseProperty("Suppliers")]
        public virtual DeliveryMethod DeliveryMethod { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.SupplierLastEditedByNavigations))]
        public virtual Person LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(PostalCityId))]
        [InverseProperty(nameof(City.SupplierPostalCities))]
        public virtual City PostalCity { get; set; }
        [ForeignKey(nameof(PrimaryContactPersonId))]
        [InverseProperty(nameof(Person.SupplierPrimaryContactPeople))]
        public virtual Person PrimaryContactPerson { get; set; }
        [ForeignKey(nameof(SupplierCategoryId))]
        [InverseProperty("Suppliers")]
        public virtual SupplierCategory SupplierCategory { get; set; }
        [InverseProperty(nameof(PurchaseOrder.Supplier))]
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        [InverseProperty(nameof(StockItemTransaction.Supplier))]
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
        [InverseProperty(nameof(StockItem.Supplier))]
        public virtual ICollection<StockItem> StockItems { get; set; }
        [InverseProperty(nameof(SupplierTransaction.Supplier))]
        public virtual ICollection<SupplierTransaction> SupplierTransactions { get; set; }
    }
}
