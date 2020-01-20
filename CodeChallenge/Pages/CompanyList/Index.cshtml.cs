using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Pages.CompanyList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Company> Companies { get; set; }

        public async Task OnGetAsync()
        {
            //Add Sample Data to DB
            Companies = await _db.Company.ToListAsync();

            if (Companies.Count == 0)
            {
                var sampleData = new List<Company>();

                sampleData.Add(new Company() { Name = "Apple Inc.", Exchange = "NASDAQ", Ticker = "AAPL", Isin = "US0378331005", Website = "http://www.apple.com" });
                sampleData.Add(new Company() { Name = "British Airways Plc", Exchange = "Pink Sheets", Ticker = "BAIRY", Isin = "US1104193065" });
                sampleData.Add(new Company() { Name = "Heineken NV", Exchange = "Euronext Amsterdam", Ticker = "HEIA", Isin = "NL0000009165" });
                sampleData.Add(new Company() { Name = "Panasonic Corp", Exchange = "Tokyo Stock Exchange", Ticker = "6752", Isin = "JP3866800000", Website = "http://www.panasonic.co.jp" });
                sampleData.Add(new Company() { Name = "Porsche Automobil", Exchange = "Deutsche Börse", Ticker = "PAH3", Isin = "DE000PAH0038", Website = "https://www.porsche.com/" });


                await _db.Company.AddRangeAsync(sampleData);
                await _db.SaveChangesAsync();
            }
        }

    }
}
