using System.Collections.Generic;





namespace IC_Assignment.Models
{
    public class StudnetFormViewModel
    {
        public IList<Course> Courses { get; set; }
        public Student Student { get; set; }

        public string title
        {
            get { return Student.Id == 0 ? "Create Student" : "Edit Student"; }
        }

    }
}