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

        [Display(Name = "Profit 24h High")]
        public string Profit24High { get; set; }

        [Display(Name = "Profit 1h High")]
        public double Profit1High { get; set; }

        [Display(Name = "Profit 24h Low")]
        public string Profit24Low { get; set; }

        [Display(Name = "Profit 1h Low")]
        public double Profit1Low { get; set; }

        [Display(Name = "24h High")]
        public string Hour24High { get; set; }

        [Display(Name = "24h Low")]
        public string Hour24Low { get; set; }

        [Display(Name = "24h Volume")]
        public string Volume24 { get; set; }

        [Display(Name = "Supply")]
        public string Supply { get; set; }

        [Display(Name = "Market Cap")]
        public string MarketCap { get; set; }
    }
}
