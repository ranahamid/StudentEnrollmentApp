using StudentEnrollment.API.DTOs.Course;
using StudentEnrollment.API.DTOs.Student;

namespace StudentEnrollment.API.DTOs.Enrollment
{
    public class EnrollmentDto: CreateEnrollmentDto
    {
        public int Id { get; set; }
        public virtual CourseDto Course { get; set; }
        public virtual StudentDto Student { get; set; }
    }
}
