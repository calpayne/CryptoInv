using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoInv.Models.Investments
{
    public class ChartDataViewModel
    {
        public double[] TotalCostData { get; set; }

        public string[] Dates { get; set; }

        public ChartDataViewModel()
        {
            TotalCostData = new double[5];
            Dates = new string[5];
        }
    }
}
