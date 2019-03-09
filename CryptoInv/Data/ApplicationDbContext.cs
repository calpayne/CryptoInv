using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CryptoInv.Models.Investments;

namespace CryptoInv.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Coin> Coins { get; set; }
        public DbSet<Investment> Investments { get; set; }
        private IHostingEnvironment HostEnv { get; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHostingEnvironment env)
            : base(options)
        {
            HostEnv = env;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            if (HostEnv != null && HostEnv.IsDevelopment())
            {
                builder.Entity<Coin>().HasData(
                    new Coin() { Id = "BTC", Name = "Bitcoin" },
                    new Coin() { Id = "ETH", Name = "Ethereum" },
                    new Coin() { Id = "BCH", Name = "Bitcoin Cash" },
                    new Coin() { Id = "LTC", Name = "Litecoin" },
                    new Coin() { Id = "XMR", Name = "Monero" },
                    new Coin() { Id = "XLM", Name = "Stellar" },
                    new Coin() { Id = "XRP", Name = "XRP" },
                    new Coin() { Id = "ZEC", Name = "Zcash" },
                    new Coin() { Id = "WAVES", Name = "Waves" },
                    new Coin() { Id = "DOGE", Name = "Dogecoin" },
                    new Coin() { Id = "DASH", Name = "Dash" },
                    new Coin() { Id = "TRX", Name = "TRON" }
                );
            }
        }
    }
}
