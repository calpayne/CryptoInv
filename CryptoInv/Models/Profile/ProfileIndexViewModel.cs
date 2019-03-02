﻿using CryptoInv.Models.Investments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoInv.Models.Profile
{
    public class ProfileIndexViewModel
    {
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

        [Display(Name = "Investments"), Required]
        public List<InvestmentViewModel> Investments { get; set; }
    }
}
