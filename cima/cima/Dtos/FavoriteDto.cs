using cima.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cima.Dtos
{
    public class FavoriteDto
    {

        [StringLength(256)]
        [Required]
        [Key]
        [Column(Order = 0)]
        public string userName { get; set; }

        [ForeignKey("Movie")]
        [Required]
        [Key]
        [Column(Order = 1)]
        public int movieId { get; set; }

        //public virtual Movie Movie { get; set; }


    }
}