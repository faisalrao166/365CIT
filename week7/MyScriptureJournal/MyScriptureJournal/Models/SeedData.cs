using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyScriptureJournal.Data;
using RazorPagesMovie.Models;
using System;
using System.Linq;

namespace MyScriptureJournal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                // Look for any movies.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Canon = "New Testament",
                        Book = "Mathew",
                        Chapter = 4,
                        Verses = "17-25",
                        Notes = "Feeding the poor and clothing the naked",
                        CreatedDate = DateTime.Parse("2020-11-23"),
                       
                    },
                    new Scripture
                    {
                        Canon = "Old Testament",
                        Book = "Genesis",
                        Chapter = 40,
                        Verses = "1-30",
                        Notes = "In the beginning, when God created the universe",
                        CreatedDate = DateTime.Parse("2020-11-24"),

                    }
                );
                context.SaveChanges();
            }
        }
    }
}