using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoInv.Models.Investments
{
    public class InvestmentEditViewModel : InvestmentCreateViewModel
    {
        [Display(Name = "Paid")]
        public double Cost { get; set; }

        [Display(Name = "User")]
        public string UserId { get; set; }

        [Display(Name = "Investment End Date"), DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InvestmentDateEnd { get; set; }
    }
}
