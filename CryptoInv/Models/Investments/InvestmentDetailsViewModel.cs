using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoInv.Models.Investments
{
    public class InvestmentDetailsViewModel : InvestmentViewModel
    {
        public double[] ChartDataValue { get; set; }

        public string[] ChartDataDate { get; set; }

        [Display(Name = "24 High")]
        public string Hour24High { get; set; }

        [Display(Name = "24 Low")]
        public string Hour24Low { get; set; }

        [Display(Name = "24 Volume")]
        public string Volume24 { get; set; }

        [Display(Name = "Market Cap")]
        public string MarketCap { get; set; }
    }
}
