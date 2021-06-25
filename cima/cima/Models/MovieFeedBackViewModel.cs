using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cima.Model
{
    public class MovieFeedBackViewModel
    {


        [StringLength(255)]
        [Display(Name = "Added By")]
        public string userName { get; set; }


        [Display(Name = "Movie Genre")]
        public movieGenre MovieGenre { get; set; }

        

        [Required]
        [Display(Name = "Release Date")]
        public DateTime releaseDate { get; set; }

        [Display(Name = "Movie Name")]
        public int movieId { get; set; }



        [Display(Name = "Movie Name")]
        [Required]
        [StringLength(255)]
        public string movieName { get; set; }

        [Display(Name = "Movie Year")]
        [Required]
        public int movieYear { get; set; }


        [Display(Name = "Movie Season")]
        public int movieSeason { get; set; }


        [Display(Name = "Movie Starring")]
        [StringLength(255)]
        public string starring { get; set; }

        [Display(Name = "Movie Creator")]
        [StringLength(255)]
        [Required]
        public string creator { get; set; }


        
        [StringLength(500)]
        [Display(Name = "Feedback Comment")]
        public string comment { get; set; }


        [Required]
        [Display(Name = "FeedBack Added By")]
        [StringLength(256)]
        public string feedbackcreator { get; set; }





    }
}