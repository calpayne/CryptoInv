﻿using CryptoInv.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoInv.Models.Investments
{
    public class InvestmentCreateViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Coin"), Required]
        public string CoinId { get; set; }

        [Display(Name = "Amount"), Range(0.00000001, Double.MaxValue), Required]
        public double Amount { get; set; }

        [Display(Name = "Coin Price"), Range(0.00001, Double.MaxValue), Required]
        public double PricePerCoin { get; set; }

        [Display(Name = "Investment Date"), Required]
        public DateTime InvestmentDate { get; set; }
    }
}
