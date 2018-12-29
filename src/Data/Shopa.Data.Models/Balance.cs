using System;
using System.Collections.Generic;
using System.Text;

namespace Shopa.Data.Models
{
    public class Balance : BaseModel<int>
    {
        public Balance()
        {
        }

        public decimal Outcome { get; set; }

        public decimal Revenue { get; set; }

        public decimal Rent { get; set; }

        public decimal Bills { get; set; }

        public decimal WorkerSalaries{ get; set; }

        public decimal Taxes { get; set; }

        public ICollection<Store> Stores { get; set; }
    }
}
