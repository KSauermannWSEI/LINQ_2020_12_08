using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("Countries", Schema = "Application")]
    [Index(nameof(CountryName), Name = "UQ_Application_Countries_CountryName", IsUnique = true)]
    [Index(nameof(FormalName), Name = "UQ_Application_Countries_FormalName", IsUnique = true)]
    public partial class Country
    {
        public Country()
        {
            StateProvinces = new HashSet<StateProvince>();
        }

        [Key]
        [Column("CountryID")]
        public int CountryId { get; set; }
        [Required]
        [StringLength(60)]
        public string CountryName { get; set; }
        [Required]
        [StringLength(60)]
        public string FormalName { get; set; }
        [StringLength(3)]
        public string IsoAlpha3Code { get; set; }
        public int? IsoNumericCode { get; set; }
        [StringLength(20)]
        public string CountryType { get; set; }
        public long? LatestRecordedPopulation { get; set; }
        [Required]
        [StringLength(30)]
        public string Continent { get; set; }
        [Required]
        [StringLength(30)]
        public string Region { get; set; }
        [Required]
        [StringLength(30)]
        public string Subregion { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.Countries))]
        public virtual Person LastEditedByNavigation { get; set; }
        [InverseProperty(nameof(StateProvince.Country))]
        public virtual ICollection<StateProvince> StateProvinces { get; set; }
    }
}
