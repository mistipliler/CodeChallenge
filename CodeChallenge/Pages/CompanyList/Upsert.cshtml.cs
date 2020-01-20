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
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Company Company { get; set; }

        //Get Company
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Company = new Company();

            //Company Create Page
            if (id == null)
                return Page();

            //Company Update Page
            Company = await _db.Company.FirstOrDefaultAsync(q => q.Id == id);

            if (Company == null)
                return NotFound();

            return Page();
        }

        //Create - Update Company
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                //New record
                if (Company.Id == 0)
                {
                    //Control isin
                    var isIsinExist = await _db.Company.FirstOrDefaultAsync(q => q.Isin == Company.Isin) != null;

                    //Add company
                    if(!isIsinExist)
                        _db.Company.Add(Company);
                    else
                        return BadRequest("Isin is already exist"); //TODO Warning popup (Isin is already exist)
                }
                else
                {
                    //Control isin
                    var isIsinExist = await _db.Company.FirstOrDefaultAsync(q => q.Id != Company.Id && q.Isin == Company.Isin) != null;

                    //Update record
                    if (!isIsinExist)
                        _db.Company.Update(Company);
                    else
                        return BadRequest("Isin is already exist"); //TODO Warning popup (Isin is already exist)
                }
                     

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}
