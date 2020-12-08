using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("SystemParameters", Schema = "Application")]
    [Index(nameof(DeliveryCityId), Name = "FK_Application_SystemParameters_DeliveryCityID")]
    [Index(nameof(PostalCityId), Name = "FK_Application_SystemParameters_PostalCityID")]
    public partial class SystemParameter
    {
        [Key]
        [Column("SystemParameterID")]
        public int SystemParameterId { get; set; }
        [Required]
        [StringLength(60)]
        public string DeliveryAddressLine1 { get; set; }
        [StringLength(60)]
        public string DeliveryAddressLine2 { get; set; }
        [Column("DeliveryCityID")]
        public int DeliveryCityId { get; set; }
        [Required]
        [StringLength(10)]
        public string DeliveryPostalCode { get; set; }
        [Required]
        [StringLength(60)]
        public string PostalAddressLine1 { get; set; }
        [StringLength(60)]
        public string PostalAddressLine2 { get; set; }
        [Column("PostalCityID")]
        public int PostalCityId { get; set; }
        [Required]
        [StringLength(10)]
        public string PostalPostalCode { get; set; }
        [Required]
        public string ApplicationSettings { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(DeliveryCityId))]
        [InverseProperty(nameof(City.SystemParameterDeliveryCities))]
        public virtual City DeliveryCity { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.SystemParameters))]
        public virtual Person LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(PostalCityId))]
        [InverseProperty(nameof(City.SystemParameterPostalCities))]
        public virtual City PostalCity { get; set; }
    }
}
