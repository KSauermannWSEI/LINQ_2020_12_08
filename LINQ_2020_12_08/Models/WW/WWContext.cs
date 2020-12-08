using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    public partial class WWContext : DbContext
    {
        public WWContext()
        {
        }

        public WWContext(DbContextOptions<WWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BuyingGroup> BuyingGroups { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<ColdRoomTemperature> ColdRoomTemperatures { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Customer1> Customers1 { get; set; }
        public virtual DbSet<CustomerCategory> CustomerCategories { get; set; }
        public virtual DbSet<CustomerTransaction> CustomerTransactions { get; set; }
        public virtual DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }
        public virtual DbSet<PackageType> PackageTypes { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public virtual DbSet<SpecialDeal> SpecialDeals { get; set; }
        public virtual DbSet<StateProvince> StateProvinces { get; set; }
        public virtual DbSet<StockGroup> StockGroups { get; set; }
        public virtual DbSet<StockItem> StockItems { get; set; }
        public virtual DbSet<StockItemHolding> StockItemHoldings { get; set; }
        public virtual DbSet<StockItemStockGroup> StockItemStockGroups { get; set; }
        public virtual DbSet<StockItemTransaction> StockItemTransactions { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Supplier1> Suppliers1 { get; set; }
        public virtual DbSet<SupplierCategory> SupplierCategories { get; set; }
        public virtual DbSet<SupplierTransaction> SupplierTransactions { get; set; }
        public virtual DbSet<SystemParameter> SystemParameters { get; set; }
        public virtual DbSet<TransactionType> TransactionTypes { get; set; }
        public virtual DbSet<VehicleTemperature> VehicleTemperatures { get; set; }
        public virtual DbSet<VehicleTemperature1> VehicleTemperatures1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\;Database=WideWorldImporters;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_100_CI_AS");

            modelBuilder.Entity<BuyingGroup>(entity =>
            {
                entity.Property(e => e.BuyingGroupId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[BuyingGroupID])");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.BuyingGroups)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_BuyingGroups_Application_People");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[CityID])");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_Cities_Application_People");

                entity.HasOne(d => d.StateProvince)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_Cities_StateProvinceID_Application_StateProvinces");
            });

            modelBuilder.Entity<ColdRoomTemperature>(entity =>
            {
                entity.HasKey(e => e.ColdRoomTemperatureId)
                    .HasName("PK_Warehouse_ColdRoomTemperatures")
                    .IsClustered(false);

                entity.HasAnnotation("SqlServer:MemoryOptimized", true);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.Property(e => e.ColorId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[ColorID])");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.Colors)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warehouse_Colors_Application_People");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[CountryID])");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_Countries_Application_People");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[CustomerID])");

                entity.HasOne(d => d.AlternateContactPerson)
                    .WithMany(p => p.CustomerAlternateContactPeople)
                    .HasForeignKey(d => d.AlternateContactPersonId)
                    .HasConstraintName("FK_Sales_Customers_AlternateContactPersonID_Application_People");

                entity.HasOne(d => d.BillToCustomer)
                    .WithMany(p => p.InverseBillToCustomer)
                    .HasForeignKey(d => d.BillToCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Customers_BillToCustomerID_Sales_Customers");

                entity.HasOne(d => d.BuyingGroup)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.BuyingGroupId)
                    .HasConstraintName("FK_Sales_Customers_BuyingGroupID_Sales_BuyingGroups");

                entity.HasOne(d => d.CustomerCategory)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CustomerCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Customers_CustomerCategoryID_Sales_CustomerCategories");

                entity.HasOne(d => d.DeliveryCity)
                    .WithMany(p => p.CustomerDeliveryCities)
                    .HasForeignKey(d => d.DeliveryCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Customers_DeliveryCityID_Application_Cities");

                entity.HasOne(d => d.DeliveryMethod)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.DeliveryMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Customers_DeliveryMethodID_Application_DeliveryMethods");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.CustomerLastEditedByNavigations)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Customers_Application_People");

                entity.HasOne(d => d.PostalCity)
                    .WithMany(p => p.CustomerPostalCities)
                    .HasForeignKey(d => d.PostalCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Customers_PostalCityID_Application_Cities");

                entity.HasOne(d => d.PrimaryContactPerson)
                    .WithMany(p => p.CustomerPrimaryContactPeople)
                    .HasForeignKey(d => d.PrimaryContactPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Customers_PrimaryContactPersonID_Application_People");
            });

            modelBuilder.Entity<Customer1>(entity =>
            {
                entity.ToView("Customers", "Website");
            });

            modelBuilder.Entity<CustomerCategory>(entity =>
            {
                entity.Property(e => e.CustomerCategoryId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[CustomerCategoryID])");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.CustomerCategories)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_CustomerCategories_Application_People");
            });

            modelBuilder.Entity<CustomerTransaction>(entity =>
            {
                entity.HasKey(e => e.CustomerTransactionId)
                    .HasName("PK_Sales_CustomerTransactions")
                    .IsClustered(false);

                entity.HasIndex(e => e.TransactionDate, "CX_Sales_CustomerTransactions")
                    .IsClustered();

                entity.Property(e => e.CustomerTransactionId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[TransactionID])");

                entity.Property(e => e.IsFinalized).HasComputedColumnSql("(case when [FinalizationDate] IS NULL then CONVERT([bit],(0)) else CONVERT([bit],(1)) end)", true);

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerTransactions)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_CustomerTransactions_CustomerID_Sales_Customers");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.CustomerTransactions)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("FK_Sales_CustomerTransactions_InvoiceID_Sales_Invoices");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.CustomerTransactions)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_CustomerTransactions_Application_People");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.CustomerTransactions)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .HasConstraintName("FK_Sales_CustomerTransactions_PaymentMethodID_Application_PaymentMethods");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.CustomerTransactions)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_CustomerTransactions_TransactionTypeID_Application_TransactionTypes");
            });

            modelBuilder.Entity<DeliveryMethod>(entity =>
            {
                entity.Property(e => e.DeliveryMethodId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[DeliveryMethodID])");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.DeliveryMethods)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_DeliveryMethods_Application_People");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.InvoiceId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[InvoiceID])");

                entity.Property(e => e.ConfirmedDeliveryTime).HasComputedColumnSql("(TRY_CONVERT([datetime2](7),json_value([ReturnedDeliveryData],N'$.DeliveredWhen'),(126)))", false);

                entity.Property(e => e.ConfirmedReceivedBy).HasComputedColumnSql("(json_value([ReturnedDeliveryData],N'$.ReceivedBy'))", false);

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.AccountsPerson)
                    .WithMany(p => p.InvoiceAccountsPeople)
                    .HasForeignKey(d => d.AccountsPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Invoices_AccountsPersonID_Application_People");

                entity.HasOne(d => d.BillToCustomer)
                    .WithMany(p => p.InvoiceBillToCustomers)
                    .HasForeignKey(d => d.BillToCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Invoices_BillToCustomerID_Sales_Customers");

                entity.HasOne(d => d.ContactPerson)
                    .WithMany(p => p.InvoiceContactPeople)
                    .HasForeignKey(d => d.ContactPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Invoices_ContactPersonID_Application_People");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.InvoiceCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Invoices_CustomerID_Sales_Customers");

                entity.HasOne(d => d.DeliveryMethod)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.DeliveryMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Invoices_DeliveryMethodID_Application_DeliveryMethods");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.InvoiceLastEditedByNavigations)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Invoices_Application_People");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Sales_Invoices_OrderID_Sales_Orders");

                entity.HasOne(d => d.PackedByPerson)
                    .WithMany(p => p.InvoicePackedByPeople)
                    .HasForeignKey(d => d.PackedByPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Invoices_PackedByPersonID_Application_People");

                entity.HasOne(d => d.SalespersonPerson)
                    .WithMany(p => p.InvoiceSalespersonPeople)
                    .HasForeignKey(d => d.SalespersonPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Invoices_SalespersonPersonID_Application_People");
            });

            modelBuilder.Entity<InvoiceLine>(entity =>
            {
                entity.Property(e => e.InvoiceLineId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[InvoiceLineID])");

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceLines)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_InvoiceLines_InvoiceID_Sales_Invoices");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.InvoiceLines)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_InvoiceLines_Application_People");

                entity.HasOne(d => d.PackageType)
                    .WithMany(p => p.InvoiceLines)
                    .HasForeignKey(d => d.PackageTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_InvoiceLines_PackageTypeID_Warehouse_PackageTypes");

                entity.HasOne(d => d.StockItem)
                    .WithMany(p => p.InvoiceLines)
                    .HasForeignKey(d => d.StockItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_InvoiceLines_StockItemID_Warehouse_StockItems");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[OrderID])");

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.BackorderOrder)
                    .WithMany(p => p.InverseBackorderOrder)
                    .HasForeignKey(d => d.BackorderOrderId)
                    .HasConstraintName("FK_Sales_Orders_BackorderOrderID_Sales_Orders");

                entity.HasOne(d => d.ContactPerson)
                    .WithMany(p => p.OrderContactPeople)
                    .HasForeignKey(d => d.ContactPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Orders_ContactPersonID_Application_People");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Orders_CustomerID_Sales_Customers");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.OrderLastEditedByNavigations)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Orders_Application_People");

                entity.HasOne(d => d.PickedByPerson)
                    .WithMany(p => p.OrderPickedByPeople)
                    .HasForeignKey(d => d.PickedByPersonId)
                    .HasConstraintName("FK_Sales_Orders_PickedByPersonID_Application_People");

                entity.HasOne(d => d.SalespersonPerson)
                    .WithMany(p => p.OrderSalespersonPeople)
                    .HasForeignKey(d => d.SalespersonPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Orders_SalespersonPersonID_Application_People");
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.Property(e => e.OrderLineId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[OrderLineID])");

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_OrderLines_Application_People");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_OrderLines_OrderID_Sales_Orders");

                entity.HasOne(d => d.PackageType)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.PackageTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_OrderLines_PackageTypeID_Warehouse_PackageTypes");

                entity.HasOne(d => d.StockItem)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.StockItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_OrderLines_StockItemID_Warehouse_StockItems");
            });

            modelBuilder.Entity<PackageType>(entity =>
            {
                entity.Property(e => e.PackageTypeId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[PackageTypeID])");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.PackageTypes)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warehouse_PackageTypes_Application_People");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.Property(e => e.PaymentMethodId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[PaymentMethodID])");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.PaymentMethods)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_PaymentMethods_Application_People");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.PersonId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[PersonID])");

                entity.Property(e => e.OtherLanguages).HasComputedColumnSql("(json_query([CustomFields],N'$.OtherLanguages'))", false);

                entity.Property(e => e.SearchName).HasComputedColumnSql("(concat([PreferredName],N' ',[FullName]))", true);

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.InverseLastEditedByNavigation)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_People_Application_People");
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.Property(e => e.PurchaseOrderId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[PurchaseOrderID])");

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.ContactPerson)
                    .WithMany(p => p.PurchaseOrderContactPeople)
                    .HasForeignKey(d => d.ContactPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchasing_PurchaseOrders_ContactPersonID_Application_People");

                entity.HasOne(d => d.DeliveryMethod)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.DeliveryMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchasing_PurchaseOrders_DeliveryMethodID_Application_DeliveryMethods");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.PurchaseOrderLastEditedByNavigations)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchasing_PurchaseOrders_Application_People");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchasing_PurchaseOrders_SupplierID_Purchasing_Suppliers");
            });

            modelBuilder.Entity<PurchaseOrderLine>(entity =>
            {
                entity.Property(e => e.PurchaseOrderLineId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[PurchaseOrderLineID])");

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.PurchaseOrderLines)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchasing_PurchaseOrderLines_Application_People");

                entity.HasOne(d => d.PackageType)
                    .WithMany(p => p.PurchaseOrderLines)
                    .HasForeignKey(d => d.PackageTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchasing_PurchaseOrderLines_PackageTypeID_Warehouse_PackageTypes");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.PurchaseOrderLines)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchasing_PurchaseOrderLines_PurchaseOrderID_Purchasing_PurchaseOrders");

                entity.HasOne(d => d.StockItem)
                    .WithMany(p => p.PurchaseOrderLines)
                    .HasForeignKey(d => d.StockItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchasing_PurchaseOrderLines_StockItemID_Warehouse_StockItems");
            });

            modelBuilder.Entity<SpecialDeal>(entity =>
            {
                entity.Property(e => e.SpecialDealId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[SpecialDealID])");

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.BuyingGroup)
                    .WithMany(p => p.SpecialDeals)
                    .HasForeignKey(d => d.BuyingGroupId)
                    .HasConstraintName("FK_Sales_SpecialDeals_BuyingGroupID_Sales_BuyingGroups");

                entity.HasOne(d => d.CustomerCategory)
                    .WithMany(p => p.SpecialDeals)
                    .HasForeignKey(d => d.CustomerCategoryId)
                    .HasConstraintName("FK_Sales_SpecialDeals_CustomerCategoryID_Sales_CustomerCategories");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SpecialDeals)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Sales_SpecialDeals_CustomerID_Sales_Customers");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.SpecialDeals)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_SpecialDeals_Application_People");

                entity.HasOne(d => d.StockGroup)
                    .WithMany(p => p.SpecialDeals)
                    .HasForeignKey(d => d.StockGroupId)
                    .HasConstraintName("FK_Sales_SpecialDeals_StockGroupID_Warehouse_StockGroups");

                entity.HasOne(d => d.StockItem)
                    .WithMany(p => p.SpecialDeals)
                    .HasForeignKey(d => d.StockItemId)
                    .HasConstraintName("FK_Sales_SpecialDeals_StockItemID_Warehouse_StockItems");
            });

            modelBuilder.Entity<StateProvince>(entity =>
            {
                entity.Property(e => e.StateProvinceId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[StateProvinceID])");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.StateProvinces)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_StateProvinces_CountryID_Application_Countries");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.StateProvinces)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_StateProvinces_Application_People");
            });

            modelBuilder.Entity<StockGroup>(entity =>
            {
                entity.Property(e => e.StockGroupId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[StockGroupID])");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.StockGroups)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warehouse_StockGroups_Application_People");
            });

            modelBuilder.Entity<StockItem>(entity =>
            {
                entity.Property(e => e.StockItemId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[StockItemID])");

                entity.Property(e => e.SearchDetails).HasComputedColumnSql("(concat([StockItemName],N' ',[MarketingComments]))", false);

                entity.Property(e => e.Tags).HasComputedColumnSql("(json_query([CustomFields],N'$.Tags'))", false);

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.StockItems)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK_Warehouse_StockItems_ColorID_Warehouse_Colors");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.StockItems)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warehouse_StockItems_Application_People");

                entity.HasOne(d => d.OuterPackage)
                    .WithMany(p => p.StockItemOuterPackages)
                    .HasForeignKey(d => d.OuterPackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warehouse_StockItems_OuterPackageID_Warehouse_PackageTypes");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.StockItems)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warehouse_StockItems_SupplierID_Purchasing_Suppliers");

                entity.HasOne(d => d.UnitPackage)
                    .WithMany(p => p.StockItemUnitPackages)
                    .HasForeignKey(d => d.UnitPackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warehouse_StockItems_UnitPackageID_Warehouse_PackageTypes");
            });

            modelBuilder.Entity<StockItemHolding>(entity =>
            {
                entity.HasKey(e => e.StockItemId)
                    .HasName("PK_Warehouse_StockItemHoldings");

                entity.Property(e => e.StockItemId).ValueGeneratedNever();

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.StockItemHoldings)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warehouse_StockItemHoldings_Application_People");

                entity.HasOne(d => d.StockItem)
                    .WithOne(p => p.StockItemHolding)
                    .HasForeignKey<StockItemHolding>(d => d.StockItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PKFK_Warehouse_StockItemHoldings_StockItemID_Warehouse_StockItems");
            });

            modelBuilder.Entity<StockItemStockGroup>(entity =>
            {
                entity.Property(e => e.StockItemStockGroupId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[StockItemStockGroupID])");

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.StockItemStockGroups)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warehouse_StockItemStockGroups_Application_People");

                entity.HasOne(d => d.StockGroup)
                    .WithMany(p => p.StockItemStockGroups)
                    .HasForeignKey(d => d.StockGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warehouse_StockItemStockGroups_StockGroupID_Warehouse_StockGroups");

                entity.HasOne(d => d.StockItem)
                    .WithMany(p => p.StockItemStockGroups)
                    .HasForeignKey(d => d.StockItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warehouse_StockItemStockGroups_StockItemID_Warehouse_StockItems");
            });

            modelBuilder.Entity<StockItemTransaction>(entity =>
            {
                entity.HasKey(e => e.StockItemTransactionId)
                    .HasName("PK_Warehouse_StockItemTransactions")
                    .IsClustered(false);

                entity.Property(e => e.StockItemTransactionId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[TransactionID])");

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.StockItemTransactions)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Warehouse_StockItemTransactions_CustomerID_Sales_Customers");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.StockItemTransactions)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("FK_Warehouse_StockItemTransactions_InvoiceID_Sales_Invoices");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.StockItemTransactions)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warehouse_StockItemTransactions_Application_People");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.StockItemTransactions)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .HasConstraintName("FK_Warehouse_StockItemTransactions_PurchaseOrderID_Purchasing_PurchaseOrders");

                entity.HasOne(d => d.StockItem)
                    .WithMany(p => p.StockItemTransactions)
                    .HasForeignKey(d => d.StockItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warehouse_StockItemTransactions_StockItemID_Warehouse_StockItems");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.StockItemTransactions)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Warehouse_StockItemTransactions_SupplierID_Purchasing_Suppliers");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.StockItemTransactions)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warehouse_StockItemTransactions_TransactionTypeID_Application_TransactionTypes");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.SupplierId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[SupplierID])");

                entity.HasOne(d => d.AlternateContactPerson)
                    .WithMany(p => p.SupplierAlternateContactPeople)
                    .HasForeignKey(d => d.AlternateContactPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchasing_Suppliers_AlternateContactPersonID_Application_People");

                entity.HasOne(d => d.DeliveryCity)
                    .WithMany(p => p.SupplierDeliveryCities)
                    .HasForeignKey(d => d.DeliveryCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchasing_Suppliers_DeliveryCityID_Application_Cities");

                entity.HasOne(d => d.DeliveryMethod)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.DeliveryMethodId)
                    .HasConstraintName("FK_Purchasing_Suppliers_DeliveryMethodID_Application_DeliveryMethods");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.SupplierLastEditedByNavigations)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchasing_Suppliers_Application_People");

                entity.HasOne(d => d.PostalCity)
                    .WithMany(p => p.SupplierPostalCities)
                    .HasForeignKey(d => d.PostalCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchasing_Suppliers_PostalCityID_Application_Cities");

                entity.HasOne(d => d.PrimaryContactPerson)
                    .WithMany(p => p.SupplierPrimaryContactPeople)
                    .HasForeignKey(d => d.PrimaryContactPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchasing_Suppliers_PrimaryContactPersonID_Application_People");

                entity.HasOne(d => d.SupplierCategory)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.SupplierCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchasing_Suppliers_SupplierCategoryID_Purchasing_SupplierCategories");
            });

            modelBuilder.Entity<Supplier1>(entity =>
            {
                entity.ToView("Suppliers", "Website");
            });

            modelBuilder.Entity<SupplierCategory>(entity =>
            {
                entity.Property(e => e.SupplierCategoryId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[SupplierCategoryID])");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.SupplierCategories)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchasing_SupplierCategories_Application_People");
            });

            modelBuilder.Entity<SupplierTransaction>(entity =>
            {
                entity.HasKey(e => e.SupplierTransactionId)
                    .HasName("PK_Purchasing_SupplierTransactions")
                    .IsClustered(false);

                entity.HasIndex(e => e.TransactionDate, "CX_Purchasing_SupplierTransactions")
                    .IsClustered();

                entity.Property(e => e.SupplierTransactionId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[TransactionID])");

                entity.Property(e => e.IsFinalized).HasComputedColumnSql("(case when [FinalizationDate] IS NULL then CONVERT([bit],(0)) else CONVERT([bit],(1)) end)", true);

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.SupplierTransactions)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchasing_SupplierTransactions_Application_People");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.SupplierTransactions)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .HasConstraintName("FK_Purchasing_SupplierTransactions_PaymentMethodID_Application_PaymentMethods");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.SupplierTransactions)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .HasConstraintName("FK_Purchasing_SupplierTransactions_PurchaseOrderID_Purchasing_PurchaseOrders");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierTransactions)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchasing_SupplierTransactions_SupplierID_Purchasing_Suppliers");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.SupplierTransactions)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchasing_SupplierTransactions_TransactionTypeID_Application_TransactionTypes");
            });

            modelBuilder.Entity<SystemParameter>(entity =>
            {
                entity.Property(e => e.SystemParameterId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[SystemParameterID])");

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.DeliveryCity)
                    .WithMany(p => p.SystemParameterDeliveryCities)
                    .HasForeignKey(d => d.DeliveryCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_SystemParameters_DeliveryCityID_Application_Cities");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.SystemParameters)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_SystemParameters_Application_People");

                entity.HasOne(d => d.PostalCity)
                    .WithMany(p => p.SystemParameterPostalCities)
                    .HasForeignKey(d => d.PostalCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_SystemParameters_PostalCityID_Application_Cities");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.Property(e => e.TransactionTypeId).HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[TransactionTypeID])");

                entity.HasOne(d => d.LastEditedByNavigation)
                    .WithMany(p => p.TransactionTypes)
                    .HasForeignKey(d => d.LastEditedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_TransactionTypes_Application_People");
            });

            modelBuilder.Entity<VehicleTemperature>(entity =>
            {
                entity.HasKey(e => e.VehicleTemperatureId)
                    .HasName("PK_Warehouse_VehicleTemperatures")
                    .IsClustered(false);

                entity.HasAnnotation("SqlServer:MemoryOptimized", true);

                entity.Property(e => e.FullSensorData).UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.VehicleRegistration).UseCollation("Latin1_General_CI_AS");
            });

            modelBuilder.Entity<VehicleTemperature1>(entity =>
            {
                entity.ToView("VehicleTemperatures", "Website");

                entity.Property(e => e.VehicleTemperatureId).ValueGeneratedOnAdd();
            });

            modelBuilder.HasSequence<int>("BuyingGroupID", "Sequences").StartsAt(3);

            modelBuilder.HasSequence<int>("CityID", "Sequences").StartsAt(38187);

            modelBuilder.HasSequence<int>("ColorID", "Sequences").StartsAt(37);

            modelBuilder.HasSequence<int>("CountryID", "Sequences").StartsAt(242);

            modelBuilder.HasSequence<int>("CustomerCategoryID", "Sequences").StartsAt(9);

            modelBuilder.HasSequence<int>("CustomerID", "Sequences").StartsAt(1062);

            modelBuilder.HasSequence<int>("DeliveryMethodID", "Sequences").StartsAt(11);

            modelBuilder.HasSequence<int>("InvoiceID", "Sequences").StartsAt(70511);

            modelBuilder.HasSequence<int>("InvoiceLineID", "Sequences").StartsAt(228266);

            modelBuilder.HasSequence<int>("OrderID", "Sequences").StartsAt(73596);

            modelBuilder.HasSequence<int>("OrderLineID", "Sequences").StartsAt(231413);

            modelBuilder.HasSequence<int>("PackageTypeID", "Sequences").StartsAt(15);

            modelBuilder.HasSequence<int>("PaymentMethodID", "Sequences").StartsAt(5);

            modelBuilder.HasSequence<int>("PersonID", "Sequences").StartsAt(3262);

            modelBuilder.HasSequence<int>("PurchaseOrderID", "Sequences").StartsAt(2075);

            modelBuilder.HasSequence<int>("PurchaseOrderLineID", "Sequences").StartsAt(8368);

            modelBuilder.HasSequence<int>("SpecialDealID", "Sequences").StartsAt(3);

            modelBuilder.HasSequence<int>("StateProvinceID", "Sequences").StartsAt(54);

            modelBuilder.HasSequence<int>("StockGroupID", "Sequences").StartsAt(11);

            modelBuilder.HasSequence<int>("StockItemID", "Sequences").StartsAt(228);

            modelBuilder.HasSequence<int>("StockItemStockGroupID", "Sequences").StartsAt(443);

            modelBuilder.HasSequence<int>("SupplierCategoryID", "Sequences").StartsAt(10);

            modelBuilder.HasSequence<int>("SupplierID", "Sequences").StartsAt(14);

            modelBuilder.HasSequence<int>("SystemParameterID", "Sequences").StartsAt(2);

            modelBuilder.HasSequence<int>("TransactionID", "Sequences").StartsAt(336253);

            modelBuilder.HasSequence<int>("TransactionTypeID", "Sequences").StartsAt(14);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
