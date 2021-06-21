using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cima.Model
{
    public class Favorite
    {
        [Key]
        [Required]
        public int favoriteId { get; set; }


        [StringLength(256)]
        [Display(Name = "Added By")]
        [Required]
        public string userName { get; set; }

        [ForeignKey("Movie")]
        [Display(Name = "Movie Name")]
        [Required]
        public int movieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}