using Microsoft.EntityFrameworkCore;
using StarTEDSystemDB.DAL;
using StarTEDSystemDB.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace StarTEDSystemDB.BLL
{
    public class ProgramCourseServices
    {
        private readonly StarTEDContext _context;

        internal ProgramCourseServices(StarTEDContext context)
        {
            _context = context;
        }

        public List<ProgramCourse> GetAllProgramCourses(int id)
        {
            return _context.ProgramCourses
                .Where(pc => pc.ProgramId == id)
                .Include(pc => pc.Course)              
               .OrderBy(c => c.Course.CourseName)
               .ToList();
        }
    }
}
