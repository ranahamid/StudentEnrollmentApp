using StudentEnrollment.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentEnrollment.Data.Repositories
{
    public class StudentRepository: GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentEnrollmentDbContext context) : base(context)
        {
        }
        public async Task<Student> GetStudentDetails(int studentId)
        {
           var student =await _context.Students
               .Include(x=>x.Enrollments)
               .ThenInclude(x => x.Course)
               .Where(x => x.Id == studentId).FirstOrDefaultAsync();

            return student;
        } 
    }
}
