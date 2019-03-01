using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoInv.Models.Investments
{
    public class InvestmentIndexViewModel
    {
        [Display(Name = "Invested"), Required]
        public double TotalInvested { get; set; }

        [Display(Name = "Profit"), Required]
        public double TotalProfit { get; set; }

        [Display(Name = "Assets"), Required]
        public double TotalAssets { get; set; }

        [Display(Name = "Investments"), Required]
        public List<InvestmentViewModel> Investments { get; set; }
    }
}
