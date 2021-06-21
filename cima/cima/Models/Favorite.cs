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



        [StringLength(256)]
        [Display(Name = "Added By")]
        [Required]
        [Key]
        [Column(Order = 0)]
        public string userName { get; set; }

        [ForeignKey("Movie")]
        [Display(Name = "Movie Name")]
        [Required]
        [Key]
        [Column(Order = 1)]
        public int movieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}