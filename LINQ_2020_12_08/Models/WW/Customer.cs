using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("Customers", Schema = "Sales")]
    [Index(nameof(AlternateContactPersonId), Name = "FK_Sales_Customers_AlternateContactPersonID")]
    [Index(nameof(BuyingGroupId), Name = "FK_Sales_Customers_BuyingGroupID")]
    [Index(nameof(CustomerCategoryId), Name = "FK_Sales_Customers_CustomerCategoryID")]
    [Index(nameof(DeliveryCityId), Name = "FK_Sales_Customers_DeliveryCityID")]
    [Index(nameof(DeliveryMethodId), Name = "FK_Sales_Customers_DeliveryMethodID")]
    [Index(nameof(PostalCityId), Name = "FK_Sales_Customers_PostalCityID")]
    [Index(nameof(PrimaryContactPersonId), Name = "FK_Sales_Customers_PrimaryContactPersonID")]
    [Index(nameof(IsOnCreditHold), nameof(CustomerId), nameof(BillToCustomerId), Name = "IX_Sales_Customers_Perf_20160301_06")]
    [Index(nameof(CustomerName), Name = "UQ_Sales_Customers_CustomerName", IsUnique = true)]
    public partial class Customer
    {
        public Customer()
        {
            CustomerTransactions = new HashSet<CustomerTransaction>();
            InverseBillToCustomer = new HashSet<Customer>();
            InvoiceBillToCustomers = new HashSet<Invoice>();
            InvoiceCustomers = new HashSet<Invoice>();
            Orders = new HashSet<Order>();
            SpecialDeals = new HashSet<SpecialDeal>();
            StockItemTransactions = new HashSet<StockItemTransaction>();
        }

        [Key]
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }
        [Column("BillToCustomerID")]
        public int BillToCustomerId { get; set; }
        [Column("CustomerCategoryID")]
        public int CustomerCategoryId { get; set; }
        [Column("BuyingGroupID")]
        public int? BuyingGroupId { get; set; }
        [Column("PrimaryContactPersonID")]
        public int PrimaryContactPersonId { get; set; }
        [Column("AlternateContactPersonID")]
        public int? AlternateContactPersonId { get; set; }
        [Column("DeliveryMethodID")]
        public int DeliveryMethodId { get; set; }
        [Column("DeliveryCityID")]
        public int DeliveryCityId { get; set; }
        [Column("PostalCityID")]
        public int PostalCityId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? CreditLimit { get; set; }
        [Column(TypeName = "date")]
        public DateTime AccountOpenedDate { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal StandardDiscountPercentage { get; set; }
        public bool IsStatementSent { get; set; }
        public bool IsOnCreditHold { get; set; }
        public int PaymentDays { get; set; }
        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(20)]
        public string FaxNumber { get; set; }
        [StringLength(5)]
        public string DeliveryRun { get; set; }
        [StringLength(5)]
        public string RunPosition { get; set; }
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
        [InverseProperty(nameof(Person.CustomerAlternateContactPeople))]
        public virtual Person AlternateContactPerson { get; set; }
        [ForeignKey(nameof(BillToCustomerId))]
        [InverseProperty(nameof(Customer.InverseBillToCustomer))]
        public virtual Customer BillToCustomer { get; set; }
        [ForeignKey(nameof(BuyingGroupId))]
        [InverseProperty("Customers")]
        public virtual BuyingGroup BuyingGroup { get; set; }
        [ForeignKey(nameof(CustomerCategoryId))]
        [InverseProperty("Customers")]
        public virtual CustomerCategory CustomerCategory { get; set; }
        [ForeignKey(nameof(DeliveryCityId))]
        [InverseProperty(nameof(City.CustomerDeliveryCities))]
        public virtual City DeliveryCity { get; set; }
        [ForeignKey(nameof(DeliveryMethodId))]
        [InverseProperty("Customers")]
        public virtual DeliveryMethod DeliveryMethod { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.CustomerLastEditedByNavigations))]
        public virtual Person LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(PostalCityId))]
        [InverseProperty(nameof(City.CustomerPostalCities))]
        public virtual City PostalCity { get; set; }
        [ForeignKey(nameof(PrimaryContactPersonId))]
        [InverseProperty(nameof(Person.CustomerPrimaryContactPeople))]
        public virtual Person PrimaryContactPerson { get; set; }
        [InverseProperty(nameof(CustomerTransaction.Customer))]
        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }
        [InverseProperty(nameof(Customer.BillToCustomer))]
        public virtual ICollection<Customer> InverseBillToCustomer { get; set; }
        [InverseProperty(nameof(Invoice.BillToCustomer))]
        public virtual ICollection<Invoice> InvoiceBillToCustomers { get; set; }
        [InverseProperty(nameof(Invoice.Customer))]
        public virtual ICollection<Invoice> InvoiceCustomers { get; set; }
        [InverseProperty(nameof(Order.Customer))]
        public virtual ICollection<Order> Orders { get; set; }
        [InverseProperty(nameof(SpecialDeal.Customer))]
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }
        [InverseProperty(nameof(StockItemTransaction.Customer))]
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
    }
}
