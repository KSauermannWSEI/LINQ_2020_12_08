﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LINQ_2020_12_08.Models.WW
{
    [Table("InvoiceLines", Schema = "Sales")]
    [Index(nameof(InvoiceId), Name = "FK_Sales_InvoiceLines_InvoiceID")]
    [Index(nameof(PackageTypeId), Name = "FK_Sales_InvoiceLines_PackageTypeID")]
    [Index(nameof(StockItemId), Name = "FK_Sales_InvoiceLines_StockItemID")]
    public partial class InvoiceLine
    {
        [Key]
        [Column("InvoiceLineID")]
        public int InvoiceLineId { get; set; }
        [Column("InvoiceID")]
        public int InvoiceId { get; set; }
        [Column("StockItemID")]
        public int StockItemId { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [Column("PackageTypeID")]
        public int PackageTypeId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? UnitPrice { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal TaxRate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TaxAmount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal LineProfit { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ExtendedPrice { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        [InverseProperty("InvoiceLines")]
        public virtual Invoice Invoice { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(Person.InvoiceLines))]
        public virtual Person LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(PackageTypeId))]
        [InverseProperty("InvoiceLines")]
        public virtual PackageType PackageType { get; set; }
        [ForeignKey(nameof(StockItemId))]
        [InverseProperty("InvoiceLines")]
        public virtual StockItem StockItem { get; set; }
    }
}
