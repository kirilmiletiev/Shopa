using System;
using System.Collections.Generic;
using System.Text;

namespace Shopa.Data.Models.Enums
{
   public class Review : BaseModel<int>
    {
        public ShopaUser User { get; set; }

        public Product Product { get; set; }

        public string Text { get; set; }

        public Rating Rating { get; set; }
    }
}
