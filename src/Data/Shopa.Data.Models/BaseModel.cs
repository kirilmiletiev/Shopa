using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shopa.Data.Models
{
    public class BaseModel<TEntity>
    {
        [Required]
        public TEntity Id { get; set; } 
    }
}
