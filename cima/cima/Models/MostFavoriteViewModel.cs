using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cima.Model
{
    public class MostFavoriteViewModel
    {
        [Display(Name = "Movie Name")]
        [Required]
        [StringLength(255)]
        public string MovieName { get; set; }


        [Required]
        public int MovieId { get; set; }


        [StringLength(255)]
        [Display(Name = "Added By")]
        public string userName { get; set; }

        [Display(Name = "Favorites")]   
        public int Count { get; set; }



    }
}