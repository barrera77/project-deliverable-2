using StarTEDSystemDB.DAL;
using StarTEDSystemDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarTEDSystemDB.BLL
{
    public class CourseServices
    {
        private readonly StarTEDContext _context;

        internal CourseServices( StarTEDContext context )
        {
            _context = context;
        }

        public List<Course>GetAllCourses()
        {
            return _context.Courses.ToList<Course>();
        }
    }
}
