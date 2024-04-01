﻿using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns> list of courses associated with a specific program.</returns>
        public List<ProgramCourse> GetAllProgramCourses(int id)
        {
            return _context.ProgramCourses
                .Where(pc => pc.ProgramId == id)
                .Include(pc => pc.Course)              
               .OrderBy(c => c.Course.CourseName)
               .ToList();
        }

        /// <summary>
        /// Get all Courses by Course ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>all ProgramCourses associated with a specific CourseId</returns>
        public List<ProgramCourse> GetAllCourses(string id)
        {
            return _context.ProgramCourses
                .Where(c => c.CourseId == id)
                .Include(c => c.Course)
                .Include(p => p.Program)
               .OrderBy(c => c.Course.CourseName)
               .ToList();
        }

        /// <summary>
        /// Get a single ProgramCourse by course ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>a single program associated with a given Id</returns>

        public ProgramCourse? GetProgramCourseById(string id)
        {
            return _context.ProgramCourses
                .Where(c => c.CourseId == id)
                .Include(c => c.Course)
                .FirstOrDefault();
        }

    }
}
