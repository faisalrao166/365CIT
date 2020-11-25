using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyScriptureJournal.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Notes { get; set; }
        [BindProperty(SupportsGet = true)]
        public string NoteBook { get; set; }
        public string BookSort { get; set; }
        public string DateSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {

            // Use LINQ to get list of genres(list of books).
            IQueryable<string> genreQuery = from m in _context.Scripture
                                            orderby m.Book
                                            select m.Book;
            //Searchbar (notes)

            var searchbar = from m in _context.Scripture
                            select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                searchbar = searchbar.Where(s => s.Notes.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(NoteBook))
            {
                searchbar = searchbar.Where(x => x.Book == NoteBook);
            }
            //sorting, date and book

            BookSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<Scripture> columnSort = from s in _context.Scripture
                                               select s;
       

            switch (sortOrder)
            {
                case "name_desc":
                    columnSort = columnSort.OrderByDescending(s => s.Book);
                    break;
                case "Date":
                    columnSort = columnSort.OrderBy(s => s.CreatedDate);
                    break;
                case "date_desc":
                    columnSort = columnSort.OrderByDescending(s => s.CreatedDate);
                    break;
                default:
                    columnSort = columnSort.OrderBy(s => s.Book);
                    break;
            }
            Notes = new SelectList(await genreQuery.Distinct().ToListAsync());
            Scripture = await searchbar.ToListAsync();
      
            //Scripture = await columnSort.AsNoTracking().ToListAsync();
        }

    }
}
