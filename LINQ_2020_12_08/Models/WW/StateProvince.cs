using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("StateProvinces", Schema = "Application")]
    [Index(nameof(CountryId), Name = "FK_Application_StateProvinces_CountryID")]
    [Index(nameof(SalesTerritory), Name = "IX_Application_StateProvinces_SalesTerritory")]
    [Index(nameof(StateProvinceName), Name = "UQ_Application_StateProvinces_StateProvinceName", IsUnique = true)]
    public partial class StateProvince
    {
        public StateProvince()
        {
            Cities = new HashSet<City>();
        }

        [Key]
        [Column("StateProvinceID")]
        public int StateProvinceId { get; set; }
        [Required]
        [StringLength(5)]
        public string StateProvinceCode { get; set; }
        [Required]
        [StringLength(50)]
        public string StateProvinceName { get; set; }
        [Column("CountryID")]
        public int CountryId { get; set; }
        [Required]
        [StringLength(50)]
        public string SalesTerritory { get; set; }
        public long? LatestRecordedPopulation { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty("StateProvinces")]
        public virtual Country Country { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.StateProvinces))]
        public virtual Person LastEditedByNavigation { get; set; }
        [InverseProperty(nameof(City.StateProvince))]
        public virtual ICollection<City> Cities { get; set; }
    }
}
