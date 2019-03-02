using CryptoInv.Data.Crypto;
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
        public string TotalInvested { get; set; }

        [Display(Name = "Profit"), Required]
        public string TotalProfit { get; set; }

        [Display(Name = "Assets"), Required]
        public string TotalAssets { get; set; }

        [Display(Name = "Investments"), Required]
        public List<InvestmentViewModel> Investments { get; set; }
    }
}
