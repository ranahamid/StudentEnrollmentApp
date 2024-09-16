using StudentEnrollment.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentEnrollment.Data.Repositories
{
    public  class CourseRepository: GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(StudentEnrollmentDbContext context) : base(context)
        {
        }

        public async  Task<Course> GetStudentList(int courseId)
        {
            var course = await _context.Courses
                .Include(x => x.Enrollments)
                .ThenInclude(x => x.Student)
                .Where(x => x.Id == courseId).FirstOrDefaultAsync();

            return course;
        }
    }
}
