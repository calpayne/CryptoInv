using CryptoInv.Models.Investments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoInv.Models.Investments
{
    public class ProfileIndexViewModel
    {
        public double[] ChartDataValue { get; set; }

        public string[] ChartDataLabel { get; set; }

        [Display(Name = "Id"), Required]
        public string Id { get; set; }

        [Display(Name = "Username"), Required]
        public string Username { get; set; }

        [Display(Name = "Invested"), Required]
        public string TotalInvested { get; set; }

        [Display(Name = "Profit"), Required]
        public string TotalProfit { get; set; }

        [Display(Name = "Assets"), Required]
        public string TotalAssets { get; set; }

        [Display(Name = "Current Investments"), Required]
        public List<InvestmentViewModel> Investments { get; set; }

        [Display(Name = "Ended Investments"), Required]
        public List<InvestmentViewModel> EndedInvestments { get; set; }
    }
}
