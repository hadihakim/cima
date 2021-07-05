using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cima.Dtos
{
    public class MovieDto
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
        
            public movieGenre MovieGenre { get; set; }

            [Required]
            [Key]
            public int movieid { get; set; }

            [Required]
            public DateTime releaseDate { get; set; }



            [Required]
            [StringLength(255)]
            public string movieName { get; set; }

            [Required]
            public int movieYear { get; set; }



            [StringLength(255)]
            public string userName { get; set; }


            /*[ForeignKey("Movie")]
            [Display(Name = "Movie Name")]
            public int movieId { get; set; }*/



            public int movieSeason { get; set; }

           
            [StringLength(255)]
            public string starring { get; set; }

           
            [StringLength(255)]
            [Required]
            public string creator { get; set; }
        }
    }
