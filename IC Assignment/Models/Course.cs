using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IC_Assignment.Models
{
    public class Course
    {
        public int  Id { get; set; }

        [MaxLength(50)] 
        [Required]
        public string Name { get; set; }

    }
}