using Shopa.Data.Models;
using Shopa.Data.Models.Enums;

namespace Shopa.Data.Models
{
    public class Review : BaseModel<int>
    {
        public ShopaUser User { get; set; }
        public int UserId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public string Text { get; set; }

        public Rating Rating { get; set; }
    }
}
