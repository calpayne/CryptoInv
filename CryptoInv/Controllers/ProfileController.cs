using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoInv.Data;
using CryptoInv.Models.Profile;
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
                .FirstOrDefaultAsync(u => u.Id == id);

            return View(user);
        }
    }
}