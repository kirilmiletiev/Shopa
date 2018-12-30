using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shopa.Data.Models
{
    public class Balance : BaseModel<int>
    {
        public Balance()
        {
            Stores = new List<Store>();
        }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Outcome { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Revenue { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Rent { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Bills { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal WorkerSalaries { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Taxes { get; set; }

        public ICollection<Store> Stores { get; set; }
    }
}
