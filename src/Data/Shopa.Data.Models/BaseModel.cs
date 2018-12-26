using System;
using System.Collections.Generic;
using System.Text;

namespace Shopa.Data.Models
{
    public class BaseModel<TEntity>
    {
        public TEntity Id { get; set; } 
    }
}
