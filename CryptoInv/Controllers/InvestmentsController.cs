﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CryptoInv.Data;
using CryptoInv.Models.Investments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CryptoInv.Data.Crypto;

namespace CryptoInv.Controllers
{
    [Authorize]
    public class InvestmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public InvestmentsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        // GET: Investments
        public async Task<IActionResult> Index()
        {
            var data = await CryptoAPI.GetDataAsync();

            var applicationDbContext = await _context.Investments
                .Include(i => i.Coin)
                .Select(i => new InvestmentViewModel() {
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
                    PricePerCoinNow = data.DISPLAY[i.CoinId].GBP.PRICE,
                    CostNow = Math.Round(data.RAW[i.CoinId].GBP.PRICE * i.Amount, 2),
                    CostNowFormatted = (data.RAW[i.CoinId].GBP.PRICE * i.Amount).ToString("n2"),
                    Profit = Math.Round((data.RAW[i.CoinId].GBP.PRICE * i.Amount) - i.Cost, 2),
                    ProfitFormatted = ((data.RAW[i.CoinId].GBP.PRICE * i.Amount) - i.Cost).ToString("n2"),
                    PriceChange24Hours = data.DISPLAY[i.CoinId].GBP.CHANGEPCT24HOUR
                })
                .Where(i => i.UserId == _userManager.GetUserId(this.User))
                .ToListAsync();

            InvestmentIndexViewModel viewModel = new InvestmentIndexViewModel()
            {
                TotalInvested = applicationDbContext.Sum(t => t.Cost).ToString("n2"),
                TotalProfit = applicationDbContext.Sum(t => t.Profit).ToString("n2"),
                TotalAssets = applicationDbContext.Sum(t => t.CostNow).ToString("n2"),
                Investments = applicationDbContext
            };

            return View(viewModel);
        }

        // GET: Investments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await CryptoAPI.GetDataAsync();

            var investment = await _context.Investments
                .Include(i => i.Coin)
                .Select(i => new InvestmentDetailsViewModel()
                {
                    Id = i.Id,
                    CoinId = i.CoinId,
                    Coin = i.Coin,
                    Amount = i.Amount,
                    PricePerCoin = i.PricePerCoin,
                    PricePerCoinNow = data.DISPLAY[i.CoinId].GBP.PRICE,
                    Profit = Math.Round(data.RAW[i.CoinId].GBP.PRICE - i.Cost, 2),
                    Profit24High = ((data.RAW[i.CoinId].GBP.HIGH24HOUR * i.Amount) - i.Cost).ToString("n2"),
                    Profit24Low = ((data.RAW[i.CoinId].GBP.LOW24HOUR * i.Amount) - i.Cost).ToString("n2"),
                    Cost = i.Cost,
                    CostNow = Math.Round(data.RAW[i.CoinId].GBP.PRICE * i.Amount, 2),
                    CostNowFormatted = (data.RAW[i.CoinId].GBP.PRICE * i.Amount).ToString("n2"),
                    InvestmentDate = i.InvestmentDate,
                    UserId = i.UserId,
                    PriceChange24Hours = data.DISPLAY[i.CoinId].GBP.CHANGEPCT24HOUR,
                    Hour24High = data.DISPLAY[i.CoinId].GBP.HIGH24HOUR,
                    Hour24Low = data.DISPLAY[i.CoinId].GBP.LOW24HOUR,
                    Volume24 = data.DISPLAY[i.CoinId].GBP.VOLUME24HOUR,
                    Supply = data.DISPLAY[i.CoinId].GBP.SUPPLY,
                    MarketCap = data.DISPLAY[i.CoinId].GBP.MKTCAP,
                    ChartDataValue = new double[31],
                    ChartDataDate = new string[31]
                })
                .Where(i => i.UserId == _userManager.GetUserId(this.User))
                .FirstOrDefaultAsync(m => m.Id == id);

            if (investment == null)
            {
                return NotFound();
            }

            int count = 0;
            var profitHistory = await CryptoAPI.GetHistoryDataAsync(investment.CoinId);
            foreach (Datum item in profitHistory.Data)
            {
                investment.ChartDataDate[count] = item.TimeFormatted;
                investment.ChartDataValue[count] = Math.Round(investment.Amount * item.close, 2);
                count++;
            }

            return View(investment);
        }

        // GET: Investments/Create
        public IActionResult Create()
        {
            ViewData["CoinId"] = new SelectList(_context.Coins, "Id", "Name");
            var investment = new InvestmentCreateViewModel()
            {
                InvestmentDate = DateTime.Now
            };
            return View(investment);
        }

        // POST: Investments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CoinId,Amount,PricePerCoin,InvestmentDate")] InvestmentCreateViewModel investment)
        {
            if (ModelState.IsValid)
            {
                var newInvestment = new Investment()
                {
                    Id = investment.Id,
                    CoinId = investment.CoinId,
                    Amount = investment.Amount,
                    PricePerCoin = investment.PricePerCoin,
                    Cost = investment.Amount * investment.PricePerCoin,
                    InvestmentDate = investment.InvestmentDate,
                    UserId = _userManager.GetUserId(this.User)
                };
                _context.Add(newInvestment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CoinId"] = new SelectList(_context.Coins, "Id", "Name", investment.CoinId);
            return View(investment);
        }

        // GET: Investments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investment = await _context.Investments.FindAsync(id);
            if (investment == null || investment.UserId != _userManager.GetUserId(this.User))
            {
                return NotFound();
            }
            ViewData["CoinId"] = new SelectList(_context.Coins, "Id", "Id", investment.CoinId);
            return View(investment);
        }

        // POST: Investments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CoinId,Amount,PricePerCoin,PricePerCoinEnd,Cost,CostEnd,InvestmentDate,InvestmentDateEnd,UserId")] Investment investment)
        {
            if (id != investment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(investment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvestmentExists(investment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CoinId"] = new SelectList(_context.Coins, "Id", "Id", investment.CoinId);
            return View(investment);
        }

        // GET: Investments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investment = await _context.Investments
                .Include(i => i.Coin)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (investment == null || investment.UserId != _userManager.GetUserId(this.User))
            {
                return NotFound();
            }

            return View(investment);
        }

        // POST: Investments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var investment = await _context.Investments.FindAsync(id);
            _context.Investments.Remove(investment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvestmentExists(int id)
        {
            return _context.Investments.Any(e => e.Id == id);
        }
    }
}
