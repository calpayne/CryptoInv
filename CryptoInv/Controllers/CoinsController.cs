using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CryptoInv.Data;
using CryptoInv.Models.Coins;
using CryptoInv.Data.Crypto;

namespace CryptoInv.Controllers
{
    public class CoinsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoinsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Coins
        public async Task<IActionResult> Index()
        {
            var data = await CryptoAPI.GetDataAsync();

            var viewModel = await _context.Coins
                                    .Select(c => new CoinViewModel()
                                    {
                                        Id = c.Id,
                                        Name = c.Name,
                                        PricePerCoinFormatted = data.DISPLAY[c.Id].GBP.PRICE,
                                        PriceChange24Hours = data.DISPLAY[c.Id].GBP.CHANGEPCT24HOUR,
                                        Volume24 = data.DISPLAY[c.Id].GBP.VOLUME24HOUR,
                                        Hour24High = data.DISPLAY[c.Id].GBP.HIGH24HOUR,
                                        Hour24Low = data.DISPLAY[c.Id].GBP.LOW24HOUR,
                                        MarketCap = data.DISPLAY[c.Id].GBP.MKTCAP,
                                    })
                                    .ToListAsync();
            return View(viewModel);
        }

    }
}
