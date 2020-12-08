using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("ColdRoomTemperatures", Schema = "Warehouse")]
    [Index(nameof(ColdRoomSensorNumber), Name = "IX_Warehouse_ColdRoomTemperatures_ColdRoomSensorNumber")]
    public partial class ColdRoomTemperature
    {
        [Key]
        [Column("ColdRoomTemperatureID")]
        public long ColdRoomTemperatureId { get; set; }
        public int ColdRoomSensorNumber { get; set; }
        public DateTime RecordedWhen { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Temperature { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
