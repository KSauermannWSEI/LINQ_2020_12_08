using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("People", Schema = "Application")]
    [Index(nameof(FullName), Name = "IX_Application_People_FullName")]
    [Index(nameof(IsEmployee), Name = "IX_Application_People_IsEmployee")]
    [Index(nameof(IsSalesperson), Name = "IX_Application_People_IsSalesperson")]
    [Index(nameof(IsPermittedToLogon), nameof(PersonId), Name = "IX_Application_People_Perf_20160301_05")]
    public partial class Person
    {
        public Person()
        {
            BuyingGroups = new HashSet<BuyingGroup>();
            Cities = new HashSet<City>();
            Colors = new HashSet<Color>();
            Countries = new HashSet<Country>();
            CustomerAlternateContactPeople = new HashSet<Customer>();
            CustomerCategories = new HashSet<CustomerCategory>();
            CustomerLastEditedByNavigations = new HashSet<Customer>();
            CustomerPrimaryContactPeople = new HashSet<Customer>();
            CustomerTransactions = new HashSet<CustomerTransaction>();
            DeliveryMethods = new HashSet<DeliveryMethod>();
            InverseLastEditedByNavigation = new HashSet<Person>();
            InvoiceAccountsPeople = new HashSet<Invoice>();
            InvoiceContactPeople = new HashSet<Invoice>();
            InvoiceLastEditedByNavigations = new HashSet<Invoice>();
            InvoiceLines = new HashSet<InvoiceLine>();
            InvoicePackedByPeople = new HashSet<Invoice>();
            InvoiceSalespersonPeople = new HashSet<Invoice>();
            OrderContactPeople = new HashSet<Order>();
            OrderLastEditedByNavigations = new HashSet<Order>();
            OrderLines = new HashSet<OrderLine>();
            OrderPickedByPeople = new HashSet<Order>();
            OrderSalespersonPeople = new HashSet<Order>();
            PackageTypes = new HashSet<PackageType>();
            PaymentMethods = new HashSet<PaymentMethod>();
            PurchaseOrderContactPeople = new HashSet<PurchaseOrder>();
            PurchaseOrderLastEditedByNavigations = new HashSet<PurchaseOrder>();
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
            SpecialDeals = new HashSet<SpecialDeal>();
            StateProvinces = new HashSet<StateProvince>();
            StockGroups = new HashSet<StockGroup>();
            StockItemHoldings = new HashSet<StockItemHolding>();
            StockItemStockGroups = new HashSet<StockItemStockGroup>();
            StockItemTransactions = new HashSet<StockItemTransaction>();
            StockItems = new HashSet<StockItem>();
            SupplierAlternateContactPeople = new HashSet<Supplier>();
            SupplierCategories = new HashSet<SupplierCategory>();
            SupplierLastEditedByNavigations = new HashSet<Supplier>();
            SupplierPrimaryContactPeople = new HashSet<Supplier>();
            SupplierTransactions = new HashSet<SupplierTransaction>();
            SystemParameters = new HashSet<SystemParameter>();
            TransactionTypes = new HashSet<TransactionType>();
        }

        [Key]
        [Column("PersonID")]
        public int PersonId { get; set; }
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        [Required]
        [StringLength(50)]
        public string PreferredName { get; set; }
        [Required]
        [StringLength(101)]
        public string SearchName { get; set; }
        public bool IsPermittedToLogon { get; set; }
        [StringLength(50)]
        public string LogonName { get; set; }
        public bool IsExternalLogonProvider { get; set; }
        public byte[] HashedPassword { get; set; }
        public bool IsSystemUser { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsSalesperson { get; set; }
        public string UserPreferences { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [StringLength(20)]
        public string FaxNumber { get; set; }
        [StringLength(256)]
        public string EmailAddress { get; set; }
        public byte[] Photo { get; set; }
        public string CustomFields { get; set; }
        public string OtherLanguages { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.InverseLastEditedByNavigation))]
        public virtual Person LastEditedByNavigation { get; set; }
        [InverseProperty(nameof(BuyingGroup.LastEditedByNavigation))]
        public virtual ICollection<BuyingGroup> BuyingGroups { get; set; }
        [InverseProperty(nameof(City.LastEditedByNavigation))]
        public virtual ICollection<City> Cities { get; set; }
        [InverseProperty(nameof(Color.LastEditedByNavigation))]
        public virtual ICollection<Color> Colors { get; set; }
        [InverseProperty(nameof(Country.LastEditedByNavigation))]
        public virtual ICollection<Country> Countries { get; set; }
        [InverseProperty(nameof(Customer.AlternateContactPerson))]
        public virtual ICollection<Customer> CustomerAlternateContactPeople { get; set; }
        [InverseProperty(nameof(CustomerCategory.LastEditedByNavigation))]
        public virtual ICollection<CustomerCategory> CustomerCategories { get; set; }
        [InverseProperty(nameof(Customer.LastEditedByNavigation))]
        public virtual ICollection<Customer> CustomerLastEditedByNavigations { get; set; }
        [InverseProperty(nameof(Customer.PrimaryContactPerson))]
        public virtual ICollection<Customer> CustomerPrimaryContactPeople { get; set; }
        [InverseProperty(nameof(CustomerTransaction.LastEditedByNavigation))]
        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }
        [InverseProperty(nameof(DeliveryMethod.LastEditedByNavigation))]
        public virtual ICollection<DeliveryMethod> DeliveryMethods { get; set; }
        [InverseProperty(nameof(Person.LastEditedByNavigation))]
        public virtual ICollection<Person> InverseLastEditedByNavigation { get; set; }
        [InverseProperty(nameof(Invoice.AccountsPerson))]
        public virtual ICollection<Invoice> InvoiceAccountsPeople { get; set; }
        [InverseProperty(nameof(Invoice.ContactPerson))]
        public virtual ICollection<Invoice> InvoiceContactPeople { get; set; }
        [InverseProperty(nameof(Invoice.LastEditedByNavigation))]
        public virtual ICollection<Invoice> InvoiceLastEditedByNavigations { get; set; }
        [InverseProperty(nameof(InvoiceLine.LastEditedByNavigation))]
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
        [InverseProperty(nameof(Invoice.PackedByPerson))]
        public virtual ICollection<Invoice> InvoicePackedByPeople { get; set; }
        [InverseProperty(nameof(Invoice.SalespersonPerson))]
        public virtual ICollection<Invoice> InvoiceSalespersonPeople { get; set; }
        [InverseProperty(nameof(Order.ContactPerson))]
        public virtual ICollection<Order> OrderContactPeople { get; set; }
        [InverseProperty(nameof(Order.LastEditedByNavigation))]
        public virtual ICollection<Order> OrderLastEditedByNavigations { get; set; }
        [InverseProperty(nameof(OrderLine.LastEditedByNavigation))]
        public virtual ICollection<OrderLine> OrderLines { get; set; }
        [InverseProperty(nameof(Order.PickedByPerson))]
        public virtual ICollection<Order> OrderPickedByPeople { get; set; }
        [InverseProperty(nameof(Order.SalespersonPerson))]
        public virtual ICollection<Order> OrderSalespersonPeople { get; set; }
        [InverseProperty(nameof(PackageType.LastEditedByNavigation))]
        public virtual ICollection<PackageType> PackageTypes { get; set; }
        [InverseProperty(nameof(PaymentMethod.LastEditedByNavigation))]
        public virtual ICollection<PaymentMethod> PaymentMethods { get; set; }
        [InverseProperty(nameof(PurchaseOrder.ContactPerson))]
        public virtual ICollection<PurchaseOrder> PurchaseOrderContactPeople { get; set; }
        [InverseProperty(nameof(PurchaseOrder.LastEditedByNavigation))]
        public virtual ICollection<PurchaseOrder> PurchaseOrderLastEditedByNavigations { get; set; }
        [InverseProperty(nameof(PurchaseOrderLine.LastEditedByNavigation))]
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        [InverseProperty(nameof(SpecialDeal.LastEditedByNavigation))]
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }
        [InverseProperty(nameof(StateProvince.LastEditedByNavigation))]
        public virtual ICollection<StateProvince> StateProvinces { get; set; }
        [InverseProperty(nameof(StockGroup.LastEditedByNavigation))]
        public virtual ICollection<StockGroup> StockGroups { get; set; }
        [InverseProperty(nameof(StockItemHolding.LastEditedByNavigation))]
        public virtual ICollection<StockItemHolding> StockItemHoldings { get; set; }
        [InverseProperty(nameof(StockItemStockGroup.LastEditedByNavigation))]
        public virtual ICollection<StockItemStockGroup> StockItemStockGroups { get; set; }
        [InverseProperty(nameof(StockItemTransaction.LastEditedByNavigation))]
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
        [InverseProperty(nameof(StockItem.LastEditedByNavigation))]
        public virtual ICollection<StockItem> StockItems { get; set; }
        [InverseProperty(nameof(Supplier.AlternateContactPerson))]
        public virtual ICollection<Supplier> SupplierAlternateContactPeople { get; set; }
        [InverseProperty(nameof(SupplierCategory.LastEditedByNavigation))]
        public virtual ICollection<SupplierCategory> SupplierCategories { get; set; }
        [InverseProperty(nameof(Supplier.LastEditedByNavigation))]
        public virtual ICollection<Supplier> SupplierLastEditedByNavigations { get; set; }
        [InverseProperty(nameof(Supplier.PrimaryContactPerson))]
        public virtual ICollection<Supplier> SupplierPrimaryContactPeople { get; set; }
        [InverseProperty(nameof(SupplierTransaction.LastEditedByNavigation))]
        public virtual ICollection<SupplierTransaction> SupplierTransactions { get; set; }
        [InverseProperty(nameof(SystemParameter.LastEditedByNavigation))]
        public virtual ICollection<SystemParameter> SystemParameters { get; set; }
        [InverseProperty(nameof(TransactionType.LastEditedByNavigation))]
        public virtual ICollection<TransactionType> TransactionTypes { get; set; }
    }
}
