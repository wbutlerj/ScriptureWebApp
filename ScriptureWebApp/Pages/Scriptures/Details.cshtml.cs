using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScriptureWebApp.Data;
using ScriptureWebApp.Models;

namespace ScriptureWebApp.Pages.Scriptures
{
    public class DetailsModel : PageModel
    {
        private readonly ScriptureWebApp.Data.ScriptureWebAppContext _context;

        public DetailsModel(ScriptureWebApp.Data.ScriptureWebAppContext context)
        {
            _context = context;
        }

        public Scripture Scripture { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Scripture = await _context.Scripture.FirstOrDefaultAsync(m => m.ScriptureID == id);

            if (Scripture == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
