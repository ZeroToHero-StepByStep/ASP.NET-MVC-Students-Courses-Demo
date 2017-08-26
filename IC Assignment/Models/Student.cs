using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IC_Assignment.Models
{
    public class Student
    {

        public int Id { get; set; }

        [MaxLength(20)]
        public string City { get; set; }
       
        [Range(16,58)]
        public int  Age { get; set; }
        public Gender Gender { get; set; }

        public IList<Course> CoursesEnrolled { get; set; }


        [MaxLength(20)]
        public string Name { get; set; }
      
    }

    public enum Gender
    {
        Male,
        Femal,
        Others
    }
}