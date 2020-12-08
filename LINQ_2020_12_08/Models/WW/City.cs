using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("Cities", Schema = "Application")]
    [Index(nameof(StateProvinceId), Name = "FK_Application_Cities_StateProvinceID")]
    public partial class City
    {
        public City()
        {
            CustomerDeliveryCities = new HashSet<Customer>();
            CustomerPostalCities = new HashSet<Customer>();
            SupplierDeliveryCities = new HashSet<Supplier>();
            SupplierPostalCities = new HashSet<Supplier>();
            SystemParameterDeliveryCities = new HashSet<SystemParameter>();
            SystemParameterPostalCities = new HashSet<SystemParameter>();
        }

        [Key]
        [Column("CityID")]
        public int CityId { get; set; }
        [Required]
        [StringLength(50)]
        public string CityName { get; set; }
        [Column("StateProvinceID")]
        public int StateProvinceId { get; set; }
        public long? LatestRecordedPopulation { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.Cities))]
        public virtual Person LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(StateProvinceId))]
        [InverseProperty("Cities")]
        public virtual StateProvince StateProvince { get; set; }
        [InverseProperty(nameof(Customer.DeliveryCity))]
        public virtual ICollection<Customer> CustomerDeliveryCities { get; set; }
        [InverseProperty(nameof(Customer.PostalCity))]
        public virtual ICollection<Customer> CustomerPostalCities { get; set; }
        [InverseProperty(nameof(Supplier.DeliveryCity))]
        public virtual ICollection<Supplier> SupplierDeliveryCities { get; set; }
        [InverseProperty(nameof(Supplier.PostalCity))]
        public virtual ICollection<Supplier> SupplierPostalCities { get; set; }
        [InverseProperty(nameof(SystemParameter.DeliveryCity))]
        public virtual ICollection<SystemParameter> SystemParameterDeliveryCities { get; set; }
        [InverseProperty(nameof(SystemParameter.PostalCity))]
        public virtual ICollection<SystemParameter> SystemParameterPostalCities { get; set; }
    }
}
