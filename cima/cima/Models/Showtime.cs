using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cima.Models
{
    public enum days
    { 
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public class Showtime
    {
        [Key]
        [Required]
        public int showtimeId { get; set; }

        [ForeignKey("Movie")]
        [Display(Name = "Movie Name")]
        public int movieId{ get; set; }

        public virtual Movie Movie { get; set; }

        [Required]
        public days day { get; set; }

        [Display(Name = "First Showtime")]
        public DateTime time1 { get; set; }
        [Display(Name = "Second Showtime")]
        public DateTime time2 { get; set; }
        [Display(Name = "Third Showtime")]
        public DateTime time3 { get; set; }
        [Display(Name = "Fourth Showtime")]
        public DateTime time4 { get; set; }
    }
}