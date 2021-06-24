using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cima.Model
{
    public class FeedBack
    {
        [Key]
        [Required]
        [Display(Name = "FeedBack Number")]
        public int feedBackId { get; set; }


        [ForeignKey("Movie")]
        [Display(Name = "Movie Name")]
        public int movieId { get; set; }
        public virtual Movie Movie { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Feedback Comment")]
        public string comment { get; set; }


        [Required]
        [Display(Name = "Added by")]
        [StringLength(256)]
        public string userName { get; set; }


    }
}