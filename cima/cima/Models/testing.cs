using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cima.Model
{
    public class testing
    {
        [Key]
        public int testId { get; set; }
        public string testname { get; set; }
    }
}