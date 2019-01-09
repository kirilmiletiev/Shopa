using System.ComponentModel.DataAnnotations;
using Shopa.Data.Models;
using Shopa.Data.Models.Enums;

namespace Shopa.Data.Models
{
    public class Review : BaseModel<int>
    {
        public Review()
        {
            this.Rating = Rating.Five;
        }

        [Required]
        public int UserId { get; set; }
        public ShopaUser User { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public string Text { get; set; }

        [Required]
        public Rating Rating { get; set; }
    }
}
