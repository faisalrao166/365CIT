using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Scripture
    {
        public int ID { get; set; }
        public string Canon { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Book { get; set; }

        [Required]
        public int Chapter { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Verses { get; set; }

        [Required]
        public string Notes { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

    }
}