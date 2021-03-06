using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cima.Model
{
    public enum movieGenre
    {
        Action,
        Horror,
        Drama,
        Romance,
        Science_fiction,
        Comedy,
        Thriller,
        Musical,
        Crime
    }
    public class Movie
    {
        [Display(Name = "Movie Genre")]
        public movieGenre MovieGenre { get; set; }

        [Required]
        [Key]
        [Display(Name = "Movie Name")]
        public int movieid { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime releaseDate { get; set; }

        

        [Display(Name = "Movie Name")]
        [Required]
        [StringLength(255)]
        public string movieName { get; set; }

        [Display(Name = "Movie Year")]
        [Required]
        public int movieYear { get; set; }


        
          [StringLength(255)]
          [Display(Name = "Added By")]
        public string userName{ get; set; }
         

        /*[ForeignKey("Movie")]
        [Display(Name = "Movie Name")]
        public int movieId { get; set; }*/

        

        [Display(Name = "Movie Season")]
        public int movieSeason { get; set; }

        [Display(Name = "Movie Starring")]
        [StringLength(255)]
        public string starring { get; set; }

        [Display(Name = "Movie Creator")]
        [StringLength(255)]
        [Required]
        public string creator { get; set; }

    }
}