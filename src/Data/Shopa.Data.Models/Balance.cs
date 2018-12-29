using System;
using System.Collections.Generic;
using System.Text;

namespace Shopa.Data.Models
{
    public class Balance : BaseModel<int>
    {
        public Balance()
        {
            this.Stores = new List<Store>();
            //Outcome = new decimal(1.0);
            //Revenue = new decimal(1.0);
            //Rent = new decimal(1.0);
            //Bills = new decimal(1.0);
            //WorkerSalaries = new decimal(1.0);
            //this.Taxes = new decimal(1.0);
        }

        public decimal Outcome { get; set; }

        public decimal Revenue { get; set; }

        public decimal Rent => 1500;

        public decimal Bills { get; set; }

        public decimal WorkerSalaries { get; set; }

        public decimal Taxes { get; set; }

        public ICollection<Store> Stores { get; set; }
    }
}
