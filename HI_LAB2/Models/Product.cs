using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace HI_LAB2
{
    public partial class Product
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }
        [Required]
        [Column(TypeName = "decimal (8,2)")]
        public decimal Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
