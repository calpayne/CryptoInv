using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoInv.Models.Investments
{
    public class InvestmentDetailsViewModel : InvestmentViewModel
    {
        public double[] ChartDataValue { get; set; }

        public string[] ChartDataDate { get; set; }
    }
}
