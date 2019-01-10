using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shopa.Data.Models
{
    public class Favorite : BaseModel<int>
    {
        public Favorite()
        {
            IsActive = true;
        }
        [Required] public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required] public string ShopaUserId { get; set; }
        public ShopaUser ShopaUser { get; set; }

        public bool IsActive { get; set; }
    }
}
