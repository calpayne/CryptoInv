using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoInv.Data;
using CryptoInv.Data.Crypto;
using CryptoInv.Models.Investments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CryptoInv.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("/Profile/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Select(u => new ProfileIndexViewModel()
                {
                    Id = u.Id,
                    Username = u.UserName
                })
                .FirstOrDefaultAsync(u => u.Username == id);

            if (user == null)
            {
                return NotFound();
            }

            var data = await CryptoAPI.GetDataAsync();

            var investments = await _context.Investments
                .Include(i => i.Coin)
                .Select(i => new InvestmentViewModel()
                {
                    Id = i.Id,
                    CoinId = i.CoinId,
                    Coin = i.Coin,
                    Amount = i.Amount,
                    PricePerCoin = i.PricePerCoin,
                    PricePerCoinFormatted = i.PricePerCoin.ToString("n2"),
                    Cost = i.Cost,
                    CostFormatted = i.Cost.ToString("n2"),
                    InvestmentDate = i.InvestmentDate,
                    UserId = i.UserId,
                    InvestmentDateEnd = i.InvestmentDateEnd,
                    PricePerCoinNow = data.DISPLAY[i.CoinId].GBP.PRICE,
                    CostNow = Math.Round(data.RAW[i.CoinId].GBP.PRICE * i.Amount, 2),
                    CostNowFormatted = (data.RAW[i.CoinId].GBP.PRICE * i.Amount).ToString("n2"),
                    Profit = Math.Round((data.RAW[i.CoinId].GBP.PRICE * i.Amount) - i.Cost, 2),
                    ProfitFormatted = ((data.RAW[i.CoinId].GBP.PRICE * i.Amount) - i.Cost).ToString("n2"),
                    PriceChange24Hours = data.DISPLAY[i.CoinId].GBP.CHANGEPCT24HOUR,
                })
                .Where(i => i.UserId == user.Id)
                .Where(i => i.InvestmentDateEnd == null)
                .ToListAsync();

            var endedInvestments = await _context.Investments
                .Include(i => i.Coin)
                .Select(i => new InvestmentViewModel()
                {
                    Id = i.Id,
                    CoinId = i.CoinId,
                    Coin = i.Coin,
                    Amount = i.Amount,
                    PricePerCoin = i.PricePerCoin,
                    PricePerCoinFormatted = i.PricePerCoin.ToString("n2"),
                    Cost = i.Cost,
                    CostFormatted = i.Cost.ToString("n2"),
                    InvestmentDate = i.InvestmentDate,
                    UserId = i.UserId,
                    InvestmentDateEnd = i.InvestmentDateEnd,
                    PricePerCoinEnd = i.PricePerCoinEnd,
                    CostEnd = i.CostEnd,
                    Profit = Math.Round(i.CostEnd.Value - i.Cost, 2)
                })
                .Where(i => i.UserId == user.Id)
                .Where(i => i.InvestmentDateEnd != null)
                .ToListAsync();

            ProfileIndexViewModel viewModel = new ProfileIndexViewModel()
            {
                Id = user.Id,
                Username = user.Username,
                TotalInvested = (investments.Sum(t => t.Cost) + endedInvestments.Sum(t => t.Cost)).ToString("n2"),
                TotalProfit = (investments.Sum(t => t.Profit) + endedInvestments.Sum(t => t.Profit)).ToString("n2"),
                TotalAssets = (investments.Sum(t => t.CostNow) + endedInvestments.Sum(t => t.CostEnd).Value).ToString("n2"),
                Investments = investments,
                EndedInvestments = endedInvestments,
                ChartDataLabel = await _context.Coins.Select(c => c.Id).ToArrayAsync(),
                ChartDataValue = new double[13]
            };

            int count = 0;
            foreach (string s in viewModel.ChartDataLabel)
            {
                viewModel.ChartDataValue[count] = _context.Investments.Where(i => i.CoinId == s).Count();
                count++;
            }

            return View(viewModel);
        }
    }
}