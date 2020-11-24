using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Scripture
    {
        public int ID { get; set; }
        public string Canon { get; set; }
        public string Book { get; set; }
        public string Chapter { get; set; }
        public string Verse { get; set; }
        public string Note { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

    }
}