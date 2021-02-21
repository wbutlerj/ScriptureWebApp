using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScriptureWebApp.Data;
using ScriptureWebApp.Models;

namespace ScriptureWebApp.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly ScriptureWebApp.Data.ScriptureWebAppContext _context;

        public IndexModel(ScriptureWebApp.Data.ScriptureWebAppContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Book { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ScriptureBook { get; set; }
        public DateTime NoteDate { get; set; }
        public SelectList Dates { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> bookQuery = from m in _context.Scripture
                                            orderby m.Book
                                            select m.Book;

            IQueryable<DateTime> dateQuery = from m in _context.Scripture
                                            orderby m.CreatedDate
                                            select m.CreatedDate;

            var scriptures = from m in _context.Scripture
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Notes.Contains(SearchString) || s.Book.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ScriptureBook))
            {
                scriptures = scriptures.Where(x => x.Book == ScriptureBook);
            }

            Book = new SelectList(await bookQuery.Distinct().ToListAsync());

            Dates = new SelectList(await dateQuery.Distinct().ToListAsync());

            Scripture = await scriptures.ToListAsync();
        }
    }
}
