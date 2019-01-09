using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shopa.Data.Models;
using Shopa.Data.Models.Enums;

namespace Shopa.Data.ViewModels.Products
{
    public class CreateProductsViewModel
    {
        [Required]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string PictureLocalPath { get; set; }

        [Required]
        public ShopaUser User { get; set; } 
        

        [Required]
        public Category Category { get; set; }
        
    }
}
